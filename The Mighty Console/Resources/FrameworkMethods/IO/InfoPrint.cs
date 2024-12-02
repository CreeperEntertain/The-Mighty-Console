namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class InfoPrint
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string input)
        {
            string previousTextColor = Console.ForegroundColor.ToString();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Framework.DelayedPrint("INFO: ", 0, false);
            Console.ForegroundColor = ConsoleColor.White;
            Framework.DelayedPrint(input, 0);
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), previousTextColor);
        }
    }
}