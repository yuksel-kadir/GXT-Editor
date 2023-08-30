using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace GTXEditor
{
    public static class Utility
    {
        private static readonly ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = "powershell.exe",
            RedirectStandardOutput = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        public static Dictionary<string, string> CreateDictionaryFromTextFile(string filePath)
        {
            string text = File.ReadAllText(filePath);

            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            using (StringReader reader = new StringReader(text))
            {
                string currentKey = null;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        currentKey = line.Trim('[', ']');
                        dictionary[currentKey] = "";
                    }
                    else if (!string.IsNullOrEmpty(currentKey))
                    {
                        if (line.Contains("{"))
                        {
                            dictionary[currentKey] += Environment.NewLine + Environment.NewLine + line;
                        }
                        else
                        {
                            if (line.Contains("AS THE LAST LABEL DOES NOT GET COMPILED!!"))
                            {
                                dictionary[currentKey] += Environment.NewLine + line;
                            }
                            else
                            {
                                dictionary[currentKey] += line;
                            }
                        }
                    }
                }
            }

            return dictionary;
        }


        public static string DecompileGXTFile(string exePath, string arguments)
        {

            using (Process process = new Process { StartInfo = startInfo })
            {
                try
                {
                    string command = $"{exePath} {arguments}";
                    process.Start();
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.Flush();
                    process.StandardInput.Close();
                    string consoleOutput = process.StandardOutput.ReadToEnd();
                    Console.WriteLine(consoleOutput);
                    process.WaitForExit();
                    Console.WriteLine("sfgsgfsfg");
                    int exitCode = process.ExitCode;
                    if (exitCode == 0)
                    {
                        
                        if (consoleOutput.ToLower().Contains("bad allocation"))
                        {
                            return $"Decompiling failed: Bad Allocation. Couldn't decompile the gxt file.";
                        }
                        Console.WriteLine("Command ran successfully.");
                        return "";
                    }
                    else
                    {
                        Console.WriteLine($"Command failed with exit code: {exitCode}");
                        return $"Decompiling failed with exit code: {exitCode}";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    return $"Something went wrong: {ex.Message}";
                }

            }
        }

        public static string RunOpenWithWindow(string arguments)
        {
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    UseShellExecute = true,
                    FileName = "rundll32.exe",
                    Arguments = $"shell32.dll,OpenAs_RunDLL {arguments}"
                };

                Process process = new Process
                {
                    StartInfo = startInfo
                };
                process.Start();
                process.WaitForExit();
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;                
            }
        }

        public static Dictionary<string, Dictionary<string, string>> TestReadTables(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            Dictionary<string, Dictionary<string, string>> baseDictionary = new Dictionary<string, Dictionary<string, string>>();
            
            string currentTable = "MAIN";
            string currentKey = null;
            baseDictionary.Add(currentTable, new Dictionary<string, string>());

            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                Match tableMatch = Regex.Match(trimmedLine, @"^{=+ MISSION TABLE (.+) =+}$");
                if (tableMatch.Success)
                {
                    currentTable = tableMatch.Groups[1].Value;
                    baseDictionary[currentTable] = new Dictionary<string, string>();
                }
                else if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    currentKey = trimmedLine.Substring(1, trimmedLine.Length - 2);
                    if (!baseDictionary[currentTable].ContainsKey(currentKey))
                    {
                        baseDictionary[currentTable].Add(currentKey, "");
                    }                    
                }
                else if (currentKey != null && !string.IsNullOrEmpty(trimmedLine))
                {
                    baseDictionary[currentTable][currentKey] = trimmedLine;
                }
            }

            foreach (var table in baseDictionary)
            {
                Console.WriteLine($"Table: {table.Key}");
                foreach (var entry in table.Value)
                {
                    Console.WriteLine($"  Key: {entry.Key}");
                    Console.WriteLine($"  Value: {entry.Value}");
                }
            }
            return baseDictionary;
        }
    }
}
