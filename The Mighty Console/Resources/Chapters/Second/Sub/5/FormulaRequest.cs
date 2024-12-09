﻿using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.Chapters.Second.Sub._5
{
    internal class FormulaRequest
    {
        private Framework Framework => Framework.Instance;

        private Second second = new Second();

        public void Exec()
        {
            if (second.whatIsTheFormulaForTheAntidoteAsked)
                AltRespose();
            else DecideResponse();
        }

        private void AltRespose()
        {

        }
        private void DecideResponse()
        {
            if (Framework.aiTrustLevel >= 3)
                Dialogue();
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Framework.DelayedPrint("Sorry, comrade.");
                Framework.DelayedPrint("I cannot do that now.");
                Framework.TrustManager(Framework.aiTrustLevel - 1);
                Framework.falseRequestAttempts++;
                Console.ReadKey();
            }
        }

        private void Dialogue()
        {
            PrintAccordingly("FormulaRequest.txt");
            Choice(new List<string> { "Is there no other way to get the formula?" });
            PrintAccordingly("NoComrade.txt");
            Choice(new List<string> { "Unless what?" });
            PrintAccordingly("UnlessWhat.txt");
            Choice(new List<string> { "How can I get the flash drive?" });
            PrintAccordingly("GetFlashDrive.txt");
            ConsoleStorage.Clear();
            Framework.usbPerms = true;
            new Leave().Exec("leave", true);
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.5.{dotPath}");
    }
}