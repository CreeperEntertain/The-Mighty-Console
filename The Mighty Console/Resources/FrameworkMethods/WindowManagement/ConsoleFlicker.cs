#pragma warning disable CA1416 // Shut up.
namespace The_Mighty_Console.Resources.FrameworkMethods.WindowManagement
{
    internal class ConsoleFlicker
    {
        public void Exec(ConsoleColor flickerColor = ConsoleColor.Red, int repetitions = 10, int delay = 100)
        {
            ConsoleStorage.Instance.StoreConsole();
            ConsoleStorage.Instance.PauseRecording();
            ConsoleColor previous = Console.BackgroundColor;
            int previousBuffer = Console.BufferHeight;
            Console.BufferHeight = Console.WindowHeight;
            for (int i = 0; i < repetitions; i++)
            {
                Console.BackgroundColor = flickerColor;
                ConsoleStorage.Clear(); // Necessary cuz the fuckin background color won't change except behind new text. Infuriating, but it's whatever.
                Thread.Sleep(delay);
                Console.BackgroundColor = previous;
                ConsoleStorage.Clear();
                Thread.Sleep(delay);
            }
            Console.BufferHeight = previousBuffer;
            ConsoleStorage.Instance.ResumeRecording();
            ConsoleStorage.Instance.RestoreConsole();
        }
    }
}