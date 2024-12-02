namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Printdirectory
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "printdirectory");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint(Framework.ConvertToBackslashPath(Framework.userPath, false), 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}