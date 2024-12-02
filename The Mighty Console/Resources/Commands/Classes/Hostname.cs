namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Hostname
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "hostname");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint(Framework.systemHostname, 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}