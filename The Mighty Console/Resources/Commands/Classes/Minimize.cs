namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Minimize
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "minimize");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Framework.FocusWindow();
                Framework.MinimizeWindow();
            }
        }
    }
}