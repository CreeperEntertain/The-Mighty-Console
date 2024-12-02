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
                if (!isAge) PrintAgeDialogue("Invalid.txt");
                else switch (age)
                    {
                        case < 0:
                            PrintAgeDialogue("Negative.txt");
                            break;
                        case < 7:
                            PrintAgeDialogue("Baby.txt");
                            break;
                        case < 12:
                            PrintAgeDialogue("Youth.txt");
                            break;
                        case < 20:
                            PrintAgeDialogue("NonAdult");
                            CommentAge(age);
                            break;
                        case > 100:
                            PrintAgeDialogue("Skeleton.txt");
                            break;
                        case > 85:
                            PrintAgeDialogue("Old.txt");
                            break;
                        case > 60:
                            PrintAgeDialogue("Mature.txt");
                            CommentAge(age);
                            break;
                        default:
                            CommentAge(age);
                            break;
                    }
            } while (Framework.age == null);
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