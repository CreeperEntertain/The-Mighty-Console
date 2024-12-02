namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Alwaysontop
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "alwaysontop");
            if (!Framework.HelpFlagChecker(textInput))
            {
                bool isTop = Framework.SetTopWindow();
                if (isTop) Framework.InfoPrint("Window set to stay topmost.");
                else Framework.InfoPrint("Window no longer always topmost.");
            }
        }
    }
}