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
      Inventory = new List<Item>();
      PlayerName = playername;
      switch (playername)
      {
        case "Tyrion":
          Photo = @"
hey i'm Tyrion
";
          break;
        case "Jon Snow":
          Photo = @"
hey i'm Jon Snow
";
          break;
        case "Daenerys":
          Photo = @"
hey i'm Daenerys
";
          break;
      }
    }
    public void addItem(Item item)
    {
      Inventory.Add(item);
    }
    public void removeItem(Item item)
    {
      Inventory.Remove(item);
    }
  }
}