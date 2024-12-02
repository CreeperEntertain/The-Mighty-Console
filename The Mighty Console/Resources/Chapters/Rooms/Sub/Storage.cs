namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class Storage
    {
        private Framework Framework => Framework.Instance;
        public void StorageExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Investigate");
            choices.Add("Return To Hall");

            if (!Framework.exploredStorage)
            {
                Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Storage.Intro.txt");
                Framework.exploredStorage = true;
            } else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Storage.IntroAlt.txt");
            Console.WriteLine();

            bool choiceLoop = true;
            while (choiceLoop)
            {
                if (Framework.discoveredHint && choices.Count < 3)
                    choices.Add("Read Hidden Note");
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        if (!Framework.investigatedStorage) Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Storage.Investigate.txt");
                        else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Storage.InvestigateAlt.txt");
                        Console.WriteLine();
                        if (!Framework.discoveredHint) choices.Add("Read Hidden Note");
                        Framework.discoveredHint = true;
                        Framework.investigatedStorage = true;
                        break;
                    case 1:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Storage.Return.txt");
                        choiceLoop = false;
                        break;
                    case 2:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.Storage.HelpNote.txt");
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}