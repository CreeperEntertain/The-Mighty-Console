namespace The_Mighty_Console.Resources.Chapters.Second.Sub._2
{
    internal class TmcHistory
    {
        private Framework Framework => Framework.Instance;

        public void Exec(ref bool param)
        {
            if (param)
                AltResponse();
            else RegularResponse(ref param);
        }

        private void AltResponse() => PrintAccordingly("Alt.txt");
        private void RegularResponse(ref bool param)
        {
            PrintAccordingly("TmcHistory.txt");
            Choice(new List<string> { "Sounds rough..." });
            PrintAccordingly("SoundsRough.txt");
            Choice(new List<string> { "I would not, I cannot. Not now." });
            Framework.TrustManager(Framework.aiTrustLevel + 1);
            PrintAccordingly("ICannot.txt");
            param = true;
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions._2.{dotPath}");
    }
}