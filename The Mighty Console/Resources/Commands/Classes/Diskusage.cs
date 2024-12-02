namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Diskusage
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "diskusage");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint("    Total: 4000634109 K", 0);
                Framework.DelayedPrint("     Used: 3278674982 K", 0);
                Framework.DelayedPrint("Available:  721959127 K", 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}