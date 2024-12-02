namespace The_Mighty_Console.Resources.FrameworkMethods.IngameCommands
{
    internal class CommandFlagHandler
    {
        public string Exec(string input, string flag, out bool flagDetected, int position = 1)
        {
            string[] parts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 1 && parts[position].Equals(flag, StringComparison.OrdinalIgnoreCase))
            {
                flagDetected = true;
                return parts[0] + " " + string.Join(" ", parts.Skip(position + 1));
            }
            flagDetected = false;
            return input;
        }
    }
}