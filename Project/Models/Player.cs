using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Player : IPlayer
  {

    public string Photo { get; private set; }
    public string PlayerName { get; set; }
    public List<Item> Inventory { get; set; }

    public Player(string playername)
    {
      PlayerName = playername;
      switch (playername)
      {

      }
    }

  }
  enum Players
  {
    Tyrion,
    JonSnow,
    Daenerys
  }
}