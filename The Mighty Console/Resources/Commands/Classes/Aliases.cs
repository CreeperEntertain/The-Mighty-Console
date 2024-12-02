namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Aliases
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "aliases");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.PrintFromInternalFile("Resources.Tables.Aliases.txt", 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}