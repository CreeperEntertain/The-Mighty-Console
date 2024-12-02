namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class RemoveFolderSuffix
    {
        public string Exec(string dotPath)
        {
            dotPath = dotPath.EndsWith(".dd") ? dotPath.Substring(0, dotPath.Length - 3) : dotPath;
            dotPath = dotPath.EndsWith(".d") ? dotPath.Substring(0, dotPath.Length - 2) : dotPath;
            return dotPath;
        }
    }
}