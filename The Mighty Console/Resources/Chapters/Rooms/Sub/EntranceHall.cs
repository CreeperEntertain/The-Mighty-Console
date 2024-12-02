namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class EntranceHall
    {
        private Framework Framework => Framework.Instance;

        private Outside Outside = new Outside();

        public void EntranceHallExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Outside");
            choices.Add("Return To Hall");

            if (!Framework.exploredEntranceHall)
            {
                Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.EntranceHall.Intro.txt");
                Framework.exploredEntranceHall = true;
            } else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.EntranceHall.IntroAlt.txt");
            Console.WriteLine();

            bool choiceLoop = true;
            while (choiceLoop)
            {
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        Outside.OutsideExec();
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.EntranceHall.Return.txt");
                        choiceLoop = false;
                        break;
                }
            }
        }
    }
}