namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Changedirectory
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "changedirectory");
            if (!Framework.HelpFlagChecker(textInput))
            {
                textInput = Framework.RemoveFirstWord(textInput);
                string dotPath = Framework.ConvertToDotPath(textInput) ?? "";
                bool isFolder = Framework.CheckForInternalDirectory(dotPath, out bool isFile);
                if (textInput == "")
                    Framework.ErrorPrint("Input cannot be empty.");
                else if (isFile)
                {
                    Framework.InfoPrint(dotPath);
                    Framework.ErrorPrint("Path has to lead to a directory.");
                }
                else if (isFolder)
                    Framework.userPath = Framework.TrimDotPathDirPrefix(dotPath);
                else if (!(isFolder && isFile))
                    Framework.ErrorPrint("Invalid path.");
                else Framework.ErrorPrint("Unexpected error.");
            }
        }
    }
}