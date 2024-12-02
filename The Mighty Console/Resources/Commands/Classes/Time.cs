namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Time
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "time");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint(DateTime.Now.ToString("HH:mm:ss"), 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}