namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Ipconfig
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "ipconfig");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.PrintFromInternalFile("Resources.Tables.Ipconfig.txt");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}