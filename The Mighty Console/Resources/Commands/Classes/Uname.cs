namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Uname
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "uname");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                textInput = Framework.CommandFlagHandler(textInput, "detailed", out bool flagDetected);
                if (!flagDetected) Framework.DelayedPrint("TMC-OS 'The Mighty Console'", 0);
                else Framework.PrintFromInternalFile("Resources.Tables.Uname.txt");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}