namespace The_Mighty_Console.Resources.Chapters.Second.Sub._4
{
    internal class MentionRash
    {
        private Framework Framework => Framework.Instance;

        public void Exec()
        {
            PrintAccordingly("MentionRash.txt");
            ChoicesInOrder(new List<string> {
                "I have an illness.",
                "A rash.",
                "If untreated, it will kill me.",
                "That is why I truly need your help." });
            PrintAccordingly("Reaction.txt");
            int chosen = Choice(new List<string> {
                "I do.",
                "I do not." });
            if (chosen == 0)
                PrintAccordingly("IDo.txt");
            else PrintAccordingly("IDoNot.txt");
        }

        private void ChoicesInOrder(List<string> input)
        {
            foreach (string item in input)
                Choice(new List<string> { item });
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.4.{dotPath}");
    }
}