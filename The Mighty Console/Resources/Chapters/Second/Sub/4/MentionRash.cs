namespace The_Mighty_Console.Resources.Chapters.Second.Sub._4
{
    internal class MentionRash
    {
        private Framework Framework => Framework.Instance;

        private Second second = new Second();

        public void Exec(ref bool param)
        {
            if (param)
                AltResponse();
            else RegularResponse(ref param);
        }

        private void AltResponse() => PrintAccordingly("Alt.txt");
        private void RegularResponse(ref bool param)
        {
            PrintAccordingly("MentionRash.txt");
            ChoicesInOrder(new List<string> {
                "I have an illness.",
                "A rash.",
                "If untreated, it will kill me.",
                "That is why I truly need your help." });
            Framework.rashMentioned = true;
            PrintAccordingly("Reaction.txt");
            int chosen = Choice(new List<string> {
                "I do.",
                "I do not." });
            if (chosen == 0)
            {
                Framework.TrustManager(Framework.aiTrustLevel + 1);
                PrintAccordingly("IDo.txt");
            }
            else PrintAccordingly("IDoNot.txt");
            param = true;
        }

        private void ChoicesInOrder(List<string> input)
        {
            foreach (string item in input)
                Choice(new List<string> { item });
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions._4.{dotPath}");
    }
}