namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Tasklist
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "tasklist");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                if (Framework.CommandFlagChecker(textInput, "detailed"))
                {
                    Framework.DelayedPrint("Image Name                     PID Session Name        Mem Usage", 0);
                    Framework.DelayedPrint("========================= ======== ================ ============", 0);
                    foreach (var process in Framework.processes)
                        Framework.DelayedPrint(process.ToString(), 0);
                }
                else foreach (var process in Framework.processes)
                        Framework.DelayedPrint(process.ProcessName, 0);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}