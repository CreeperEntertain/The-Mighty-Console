using System.Runtime.InteropServices;

namespace The_Mighty_Console.Resources.FrameworkMethods.WindowManagement
{
    internal class RestoreWindow
    {
        public void Exec()
        {
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();
            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
            const int SW_RESTORE = 9;
            IntPtr consoleWindowHandle = GetForegroundWindow();
            ShowWindow(consoleWindowHandle, SW_RESTORE);
        }
    }
}