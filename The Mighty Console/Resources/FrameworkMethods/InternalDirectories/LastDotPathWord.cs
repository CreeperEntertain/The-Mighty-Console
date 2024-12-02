namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class LastDotPathWord
    {
        public string Exec(string dotPath)
        {
            int lastDotIndex = dotPath.LastIndexOf('.');
            string result = lastDotIndex != -1 ? dotPath.Substring(lastDotIndex + 1) : dotPath;
            return result;
        }
    }
}