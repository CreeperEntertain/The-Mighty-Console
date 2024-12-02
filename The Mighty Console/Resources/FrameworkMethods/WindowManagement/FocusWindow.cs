using System.Runtime.InteropServices;

namespace The_Mighty_Console.Resources.FrameworkMethods.WindowManagement
{
    internal class FocusWindow
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        public void Exec()
        {
            IntPtr consoleWindowHandle = GetConsoleWindow();
            if (consoleWindowHandle != GetForegroundWindow())
                SetForegroundWindow(consoleWindowHandle);
        }
    }
}