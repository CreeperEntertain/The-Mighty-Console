using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.Chapters.Second.Sub._5
{
    internal class FormulaRequest
    {
        private Framework Framework => Framework.Instance;

        public void Exec(ref bool param)
        {
            if (param)
                AltResponse();
            else DecideResponse(ref param);
        }

        private void AltResponse()
        {
            if (Framework.aiTrustLevel >= 3)
                PrintAccordingly("Alt.txt");
            else
            {
                PrintAccordingly("AltNegative.txt");
                Framework.TrustManager(Framework.aiTrustLevel - 1);
            }
        }
        private void DecideResponse(ref bool param)
        {
            if (Framework.aiTrustLevel >= 3)
                Dialogue(ref param);
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

        private void Dialogue(ref bool param)
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
            param = true;
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions._5.{dotPath}");
    }
}