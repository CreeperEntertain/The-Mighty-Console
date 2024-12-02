namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class ReturnFirstWord
    {
        public string Exec(string input)
        {
            int spaceIndex = input.IndexOf(' ');
            if (spaceIndex == -1) return input;
            return input.Substring(0, spaceIndex);
        }
    }
}