namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class PlayerWarning
    {
        private Framework Framework => Framework.Instance;
        public void Exec()
        {
            ConsoleColor previousColor = Console.ForegroundColor;
            string warning = "  WARNING! This choice will impact your ending.  ";
            string empty = "";
            foreach (char c in warning)
                empty += " ";
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Framework.DelayedPrint(empty);
            Framework.DelayedPrint(warning);
            Framework.DelayedPrint(empty);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = previousColor;
            Console.WriteLine();
            Framework.Beep();
        }
    }
}