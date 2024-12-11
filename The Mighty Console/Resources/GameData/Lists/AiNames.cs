namespace The_Mighty_Console.Resources.GameData.Lists
{
    public static class AiNames
    {
        private static Framework Framework => Framework.Instance;

        private static readonly List<string> _items;

        static AiNames()
        {
            _items = Framework.InternalFileToList("Resources.GameData.Lists.Source.AiNames.txt") ?? new List<string>();
        }

        public static bool Contains(string input) => _items.Contains(input);
    }
}