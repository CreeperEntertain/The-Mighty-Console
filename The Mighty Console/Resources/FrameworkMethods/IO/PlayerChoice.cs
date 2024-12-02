#pragma warning disable CA1416
namespace The_Mighty_Console.Resources.FrameworkMethods.IO
{
    internal class PlayerChoice
    {
        private Framework Framework => Framework.Instance;
        public int Exec(List<string> playerChoices, bool clearChoiceList = true, int delay = 1, bool printOutput = true, bool resumeRecording = true, ConsoleColor selectionColor = ConsoleColor.Blue, bool addInputDecoration = false)
        {
            ConsoleStorage.Instance.PauseRecording();
            int selectedIndex = 0;
            ConsoleKey key;
            Console.CursorVisible = false;
            int initialWindowTop = Console.WindowTop;
            int optionsStartLine = Console.CursorTop;
            int lastWindowWidth = Console.WindowWidth;
            int lastWindowHeight = Console.WindowHeight;
            int lastLinesUsed = DisplayChoices(playerChoices, selectedIndex, optionsStartLine, selectionColor);
            do
            {
                if (Console.WindowWidth != lastWindowWidth || Console.WindowHeight != lastWindowHeight)
                {
                    lastWindowWidth = Console.WindowWidth;
                    lastWindowHeight = Console.WindowHeight;
                    lastLinesUsed = RedrawChoices(playerChoices, selectedIndex, optionsStartLine, lastLinesUsed, selectionColor);
                }
                int currentWindowTop = Console.WindowTop;
                if (currentWindowTop != initialWindowTop)
                    initialWindowTop = currentWindowTop;
                key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + playerChoices.Count) % playerChoices.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % playerChoices.Count;
                        break;
                }
                lastLinesUsed = RedrawChoices(playerChoices, selectedIndex, optionsStartLine, lastLinesUsed, selectionColor);
                Console.WindowTop = initialWindowTop;
            } while (key != ConsoleKey.Enter);
            ClearOptionsDisplay(optionsStartLine, lastLinesUsed);
            Console.ForegroundColor = selectionColor;
            if (resumeRecording)
                ConsoleStorage.Instance.ResumeRecording();
            if (addInputDecoration)
                Console.Write(Framework.InputDecoration());
            if (printOutput)
                Framework.DelayedPrint(playerChoices[selectedIndex], delay); // Show the bastard.
            Console.ResetColor();
            Console.CursorVisible = true;
            if (clearChoiceList) playerChoices.Clear();
            return selectedIndex;
        }

        private void ClearOptionsDisplay(int startLine, int linesUsed)
        {
            for (int i = 0; i < linesUsed; i++)
            {
                Console.SetCursorPosition(0, startLine + i);
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            Console.SetCursorPosition(0, startLine);
        }
        private int DisplayChoices(List<string> choices, int selectedIndex, int startLine, ConsoleColor selectionColor)
        {
            int currentLine = startLine;
            int totalLinesUsed = 0;
            for (int i = 0; i < choices.Count; i++)
            {
                int linesForOption = (i + 1 + ". " + choices[i]).Length / Console.WindowWidth + 1;
                DisplayOption(choices[i], i == selectedIndex, currentLine, i, selectionColor);
                currentLine += linesForOption;
                totalLinesUsed += linesForOption;
            }
            return totalLinesUsed;
        }
        private int RedrawChoices(List<string> choices, int selectedIndex, int startLine, int linesUsed, ConsoleColor selectionColor)
        {
            ClearOptionsDisplay(startLine, linesUsed);
            return DisplayChoices(choices, selectedIndex, startLine, selectionColor);
        }
        private void DisplayOption(string optionText, bool isSelected, int lineIndex, int optionIndex, ConsoleColor selectionColor)
        {
            string numberedOption = $"{optionIndex + 1}. {optionText}";
            int lines = numberedOption.Length / Console.WindowWidth + 1;

            if (isSelected)
            {
                Console.BackgroundColor = selectionColor;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = selectionColor;
            }
            for (int i = 0; i < lines; i++)
            {
                int targetLine = lineIndex + i;
                if (targetLine >= Console.WindowTop + Console.WindowHeight)
                    Console.WindowTop += 1;
                string line = numberedOption.Substring(i * Console.WindowWidth, Math.Min(Console.WindowWidth, numberedOption.Length - i * Console.WindowWidth));
                Console.SetCursorPosition(0, targetLine);
                Console.WriteLine(line.PadRight(Console.WindowWidth));
            }
            Console.ResetColor();
        }
    }
}