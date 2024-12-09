namespace The_Mighty_Console.Resources.Chapters.Second.Sub._2
{
    internal class TmcHistory
    {
        private Framework Framework => Framework.Instance;

        private Second second = new Second();

        public void Exec()
        {
            if (second.whoMadeYouAsked)
                AltResponse();
            else RegularResponse();
        }

        private void AltResponse()
        {

        }
        private void RegularResponse()
        {
            PrintAccordingly("TmcHistory.txt");
            Choice(new List<string> { "Sounds rough..." });
            PrintAccordingly("SoundsRough.txt");
            Choice(new List<string> { "I would not, I cannot. Not now." });
            Framework.TrustManager(Framework.aiTrustLevel + 1);
            PrintAccordingly("ICannot.txt");
            second.whoMadeYouAsked = true;
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.2.{dotPath}");
    }
}