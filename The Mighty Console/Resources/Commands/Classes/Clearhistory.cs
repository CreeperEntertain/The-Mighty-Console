namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Clearhistory
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            string textInputAbs = textInput;
            textInput = Framework.ReplaceWord(textInput, "clearhistory");
            if (!Framework.HelpFlagChecker(textInput))
            {
                Framework.commandHistory.Clear();
                Framework.DelayedPrint("Command history cleared.", 0);
            }
            Framework.commandHistory.Add(textInputAbs);
        }
    }
}