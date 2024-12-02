namespace The_Mighty_Console.Resources.FrameworkMethods.IngameCommands
{
    internal class CommandFlagChecker
    {
        private Framework Framework => Framework.Instance;
        public bool Exec(string input, string flag, int position = 1)
        {
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1 && parts[position].Equals(flag, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
    }
}