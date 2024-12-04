namespace The_Mighty_Console.Resources.Chapters.Second
{
    internal class Second
    {
        private Framework Framework => Framework.Instance;

        public void Exec()
        {
            List<string> choices = new List<string>();
            choices.Add("Option A");
            choices.Add("Request formula");
            choices.Add("A9F2-34Z$-Q8@5-K1!4-GG2C-8L*M-32B7-F#7H-J10X-2V&W-7E5R");
            // TODO: Implement second chapter (player choice).
        }

        private int ChoiceMenu(List<string> choices)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("Pick your option:", 0);
            int chosen = 1 + Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
            return chosen;
        }
    }
}