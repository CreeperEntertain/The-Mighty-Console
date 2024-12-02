namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class RemoveFirstWord
    {
        public string Exec(string input)
        {
            int indexOfFirstSpace = input.IndexOf(' ');
            if (indexOfFirstSpace == -1)
                return string.Empty;
            return input.Substring(indexOfFirstSpace + 1);
        }
    }
}