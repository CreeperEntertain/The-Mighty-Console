namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Whoami
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "whoami");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (!Framework.loggedIn)
                    Framework.DelayedPrint("Temporary", 0);
                else if (Framework.name == "")
                    Framework.DelayedPrint("Research 00827", 0);
                else Framework.DelayedPrint(Framework.name, 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}