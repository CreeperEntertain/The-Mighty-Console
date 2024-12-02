namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Timecurrent
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "timecurrent");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.DelayedPrint(Math.Round((Framework.systemDate - Framework.creationDate).TotalSeconds + DateTime.Now.TimeOfDay.TotalSeconds).ToString(), 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}