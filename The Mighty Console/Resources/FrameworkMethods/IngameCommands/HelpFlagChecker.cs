namespace The_Mighty_Console.Resources.FrameworkMethods.IngameCommands
{
    internal class HelpFlagChecker
    {
        private Framework Framework => Framework.Instance;
        public bool Exec(string input, bool doNotCheck = false)
        {
            if (doNotCheck) return false;
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 2 && parts[1] == "?")
            {
                ConsoleColor previousTextColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Blue;
                Framework.PrintFromInternalFile("Resources.Commands.Tables." + Framework.CapitalizeFirstLetter(parts[0] + ".txt"));
                Console.ForegroundColor = previousTextColor;
                return true;
            }
            return false;
        }
    }
}