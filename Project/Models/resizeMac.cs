using System;
using System.Runtime.InteropServices;

using CastleGrimtol.Project;

namespace CastleGrimtol
{
  public static class MacClass
  {
    [DllImport("libc")]
    private static extern int system(string exec);


    public static void run()
    {
      system(@"printf '\e[8;100;800t'");
    }
  }
}
