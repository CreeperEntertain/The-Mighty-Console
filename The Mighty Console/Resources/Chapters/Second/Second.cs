using The_Mighty_Console.Resources.Chapters.Second.Sub._1;
using The_Mighty_Console.Resources.Chapters.Second.Sub._2;
using The_Mighty_Console.Resources.Chapters.Second.Sub._3;
using The_Mighty_Console.Resources.Chapters.Second.Sub._4;
using The_Mighty_Console.Resources.Chapters.Second.Sub._5;
using The_Mighty_Console.Resources.Chapters.Second.Sub._6;
using The_Mighty_Console.Resources.Chapters.Second.Sub._7;

namespace The_Mighty_Console.Resources.Chapters.Second
{
    internal class Second
    {
        private Framework Framework => Framework.Instance;

        public bool whoMadeYouAsked = false;
        public bool whatDidYouWorkOnAsked = false;
        public bool whatDoYouThinkAboutHumanityAsked = false;
        public bool iHaveSomethingINeedToTellYouAboutMeSaid = false;
        public bool whatIsTheFormulaForTheAntidoteAsked = false;
        public bool iFoundTheFlashDriveHowDoIUseItAsked = false;

        public void Exec()
        {
            bool loop;
            do loop = MenuWrapper();
            while (loop);
            
            // TODO: Implement behaviour after formula compute.
        }

        private bool MenuWrapper()
        {
            ConsoleStorage.Clear();
            List<string> choices = new List<string>();
            ChoiceAdder(choices);
            if (ChoiceHandler(MenuChoices(choices)))
                return true;
            return false;
        }

        private void ChoiceAdder(List<string> choices)
        {
            choices.Add("Who made you?");
            choices.Add("What did you work on?");
            choices.Add("What do you think about humanity?");
            choices.Add("I have something I need to tell you about me...");
            if (Framework.rashMentioned)
                choices.Add("What is the formula for an antidote?");
            if (Framework.usbTileLifted)
                choices.Add("I found the flash drive. How do I use it?");
            if (Framework.formulaCollected)
                choices.Add("A9F2-34Z$-Q8@5-K1!4-GG2C-8L*M-32B7-F#7H-J10X-2V&W-7E5R");
        }

        private int MenuChoices(List<string> choices)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("Pick your option:", 0);
            int chosen = Framework.PlayerChoice(choices, true, 0, true, true, ConsoleColor.White, false);
            return chosen;
        }
        private bool ChoiceHandler(int chosen)
        {
            bool continueLoop = true;
            new Action[]
            {
                () => new WhoMadeTmc().Exec(),
                () => new TmcHistory().Exec(),
                () => new OpinionAboutHumanity().Exec(),
                () => new MentionRash().Exec(),
                () => new FormulaRequest().Exec(),
                () => new UsbExplanation().Exec(),
                () => new ComputeFormula().Exec(out continueLoop)
            }[chosen]();
            return continueLoop;
        }
        
        private void PrintSecondDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.{dotPath}");
    }
}