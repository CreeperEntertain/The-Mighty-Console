using The_Mighty_Console.Resources.FrameworkMethods.IO;

namespace The_Mighty_Console.Resources.Chapters.Second.Sub._7
{
    internal class ComputeFormula
    {
        private Framework Framework => Framework.Instance;

        public void Exec(out bool continueLoop)
        {
            PrintAccordingly("ComputerFormula.txt");
            Framework.PlayerWarning();
            int chosen = Choice(new List<string> {
                "Yes",
                "No" });
            ChoiceHandler(chosen);
            continueLoop = false;
        }

        private void ChoiceHandler(int chosen)
        {
            new Action[]
            {
                () => OptionYes(),
                () => OptionNo()
            }[chosen]();
        }
        private void OptionYes()
        {
            PrintAccordingly("Yes.txt");
            Choice(new List<string> { "Take the syringe." });
            PrintAccordingly("AntidoteObtained.txt");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Framework.DelayedPrint($"{Framework.CapitalizeFirstLetter(Framework.name)}?");
            PrintAccordingly("Awakening.txt");
        }
        private void OptionNo()
        {
            PrintAccordingly("No.txt");
            Framework.GameOver();
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions._7.{dotPath}");
    }
}