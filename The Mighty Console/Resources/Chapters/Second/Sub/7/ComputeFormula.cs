namespace The_Mighty_Console.Resources.Chapters.Second.Sub._7
{
    internal class ComputeFormula
    {
        public void Exec(out bool continueLoop)
        {
            Framework.Instance.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions.7.ComputerFormula.txt");
            continueLoop = false;
        }
    }
}