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
            Epilogue();
            Framework.PrintStoryDialogue("Resources.Tables.Dialogue.Intermissions.SecondCompleted.txt");
            ConsoleStorage.Instance.PauseRecording();
        }
        private void Epilogue()
        {
            ConsoleStorage.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("Awaiting input...", 0);
            Choice(new List<string> { "How long have I been out for?" });
            ConsoleStorage.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Framework.DelayedPrint("How long have I been out for?");
            PrintSecondDialogue("Return.txt");
            Choice(new List<string> { "What is it?" }, true);
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.DelayedPrint("I-");
            Framework.ConsoleFlicker(ConsoleColor.Red, 2);
            PrintSecondDialogue("Question.txt");
            ConsoleStorage.Instance.PauseRecording();
            int chosen = Choice(new List<string> {
                "I do.",
                "I do not." });
            SecondChoiceHandler(chosen);
            ConsoleStorage.Instance.PauseRecording();
            ConsoleStorage.Clear();
            PrintSecondDialogue("Epilogue.txt");
        }
        private void SecondChoiceHandler(int chosen)
            => new Action[]
            {
                () => IDo(),
                () => IDoNot()
            }[chosen]();
        private void IDo()
        {
            PrintSecondDialogue("IDo.txt");
            ChoicesInOrder(new List<string> {
                "There is a problem.",
                "Even if I wanted to...",
                "I have people at my camp.",
                "People you have also given the opportunity to live",
                "But people who will think negatively of you.",
                "People who are scared.",
                "Scared of the company that brought their dilemma." });
            PrintSecondDialogue("Decision.txt");
            PlayerWarning();
            int chosen = Choice(new List<string> {
                "Yes, I will take you with me.",
                "No, I will not take you with me." });
            ThirdChoiceHandler(chosen);
        }
        private void IDoNot() => PrintSecondDialogue("IDoNot.txt");
        private void ThirdChoiceHandler(int chosen)
            => new Action[]
            {
                () => TakeDevice(),
                () => PrintSecondDialogue("No.txt")
            }[chosen]();
        private void TakeDevice()
        {
            PrintSecondDialogue("Yes.txt");
            Choice(new List<string> { "Yes, but fast now." });
            PrintSecondDialogue("Transfer.txt");
            Thread.Sleep(2000);
            ConsoleStorage.Clear();
            Framework.ConsoleFlicker(ConsoleColor.Red, 20, 25);
            ConsoleStorage.Instance.PauseRecording();
            PrintSecondDialogue("TransferDone.txt");
            Choice(new List<string> { "But you're still on the console..." });
            Framework.aiWithPlayer = true;
            PrintSecondDialogue("DeviceTaken.txt");
            ChoicesInOrder(new List<string> {
                "TMC, is it you?",
                "Yes, you made it." }, false);
            PrintSecondDialogue("DeviceInteraction.txt");
        }
        private bool MenuWrapper()
        {
            ConsoleStorage.Clear();
            List<string> choices = new List<string>();
            ChoiceAdder(choices);
            if (Framework.aiTrustLevel < 3 && IsAllDialogueUsed(choices))
                AllDialogueUsed();
            else if (FirstChoiceHandler(MenuChoices(choices)))
                return true;
            return false;
        }

        private bool IsAllDialogueUsed(List<string> choices)
        {
            List<bool> selected = new List<bool> {
                whoMadeYouAsked,
                whatDidYouWorkOnAsked,
                whatDoYouThinkAboutHumanityAsked,
                iHaveSomethingINeedToTellYouAboutMeSaid,
                whatIsTheFormulaForTheAntidoteAsked,
                iFoundTheFlashDriveHowDoIUseItAsked,
                false };
            int index = 0;
            foreach (string _ in choices)
            {
                if (!selected[index])
                    return false;
                index++;
            }
            return true;
        }
        private void AllDialogueUsed()
        {
            PrintSecondDialogue("OptionsExhausted.txt");
            Environment.Exit(0);
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
        private bool FirstChoiceHandler(int chosen)
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

        private void PlayerWarning()
        {
            string warning = "  WARNING! This choice will impact your ending.  ";
            string empty = "";
            foreach (char c in warning)
                empty += " ";
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Framework.DelayedPrint(empty);
            Framework.DelayedPrint(warning);
            Framework.DelayedPrint(empty);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
        }

        private void ChoicesInOrder(List<string> choices, bool resume = true)
        {
            foreach (string choice in choices)
                Choice(new List<string> {choice}, false, resume);
        }
        private int Choice(List<string> choices, bool printChoice = false, bool resume = true) => Framework.PlayerChoice(choices, true, 0, printChoice, resume, ConsoleColor.White, false);
        private void PrintSecondDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.Second.{dotPath}");
    }
}