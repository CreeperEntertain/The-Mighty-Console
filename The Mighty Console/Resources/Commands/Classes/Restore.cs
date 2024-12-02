namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Restore
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "restore");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Framework.FocusWindow();
                Framework.RestoreWindow();
            }
        }
    }
}