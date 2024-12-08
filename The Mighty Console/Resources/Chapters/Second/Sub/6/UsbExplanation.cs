namespace The_Mighty_Console.Resources.Chapters.Second.Sub._6
{
    internal class UsbExplanation
    {
        private Framework Framework => Framework.Instance;

        public void Exec()
        {
            PrintAccordingly("UsbExplanation.txt");
        }
        // TODO: Needs to set Framework.formulaPerms to true somehow.

        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.6.{dotPath}");
    }
}