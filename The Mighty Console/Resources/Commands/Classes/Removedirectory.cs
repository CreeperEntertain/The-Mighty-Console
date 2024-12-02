namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Removedirectory
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "removedirectory");
            if (!Framework.HelpFlagChecker(textInput))
            {
                bool isExternal = false;
                textInput = Framework.CommandFlagHandler(textInput, "external", out isExternal);
                if (isExternal) ExternalDirectoryHandling(textInput);
                else InternalDirectoryHandling(textInput);
            }
        }
        private void InternalDirectoryHandling(string textInput)
        {
            bool isFilePath = false;
            textInput = Framework.RemoveFirstWord(textInput);
            string dotPath = Framework.ConvertToDotPath(textInput) ?? "";
            if (textInput == "") Framework.ErrorPrint("Path cannot be empty.");
            else if (Framework.CheckForInternalDirectory(dotPath, out isFilePath))
                if (isFilePath) Framework.ErrorPrint("Path points to file.");
                else Framework.ErrorPrint("Missing write permissions.");
            else Framework.ErrorPrint("Target directory does not exist.");
        }
        private void ExternalDirectoryHandling(string textInput)
        {
            string dirPath = textInput.Substring(textInput.IndexOf(' ') + 1);
            if (!Path.IsPathRooted(dirPath))
                dirPath = Path.Combine(Directory.GetCurrentDirectory(), dirPath);
            dirPath = Path.GetFullPath(dirPath);
            if (Directory.Exists(dirPath))
                ExternalDirectoryDeletion(dirPath);
            else Framework.ErrorPrint("The specified path is not a valid directory or does not exist.");
        }
        private void ExternalDirectoryDeletion(string dirPath)
        {
            if (Directory.GetFiles(dirPath).Length > 0 || Directory.GetDirectories(dirPath).Length > 0)
            {
                Framework.ErrorPrint("Files detected in target directory.", true);
                if (!Framework.ConfirmAction())
                {
                    Framework.InfoPrint("Directory deletion cancelled.");
                    return;
                }
                try
                {
                    Directory.Delete(dirPath, true);
                    Framework.InfoPrint("Directory and files deleted.");
                }
                catch
                {
                    Framework.ErrorPrint("Failed to delete some or all contents in the directory.");
                }
            }
            else try
            {
                Directory.Delete(dirPath);
                Framework.InfoPrint("Directory deleted");
            }
            catch
            {
                Framework.ErrorPrint("Failed to delete directory.");
            }
        }
    }
}