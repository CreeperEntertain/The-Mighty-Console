namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class ReplaceWord
    {
        public string Exec(string input, string newWord, int position = 0)
        {
            string[] words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (position < 0 || position >= words.Length)
                throw new ArgumentOutOfRangeException(nameof(position), "Position is out of range.");
            words[position] = newWord;
            return string.Join(" ", words);
        }
    }
}