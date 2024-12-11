namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Shutdown
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "shutdown");
            if (!Framework.HelpFlagChecker(textInput))
                ShutdownIntermission();
        }
        public void ShutdownIntermission()
        {
            ConsoleStorage.Clear();
            ConsoleStorage.Instance.PauseRecording();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Shutting down...");
            Thread.Sleep(3500);
            ConsoleStorage.Clear();
            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.Shutdown.txt");
            Framework.GameOver();
        }
    }
}