using System.Text;
using The_Mighty_Console.Resources;

internal class ConsoleStorage
{
    private static Framework Framework => Framework.Instance;

    public static ConsoleStorage Instance { get; } = new ConsoleStorage();

    private List<(char character, ConsoleColor? foregroundColor, bool isInput)> consoleBuffer = new();
    private List<(char character, ConsoleColor? foregroundColor, bool isInput)> restoreBuffer = new();
    private StringWriter consoleCapture = new StringWriter();
    private TextWriter originalConsoleOut;
    private TextReader originalConsoleIn;
    private bool isPaused = true;
    private bool addOffset = false;

    public string TextInput { get; set; } = string.Empty;

    private ConsoleStorage()
    {
        originalConsoleOut = Console.Out;
        originalConsoleIn = Console.In;

        Console.SetOut(new MultiTextWriter(originalConsoleOut, consoleCapture));
        Console.SetIn(new MultiTextReader(originalConsoleIn));
    }

    public static void Clear()
    {
        Console.Clear();
        if (!ConsoleStorage.Instance.isPaused)
            ConsoleStorage.Instance.ClearStorage();
    }

    public void StoreConsole()
    {
        string[] lines = consoleCapture.ToString().Split(Environment.NewLine, StringSplitOptions.None);
        foreach (string line in lines)
            if (!string.IsNullOrEmpty(line))
                consoleBuffer.Add((' ', Console.ForegroundColor, false));
    }

    public void TrimBufferSpaces(List<(char character, ConsoleColor? foregroundColor, bool isInput)> buffer)
    {
        while (buffer.Count > 0 && buffer[buffer.Count - 1].character == ' ')
            buffer.RemoveAt(buffer.Count - 1);
    }

    public void RestoreConsole()
    {
        ConsoleColor previousText = Console.ForegroundColor;
        restoreBuffer.Clear();
        TrimBufferSpaces(consoleBuffer);

        foreach (var item in consoleBuffer)
            restoreBuffer.Add(item);

        int currentLine = Console.CursorTop;

        foreach (var (character, foreground, isInput) in restoreBuffer)
        {
            if (foreground.HasValue)
                Console.ForegroundColor = foreground.Value;
            if (character == '\n')
                Console.SetCursorPosition(0, currentLine++);
            else Console.Write(character);
        }
        Console.ResetColor();
        restoreBuffer.Clear();
        Console.ForegroundColor = previousText;
    }

    public void ClearStorage()
    {
        consoleBuffer.Clear();
        consoleCapture.GetStringBuilder().Clear();
    }

    public void PauseRecording() => isPaused = true;

    public void ResumeRecording() => isPaused = false;

    private class MultiTextWriter : TextWriter
    {
        private readonly TextWriter consoleWriter;
        private readonly StringWriter captureWriter;

        public MultiTextWriter(TextWriter consoleWriter, StringWriter captureWriter)
        {
            this.consoleWriter = consoleWriter;
            this.captureWriter = captureWriter;
        }

        public override Encoding Encoding => Console.OutputEncoding;

        public override void Write(char value)
        {
            ConsoleStorage.Instance.addOffset = true;
            consoleWriter.Write(value);
            if (!ConsoleStorage.Instance.isPaused)
            {
                ConsoleStorage.Instance.consoleBuffer.Add((value, Console.ForegroundColor, false));
                captureWriter.Write(value);
            }
        }

        public override void WriteLine(string? value)
        {
            value = value ?? "";
            ConsoleStorage.Instance.addOffset = false;
            consoleWriter.WriteLine(value);
            if (!ConsoleStorage.Instance.isPaused)
            {
                foreach (var character in value)
                    ConsoleStorage.Instance.consoleBuffer.Add((character, Console.ForegroundColor, false));
                captureWriter.WriteLine(value);
            }
        }
    }

    private class MultiTextReader : TextReader
    {
        private readonly TextReader originalReader;

        public MultiTextReader(TextReader originalReader) => this.originalReader = originalReader;

        public override string ReadLine()
        {
            int cursorSnapshot = Console.CursorLeft;
            string input = originalReader.ReadLine() ?? "";
            if (!ConsoleStorage.Instance.isPaused)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
                int currentLineLength = Console.CursorLeft;
                Console.Write(new string(' ', currentLineLength));  // Clear the bastard.
                Console.SetCursorPosition(0, Console.CursorTop);
                ConsoleStorage.Instance.TextInput = input;

                if (ConsoleStorage.Instance.addOffset)
                    ConsoleStorage.Instance.addOffset = false;
                Console.SetCursorPosition(cursorSnapshot, Console.CursorTop - 1);
                Console.Write(input);
                Console.WriteLine();
            }
            return input;
        }
    }
}