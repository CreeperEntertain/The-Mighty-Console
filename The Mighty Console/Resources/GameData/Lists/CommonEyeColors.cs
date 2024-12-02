namespace The_Mighty_Console.Resources.GameData.Lists
{
    public static class CommonEyeColors
    {
        private static Framework Framework => Framework.Instance;

        private static readonly List<string> _items;

        static CommonEyeColors()
        {
            _items = Framework.InternalFileToList("Resources.GameData.Lists.Source.CommonEyeColors.txt") ?? new List<string>();
        }

        public static List<string> GetItems()
        {
            return _items;
        }
    }
}