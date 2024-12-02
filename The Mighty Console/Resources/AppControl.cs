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
        public void BufferSetter()
        {
            #pragma warning disable CA1416
            Console.BufferHeight = short.MaxValue - 1;
            #pragma warning restore CA1416
        }
        public void ExitKeybindInhibitor()
        {
            #pragma warning disable CS8622
            Console.CancelKeyPress += new ConsoleCancelEventHandler(OnCancelKeyPress);
            #pragma warning restore CS8622
            void OnCancelKeyPress(object sender, ConsoleCancelEventArgs e)
            {
                e.Cancel = true;
            }
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
    }
}