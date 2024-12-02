namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Library
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "library");
            if (!Framework.HelpFlagChecker(textInput))
            {
                List<string> dirList = Framework.ListInternalDirectoryContents(Framework.userPath);
                if (dirList.Count == 0)
                    Framework.InfoPrint("Directory empty or missing permissions.");
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    foreach (string item in dirList)
                        Framework.DelayedPrint(item, 0);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}