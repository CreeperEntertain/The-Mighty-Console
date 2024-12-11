namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Echo
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "echo");
            if (!Framework.HelpFlagChecker(textInput))
            {
                string echo = string.Join(" ", textInput.Split(' ').Skip(1));
                if (string.IsNullOrEmpty(echo))
                {
                    Framework.ErrorPrint("Echo input cannot be empty.");
                    return;
                }
                string[] parts = echo.Split(new char[] { '>', '^' }, StringSplitOptions.None);
                bool isLiteral = false;
                string outputText = "";
                string filePath = "";
                bool appendToFile = false;
                bool invalidFileName = false;
                bool isExternal = false;
                InputStringProcessing(echo, ref isLiteral, ref outputText, ref appendToFile, ref isExternal, ref filePath);
                outputText = outputText.TrimEnd();
                if (!string.IsNullOrEmpty(filePath))
                    FileProcessing(ref filePath, ref invalidFileName, isExternal, appendToFile, outputText);
                if (invalidFileName)
                    Framework.ErrorPrint("Invalid file name.");
                else if (string.IsNullOrEmpty(filePath))
                    Framework.DelayedPrint(outputText, 0);
            }
        }

        private void InputStringProcessing(string echo, ref bool isLiteral, ref string outputText, ref bool appendToFile, ref bool isExternal, ref string filePath)
        {
            for (int i = 0; i < echo.Length; i++)
            {
                char currentChar = echo[i];
                if (currentChar == '^' && i + 1 < echo.Length && echo[i + 1] == '^')
                {
                    outputText += '^';
                    i++;
                }
                else if (currentChar == '^')
                    isLiteral = true;
                else if (currentChar == '>' && !isLiteral)
                {
                    if (i + 1 < echo.Length && echo[i + 1] == '>')
                    {
                        appendToFile = true;
                        i++;
                    }
                    if (i + 1 < echo.Length && echo[i + 1] == ' ' && echo.Substring(i + 2).StartsWith("external"))
                    {
                        isExternal = true;
                        filePath = echo.Substring(i + 2 + "external".Length).Trim();
                    }
                    else filePath = echo.Substring(i + 1).Trim();
                    break;
                }
                else
                {
                    outputText += currentChar;
                    isLiteral = false;
                }
            }
        }

        private void FileProcessing(ref string filePath, ref bool invalidFileName, bool isExternal, bool appendToFile, string outputText)
        {
            string fileName = Path.GetFileName(filePath).ToUpper();
            string[] invalidFileNames = {
                "CON", "PRN", "AUX", "NUL",
                "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9",
                "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
            if (fileName.IndexOfAny(new char[] { '<', '>', ':', '"', '/', '\\', '|', '?', '*' }) >= 0 || Array.Exists(invalidFileNames, name => name == fileName))
                invalidFileName = true;
            else if (isExternal)
                ExternalFileHandling(appendToFile, filePath, outputText);
            else InternalFileHandling(filePath, outputText);
        }

        private void InternalFileHandling(string filePath, string outputText)
        {
            string? dotPath = Framework.ConvertToDotPath(filePath);
            if (dotPath != null)
                if (Framework.CheckForInternalFile(dotPath))
                    Framework.ErrorPrint("Missing write permissions for file '" + filePath + "'.");
                else Framework.ErrorPrint("Missing write permissions for target directory.");
            else Framework.ErrorPrint("Attempted to write file outside user directory.");
        }

        private void ExternalFileHandling(bool appendToFile, string filePath, string outputText)
        {
            if (!Path.IsPathRooted(filePath))
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            try
            {
                FileWriting(appendToFile, filePath, outputText);
            }
            catch
            {
                Framework.ErrorPrint("Could not write to external file.");
            }
        }

        private void FileWriting(bool appendToFile, string filePath, string outputText)
        {
            try
            {
                string? directoryPath = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directoryPath) && !Directory.Exists(directoryPath))
                    Directory.CreateDirectory(directoryPath);
                if (appendToFile)
                {
                    File.AppendAllText(filePath, outputText + Environment.NewLine);
                    Framework.InfoPrint("Added to file.");
                }
                else
                {
                    File.WriteAllText(filePath, outputText + Environment.NewLine);
                    Framework.InfoPrint("Wrote to or overwrote file.");
                }
            }
            catch
            {
                Framework.ErrorPrint("Could not write to file.");
            }
        }
    }
}