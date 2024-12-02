using System.Text.RegularExpressions;

namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Dateset
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "dateset");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Framework.DelayedPrint("Valid date format: yyyy,mm,dd", 0);
                Framework.DelayedPrint("Enter new date: ", 0, false);
                string tmpDate = Console.ReadLine() ?? "";
                string datePattern = @"^\s*(\d{4})\s*,\s*(\d{1,2})\s*,\s*(\d{1,2})\s*$";
                if (Regex.IsMatch(tmpDate, datePattern))
                {
                    Framework.systemDate = DateTime.Parse(tmpDate);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Framework.DelayedPrint($"The new system time is: {Framework.systemDate.DayOfWeek.ToString().Substring(0, 3)}, {Framework.systemDate.Day}/{Framework.systemDate.Month}/{Framework.systemDate.Year}", 0);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else Framework.ErrorPrint("Invalid date format. Please run the command again and provide a valid format.");
            }
        }
    }
}