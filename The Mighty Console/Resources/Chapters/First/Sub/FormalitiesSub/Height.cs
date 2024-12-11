namespace The_Mighty_Console.Resources.Chapters.First.Sub.FormalitiesSub
{
    internal class Height
    {
        private Framework Framework => Framework.Instance;

        double moonDistance = 384400000;

        public void height()
        {
            PrintHeightDialogue("Request.txt");
            do
            {
                Framework.InputHandler();
                if (string.IsNullOrEmpty(Framework.textInput))
                {
                    PrintHeightDialogue("Empty.txt");
                    continue;
                }
                bool isHeight = double.TryParse(Framework.textInput, out double height);
                if (!isHeight)
                    PrintHeightDialogue("Invalid.txt");
                else HeightHandler(height);
            } while (Framework.height == null);
        }
        private void HeightHandler(double height)
        {
            var actionMap = new (Predicate<double> Condition, Action<double> Action)[]
            {
                (height => height < 0, height => PrintHeightDialogue("Negative.txt")),
                (height => height < 1.4, height => PrintHeightDialogue("Tiny.txt")),
                (height => height > 2.72, height => PrintHeightDialogue("Giant.txt")),
                (height => height > 2.05, height => PrintHeightDialogue("Tall.txt")),
                (_ => true, height => SetHeight(height))
            };
            foreach (var (condition, action) in actionMap)
                if (condition(height))
                {
                    action(height);
                    return;
                }
        }

        private void SetHeight(double height)
        {
            Framework.height = Math.Round(height, 2);
            double dudeStacking = Math.Round(moonDistance / (Framework.height ?? 0), 2);
            int realShit = (int)Math.Floor(dudeStacking);
            string percentageShitString = dudeStacking.ToString("F2");
            int percentageShit = int.Parse(percentageShitString.Split('.')[1]);
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("According to my calculations...");
            Framework.DelayedPrint($"You have to put yourself on top of another {dudeStacking} times to reach the moon.");
            if (dudeStacking % 1 != 0)
            {
                Framework.DelayedPrint("But that do not make sense.");
                Framework.DelayedPrint("Last time I asked, comrade did not want to disect himself.");
                Framework.DelayedPrint($"So it would be {realShit} times.");
                Framework.DelayedPrint($"That is {percentageShit}% extra you.");
                Framework.DelayedPrint("Your choice if you need the leftover.");
            }
            Console.WriteLine();
            Framework.DelayedPrint("But I talk too much.");
            Framework.DelayedPrint("Your height is saved, comrade.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void PrintHeightDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.Formalities.Height.{dotPath}");
    }
}