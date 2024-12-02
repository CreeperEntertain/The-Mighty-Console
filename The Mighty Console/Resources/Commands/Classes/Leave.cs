using The_Mighty_Console.Resources.Chapters._Non_Linear;

namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Leave
    {
        private Framework Framework => Framework.Instance;

        private Walkaround Walkaround = new Walkaround();

        public void Exec(string textInput, bool skipHelp = false)
        {
            textInput = Framework.ReplaceWord(textInput, "leave");
            if (!Framework.HelpFlagChecker(textInput, skipHelp))
            {
                ConsoleStorage.Instance.StoreConsole();
                ConsoleStorage.Instance.PauseRecording();
                Framework.isAtPC = false;
                ConsoleStorage.Clear();
                Framework.DelayedPrint("You leave the PC...");
                Console.ReadKey();
                Console.WriteLine();
                Walkaround.WalkaroundExec();
                Framework.DelayedPrint("You return to the PC...");
                Console.ReadKey();
                Framework.isAtPC = true;
                ConsoleStorage.Clear();
                ConsoleStorage.Instance.ResumeRecording();
                ConsoleStorage.Instance.RestoreConsole();
            }
        }
    }
}