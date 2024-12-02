namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class ErrorPrint
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string input, bool isWarning = false, int errorLevel = 2)
        {
            ConsoleColor previousTextColor = Console.ForegroundColor;
            switch (errorLevel)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case >= 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            Framework.DelayedPrint(isWarning ? "WARNING! " : "ERROR! ", 0, false);
            Console.ForegroundColor = ConsoleColor.White;
            Framework.DelayedPrint(input, 0);
            Console.ForegroundColor = previousTextColor;
        }
    }
}