﻿namespace The_Mighty_Console.Resources.Chapters.Second.Sub._3
{
    internal class OpinionAboutHumanity
    {
        private Framework Framework => Framework.Instance;

        private Second second = new Second();

        public void Exec()
        {
            if (second.whatDoYouThinkAboutHumanityAsked)
                AltResponse();
            else RegularResponse();
        }

        private void AltResponse()
        {

        }
        private void RegularResponse()
        {
            PrintAccordingly("OpinionAboutHumanity.txt");
            int chosen = Choice(new List<string> {
                "I love humanity.",
                "I'm indifferent.",
                "I hate humanity." });
            ChoiceHandler(chosen);
            Console.WriteLine();
            PrintAccordingly("Epilog.txt");
            second.whatDoYouThinkAboutHumanityAsked = true;
        }

        private void ChoiceHandler(int chosen)
        {
            new Action[]
            {
                () => {},
                () => Framework.TrustManager(Framework.aiTrustLevel + 1),
                () => Framework.TrustManager(Framework.aiTrustLevel - 1)
            }[chosen]();
            new Action[]
            {
                () => PrintAccordingly("Love.txt"),
                () => PrintAccordingly("Indifference.txt"),
                () => PrintAccordingly("Hate.txt")
            }[chosen]();
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.3.{dotPath}");
    }
}