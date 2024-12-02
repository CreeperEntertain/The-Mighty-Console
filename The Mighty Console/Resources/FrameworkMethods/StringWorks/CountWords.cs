namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class CountWords
    {
        public int Exec(string input)
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}