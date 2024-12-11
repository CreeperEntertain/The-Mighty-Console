namespace The_Mighty_Console.Resources.GameData.Lists
{
    internal class RareEyeColors
    {
        private static Framework Framework => Framework.Instance;

        private static readonly List<string> _items;

        static RareEyeColors()
        {
            _items = Framework.InternalFileToList("Resources.GameData.Lists.Source.RareEyeColors.txt") ?? new List<string>();
        }

        public static List<string> GetItems() => _items;
    }
}