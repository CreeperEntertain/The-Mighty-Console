namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Notes
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "notes");
            if (!Framework.HelpFlagChecker(textInput))
            {
                bool addFlag = false;
                bool removeFlag = false;
                bool clearFlag = false;
                bool viewFlag = false;
                textInput = Framework.CommandFlagHandler(textInput, "add", out addFlag);
                textInput = Framework.CommandFlagHandler(textInput, "remove", out removeFlag);
                textInput = Framework.CommandFlagHandler(textInput, "clear", out clearFlag);
                textInput = Framework.CommandFlagHandler(textInput, "view", out viewFlag);
                textInput = Framework.RemoveFirstWord(textInput);
                if (addFlag)
                {
                    Framework.playerNotes.Add(textInput);
                    Framework.InfoPrint($"Added note: {textInput}");
                }
                else if (removeFlag) RemoveEntry(textInput);
                else if (clearFlag)
                {
                    Framework.playerNotes.Clear();
                    Framework.InfoPrint("Note list cleared.");
                }
                else if (viewFlag)
                    if (Framework.playerNotes.Count < 1) Framework.InfoPrint("Note list is empty.");
                    else ViewEntries();
                else Framework.ErrorPrint("No flag detected.");
            }
        }
        private void RemoveEntry(string textInput)
        {
            int index = Convert.ToInt32(textInput) - 1;
            if (index < 0) Framework.ErrorPrint("Provide an existing note ID.");
            else if (Framework.playerNotes.Count - 1 >= index)
            {
                Framework.playerNotes.RemoveAt(index);
                Framework.InfoPrint($"Removed note {index + 1}");
            }
            else Framework.ErrorPrint("Provide an existing note ID.");
        }
        private void ViewEntries()
        {
            int i = 0;
            int numLength = Framework.playerNotes.Count.ToString().Length + 2;
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (string iteration in Framework.playerNotes)
            {
                i++;
                Framework.DelayedPrint($"{Framework.SetStringLength($"{i.ToString()}.", numLength)}{iteration}", 0);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}