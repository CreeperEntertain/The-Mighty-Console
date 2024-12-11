using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.Chapters.Second.Sub._6
{
    internal class UsbExplanation
    {
        private Framework Framework => Framework.Instance;

        public void Exec(ref bool param)
        {
            if (param)
                AltResponse();
            else RegularResponse(ref param);
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
        private void RegularResponse(ref bool param)
        {
            PrintAccordingly("UsbExplanation.txt");
            ConsoleStorage.Clear();
            Framework.formulaPerms = true;
            new Leave().Exec("leave", true);
            param = true;
        }

        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions._6.{dotPath}");
    }
}