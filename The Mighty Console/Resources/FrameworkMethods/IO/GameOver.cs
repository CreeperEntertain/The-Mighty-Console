#pragma warning disable CA1416
// Published application is a Windows x64 executable.
// It's likely the user is using Windows.
// May God help us if not...
namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class GameOver
    {
        private Framework Framework => Framework.Instance;
        public void Exec()
        {
            string gameOver = "GAME OVER!";
            string textRemover = Framework.SetStringLength(string.Empty, gameOver.Length);
            int delay = 150;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.Write(Framework.CenterString(gameOver));
            int windowTop = Console.WindowTop;
            int cursorTop = Console.CursorTop;
            for (int i = 0; i < 10; i++)
            {
                GameOverBlink(windowTop, cursorTop, textRemover, delay);
                GameOverBlink(windowTop, cursorTop, gameOver, delay);
            }
            Console.WriteLine();
            Console.WriteLine();
            Framework.DelayedPrint("Press any key to close the game...");
            Console.CursorVisible = true;
            Console.ReadKey();
            Environment.Exit(0);
        }
        private void GameOverBlink(int windowTop, int cursorTop, string displayText, int delay)
        {
            CursorReset(windowTop, cursorTop);
            Console.Write(Framework.CenterString(displayText));
            Thread.Sleep(delay);
        }
        private void CursorReset(int windowTop, int cursorTop)
        {
            Console.WindowTop = windowTop;
            Console.SetCursorPosition(0, cursorTop);
        }
    }
}