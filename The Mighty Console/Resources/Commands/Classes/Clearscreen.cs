namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Clearscreen
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "clearscreen");
            if (!Framework.HelpFlagChecker(textInput))
                ConsoleStorage.Clear();
        }
    }
}