using System.Runtime.InteropServices;

namespace The_Mighty_Console.Resources.FrameworkMethods.WindowManagement
{
    internal class FullscreenWindow
    {
        public void Exec()
        {
            [DllImport("user32.dll")]
            static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

            [DllImport("user32.dll")]
            static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);

            [DllImport("user32.dll")]
            static extern bool MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool bRepaint);

            const int SW_MAXIMIZE = 3;
            IntPtr consoleWindowHandle = GetForegroundWindow();
            ShowWindow(consoleWindowHandle, SW_MAXIMIZE);
            Rect screenRect;
            GetWindowRect(consoleWindowHandle, out screenRect);
            int width = screenRect.Right - screenRect.Left;
            int height = screenRect.Bottom - screenRect.Top;
            MoveWindow(consoleWindowHandle, screenRect.Left, screenRect.Top, width, height, true);
        }
    }
}