using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;

namespace CastleGrimtol.Project.Models
{
  public class Room : IRoom
  {
    public Room(string name, string description)
    {
      Name = name;
      Description = description;
      List<Item> inRoomItems = roomItems;
      Dictionary<Directions, IRoom> currentMoves = Exits;
    }

    public string Photo { get; set; }
    public List<Item> roomItems;
    public string Name { get; set; }

    public string Description { get; set; }

    public List<Item> Items { get; set; }

    public Dictionary<Directions, IRoom> Exits { get; set; }

    public void NearbyRoom(Directions direction, IRoom dest)
    {
      Exits.Add(direction, dest);
    }

    public void addRoomItem(Item item)
    {
      roomItems.Add(item);
    }
    public IRoom TraveltoDest(Directions dir)
    {
      if (Exits.ContainsKey(dir))
      {
        return Exits[dir];
      }
      System.Console.WriteLine("you cannot go in there");
      return (Room)this;
    }
  }
  public enum Directions
  {
    North,
    South,
    East,
    West,
  }

}