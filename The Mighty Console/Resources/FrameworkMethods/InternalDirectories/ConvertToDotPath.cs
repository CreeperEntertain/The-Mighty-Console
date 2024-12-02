namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class ConvertToDotPath
    {
        private Framework Framework => Framework.Instance;
        public string? Exec(string filePath)
        {
            filePath = Framework.ConvertToBackslashPath(Framework.userPath, false) + "\\" + filePath;
            var pathSegments = new Stack<string>();
            bool startsWithinIngameDir = true;
            foreach (string part in filePath.Split(new[] { '\\', '/' }, StringSplitOptions.RemoveEmptyEntries))
                if (part == "..")
                    if (pathSegments.Count == 0) startsWithinIngameDir = false;
                    else pathSegments.Pop();
                else pathSegments.Push(part);
            if (!startsWithinIngameDir)
                return null;
            var normalizedPathSegments = pathSegments.ToArray();
            Array.Reverse(normalizedPathSegments);
            string pathInDots = string.Join(".", normalizedPathSegments);
            return "IngameDir." + pathInDots;
        }
    }
}