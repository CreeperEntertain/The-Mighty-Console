namespace The_Mighty_Console.Resources.Chapters.Second.Sub._6
{
    internal class UsbExplanation
    {
        private Framework Framework => Framework.Instance;

        private Second second = new Second();

        public void Exec()
        {
            if (second.iFoundTheFlashDriveHowDoIUseItAsked)
                AltResponse();
            else RegularResponse();
        }

        private void AltResponse()
        {

        }
        private void RegularResponse() // TODO: Needs to set Framework.formulaPerms to true somehow.
        {
            PrintAccordingly("UsbExplanation.txt");
            second.iFoundTheFlashDriveHowDoIUseItAsked = true;
        }

        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.6.{dotPath}");
    }
}