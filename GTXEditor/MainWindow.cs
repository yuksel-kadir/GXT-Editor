using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GTXEditor
{
    public partial class MainWindow : Form
    {
        private const string EXE_PATH = @"\Compiler\gxt.exe";
        private const string CURRENT_FILE_LABEL = "Current File Path: ";
        private string lastSearchKeyword = "";
        private string currentFilePath = "";
        private readonly string[] fontNames = { "Bank Gothic", "Beckett", "GTA VC Regular", "Old English", "Rage Italic" };
        private StringBuilder logBuilder = new StringBuilder();
        private static PrivateFontCollection privateFonts = new PrivateFontCollection();
        private int lastFoundRowIndex = -1;
        
        public enum CustomFonts
        {
            BankGothic = 0,
            Beckett = 1,
            GTAVCRegular = 2,
            OldEnglish = 3,
            RageItalic = 4
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadCustomFont();
            InitializePreviewText();
            DisableComponentsBeforeTableLoaded();
        }

        private void InitializePreviewText()
        {
            textFonts.SelectedIndex = 0;
            GXTValueTextBox.Text = "Placeholder Text";
            Font customFont = new Font(privateFonts.Families[textFonts.SelectedIndex], 20, FontStyle.Regular);
            GXTValueTextBox.Font = customFont;
        }

        private void DisableComponentsBeforeTableLoaded()
        {
            searchButton.Enabled = false;
            refreshTableButton.Enabled = false;
            compileTableButton.Enabled = false;
            GXTTable.Enabled = false;
        }

        private void EnableComponentsAfterTableLoaded()
        {
            searchButton.Enabled = true;
            refreshTableButton.Enabled = true;
            compileTableButton.Enabled = true;
            GXTTable.Enabled = true;
        }

        private void LoadCustomFont()
        {
            foreach (CustomFonts fontEnum in Enum.GetValues(typeof(CustomFonts)))
            {
                string fontFileName = GetFontFileName(fontEnum);
                string fontFilePath = Path.Combine(Application.StartupPath, "TextFonts", fontFileName);
                privateFonts.AddFontFile(fontFilePath);
            }
        }

        private string GetFontFileName(CustomFonts fontEnum)
        {
            switch (fontEnum)
            {
                case CustomFonts.BankGothic:
                    return "Bank Gothic.ttf";
                case CustomFonts.Beckett:
                    return "Beckett.ttf";
                case CustomFonts.OldEnglish:
                    return "Old English.ttf";
                case CustomFonts.GTAVCRegular:
                    return "GTAVC Regular.ttf";
                case CustomFonts.RageItalic:
                    return "Rage Italic.ttf";
                default:
                    throw new ArgumentOutOfRangeException(nameof(fontEnum), fontEnum, "Unknown font enum");
            }
        }

        private void Log(string message)
        {
            logBuilder.AppendLine($"{DateTime.Now}: {message}");
            logBox.Text = logBuilder.ToString();
            logBox.SelectionStart = logBox.Text.Length;
            logBox.ScrollToCaret();
        }

        private void SaveCurrentTableIntoTextFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Log($"Saving table to {saveFileDialog.FileName} ...");
                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    foreach (DataGridViewRow row in GXTTable.Rows)
                    {
                        if (row.Cells.Count >= 2)
                        {
                            string key = row.Cells[0].Value?.ToString();
                            string value = row.Cells[1].Value?.ToString();

                            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                            {
                                writer.WriteLine($"[{key}]");
                                writer.WriteLine(value);
                                writer.WriteLine();
                            }
                        }
                    }
                }
                Log($"GXT table is saved to {saveFileDialog.FileName}.");
                MessageBox.Show($"GXT table is saved to: {saveFileDialog.FileName}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Dictionary<string, string> ReadSelectedGXTFile(string filePath)
        {
            Dictionary<string, string> dictionary = Utility.CreateDictionaryFromTextFile(filePath);
            foreach (var kvp in dictionary)
            {
                //Console.WriteLine($"key -> {kvp.Key} value -> {kvp.Value}");
                GXTTable.Rows.Add(kvp.Key, kvp.Value);
            }
            Log($"Reading completed.");
            return dictionary;
        }

        private void SearchKeyAndSelectRow(string keyword)
        {
            if (keyword != lastSearchKeyword)
            {
                lastSearchKeyword = keyword;
                lastFoundRowIndex = -1; // Reset the last found index
            }

            int startRowIndex = lastFoundRowIndex + 1; // Start searching from the next row

            for (int rowIndex = startRowIndex; rowIndex < GXTTable.Rows.Count; rowIndex++)
            {
                if (GXTTable.Rows[rowIndex].Cells[0].Value != null &&
                    GXTTable.Rows[rowIndex].Cells[0].Value.ToString().ToLower().Contains(keyword.ToLower()))
                {
                    GXTTable.CurrentCell = GXTTable.Rows[rowIndex].Cells[0]; // Select the cell
                    GXTTable.FirstDisplayedScrollingRowIndex = rowIndex; // Scroll to the row
                    lastFoundRowIndex = rowIndex; // Update the last found index
                    return; // Found and selected the row
                }
            }
            MessageBox.Show("Keyword not found.");
        }

        private void SearchValueAndSelectRow(string keyword)
        {
            if (keyword != lastSearchKeyword)
            {
                lastSearchKeyword = keyword;
                lastFoundRowIndex = -1; // Reset the last found index
            }

            int startRowIndex = lastFoundRowIndex + 1; // Start searching from the next row

            for (int rowIndex = startRowIndex; rowIndex < GXTTable.Rows.Count; rowIndex++)
            {
                if (GXTTable.Rows[rowIndex].Cells[1].Value != null &&
                    GXTTable.Rows[rowIndex].Cells[1].Value.ToString().ToLower().Contains(keyword.ToLower()))
                {
                    GXTTable.CurrentCell = GXTTable.Rows[rowIndex].Cells[1]; // Select the cell
                    GXTTable.FirstDisplayedScrollingRowIndex = rowIndex; // Scroll to the row
                    lastFoundRowIndex = rowIndex; // Update the last found index
                    return; // Found and selected the row
                }
            }

            MessageBox.Show("Value not found.");
        }

        private string DecompileSelectedGXTFile(string filePath)
        {
            GXTTable.Rows.Clear();
            string filePathWithoutExtension = filePath.Replace(".gxt", "");
            string decompileArguments = $"-i {filePath} -o {filePathWithoutExtension}.txt";

            string workingDirectory = Directory.GetCurrentDirectory();
            string absoluteExePath = workingDirectory + EXE_PATH;
            string commandExitStatus = Utility.CallExeWithArguments(absoluteExePath, decompileArguments);
            if (commandExitStatus.Length == 0)
            {
                return filePathWithoutExtension + ".txt";
            }
            return "";
        }

        private void CompileCurrentGXTTableToGXTFile()
        {

        }

        private string SelectGXTFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "GXT Files|*.gxt"; // Filter to only .gxt files
            openFileDialog.Title = "Select a GXT File";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = openFileDialog.FileName;
                return selectedFilePath;
            }
            return null;
        }

        private string CopySelectedGXTFileToGXTsFolder(string selectedFilePath)
        {
            // Create a subdirectory named 'gxts' in the current working directory
            string destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "gxts");
            Directory.CreateDirectory(destinationDirectory);

            string destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(selectedFilePath));

            try
            {
                // Copy the file, overwriting if it already exists
                File.Copy(selectedFilePath, destinationFilePath, true);
                return destinationFilePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private void ChangeCurrentFilePathLabelText(string filePath)
        {
            currentFilePathLabel.Text = CURRENT_FILE_LABEL + filePath;
            currentFilePath = filePath;
        }

        private void openGXTFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string selectedFilePath = SelectGXTFile();
            if (selectedFilePath != null)
            {
                Log($"File selected path: {selectedFilePath}");
                string newFilePath = CopySelectedGXTFileToGXTsFolder(selectedFilePath);
                if (newFilePath != null)
                {
                    Log($"Selected file copied to: {newFilePath}");
                    string decompiledFilePath = DecompileSelectedGXTFile(newFilePath);
                    if (decompiledFilePath.Length != 0)
                    {
                        Log($"Decompiled file path: {decompiledFilePath}");
                        Log($"Reading decompiled file {decompiledFilePath} ...");
                        ReadSelectedGXTFile(decompiledFilePath);
                        MessageBox.Show($"File '{selectedFilePath}' decompiled and read successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChangeCurrentFilePathLabelText(decompiledFilePath);
                        EnableComponentsAfterTableLoaded();
                    }
                }
            }
        }

        private void textFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Log($"Selected text font: {fontNames[textFonts.SelectedIndex]}, index: {textFonts.SelectedIndex}");
            Font customFont = new Font(privateFonts.Families[textFonts.SelectedIndex], 25, FontStyle.Regular);
            GXTValueTextBox.Font = customFont;
        }

        private void GXTTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 1) // Check if a valid cell is clicked
            {
                DataGridViewCell selectedCell = GXTTable.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (selectedCell.Value != null)
                {
                    string cellValue = selectedCell.Value.ToString();
                    GXTValueTextBox.Text = cellValue;
                }
            }
        }

        private void saveCurrentGXTFileAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GXTTable.Rows.Count >= 2)
            {
                SaveCurrentTableIntoTextFile();
            }
            else
            {
                MessageBox.Show("Please open a GXT file first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchKeyInput.Text.Trim();
            if (!string.IsNullOrEmpty(keyword))
            {

                if (radioSearchKey.Checked)
                {
                    SearchKeyAndSelectRow(keyword);
                }
                else if (radioSearchValue.Checked)
                {
                    SearchValueAndSelectRow(keyword);
                }
            }
        }

        private void searchKeyTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                searchButton_Click(sender, e);
                e.Handled = true; // Prevent the Enter key from being input into the TextBox
            }
        }

        private void radioSearchKey_CheckedChanged(object sender, EventArgs e)
        {
            lastFoundRowIndex = -1;
            lastSearchKeyword = "";
        }

        private void radioSearchValue_CheckedChanged(object sender, EventArgs e)
        {
            lastFoundRowIndex = -1;
            lastSearchKeyword = "";
        }

        private void compileCurrentFileTogxtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compileTableButton_Click(object sender, EventArgs e)
        {

        }
    }

}
