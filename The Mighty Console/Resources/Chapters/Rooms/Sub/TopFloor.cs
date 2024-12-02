namespace The_Mighty_Console.Resources.Chapters._Non_Linear.Sub
{
    internal class TopFloor
    {
        private Framework Framework => Framework.Instance;
        public void TopFloorExec()
        {
            List<string> choices = new List<string>();
            choices.Add("Investigate");
            choices.Add("Check Management");
            choices.Add("Go Back Down");
            if (Framework.formulaPerms && !Framework.formulaCollected) choices.Add("Collect Formula");

            if (!Framework.exploredTopFloor)
            {
                Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.Intro.txt");
                Framework.exploredTopFloor = true;
            } else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.IntroAlt.txt");

            bool choiceLoop = true;
            while (choiceLoop)
            {
                int chosen = Framework.PlayerChoice(choices, false, 1, true, false);
                switch (chosen)
                {
                    case 0:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.Investigate.txt");
                        Console.WriteLine();
                        break;
                    case 1:
                        Console.WriteLine();
                        if (!Framework.investigatedManagement) Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.Management.txt");
                        else Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.ManagementAlt.txt");
                        Console.WriteLine();
                        Framework.investigatedManagement = true;
                        break;
                    case 2:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.Return.txt");
                        choiceLoop = false;
                        break;
                    case 3:
                        Console.WriteLine();
                        Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Rooms.TopFloor.CollectFormula.txt");
                        Console.WriteLine();
                        Framework.formulaCollected = true;
                        if (choices.Count >= 4) choices.RemoveAt(3);
                        break;
                }
            }
        }
    }
}