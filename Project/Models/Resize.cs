using System;

namespace CastleGrimtol
{
  public static class Resize
  {
    public static string Fullscreen()
    {
      System.Console.WriteLine("Please enter 'W' if you are playing on Windows,'M' for mac.");
      string opSystem = System.Console.ReadLine();
      if (opSystem.ToLower() == "w")
      {
        WinClass.run();
        return "w";
      }
      else if (opSystem.ToLower() == "m")
      {
        MacClass.run();
        return "m";
      }
      else
      {
        System.Console.WriteLine("input not recognized, press any key to try again.");
        System.Console.ReadKey();
        Console.Clear();
        Fullscreen();
        return "";
      }
    }
  }
}