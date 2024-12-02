using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class CheckForInternalFile
    {
        private Framework Framework => Framework.Instance;
        public bool Exec(string filePathInDots)
        {
            if (string.IsNullOrEmpty(filePathInDots) || !filePathInDots.Contains('.') || filePathInDots.LastIndexOf('.') == filePathInDots.Length - 1)
                return false;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = $"The_Mighty_Console.{filePathInDots}";
            using (Stream stream = assembly.GetManifestResourceStream(Framework.RemoveFolderSuffix(resourceName)) ?? Stream.Null)
                return stream != Stream.Null;
        }
    }
}