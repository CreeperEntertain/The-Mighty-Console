namespace The_Mighty_Console.Resources.Chapters
{
    internal class Preface
    {
        private Framework Framework => Framework.Instance;
        public void Exec()
        {
            Framework.ErrorPrint("This game features flashing lights. Players prone to photosensitive epilepsy should not play. Continue?", true);
            int chosen = Framework.PlayerChoice(new List<string> { 
                "Yes",
                "No" }, false, 0, false, true, ConsoleColor.Red);
            if (chosen == 1)
                Environment.Exit(0);
            ConsoleStorage.Clear();
        }
    }
}