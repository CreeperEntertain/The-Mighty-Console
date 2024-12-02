namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class Basement
    {
        private Framework Framework => Framework.Instance;
        public void BasementExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Investigate");
            choices.Add("Return To Hall");

            if (!Framework.exploredBasement)
            {
                Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Basement.Intro.txt");
                Framework.exploredBasement = true;
            } else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Basement.IntroAlt.txt");
            Console.WriteLine();

            bool choiceLoop = true;
            while (choiceLoop)
            {
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Basement.Investigate.txt");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Basement.Return.txt");
                        choiceLoop = false;
                        break;
                }
            }
        }
    }
}