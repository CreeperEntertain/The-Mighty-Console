using The_Mighty_Console.Resources.FrameworkMethods.IO;

namespace The_Mighty_Console.Resources.Chapters.Second.Sub._7
{
    internal class ComputeFormula
    {
        private Framework Framework => Framework.Instance;

        public void Exec(out bool continueLoop)
        {
            PrintAccordingly("ComputerFormula.txt");
            PlayerWarning();
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

        private void PlayerWarning()
        {
            string warning = "  WARNING! This choice will impact your ending.  ";
            string empty = "";
            foreach (char c in warning)
                empty += " ";
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Framework.DelayedPrint(empty);
            Framework.DelayedPrint(warning);
            Framework.DelayedPrint(empty);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
        }

        private int Choice(List<string> choices) => Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
        private void PrintAccordingly(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.Questions._7.{dotPath}");
    }
}