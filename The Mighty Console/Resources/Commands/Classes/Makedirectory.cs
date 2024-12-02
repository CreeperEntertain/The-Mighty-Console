namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Makedirectory
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "makedirectory");
            if (!Framework.HelpFlagChecker(textInput))
            {
                textInput = Framework.CommandFlagHandler(textInput, "external", out bool isExternal);
                if (isExternal) ExternalDirectoryCreation(textInput);
                else InternalDirectoryHandling(textInput);
            }
        }
        private void InternalDirectoryHandling(string textInput)
        {
            string? dotPath = Framework.ConvertToDotPath(textInput);
            if (dotPath != null)
                Framework.ErrorPrint("Missing write permissions.");
            else Framework.ErrorPrint("Invalid directory path.");
        }
        private void ExternalDirectoryCreation(string textInput)
        {
            string dirPath = textInput.Substring(textInput.IndexOf(' ') + 1);
            if (!Path.IsPathRooted(dirPath))
                dirPath = Path.Combine(Directory.GetCurrentDirectory(), dirPath);
            dirPath = Path.GetFullPath(dirPath);
            try
            {
                Directory.CreateDirectory(dirPath);
                Framework.InfoPrint("Directory created.");
            }
            catch
            {
                Framework.ErrorPrint("Failed to create the specified directory.");
            }
        }
    }
}