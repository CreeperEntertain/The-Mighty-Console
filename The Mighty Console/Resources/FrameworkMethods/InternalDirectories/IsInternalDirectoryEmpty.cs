using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class IsInternalDirectoryEmpty
    {
        private Framework Framework => Framework.Instance;
        public bool Exec(string filePathInDots)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "The_Mighty_Console." + Framework.RemoveFolderSuffix(filePathInDots);
            using (Stream stream = assembly.GetManifestResourceStream(resourceName) ?? Stream.Null)
            {
                if (stream == null) return false;
                using (StreamReader reader = new StreamReader(stream))
                    if (reader.ReadLine() == null) return true;
            }
            return false;
        }
    }
}