﻿namespace The_Mighty_Console.Resources.Chapters.Second.Sub._1
{
    internal class WhoMadeTmc
    {
        private Framework Framework => Framework.Instance;

        public void Exec()
        {
            PrintAccordingly("WhoMadeTmc.txt");
            Choice(new List<string> { "I told you my name." });
            PrintAccordingly("IToldYouMyName.txt");
            int chosen = 1 + Choice(new List<string> {
                "Someone who wants to help others.",
                "Someone who needs help.",
                "I cannot tell you.",
                "I won't tell you." });
            ChoiceHandler(chosen);
        }

        private void ChoiceHandler(int chosen)
        {
            new Action[]
            {
                () => Framework.TrustManager(Framework.aiTrustLevel + 1),
                () => Framework.TrustManager(Framework.aiTrustLevel + 1),
                () => Framework.TrustManager(Framework.aiTrustLevel),
                () => Framework.TrustManager(Framework.aiTrustLevel - 1)
            }[chosen]();
            new Action[]
            {
                () => PrintAccordingly("HelpOthers.txt"),
                () => PrintAccordingly("NeedsHelp.txt"),
                () => PrintAccordingly("CannotTell.txt"),
                () => PrintAccordingly("WillNotTell.txt")
            }[chosen]();
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.1.{dotPath}");
    }
}