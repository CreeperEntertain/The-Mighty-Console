using The_Mighty_Console.Resources.GameData.Lists;

namespace The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub
{
    internal class Name
    {
        private Framework Framework => Framework.Instance;

        int nameAttempts = 0;

        public void name()
        {
            do
            {
                Framework.InputHandler();
                if (Framework.textInput.ToLower() == "rick")
                    System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=dQw4w9WgXcQ"); // We're never gonna give up the player.
                if (string.IsNullOrEmpty(Framework.textInput))
                    PrintNameDialogue("Empty.txt");
                else if (AiNames.Contains(Framework.textInput.ToLower()))
                    PrintNameDialogue("AiName.txt");
                else if (CommonNames.Contains(Framework.textInput.ToLower()))
                {
                    PrintNameDialogue("Common.txt");
                    Framework.name = Framework.textInput;
                }
                else UncommonName();
            } while (string.IsNullOrEmpty(Framework.name));
        }
        private void UncommonName()
        {
            if (nameAttempts < 3)
            {
                nameAttempts++;
                PrintNameDialogue($"Attempt{nameAttempts}.txt");
            }
            else
            {
                PrintNameDialogue("FinalAttempt.txt");
                Framework.name = Framework.textInput;
            }
        }
        private void PrintNameDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.Name.{dotPath}");
    }
}