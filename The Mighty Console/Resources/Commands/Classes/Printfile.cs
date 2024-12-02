namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Printfile
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "printfile");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (!string.IsNullOrEmpty(textInput))
                    FilePathChecking(textInput);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        private void FilePathChecking(string textInput)
        {
            string[] parts = textInput.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2) Framework.ErrorPrint("File path cannot be empty.");
            else
            {
                string fileType = parts[1].Equals("external", StringComparison.OrdinalIgnoreCase) ? "external" : "internal";
                string filePath = parts.Length > 2 ? parts[2] : parts[1];
                if (fileType == "internal")
                    InternalFileHandling(filePath);
                else if (fileType == "external")
                    ExternalFileChecking(filePath);
            }
        }
        private void InternalFileHandling(string filePath)
        {
            string? internalFilePath = Framework.ConvertToDotPath(filePath);
            if (internalFilePath != null)
                if (Framework.CheckForInternalFile(internalFilePath))
                    FilePrinting(internalFilePath);
                else Framework.ErrorPrint("No file found at " + filePath);
            else Framework.ErrorPrint("Attempted to read file outside user directory.");
        }
        private void FilePrinting(string internalFilePath)
        {
            try
            {
                Framework.PrintFromInternalFile(internalFilePath);
            }
            catch
            {
                Framework.ErrorPrint("Failed to print file.");
            }
        }
        private void ExternalFileChecking(string filePath)
        {
            if (!Path.IsPathRooted(filePath))
                filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            if (File.Exists(filePath))
                ReadExternalFile(filePath);
            else Framework.ErrorPrint("External file does not exist.");
        }
        private void ReadExternalFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                    Framework.DelayedPrint(line, 0);
            }
            catch
            {
                Framework.ErrorPrint("Could not read from external file.");
            }
        }
    }
}