using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class PrintFromInternalFile
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string filePathInDots, int delay = 0)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "The_Mighty_Console." + filePathInDots;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName) ?? Stream.Null)
            using (StreamReader reader = new StreamReader(stream))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line == "") line = " ";
                    Framework.DelayedPrint(line, delay);
                }
            }
        }
    }
}