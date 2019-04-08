using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public static class WinClass
  {
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    private static IntPtr ThisConsole = GetConsoleWindow();
    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int HIDE = 0;
    private const int MAXIMIZE = 3;
    private const int MINIMIZE = 6;
    private const int RESTORE = 9;
    public static void run()
    {
      Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
      ShowWindow(ThisConsole, MAXIMIZE);
    }
  }
}