namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class MainRoom
    {
        private Framework Framework => Framework.Instance;

        private EntranceHall EntranceHall = new EntranceHall();
        private Basement Basement = new Basement();
        private Upstairs Upstairs = new Upstairs();
        private Storage Storage = new Storage();

        public void MainRoomExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Investigate Server");
            choices.Add("Upstairs");
            choices.Add("Storage");
            choices.Add("Basement");
            choices.Add("Entrance Hall");
            choices.Add("Return To Computer");

            if (!Framework.exploredMain)
            {
                Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.MainRoom.Intro.txt");
                Framework.exploredMain = true;
            } else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.MainRoom.IntroAlt.txt");
            Console.WriteLine();

            bool choiceLoop = true;
            while (choiceLoop)
            {
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.MainRoom.Server.txt");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        Upstairs.UpstairsExec();
                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine();
                        Storage.StorageExec();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine();
                        Basement.BasementExec();
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.WriteLine();
                        EntranceHall.EntranceHallExec();
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine();
                        choiceLoop = false;
                        break;
                }
            }
        }
    }
}