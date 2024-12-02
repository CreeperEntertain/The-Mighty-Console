namespace The_Mighty_Console.Resources.Commands.Classes
{
    internal class Free
    {
        private Framework Framework => Framework.Instance;
        public void Exec(string textInput)
        {
            Framework.commandHistory.Add(textInput);
            textInput = Framework.ReplaceWord(textInput, "free");
            if (!Framework.HelpFlagChecker(textInput))
            {
                int totalMemory = 16777216;
                int usedMemory = Framework.Instance.processes.Sum(process => process.MemoryUsage);
                int availableMemory = totalMemory - usedMemory;
                int longest = totalMemory.ToString().Length;
                if (longest < usedMemory.ToString().Length)
                    longest = usedMemory.ToString().Length;
                if (longest < availableMemory.ToString().Length)
                    longest = availableMemory.ToString().Length;
                Console.ForegroundColor = ConsoleColor.Blue;
                string totalMemoryString = Framework.SetStringLength(totalMemory.ToString(), longest, true);
                string usedMemoryString = Framework.SetStringLength(usedMemory.ToString(), longest, true);
                string availableMemoryString = Framework.SetStringLength(availableMemory.ToString(), longest, true);
                Framework.DelayedPrint($"    Total: {totalMemoryString} K", 0);
                Framework.DelayedPrint($"     Used: {usedMemoryString} K", 0);
                Framework.DelayedPrint($"Available: {availableMemoryString} K", 0);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Framework.InfoPrint("For a more detailed view, enter 'TL detailed'.");
            }
        }
    }
}