using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Item : IItem
  {
    public Item(string name, string description, string used)
    {
      Name = name;
      Description = description;
      Used = used;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Used { get; set; }
  }
}