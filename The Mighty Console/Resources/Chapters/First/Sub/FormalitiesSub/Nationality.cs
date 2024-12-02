using The_Mighty_Console.Resources.GameData.Lists;

namespace The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub
{
    internal class Nationality
    {
        private Framework Framework => Framework.Instance;

        int nationAttempts = 0;

        public void nationality()
        {
            PrintNationalityDialogue("Request.txt");
            do
            {
                Framework.InputHandler();
                if (string.IsNullOrEmpty(Framework.textInput))
                    PrintNationalityDialogue("Empty.txt");
                else if (Nations.Contains(Framework.textInput.ToLower()))
                {
                    PrintNationalityDialogue("Common.txt");
                    Framework.nationality = Framework.CapitalizeFirstLetter(Framework.textInput);
                }
                else UncommonNationality();
            } while (string.IsNullOrEmpty(Framework.nationality));
        }
        private void UncommonNationality()
        {
            if (nationAttempts < 3)
            {
                nationAttempts++;
                PrintNationalityDialogue($"Attempt{nationAttempts}.txt");
            }
            else
            {
                PrintNationalityDialogue("FinalAttempt.txt");
                Framework.nationality = Framework.CapitalizeFirstLetter(Framework.textInput);
            }
        }
        private void PrintNationalityDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.Nationality.{dotPath}");
    }
}