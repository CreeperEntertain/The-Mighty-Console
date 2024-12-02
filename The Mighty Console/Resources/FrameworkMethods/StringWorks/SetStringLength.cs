namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class SetStringLength
    {
        public string Exec(string input, int length, bool rightBound = false)
        {
            if (input.Length > length)
                return input.Substring(0, length);
            int paddingNeeded = length - input.Length;
            if (rightBound)
                return input.PadLeft(length);
            else
                return input.PadRight(length);
        }
    }
}