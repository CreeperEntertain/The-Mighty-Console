namespace The_Mighty_Console.Resources.GameData.Arrays
{
    public static class AsciiArtCharacters
    {
        private static readonly char[] asciiCharList;
        static AsciiArtCharacters()
        {
            asciiCharList = new char[] { ' ', '´', ',', '\'', '-', '+', ';', '<', '/', 'j', 'U', 'O', '§', '#', '%', '@' };
        }

        /// <summary>
        /// Expected range is 0-15.
        /// </summary>
        /// <param name="brightness"></param>
        /// <returns></returns>
        public static char Get(int brightness)
        {
            return asciiCharList[Math.Clamp(brightness, 0, 15)];
        }
    }
}