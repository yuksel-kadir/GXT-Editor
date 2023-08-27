using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

        public static string CallExeWithArguments(string exePath, string arguments)
        {

            using (Process process = new Process { StartInfo = startInfo })
            {
                try
                {
                    string command = exePath + " " + arguments;
                    process.Start();
                    process.StandardInput.WriteLine(command);
                    process.StandardInput.Flush();
                    process.StandardInput.Close();
                    process.WaitForExit();

                    int exitCode = process.ExitCode;
                    if (exitCode == 0)
                    {
                        Console.WriteLine(process.StandardOutput.ReadToEnd());
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
    }
}
