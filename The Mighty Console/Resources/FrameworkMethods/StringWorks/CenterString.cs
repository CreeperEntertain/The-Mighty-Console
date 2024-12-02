namespace The_Mighty_Console.Resources.FrameworkMethods.StringWorks
{
    internal class CenterString
    {
        private Framework Framework => Framework.Instance;
        public string Exec(string input)
        {
            int stringLength = (Console.BufferWidth + input.Length) / 2;
            return Framework.SetStringLength(input, stringLength, true);
        }
    }
}