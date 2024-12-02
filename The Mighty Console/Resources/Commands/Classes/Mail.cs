namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Mail
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "mail");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.PrintFromInternalFile("Resources.Tables.Mail.txt");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}