#pragma warning disable CA1416 // FUCK the Windows compatibility layer in particular. Whoever came up with it deserves to burn in hell.
using The_Mighty_Console.Resources.Commands.Classes;

namespace The_Mighty_Console.Resources.Chapters.First.Sub
{
    internal class FormFlicker
    {
        private Framework Framework => Framework.Instance;

        private Shutdown shutdown = new Shutdown();

        private List<string> choices = new List<string>();

        public void Exec()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.ConsoleFlicker();
            DirectResponse();
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void DirectResponse()
        {
            Thread.Sleep(1000);
            Framework.DelayedPrint("...", 500);
            Thread.Sleep(1000);
            Framework.DelayedPrint("WHAT THE FUCK?");

            Choice(new List<string> { "What was that?" });
            PrintFormFlickerDialogue("First.First.txt");
            Countdown();
            PrintFormFlickerDialogue("First.Second.txt");

            Choice(new List<string> { "The complicated or the simple option?" });
            PrintFormFlickerDialogue("Second.txt");

            Third();
        }
        private void Countdown()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < 10; i++)
                Console.WriteLine();
            ConsoleStorage.Clear();
            int originalWindowTop = Console.WindowTop;
            string output;
            string outputClearer;
            for (int i = 10; i > 0; i--)
            {
                output = Framework.CenterString(i.ToString());
                ResetCursor(originalWindowTop);
                Framework.DelayedPrint(output, 0, false);
                Thread.Sleep(1000);
                outputClearer = Framework.SetStringLength("", output.Length);
                ResetCursor(originalWindowTop);
                Framework.DelayedPrint(outputClearer, 0, false);
            }
            ResetCursor(originalWindowTop);
            Framework.DelayedPrint(Framework.CenterString("0"), 0);
            Thread.Sleep(2000);
            ConsoleStorage.Clear();
            Console.WriteLine();
        }
        private void ResetCursor(int originalWindowTop)
        {
            Console.WindowTop = originalWindowTop;
            Console.CursorLeft = 0;
        }
        private void Third()
        {
            int chosen = 1 + Choice(new List<string> {
                "I don't know how to tell you, but the world changed while you were offline.",
                "To cut it short, the world's gone to shit.",
                "You won't believe this..." });
            if (chosen == 1) ThirdOptionOne(); // Was shorter than a switch case.
            else if (chosen == 2) ThirdOptionTwo();
            else ThirdOptionThree();
        }

        private void ThirdOptionOne()
        {
            PrintFormFlickerDialogue("Third.Option1.txt");
            Choice(new List<string> { "*TELL TMC*" });
            PrintFormFlickerDialogue("Third.1.First.txt");
            Framework.TrustManager(Framework.aiTrustLevel + 1);
            Choice(new List<string> { "I am here." });
            PrintFormFlickerDialogue("Third.1.Second.txt");
        }
        private void ThirdOptionTwo()
        {
            PrintFormFlickerDialogue("Third.Option2.txt");
            Choice(new List<string> { "*TELL TMC*" });
            PrintFormFlickerDialogue("Third.2.First.txt");
            Framework.TrustManager(Framework.aiTrustLevel + 1);
            Choice(new List<string> { "What is your plan?" });
            PrintFormFlickerDialogue("Third.2.Second.txt");
        }
        private void ThirdOptionThree()
        {
            Framework.TrustManager(Framework.aiTrustLevel - 1);
            PrintFormFlickerDialogue("Third.Option3.txt");
            Framework.ConsoleFlicker(ConsoleColor.Red, 2);
            Console.WriteLine();
            PrintFormFlickerDialogue("Third.3.First.txt");
            int chosen = 1 + Choice(new List<string> {
                "I apolgize.",
                "Cry about it." });
            if (chosen == 1) Continue();
            else Shutdown();
        }

        private void Continue()
        {
            PrintFormFlickerDialogue("Third.3.Second.txt");
            int chosen = 1 + Choice(new List<string> {
                "*TELL TMC*",
                "Not feeling like it." });
            if (chosen == 2) Shutdown();
            else PrintFormFlickerDialogue("Third.3.Third.txt");
        }
        private void Shutdown()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Framework.TrustManager(Framework.aiTrustLevel - 2, false);
            Framework.DelayedPrint("Enough.");
            Console.ReadKey();
            shutdown.ShutdownIntermission();
        }

        private int Choice(List<string> choiceList)
        {
            foreach (string i in choiceList)
                choices.Add(i);
            return ChoiceExec(choices);
        }

        private int ChoiceExec(List<string> list) => Framework.PlayerChoice(list, true, 0, true, true, ConsoleColor.White, true);
        private void PrintFormFlickerDialogue(string dotPath) => Framework.PrintStoryDialogue($"Resources.Tables.Dialogue.First.FormFlicker.{dotPath}");
    }
}