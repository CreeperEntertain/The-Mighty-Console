namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class DelayedPrint
    {
        public void Exec(string? input = "", int delayInMilliseconds = 1, bool newLine = true)
        {
            if (input == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Exec("WARNING!", 1, false);
                Console.ForegroundColor = ConsoleColor.White;
                Exec(" You are using this translation software incorrectly. Please consult the user manual or contact service personnel.", 1, false);
            }
            foreach (char c in input ?? "")
            {
                Console.Write(c);
                Thread.Sleep(delayInMilliseconds);
            }
            if (newLine) Console.WriteLine();
        }
    }
}