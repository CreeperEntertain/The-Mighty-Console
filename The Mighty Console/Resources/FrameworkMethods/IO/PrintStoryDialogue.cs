using System.Reflection;

namespace The_Mighty_Console.Resources.FrameworkMethods.PrintMethods
{
    internal class PrintStoryDialogue
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string filePathInDots)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = "The_Mighty_Console." + filePathInDots;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName) ?? Stream.Null)
            using (StreamReader reader = new StreamReader(stream))
            {
                string? line;
                bool confirm = true;
                while ((line = reader.ReadLine()) != null)
                {
                    line = line.TrimEnd();
                    FormattingHandler(line, confirm);
                }
            }
            Console.ResetColor();
        }

        private void FormattingHandler(string line, bool confirm)
        {
            if (line == "")
                Console.WriteLine();
            else if (line == "...")
                Framework.DelayedPrint(line, 1000);
            else if (line == "#CLEAR")
                ConsoleStorage.Clear();
            else if (line == "#AUTO")
                confirm = false;
            else if (line == "#CONFIRM")
                confirm = true;
            else if (line.StartsWith("#"))
            {
                string colorName = line.Substring(1).Trim();
                if (Enum.TryParse(colorName, true, out ConsoleColor color))
                    Console.ForegroundColor = color;
                else
                {
                    Framework.DelayedPrint(line);
                    Console.ReadKey();
                }
            }
            else
            {
                Framework.DelayedPrint(line);
                if (confirm) Console.ReadKey();
            }
        }
    }
}