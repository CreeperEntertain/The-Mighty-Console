using The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub;

namespace The_Mighty_Console.Resources.Chapters.First.Sub
{
    internal class Formalities
    {
        private Framework Framework => Framework.Instance;

        private Name Name = new Name();
        private Age Age = new Age();
        private Height Height = new Height();
        private Nationality Nationality = new Nationality();
        private EyeColor EyeColor = new EyeColor();

        public void Exec()
        {
            PrintFormalitiesDialogue("Greetings.txt");
            Name.name();
            Console.WriteLine();
            Age.age();
            Console.WriteLine();
            Height.height();
            Console.WriteLine();
            EyeColor.eyeColor();
            Console.WriteLine();
            Nationality.nationality();
            Framework.skippedFirst = false;
            Console.WriteLine();
            PrintFormalitiesDialogue("Conclusion.txt");
            Console.ReadKey();
        }
        public void RespondWithDataPoints()
        {
            ConsoleStorage.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            DataSummarization();
            Confirmation();
            PrintFormalitiesDialogue("ExitResponse.txt");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void DataSummarization()
        {
            Framework.DelayedPrint("Alright comrade, to summarize...");
            Framework.DelayedPrint($"Your name is {Framework.name}.");
            Framework.DelayedPrint($"You're {Framework.age} years old and born in {Framework.systemDate.Year - Framework.age}.");
            Framework.DelayedPrint($"You're {Framework.height} meters tall.");
            if (Framework.height >= 1.95 && Framework.age < 25)
                BasketballEasterEgg();
            Framework.DelayedPrint($"Your eye type is {Framework.eyeColor?.ToLower()}.");
            Framework.DelayedPrint($"And you come from {Framework.CapitalizeFirstLetter(Framework.nationality)}.");
            Framework.DelayedPrint("All proper?");
        }
        private void BasketballEasterEgg()
        {
            Console.WriteLine();
            Framework.DelayedPrint("Must say, would be good basketball player.");
            Framework.DelayedPrint("That sport from capitalist nation.");
            Framework.DelayedPrint("Anyway...");
            Console.WriteLine();
        }
        private void Confirmation()
        {
            List<string> choices = new List<string>();
            choices.Add("Correct.");
            Framework.PlayerChoice(choices, false, 0, true, true, ConsoleColor.White, true);
        }

        private void PrintFormalitiesDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.{dotPath}");
    }
}