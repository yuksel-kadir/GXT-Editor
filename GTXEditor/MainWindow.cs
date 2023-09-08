using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace GTXEditor
{
    public partial class MainWindow : Form
    {
        private const string EXE_PATH = @"\Compiler\gxt.exe";
        private const string CURRENT_FILE_LABEL = "Current Text File Path: ";
        private const string PREVIEW_TEXT = "Preview Text";
        private const string OPEN_GXT_FILE_WARNING_MESSAGE = "Please open a GXT file first.";
        private const string MISSION_TABLE_LINE = "{=================================== MISSION TABLE AMBULAE ===================================}";

        private string lastSearchKeyword = "";
        private string currentTextFilePath = "";
        private readonly string[] fontNames = { "Bank Gothic", "Beckett", "GTA VC Regular", "Old English", "Rage Italic" };

        private StringBuilder logBuilder = new StringBuilder();
        private static PrivateFontCollection privateFonts = new PrivateFontCollection();
        private int lastFoundRowIndex = -1;

        private Dictionary<string, string> currentDictionary;
        Dictionary<string, Dictionary<string, string>> baseDictionary = new Dictionary<string, Dictionary<string, string>>();// = new Dictionary<string, Dictionary<string, string>>();

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
            InitializeDataGridView();
        }

        private void InitializePreviewText()
        {
            textFonts.SelectedIndex = 0;
            GXTValueTextBox.Text = "Placeholder Text";
            Font customFont = new Font(privateFonts.Families[textFonts.SelectedIndex], 20, FontStyle.Regular);
            GXTValueTextBox.Font = customFont;
        }

        private void InitializeDataGridView()
        {
            GXTTable.VirtualMode = true;
            GXTTable.CellValueNeeded += GXTTable_CellValueNeeded;
        }

        private void LoadDataToDataGridView(Dictionary<string, string> dictionary)
        {
            currentDictionary = dictionary;
            GXTTable.RowCount = currentDictionary.Count;
        }

        private void GXTTable_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (e.RowIndex >= currentDictionary.Count || e.RowIndex < 0)
                return;

            KeyValuePair<string, string> rowData = currentDictionary.ElementAt(e.RowIndex);

            if (e.ColumnIndex == 0)
            {
                e.Value = rowData.Key;
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = rowData.Value;
            }
        }



        private void DisableComponentsBeforeTableLoaded()
        {
            searchButton.Enabled = false;
            refreshTableButton.Enabled = false;
            compileTableButton.Enabled = false;
            GXTTable.Enabled = false;
            buttonOpenWith.Enabled = false;
        }

        private void EnableComponentsAfterTableLoaded()
        {
            searchButton.Enabled = true;
            refreshTableButton.Enabled = true;
            compileTableButton.Enabled = true;
            GXTTable.Enabled = true;
            GXTTable.VirtualMode = true;
            buttonOpenWith.Enabled = true;
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
                    ChangePreviewText(GXTTable.Rows[rowIndex].Cells[1].Value.ToString());
                    return; // Found and selected the row
                }
            }

            MessageBox.Show("Value not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearTable()
        {
            GXTTable.Rows.Clear();
        }

        private string DecompileSelectedGXTFile(string inputFilePath)
        {
            inputFilePath = inputFilePath.Replace(" ", "` "); //Add backtick character before any space character in the path. The powershell command doesn't work without backtick character.
            string outputFilePath = "";

            if (inputFilePath.Contains(".GXT"))
            {
                outputFilePath = inputFilePath.Replace(".GXT", ".txt");
            }
            else if (inputFilePath.Contains(".gxt"))
            {
                outputFilePath = inputFilePath.Replace(".gxt", ".txt");
            }

            string decompileArguments = $"-i {inputFilePath} -o {outputFilePath}";
            if (radioSA.Checked)
            {
                decompileArguments += " -k CRC32 -w0 -h1";
            }
            else if (radioIV.Checked)
            {
                decompileArguments += " -h1 -k JENKINS -m0";
            }


            string workingDirectory = Directory.GetCurrentDirectory();
            string absoluteExePath = workingDirectory + EXE_PATH;
            string commandExitStatus = Utility.DecompileGXTFile(absoluteExePath.Replace(" ", "` "), decompileArguments);
            if (commandExitStatus.Length == 0)
            {
                return outputFilePath.Replace("` ", " ");
            }
            else
            {
                MessageBox.Show($"An error occurred: {commandExitStatus}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
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
            currentTextFilePath = filePath;
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /*
        private void LoadGXTTable(Dictionary<string, string> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                //Console.WriteLine($"key -> {kvp.Key} value -> {kvp.Value}");
                GXTTable.Rows.Add(kvp.Key, kvp.Value);
            }
        }
        */
        private void LoadDataAndTable(string filePath)
        {
            baseDictionary.Clear();
            Utility.ReadTables(filePath, baseDictionary);
            if (baseDictionary.Keys.Count > 0)
            {
                ClearGXTTableComboBoxElements();
                setTableComboBoxItems();
                //ClearTable();
                //LoadDataToDataGridView(baseDictionary[comboBoxGXTTables.SelectedItem.ToString()]);
                //EnableComponentsAfterTableLoaded();
                ChangeCurrentFilePathLabelText(filePath);
            }
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
                    if (!string.IsNullOrEmpty(decompiledFilePath))
                    {
                        Log($"Decompiled file path: {decompiledFilePath}");
                        Log($"Reading decompiled file {decompiledFilePath} ...");
                        ClearTable();
                        LoadDataAndTable(decompiledFilePath);
                        MessageBox.Show($"File '{selectedFilePath}' decompiled and read successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*
                        Log($"Decompiled file path: {decompiledFilePath}");
                        Log($"Reading decompiled file {decompiledFilePath} ...");
                        ClearTable();                       
                        LoadDataToDataGridView(Utility.CreateDictionaryFromTextFile(decompiledFilePath));
                        //ReadSelectedGXTFile(decompiledFilePath)
                        MessageBox.Show($"File '{selectedFilePath}' decompiled and read successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ChangeCurrentFilePathLabelText(decompiledFilePath);
                        EnableComponentsAfterTableLoaded();
                        */
                    }
                }
            }
        }

        private void refreshTableButton_Click(object sender, EventArgs e)
        {
            DisableComponentsBeforeTableLoaded();
            Log("Refresing the table...");
            LoadDefaultTextForPreviewText();
            LoadDataAndTable(currentTextFilePath);
            Log("The table refreshed.");
        }

        private void ClearGXTTableComboBoxElements()
        {
            comboBoxGXTTables.Items.Clear();
        }

        private void setTableComboBoxItems()
        {
            foreach (string tableNames in baseDictionary.Keys)
            {
                comboBoxGXTTables.Items.Add(tableNames);
            }

            if (comboBoxGXTTables.Items.Count > 0)
                comboBoxGXTTables.SelectedIndex = 0;
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

        private void LoadDefaultTextForPreviewText()
        {
            GXTValueTextBox.Text = PREVIEW_TEXT;
        }

        private void ChangePreviewText(string text)
        {
            GXTValueTextBox.Text = text;
        }

        private void saveCurrentGXTFileAstxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GXTTable.Rows.Count >= 2)
            {
                SaveCurrentTableIntoTextFile();
            }
            else
            {
                ShowWarningMessage(OPEN_GXT_FILE_WARNING_MESSAGE);
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



        private void currentFilePathLabel_Click(object sender, EventArgs e)
        {
            string path = currentFilePathLabel.Text.Replace(CURRENT_FILE_LABEL, "");
            if (!string.IsNullOrEmpty(path))
            {
                Clipboard.SetText(path);
                MessageBox.Show($"'{path}' path copied to clipboard.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowWarningMessage(OPEN_GXT_FILE_WARNING_MESSAGE);
            }
        }

        private void buttonOpenWith_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTextFilePath))
            {
                string message = Utility.RunOpenWithWindow(currentTextFilePath);
                if (message.Length > 0)
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ShowWarningMessage(OPEN_GXT_FILE_WARNING_MESSAGE);
            }

        }

        private void comboBoxGXTTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTable();
            LoadDataToDataGridView(baseDictionary[comboBoxGXTTables.SelectedItem.ToString()]);
            EnableComponentsAfterTableLoaded();
        }
    }

}
