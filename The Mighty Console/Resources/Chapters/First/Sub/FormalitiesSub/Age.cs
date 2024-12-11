using System.Globalization;

namespace The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub
{
    internal class Age
    {
        private Framework Framework => Framework.Instance;
        public void age()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint($"Please now enter your age, comrade {Framework.name}.");
            Console.ForegroundColor = ConsoleColor.White;
            do
            {
                Framework.InputHandler();
                if (string.IsNullOrEmpty(Framework.textInput))
                {
                    PrintAgeDialogue("Empty.txt");
                    continue;
                }
                bool isAge = int.TryParse(Framework.textInput, out int age);
                if (!isAge)
                    PrintAgeDialogue("Invalid.txt");
                else AgeHandler(age);
            } while (Framework.age == null);
        }
        private void AgeHandler(int age)
        {
            var actionMap = new (Predicate<int> Condition, Action<int> Action)[]
            {
                (age => age < 0, age => PrintAgeDialogue("Negative.txt")),
                (age => age < 7, age => PrintAgeDialogue("Baby.txt")),
                (age => age < 12, age => PrintAgeDialogue("Youth.txt")),
                (age => age < 20, age => { PrintAgeDialogue("NonAdult"); CommentAge(age); }),
                (age => age > 100, age => PrintAgeDialogue("Skeleton.txt")),
                (age => age > 85, age => PrintAgeDialogue("Old.txt")),
                (age => age > 60, age => { PrintAgeDialogue("Mature.txt"); CommentAge(age); }),
                (_ => true, age => CommentAge(age))
            };
            foreach (var (condition, action) in actionMap)
                if (condition(age))
                {
                    action(age);
                    return;
                }
        }
        
        private void CommentAge(int age)
        {
            Framework.age = age;
            int birthYear = Framework.systemDate.Year - age;
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint($"Ah, born in {birthYear}... Nice economy.");
            Framework.DelayedPrint("Classic communism.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintAgeDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.Age.{dotPath}");
    }
}