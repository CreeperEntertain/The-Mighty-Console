namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class TrimDotPathDirPrefix
    {
        public string Exec(string filePathInDots, string toTrim = "IngameDir.")
        {
            return filePathInDots.StartsWith(toTrim) ?
                filePathInDots.Substring(toTrim.Length) :
                filePathInDots;
        }
    }
}