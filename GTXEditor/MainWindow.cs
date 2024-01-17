using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Windows.Forms;


namespace GTXEditor
{
    public partial class MainWindow : Form
    {
        private readonly Logger logger = Logger.Instance;        
        private string currentTextFilePath = "";

        private static PrivateFontCollection privateFonts = new PrivateFontCollection();                

        private GXTTableManager gxtTableManager;

        public MainWindow()
        {
            InitializeComponent();
            gxtTableManager = new GXTTableManager(GXTTable);
            gxtTableManager.InitializeTable(GXTTable);

            FileUtils.LoadCustomFontFiles(privateFonts);
            InitializePreviewText();
            DisableComponentsBeforeTableLoaded();
            //InitializeDataGridView();

        }

        private void InitializePreviewText()
        {
            textFonts.SelectedIndex = 0;
            GXTValueTextBox.Text = Constants.PLACEHOLDER_TEXT;
            Font customFont = new Font(privateFonts.Families[textFonts.SelectedIndex], 20, FontStyle.Regular);
            GXTValueTextBox.Font = customFont;
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

        private void SaveCurrentTableIntoTextFile()
        {            
            string result = FileUtils.SaveMissionTablesToTextFile(GXTTable);
            if (result != null)
            {
                if (FileUtils.IsFilePathValid(result))//If the mission tables are saved to a text file then result is going to be a valid text file path.
                {                                   
                    logger.PrintLogMessage(logBox, DialogBoxMessageTexts.GXT_TABLE_SAVED_TO, result);
                    string formattedText = DialogBoxMessageTexts.GetFormattedText(DialogBoxMessageTexts.GXT_TABLE_SAVED_TO, result);
                    MessageBox.Show(formattedText, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    logger.PrintLogMessage(logBox, DialogBoxMessageTexts.ERROR_OCCURRED_FILE_SAVE, result);
                    string formattedText = DialogBoxMessageTexts.GetFormattedText(DialogBoxMessageTexts.ERROR_OCCURRED_FILE_SAVE, result);
                    MessageBox.Show(formattedText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        
        private void SearchKeyAndSelectRow(string keyword)
        {
            int foundRowIndex = gxtTableManager.FindGxtKey(keyword);
            if(foundRowIndex == -1)
            {
                MessageBox.Show(DialogBoxMessageTexts.KEY_NOT_FOUND, DialogBoxMessageTexts.TITLE_GXT_KEY_NOT_FOUND, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
        }

        private void SearchValueAndSelectRow(string keyword)
        {            
            int foundIndex = gxtTableManager.FindGxtValue(keyword);
            if(foundIndex == -1)
            {
                MessageBox.Show(DialogBoxMessageTexts.VALUE_NOT_FOUND, DialogBoxMessageTexts.TITLE_GXT_VALUE_NOT_FOUND, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChangePreviewText(GXTTable.Rows[foundIndex].Cells[Constants.GXT_VALUE_COLUMN].Value.ToString());
        }
        
        private string DecompileSelectedGXTFile(string inputFilePath)
        {
            string decompileArguments = "";
            string outputFilePath = "";

            if (radioSA.Checked)
            {
                decompileArguments += Constants.GTA_SA_DECOMPILE_ARGUMENTS;
            }
            else if (radioIV.Checked)
            {
                decompileArguments += Constants.GTA_IV_DECOMPILE_ARGUMENTS;
            }

            string commandExitStatus = FileUtils.DecompileGXTFile(inputFilePath, decompileArguments, out outputFilePath);

            if (commandExitStatus.Length == 0)
            {
                return outputFilePath.Replace("` ", " ");
            }
            else
            {
                string formattedText = DialogBoxMessageTexts.GetFormattedText(DialogBoxMessageTexts.ERROR_OCCURRED, commandExitStatus);
                MessageBox.Show(formattedText, DialogBoxMessageTexts.TITLE_ERROR_OCCURED, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void CompileCurrentGXTTableToGXTFile()
        {

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
                string formattedText = DialogBoxMessageTexts.GetFormattedText(DialogBoxMessageTexts.ERROR_OCCURRED, ex.Message);
                MessageBox.Show(formattedText, DialogBoxMessageTexts.TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        private void ChangeCurrentFilePathLabelText(string filePath)
        {
            currentFilePathLabel.Text = Constants.CURRENT_FILE_LABEL + filePath;
            currentTextFilePath = filePath;
        }

        private void ShowWarningMessage(string message)
        {
            MessageBox.Show(message, DialogBoxMessageTexts.TITLE_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        
        private void LoadDataAndTable(string filePath)
        {            
            gxtTableManager.ClearBaseDictionary();
            FileUtils.ReadMissionTablesFromTextFile(filePath, gxtTableManager.GetBaseDictionary());
            
            if (gxtTableManager.GetBaseDictionary() != null && gxtTableManager.GetBaseDictionary().Keys.Count > 0)
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
            string selectedFilePath = FileUtils.SelectGXTFile();
            if (!string.IsNullOrEmpty(selectedFilePath))
            {
                logger.PrintLogMessage(logBox, LogMessageTexts.FILE_SELECTED_PATH, selectedFilePath);
                string newFilePath = CopySelectedGXTFileToGXTsFolder(selectedFilePath);
                if (!string.IsNullOrEmpty(newFilePath))
                {
                    logger.PrintLogMessage(logBox, LogMessageTexts.FILE_COPIED_TO_PATH, newFilePath);
                    string decompiledFilePath = DecompileSelectedGXTFile(newFilePath);
                    if (!string.IsNullOrEmpty(decompiledFilePath))
                    {
                        logger.PrintLogMessage(logBox, LogMessageTexts.DECOMPILED_FILE_PATH, decompiledFilePath);
                        logger.PrintLogMessage(logBox, LogMessageTexts.READING_DECOMPILED_FILE_PATH, decompiledFilePath);                        
                        gxtTableManager.ClearTable();
                        LoadDataAndTable(decompiledFilePath);
                        MessageBox.Show($"File '{selectedFilePath}' decompiled and read successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        /*                                                                                                                    
                        EnableComponentsAfterTableLoaded();
                        */
                    }
                }
            }
        }

        private void refreshTableButton_Click(object sender, EventArgs e)
        {
            DisableComponentsBeforeTableLoaded();
            logger.PrintLogMessage(logBox, LogMessageTexts.TABLE_REFRESHING);
            LoadDefaultTextForPreviewText();
            LoadDataAndTable(currentTextFilePath);
            logger.PrintLogMessage(logBox, LogMessageTexts.TABLE_REFRESHED);
        }

        private void ClearGXTTableComboBoxElements()
        {
            comboBoxGXTTables.Items.Clear();
        }

        private void setTableComboBoxItems()
        {
            if (gxtTableManager.GetBaseDictionary() != null)
            {
                foreach (string tableNames in gxtTableManager.GetBaseDictionary().Keys)
                {
                    comboBoxGXTTables.Items.Add(tableNames);
                }

                if (comboBoxGXTTables.Items.Count > 0)
                {
                    comboBoxGXTTables.SelectedIndex = 0;
                }                    
            }
        }

        private void textFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            logger.PrintLogMessage(logBox, LogMessageTexts.SELECTED_TEXT_FONT, Constants.fontNames[textFonts.SelectedIndex], textFonts.SelectedIndex);
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
            GXTValueTextBox.Text = Constants.PREVIEW_TEXT;
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
                ShowWarningMessage(DialogBoxMessageTexts.OPEN_GXT_FILE);
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
            gxtTableManager.ResetLastSearchKeywordAndIndex("");            
        }

        private void radioSearchValue_CheckedChanged(object sender, EventArgs e)
        {
            gxtTableManager.ResetLastSearchKeywordAndIndex("");
        }

        private void compileCurrentFileTogxtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void compileTableButton_Click(object sender, EventArgs e)
        {

        }

        private void currentFilePathLabel_Click(object sender, EventArgs e)
        {
            string path = currentFilePathLabel.Text.Replace(Constants.CURRENT_FILE_LABEL, "");
            if (!string.IsNullOrEmpty(path))
            {
                Clipboard.SetText(path);
                string formattedText = DialogBoxMessageTexts.GetFormattedText(DialogBoxMessageTexts.PATH_COPIED_TO_CLIPBOARD, path);
                MessageBox.Show(formattedText, DialogBoxMessageTexts.TITLE_INFO, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowWarningMessage(DialogBoxMessageTexts.OPEN_GXT_FILE);
            }
        }

        private void buttonOpenWith_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTextFilePath))
            {
                string message = Utility.RunOpenWithWindow(currentTextFilePath);
                if (message.Length > 0)
                {
                    MessageBox.Show(message, DialogBoxMessageTexts.TITLE_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ShowWarningMessage(DialogBoxMessageTexts.OPEN_GXT_FILE);
            }

        }

        private void comboBoxGXTTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;            
            gxtTableManager.ClearTable();
            LoadDefaultTextForPreviewText();            
            gxtTableManager.LoadSelectedMissionTableToDataGridView(comboBoxGXTTables.SelectedItem.ToString());
            EnableComponentsAfterTableLoaded();
            this.Cursor = Cursors.Default;
        }
    }

}
