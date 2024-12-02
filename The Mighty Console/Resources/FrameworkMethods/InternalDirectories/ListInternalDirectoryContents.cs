using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class ListInternalDirectoryContents
    {
        private Framework Framework => Framework.Instance;
        public List<string> Exec(string dotPath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string directoryPrefix = "The_Mighty_Console.IngameDir." + dotPath;
            List<string> output = new List<string>();
            string[] resources = assembly.GetManifestResourceNames().Where(r => r.StartsWith(directoryPrefix)).ToArray();
            var directoryContents = new Dictionary<string, bool>();
            foreach (string resource in resources)
            {
                string relativePath = resource.Substring(directoryPrefix.Length).Trim('.');
                string[] pathParts = relativePath.Split('.');
                if (pathParts.Length == 1)
                {
                    string folderName = pathParts[0];
                    if (folderName.Equals("d", StringComparison.OrdinalIgnoreCase) || folderName.Equals("dd", StringComparison.OrdinalIgnoreCase))
                        continue;
                    directoryContents[folderName] = false;
                }
                else
                {
                    string folderName = pathParts[0];
                    string fullFileName = string.Join(".", pathParts);
                    if (relativePath.Count(c => c == '.') == 1)
                    {
                        if (fullFileName.EndsWith(".d"))
                        {
                            string nameWithoutExtension = fullFileName.Substring(0, fullFileName.Length - 2);
                            if (nameWithoutExtension.Equals("d", StringComparison.OrdinalIgnoreCase))
                                continue;
                            output.Add($"D: {nameWithoutExtension}");
                            directoryContents[nameWithoutExtension] = false;
                        }
                        else if (fullFileName.EndsWith(".dd"))
                        {
                            string nameWithoutExtension = fullFileName.Substring(0, fullFileName.Length - 3);
                            if (nameWithoutExtension.Equals("dd", StringComparison.OrdinalIgnoreCase))
                                continue;
                            output.Add($"D: {nameWithoutExtension}\\..");
                            directoryContents[nameWithoutExtension] = true;
                        }
                        else
                        {
                            output.Add($"F: {fullFileName}");
                            if (directoryContents.ContainsKey(folderName))
                                directoryContents[folderName] = true;
                        }
                    }
                    else directoryContents[folderName] = true;
                }
            }
            foreach (var kvp in directoryContents)
                if (kvp.Value) output.Add($"D: {kvp.Key}\\..");
                else output.Add($"D: {kvp.Key}");
            output = Framework.RemoveDuplicates(output);
            output.Sort();
            return output;
        }
    }
}