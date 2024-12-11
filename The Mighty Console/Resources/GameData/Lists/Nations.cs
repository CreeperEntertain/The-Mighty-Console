namespace The_Mighty_Console.Resources.GameData.Lists
{
    public static class Nations
    {
        private static Framework Framework => Framework.Instance;

        private static readonly List<string> _items;

        static Nations()
        {
            _items = Framework.InternalFileToList("Resources.GameData.Lists.Source.Nations.txt") ?? new List<string>();
        }

        public static bool Contains(string input) => _items.Contains(input);
    }
}