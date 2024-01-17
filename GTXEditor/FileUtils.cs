using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing.Text;

namespace GTXEditor
{
    public static class FileUtils
    {
        private static readonly Logger logger = Logger.Instance;

        public enum CustomFonts
        {
            BankGothic = 0,
            Beckett = 1,
            GTAVCRegular = 2,
            OldEnglish = 3,
            RageItalic = 4
        }

        public static void ReadMissionTablesFromTextFile(string filePath, Dictionary<string, Dictionary<string, string>> baseDictionary)
        {
            string[] lines = File.ReadAllLines(filePath);

            //Dictionary<string, Dictionary<string, string>> baseDictionary = new Dictionary<string, Dictionary<string, string>>();

            string currentTable = "MAIN";
            string currentKey = null;
            baseDictionary.Add(currentTable, new Dictionary<string, string>());

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                //Find strings like this to seperate tables from each other -> {=================================== MISSION TABLE SAL1 ===================================}
                Match tableMatch = Regex.Match(trimmedLine, Constants.MISSION_TABLE_REGEX);
                if (tableMatch.Success)
                {
                    currentTable = tableMatch.Groups[1].Value;
                    baseDictionary[currentTable] = new Dictionary<string, string>();
                }
                else if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]")) //Check if the line is key like -> [CLOTHB]
                {
                    currentKey = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    if (!baseDictionary[currentTable].ContainsKey(currentKey))
                    {
                        baseDictionary[currentTable].Add(currentKey, "");
                    }
                }
                else if (currentKey != null && !string.IsNullOrEmpty(trimmedLine)) //Check if the line is value like -> ~w~You can change clothes here at any time.
                {
                    baseDictionary[currentTable][currentKey] = trimmedLine;
                }
            }

            PrintBaseDictionaryToConsole(baseDictionary);
        }

        public static string SaveMissionTablesToTextFile(DataGridView GXTTable)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = Constants.TEXT_FILE_FILTER
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
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
                    return saveFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            return null;
        }

        private static void PrintBaseDictionaryToConsole(Dictionary<string, Dictionary<string, string>> baseDictionary)
        {
            //Print key-value pairs for debugging
            foreach (var table in baseDictionary)
            {
                Console.WriteLine($"Table: {table.Key}");
                foreach (var entry in table.Value)
                {
                    Console.WriteLine($"  Key: {entry.Key}");
                    Console.WriteLine($"  Value: {entry.Value}");
                }
            }
        }

        public static string SelectGXTFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = Constants.GXT_FILE_FILTER, // Filter to only .gxt files
                Title = DialogBoxMessageTexts.TITLE_SELECT_GXT_FILE
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Return selected gxt file.
                return openFileDialog.FileName;
            }
            return null;
        }

        public static string GetFontFileName(CustomFonts fontEnum)
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

        public static void LoadCustomFontFiles(PrivateFontCollection privateFonts)
        {
            foreach (CustomFonts fontEnum in Enum.GetValues(typeof(CustomFonts)))
            {
                string fontFileName = GetFontFileName(fontEnum);
                string fontFilePath = Path.Combine(Application.StartupPath, "TextFonts", fontFileName);
                privateFonts.AddFontFile(fontFilePath);
            }
        }

        public static bool IsFilePathValid(string path)
        {
            try
            {
                // Use Path.GetFullPath to resolve any relative paths and ensure the path is well-formed.
                string fullPath = Path.GetFullPath(path);

                // Check if the path is a valid file path.
                return File.Exists(fullPath);
            }
            catch (Exception)
            {
                // Handle any exceptions that may occur during path validation.
                return false;
            }
        }
        
        public static string DecompileGXTFile(string inputFilePath, string extraDecompileArguments, out string outputFilePath)
        {
            inputFilePath = inputFilePath.Replace(" ", "` "); //Add backtick character before any space character in the path. The powershell command doesn't work without backtick character.           
            outputFilePath = "";

            string extension = Path.GetExtension(inputFilePath);
            if (string.Equals(extension, ".gxt", StringComparison.OrdinalIgnoreCase) ||
                string.Equals(extension, ".GXT", StringComparison.OrdinalIgnoreCase))
            {
                outputFilePath = Path.ChangeExtension(inputFilePath, ".txt");
            }

            string decompileArguments = $"-i {inputFilePath} -o {outputFilePath}";
            //Add more arguments if the game is SA or IV
            if (!string.IsNullOrEmpty(extraDecompileArguments))
            {
                decompileArguments += extraDecompileArguments;
            }            

            string workingDirectory = Directory.GetCurrentDirectory();
            string absoluteExePath = workingDirectory + Constants.EXE_PATH;
            string commandExitStatus = Utility.DecompileGXTFile(absoluteExePath.Replace(" ", "` "), decompileArguments);
            
            return commandExitStatus;
        }
    }
}
