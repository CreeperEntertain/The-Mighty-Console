#pragma warning disable CA1416
namespace The_Mighty_Console.Resources
{
    internal class AppControl
    {
        private Framework Framework => Framework.Instance;

        private Program Program = new Program();

        public void LaunchCheck(string[] args)
        {
            if (!(args.Length > 0 && args[0] == "launched"))
            {
                Framework.ErrorPrint("This game relies on base CMD to function correctly.", true);
                Framework.ErrorPrint("If you opened this game inside Terminal, please run the launcher instead.", true);
                Console.WriteLine();
                Framework.ErrorPrint("Proceed anyway?", true);
                Console.Write("[Y] Yes | otherwise, no: ");
                char choice = char.ToLower(Console.ReadKey().KeyChar);
                if (choice != 'y') Environment.Exit(0);
                else ConsoleStorage.Clear();
            }
        }
        public void BufferSetter() => Console.BufferHeight = short.MaxValue - 1;
        public void ExitKeybindInhibitor()
        {
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancelKeyPress);
            void OnCancelKeyPress(object? sender, ConsoleCancelEventArgs e) => e.Cancel = true;
        }
        public void ConsoleInitializer()
        {
            Framework.FocusWindow();
            Framework.FullscreenWindow();
            Console.Title = "The Mighty Console";
            Console.ResetColor();
        }
        public void ChapterFirstGameState()
        {
            Framework.loggedIn = true;
            Framework.aiRunning = true;
            Framework.AddProcess("TMC.exe", 78123, "User", 76253);
            Framework.userPath = "rsrch_00827";
        }
        public void ChapterSecondGameState()
        {
            Framework.name = "Sasha";
            Framework.nationality = "Russia";
            Framework.age = 25;
            Framework.height = 1.65;
            Framework.eyeColor = "Brown";
        }
        public void ChapterThirdGameState()
        {
            Framework.rashMentioned = true;
            Framework.usbPerms = true;
            Framework.usbTileLifted = true;
            Framework.formulaPerms = true;
            Framework.formulaCollected = true;
            Framework.DelayedPrint("Is TMC with you?");
            if (Framework.PlayerChoice(new List<string> { "Yes", "No" }, true, 0, false, false) == 0)
                Framework.aiWithPlayer = true;
        }
    }
}