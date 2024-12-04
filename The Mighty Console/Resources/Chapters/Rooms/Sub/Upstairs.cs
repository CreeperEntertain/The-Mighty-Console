namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class Upstairs
    {
        private Framework Framework => Framework.Instance;

        private TopFloor TopFloor = new TopFloor();

        public void UpstairsExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Investigate");
            choices.Add("Top Floor");
            choices.Add("Return To Hall");
            if (Framework.usbPerms && !Framework.usbTileLifted) choices.Add("Lift Tile");

            if (!Framework.exploredUpstairs)
            {
                PrintUpstairsDialogue("Intro.txt");
                Framework.exploredUpstairs = true;
            } else PrintUpstairsDialogue("IntroAlt.txt");
            Console.WriteLine();

            bool choiceLoop = true;
            while (choiceLoop)
            {
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        PrintUpstairsDialogue("Investigate.txt");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        TopFloor.TopFloorExec();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        PrintUpstairsDialogue("Return.txt");
                        choiceLoop = false;
                        break;
                    case 3:
                        Console.WriteLine();
                        PrintUpstairsDialogue("LiftTile.txt");
                        Console.WriteLine();
                        Framework.usbTileLifted = true;
                        if (choices.Count >= 4) choices.RemoveAt(3);
                        break;
                }
            }
        }

        private void PrintUpstairsDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Rooms.Upstairs.{dotPath}");
    }
}