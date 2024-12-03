namespace The_Mighty_Console.Resources.Chapters.Second
{
    internal class Second
    {
        private Framework Framework => Framework.Instance;

        public void Exec()
        {
            List<string> choices = new List<string>();
            choices.Add("Option A");
            choices.Add("Option B");
            choices.Add("Option C");
            // TODO: Implement second chapter (player choice).
        }

        private int ChoiceMenu(List<string> choices)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("Pick your option:", 0);
            int chosen = 1 + Framework.PlayerChoice(choices);
            return chosen;
        }
    }
}