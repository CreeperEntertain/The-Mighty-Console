namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class Outside
    {
        private Framework Framework => Framework.Instance;
        public void OutsideExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Cliff");
            choices.Add("Go Back Inside");

            if (!Framework.exploredOutside)
            {
                Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Outside.Intro.txt");
                Framework.exploredOutside = true;
            } else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Outside.IntroAlt.txt");
            Console.WriteLine();

            bool choiceLoop = true;
            while (choiceLoop)
            {
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Outside.Cliff.txt");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Outside.Return.txt");
                        choiceLoop = false;
                        break;
                }
            }
        }
    }
}