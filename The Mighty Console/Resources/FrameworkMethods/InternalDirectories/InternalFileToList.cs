using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.InternalDirectories
{
    internal class InternalFileToList
    {
        private Framework Framework => Framework.Instance;
        public List<string> Exec(string dotPath)
        {
            List<string> output = new List<string>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "The_Mighty_Console." + dotPath;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName) ?? Stream.Null)
            using (StreamReader reader = new StreamReader(stream))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                    output.Add(line);
            }
            return output;
        }
    }
}