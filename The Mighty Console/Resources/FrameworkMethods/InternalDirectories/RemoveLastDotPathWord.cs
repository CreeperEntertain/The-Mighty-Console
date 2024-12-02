namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class RemoveLastDotPathWord
    {
        public string Exec(string dotPath)
        {
            int lastDotIndex = dotPath.LastIndexOf('.');
            string result = lastDotIndex != -1 ? dotPath.Substring(0, lastDotIndex) : dotPath;
            return result;
        }
    }
}