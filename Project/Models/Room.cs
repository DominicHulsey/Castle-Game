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
      IsLocked = false;
      ActiveItem = null;
      Challenge = null;
    }
    public Item Challenge { get; set; }
    public Item ActiveItem { get; set; }
    public bool IsLocked { get; set; }
    public string Photo { get; set; }
    public List<Item> RoomItems { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Dictionary<Directions, IRoom> Exits { get; set; }

    public void NearbyRoom(Directions direction, IRoom dest)
    {
      Exits.Add(direction, dest);
    }

    public void addChallenge(Item item)
    {
      Challenge = item;
    }

    public void remChallenge(Item item)
    {
      ActiveItem = null;
    }

    public void addRoomItem(Item item)
    {
      RoomItems.Add(item);
    }

    public void setActive(Item item)
    {
      ActiveItem = item;
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