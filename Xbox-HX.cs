using System;
using System.Diagnostics;
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
        try
        {
            Process.Start(new ProcessStartInfo("explorer.exe", @"shell:AppsFolder\Microsoft.GamingApp_8wekyb3d8bbwe!Microsoft.Xbox.App")
            {
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка запуска Xbox: " + ex.Message);
            return;
        }

        Thread.Sleep(2000);

        IntPtr hwnd = FindWindow("Windows.UI.Core.CoreWindow", "DesktopWindowXamlSource");
        if (hwnd != IntPtr.Zero)
        {
            ShowWindow(hwnd, 0); // SW_HIDE
        }
    }
}
