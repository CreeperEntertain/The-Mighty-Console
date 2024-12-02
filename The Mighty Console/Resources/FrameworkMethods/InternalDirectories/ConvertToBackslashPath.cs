namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class ConvertToBackslashPath
    {
        public string Exec(string filePathInDots, bool isFile)
        {
            if (isFile)
            {
                int lastDotIndex = filePathInDots.LastIndexOf('.');
                if (lastDotIndex == -1 || lastDotIndex == 0)
                    return filePathInDots.Replace('.', '\\');
                string pathBeforeLastDot = filePathInDots.Substring(0, lastDotIndex).Replace('.', '\\');
                string pathAfterLastDot = filePathInDots.Substring(lastDotIndex);
                return pathBeforeLastDot + pathAfterLastDot;
            }
            return filePathInDots.Replace('.', '\\');
        }
    }
}