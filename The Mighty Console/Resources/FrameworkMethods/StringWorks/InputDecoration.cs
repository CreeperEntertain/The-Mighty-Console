namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class InputDecoration
    {
        private Framework Framework => Framework.Instance;
        public string Exec()
        {
            string inputExtension = "> ";
            if (Framework.aiRunning) inputExtension = ": TMC" + inputExtension;
            return (Framework.name == "" ? Framework.LastDotPathWord(Framework.userPath) : Framework.name) + inputExtension;
        }
    }
}