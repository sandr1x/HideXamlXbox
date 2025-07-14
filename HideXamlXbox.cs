using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("user32.dll")]
    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll")]
    static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    static void Main()
    {
        Thread.Sleep(500);
        IntPtr hwnd = FindWindow("Windows.UI.Core.CoreWindow", "DesktopWindowXamlSource");
        if (hwnd != IntPtr.Zero)
        {
            ShowWindow(hwnd, 0); // 0 = SW_HIDE
        }
    }
}
