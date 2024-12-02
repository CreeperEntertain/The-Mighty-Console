namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Date
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "date");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint($"The current date is: {Framework.systemDate.DayOfWeek.ToString().Substring(0, 3)}, {Framework.systemDate.Day}/{Framework.systemDate.Month}/{Framework.systemDate.Year}", 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}