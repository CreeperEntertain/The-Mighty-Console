using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class CheckIfFileHasExtensionInResources
    {
        private Framework Framework => Framework.Instance;
        public bool Exec(string filePathInDots)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string baseResourceName = "The_Mighty_Console." + filePathInDots;
            var resourceNames = assembly.GetManifestResourceNames();
            int matches = 0;
            foreach (var resourceName in resourceNames)
            {
                string remainder = Framework.TrimDotPathDirPrefix(Framework.RemoveFolderSuffix(resourceName), baseResourceName + ".");
                if (remainder.Count(c => c == '.') == 0 && !(remainder == ""))
                    matches++;
            }
            if (matches == 1)
                return true;
            return false;
        }
    }
}