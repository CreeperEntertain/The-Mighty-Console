using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class CheckForInternalDirectory
    {
        private Framework Framework => Framework.Instance;
        public bool Exec(string directoryPathInDots, out bool isFilePath)
        {
            isFilePath = false;
            if (Framework.CheckForInternalFile(directoryPathInDots))
                isFilePath = true;
            if (Framework.CheckIfFileHasExtensionInResources(directoryPathInDots))
                return false;
            if (isFilePath)
                return false;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourcePrefix = "The_Mighty_Console." + directoryPathInDots;
            string[] resources = assembly.GetManifestResourceNames();
            foreach (string resource in resources)
                if (resource.StartsWith(resourcePrefix + ".", StringComparison.Ordinal))
                    return true;
            return false;
        }
    }
}