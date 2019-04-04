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
      RoomItems = new List<Item>();
      Exits = new Dictionary<Directions, IRoom>();
    }

    public bool IsLocked = false;
    public string Photo { get; set; }
    public List<Item> RoomItems { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<Directions, IRoom> Exits { get; set; }

    public void NearbyRoom(Directions direction, IRoom dest)
    {
      Exits.Add(direction, dest);
    }

    public void addRoomItem(Item item)
    {
      RoomItems.Add(item);
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
    north,
    south,
    east,
    west
  }

}