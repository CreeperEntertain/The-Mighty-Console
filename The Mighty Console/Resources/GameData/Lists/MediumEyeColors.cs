namespace The_Mighty_Console.Resources.GameData.Lists
{
    internal class MediumEyeColors
    {
        private static Framework Framework => Framework.Instance;

        private static readonly List<string> _items;

        static MediumEyeColors()
        {
            _items = Framework.InternalFileToList("Resources.GameData.Lists.Source.MediumEyeColors.txt") ?? new List<string>();
        }

        public static List<string> GetItems()
        {
            return _items;
        }
    }
}