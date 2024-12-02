namespace The_Mighty_Console.Resources.Chapters.Intro.Sub
{
    internal class Prelog
    {
        private Framework Framework => Framework.Instance;

        public void PrelogExec()
        {
            Framework.DelayedPrint("Do you want to skip the intro?");
            Framework.DelayedPrint("Arrows to navigate, enter to pick.");
            Console.CursorVisible = false;
            Console.WriteLine();
            Thread.Sleep(1000);
            List<string> choices = new List<string>();
            choices.Add("No");
            choices.Add("Yes");
            int skip = Framework.PlayerChoice(choices, true, 0, false, false);
            ConsoleStorage.Clear();
            if (skip == 0) Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.Prelog.txt");
        }
    }
}