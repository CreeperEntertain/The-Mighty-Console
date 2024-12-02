namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Delete
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "delete");
            if (!Framework.HelpFlagChecker(textInput))
            {
                bool isExternal = false;
                textInput = Framework.CommandFlagHandler(textInput, "external", out isExternal);
                string filePath = Framework.RemoveFirstWord(textInput);
                if (isExternal) ExternalFileHandler(filePath);
                else InternalFileHandler(Framework.ConvertToDotPath(filePath));
            }
        }
        private void InternalFileHandler(string dotPath)
        {
            if (Framework.CheckForInternalDirectory(dotPath, out bool isFilePath))
                Framework.ErrorPrint("Path points to directory. Use REMOVEDIRECTORY instead.");
            else if (isFilePath)
                Framework.ErrorPrint("Missing write permissions.");
            else Framework.ErrorPrint("No file detected at target path.");
        }
        private void ExternalFileHandler(string filePath)
        {
            string normalizedPath;
            if (Path.IsPathRooted(filePath)) normalizedPath = filePath;
            else normalizedPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), filePath));
            if (File.Exists(normalizedPath))
                if (Framework.ConfirmAction()) ExternalFileDeletion(normalizedPath);
                else Framework.InfoPrint("File deletion canceled.");
            else Framework.ErrorPrint("File does not exist.");
        }
        private void ExternalFileDeletion(string normalizedPath)
        {
            try
            {
                File.Delete(normalizedPath);
                Framework.InfoPrint("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Framework.ErrorPrint($"Cannot delete file: {ex.Message}");
            }
        }
    }
}