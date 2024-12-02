namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Fullscreen
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "fullscreen");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Framework.FocusWindow();
                Framework.FullscreenWindow();
            }
        }
    }
}