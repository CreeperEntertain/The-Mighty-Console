namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class History
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "history");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.commandHistory.ForEach(i => Framework.DelayedPrint(i + " ", 0));
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}