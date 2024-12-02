namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Version
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "version");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint("5.23.9743", 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}