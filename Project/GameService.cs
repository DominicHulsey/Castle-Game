using System;
using System.Collections.Generic;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;

namespace CastleGrimtol.Project
{
  public class GameService
  // : IGameService
  {
    Player CurrentPlayer { get; set; }

    //Initializes the game, creates rooms, their exits, and add items to rooms

    public void Begin()
    {
      Console.Clear();
      System.Console.WriteLine(@"
                                       ....                                                                                                                
                           .;::;;:::cllodoll:.                                                                                                        
                        ':lc;..        .,ckXO'                                                                                                        
                      .lo;.                :o'                                                        .. ..                                           
                     ,xd'                  ...         .o:             .l,              .c,      .;dd:,,,;l;                                          
                    ,kO,                              .:OO,            'OO,             c0o       .xk'    ..                   .......                
                   .o0d.                              ,::Ok.           ;kKkl'          ;dOd.      .xk'              ..',',;;.  ,dc..,.                
                   ,kKo                              .c. :0d.          cl:0Nk'        ;:,dk'      .dO'            .;,......;dc.'d;                    
                   ;kXo                .';;;;'..    .:,  .o0c         .o: :k0k'      ,:..o0;      .d0c,;,::.      cc  ..... ,k;'xc....                
                   ,xKk.                .lOK0:.     :d:'''cO0;        'd,  .c0k'    ,:.  c0c      .dO;...',.     .ol  ..... 'd;.dc....                
                   .d0Xl                 'dKO'     ,o;.'...cOO'       ;d'   .cKk.  ,c.   ;0o.     .xO'            ;x; ..... :c..d;                    
                    :OK0:                .dKk.    .l:       cKd.      co.    .cKx.':.    'kx.     .dk'             ,l:;,,,'''. 'x:                    
                    .cOX0l.              'dKk.   .cc.       .dKo.     lo.     .c0kc.     .xO,     .xk'     ..        ......    .;'                    
                      ;xKXOc.            'dKk.  .cx:         'xOl..  'do.      .co.      .lOo.    ,dOo;,,;;;.                                         
                       .;oOK0dc,..      .;xKx.  ....          .....  ....                 .....   ..........                                          
                          .':coddollccccccc;.                                                                                                         
      .;;,,'''''''''''','',''',;;:ccc::;;,''',,',,,'',,,,,,'',,,',''',,''''''''''''''''',,,,',''''''''''''''''''''''''''''''''','','''''',,',,;.      
     .coccc::::lx0xccc:ccccccccccccccccccccc:cccccccccccccccccccccc:ccc:::::::::::::::cc:cc::cc:::::::::::::::::::::::::::::::::::::::::::::clxo.     
     ..        .l0o.                                                                                                                          .,.     
               .l0o     ..''.         .','.    .',,'''''.              ...''''...         ..            .....    .'''..''''.       .'',,,. .          
               .l0o     .;Ok,         .cKx.    .;0O,..,cxx;         .,;;c:,cc,:lclc'      ck:.          .;xl.    .cOd'.'':c.     ,c,...'cc.           
               .oKo      .xx.          ,Od.     .kx.    'kK:      .:o,. ''.,,.''.'d0o.    cOKk;.         .d;      ;Ol           .d:      .            
               .oKo      .xx.          ,Od.     .kx.     :Kl     .lx,   ''.,,.''  .oKk.  .cc,x0x,        .o;      ,Ol           'Ox'                  
               .oKo      .dk;..........:0d.     .kx.     cd'     ;Oo.   ''.,,.''   'xKl   cc .;kKd,      .o;      ,Oo.    .      c00o,.               
               .oKo.     .dk:,,,,,,,,,,c0d.     .kk,.  .;:.     .lKl    ''.,,.''   .lKo   cc.  .:O0o.    .o;      ,Ox,',;l:       .ckOx:.             
               .oKo.     .dd.          ,Od.     .kO:'':xk,      .cKx.   ''.,,.''   .l0c   cl.    .l00l.  .o;      ,Ol    ..         .;d0O,            
               .oKo.     .xx.          'Od.     .kx.   ,k0c.     ;0K:   ''.,,.''   'xd.   ll.      .l0Oc..l;      ;Oo.                .c0O'           
               .oKo.     .xx.          ,Od.     .kx.    .o0x,     cK0:  ''.,,.''  .oo.    lo.        'o0kco;      ;0o           .      .lk,           
               .o0o.     .xk'          ,Ox.     'kx.      ;k0l.    ,dko,:,.,,.';.,c;.     ld.          'oOO;      :0x.    ...  .:'     'o:            
               .o0d.    .'ll,.        .,ll,.   .,ll,.      .:do;..   .;:cc:c:;;;,.       .co,.           'c'     .:ol:,,,;:,   .:l;,,,,;'             
               ,dKO,                                          ....                                                                 ..                 
             ..;::c;..      
      
                            _______  _______  _______  _______  _______  _        ______     _       _________ _        _______ 
                            (  ____ \(  ___  )(       )(       )(  ___  )( (    /|(  __  \   ( \      \__   __/( (    /|(  ____ \
                            | (    \/| (   ) || () () || () () || (   ) ||  \  ( || (  \  )  | (         ) (   |  \  ( || (    \/
                            | |      | |   | || || || || || || || (___) ||   \ | || |   ) |  | |         | |   |   \ | || (__    
                            | |      | |   | || |(_)| || |(_)| ||  ___  || (\ \) || |   | |  | |         | |   | (\ \) ||  __)   
                            | |      | |   | || |   | || |   | || (   ) || | \   || |   ) |  | |         | |   | | \   || (      
                            | (____/\| (___) || )   ( || )   ( || )   ( || )  \  || (__/  )  | (____/\___) (___| )  \  || (____/\
                            (_______/(_______)|/     \||/     \||/     \||/    )_)(______/   (_______/\_______/|/    )_)(_______/
      
      ");
      Console.WriteLine("Press Any Key to Continue");
      Console.ReadKey();
      Console.Clear();
      ChoosePlayer();
    }

    public void ChoosePlayer()
    {
      System.Console.WriteLine("Please Choose Character/n1 = Tyrion, 2 = Jon Snow, 3 = Daenerys");
      string input = Console.ReadLine();
      if (!Int32.TryParse(input, out int choice) || choice > 3 || choice < 1)
      {
        Console.WriteLine("Please Enter a number from 1 to 3");
      }
      else
      {
        switch (choice)
        {
          case 1:
            Console.Clear();
            System.Console.WriteLine("You chose Tyrion");
            initialize("Tyrion");
            break;
          case 2:
            Console.Clear();
            System.Console.WriteLine("You chose Jon Snow");
            initialize("Jon Snow");
            break;
          case 3:
            Console.Clear();
            System.Console.WriteLine("You chose Daenerys");
            initialize("Jon Snow");
            break;
        }
      }
    }
    public void initialize(string playerChoice)
    {
      Room room1 = new Room("Room1", "Start");
      Room room2 = new Room("Room2", "Second Room");
      Room room3 = new Room("Room3", "Item in here maybe");
      Room room4 = new Room("Room4", "God only knows what is going on in this room");
      Room room5 = new Room("Room5", "Almost There");
      Room room6 = new Room("Room6", "Boom you win congrats");

      Item spork = new Item("Spork", "Pretty self-explanatory");

      room2.addRoomItem(spork);

      Player character = new Player(playerChoice);

      room1.NearbyRoom(Directions.North, room2);
      room2.NearbyRoom(Directions.East, room3);
      room3.NearbyRoom(Directions.East, room4);
      room4.NearbyRoom(Directions.South, room5);
      room5.NearbyRoom(Directions.South, room6);

      CurrentRoom = room1;
      StartGame();
    }
    public bool playing = true;
    //Setup and Starts the Game loop
    public void StartGame()
    {
      while (playing)
      {
        DrawRoom(CurrentRoom);
        GetUserInput();
        // go();
      }
      Console.Read();
      GetUserInput();
    }

    public void DrawRoom(Room room)
    {
      System.Console.WriteLine($"You are in {room.Name}");
    }

    public Room CurrentRoom { get; set; }



    //Gets the user input and calls the appropriate command
    public void GetUserInput()
    {

    }

    // void Reset();

    #region Console Commands

    //Stops the application
    // void Quit();

    //Should display a list of commands to the console
    // void Help();

    //Validate CurrentRoom.Exits contains the desired direction
    //if it does change the CurrentRoom
    void Go(Directions direction)
    {
      if (CurrentRoom.Exits.ContainsKey(direction))
      {
        this.CurrentRoom = (Room)CurrentRoom.Exits[direction];
      }
      System.Console.WriteLine("Dude there's no door there");
    }

    //When taking an item be sure the item is in the current room 
    //before adding it to the player inventory, Also don't forget to 
    //remove the item from the room it was picked up in
    void TakeItem(string itemName)
    {

    }

    //No need to Pass a room since Items can only be used in the CurrentRoom
    //Make sure you validate the item is in the room or player inventory before
    //being able to use the item
    void UseItem(string itemName)
    {

    }

    //Print the list of items in the players inventory to the console
    void Inventory()
    {

    }

    //Display the CurrentRoom Description, Exits, and Items
    void Look(Room room)
    {
      System.Console.WriteLine($"{room.Description}, there is a {room.roomItems} in here");
    }

    #endregion
  }
}