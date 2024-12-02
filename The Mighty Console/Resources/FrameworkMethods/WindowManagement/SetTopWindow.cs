using System.Runtime.InteropServices;

namespace The_Mighty_Console.Resources.FrameworkMethods.WindowManagement
{
    internal class SetTopWindow
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;

        private bool isAlwaysOnTop = false;

        public bool Exec()
        {
            IntPtr consoleWindowHandle = GetConsoleWindow();

            if (isAlwaysOnTop)
                SetWindowPos(consoleWindowHandle, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            else SetWindowPos(consoleWindowHandle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);

            isAlwaysOnTop = !isAlwaysOnTop;
            return isAlwaysOnTop;
        }
    }
}