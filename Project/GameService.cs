using System;
using System.Collections.Generic;
using System.Threading;
using CastleGrimtol.Project.Interfaces;
using CastleGrimtol.Project.Models;
using System.Timers;

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
      OS = Resize.Fullscreen();
      System.Console.WriteLine("Press any key to continue!");
      Console.ReadKey();
      Console.Clear();
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
      System.Console.WriteLine(@"

              ..    .....'',,,,;;;,''...                                 .......'lddoc;,',,;::cc:;;;:cocclc::;''..                                  .':dkOkkxxddddoolllc;,,,;;::;,'.. 
            .:::;;:ccc:::;;,,,,,'......,;,......                       .:xOxl::;:c:;;,,''',,,'',;cll;;coccc,,;;:c:,'..                           .;okKKK0kkxxddddooolcc;,,;::::c::cc:;'. 
            .,ldoc::;,,,''''''..........',,,,,,'''..                   .;;;,,;;,'........''.....''....''','.,,...,,';:,''.                     .ckKK00Oxxddddddddoolllc:;;:cccclcc:::::;,..  
            .;ooc:;,,,'''............. ...........''.              ....,:;,,;:;,'..........''.. ....  ...'..........,;;'',,.                  .:kK0OkOkkxdooooooooollccc:::::cccclllc:;;,,,'.
          .;xOxl::;;;;'.................. ......... ...            ',;c:;'.............    ....   ..   ..............'..'.',..              .l00Okkxxdolllllllllcccccc::::::cccccllllc:;,,,''.   
       .,lxO0Odlc:;;,'.....''..........  ...........   ..         .;:::,...........                        ...     .......'',,.            'd0Okkxdoollccccllllllccc::::::::::cccccclcc:;,,,'''. 
      'lkOOOkdolc:,'..''..''''''....          ......    ..       .'''..''..........                   ...            .....''..':;.        .cO0Okxdoolllllloooooooollcc::::::::::ccc:;:::::;,,,'''.   
     .;dkxkkdlclc;'...'...'''',''........        ...     ...     :::,...',,'.......     ..       .......'''....            .  ....;:'    'kXKOxdollllloodddddddddoollcc::::::::::::::;;;;::;,,,,''. 
   .cxxdooddl;;cc;'.','''.'''',,'............ ...        ..''    ;::...,,''..'''.........   .........',;;:c;,,'....              ..;l    .xXKkdollloodddxxxxxxdddddoollcc:;;;;;:ccc::::;,,;;:;,,,,',. 
   .xOxddddl;,;:;''',;,''',,,',''''',,,,,,'......          .,.   '....'......  ......    .:odolc:;;;cldxxxxdoc;,'...           ...;l;   .o00kdlclodxxxkkxxxxxxxxddddoollcc:;;;;;;::c::;;;,,;;;;,,,,',.   
  .okxddxkd:;::;''',::,'',,''',,,;;;::::;;,'.....           ..'. ......'''........    ..;oOKXXKK0OkxkO00KKK0Okdl:,'..          ...':c.  .l00kdlccoxxkkkkkkkkkxxxxxdddoolllc::;,,,,,;::::;;;;;;;;;,,,,'  
  'dkxxxkxc;::;,,,;::;,''''',;;::cccccc::;,'...  .      .... .,' ...'''''''...      ..,lx0KXXXXXXXKKKKKKKKKKK0kdlc;,..         ....':;  c00kxoccoxxkkkkOkkkkkkkkxxxdddoollcc:;;,,''',;::::::;;;;;,,,,,
  'kOkkxdl;;:;;::;;;;;,'',,;:clcclllcc:::;,''...... ..........'. .........         .':ldkO0KKXXXXXXKKKKKKKK000Okxdlc:,..          ...' ,k0Oxxo:cdxxkkkkkkkkkkkkkkxxxddollcc:;;,,,''''',;::::::;;:;;,,, 
  ;O0kdol::cc::c::::;,,,;:cllollloollcc::;,''... .............'' ...',....         .,coxkO0KXXXXXXXXXXXXXXXKKK0Okxdolc;'.           .  .d0Okkxl;cdxxkkkkkkkkkkkkxxdolc:;,,,'''''''...''',;:::cc:;::;,,   
  :O0Oxocclllllccc::::cloollodlcodooccc:;,......  ...     .....' ..''...        ..,:oxkO0KKKXXXXXXXXXXXXXXXKK0Okkxdoc;,..        ..    cO0Okxdc;cdddooooddxxxxxxdol:;,,',,,;;:::;,'...'''';:cclc::::;, 
 .cxxkxoccloollollccccloooooooccooolc:;;,'......        ........ ......       .';coxkO0KKXXXXXXXXXXKXXXXXXKK0OOkxdol:,..        .....  k00Okxdc;:cc:::::clddxdddolc;;,,;::::::::;;,'..'''',;:clllc::;,
 .lxxxkxlcclodxdoc;,''',,;:::cc:ll:;,'''.........      ........, ..... ......  .,coxk0KKXXXXXXXXKKK0KKKXXXXXKK0OOkxdl:,..        ....  K00Okxd:,:oollccccloodxddl:,',,,;;;,,''''''''.'''',,,;cclllc::,
.:dxkkxdoccokOkdlcc,',,'';ccllc;:;................     .......': ....   ...',...,lddxkO00KKKKKKK00OOOO0KKKKK00OOOkxdol:,..       . ..  kkkkxxxdoccoxkxxxxxxxdxdoc;'''';cooooooollc:;,,''''''..;odddddx
.odddoddoccx0KOkkxdlc:;;cokOkdl:;'...',...........     .......', ...     .......';,,,,,,;;:::lodxkkkkkkOOkxollcc:;;,,::,..             K00Okxdc;loolcccc:ccloxxdc,'',;,''''.........'',,,,,',:lloolc:;
;kxocll:;;lOXXK00Okdlc:lxOOOdc;,,'..';:,'''.......  ..........'. ...    .....  .,;;;,'........';coddddddo:,.........',,'..             000Okxdc;:cc:;,,,,;;coxxdc,',;;;::;,',,,''',;;;;;,,,,,;loooolc:
;xddolc;;:xXWNK0OOkdooxO0Oxdo:;''''.',,,''........   ..........  ........    .,:c:;... ...'...,;looooc:,...... .....,,'..      ..      000Okxdl,,;,'.''';:::oddoc;,,:cllllcc:::::cccc:;;,,,,',cdoddolc
,xxoolc;';kNWN0OkkxdxkO00Odooc;'....'',,,''.......    .. .....   ''.. ...   .':oxxdc;;'.,cl;,;:cdkkOkl,........,;'...','.  ..  ...     O00Okxxo;',',;;,;:clodddoc;,;;clodddooooooollc:;,,',,',:oddxdoo
.d0kdoc;,c0WWX0xddxkkOOOOkdolc,'.....''''''''''...        ...    ''.   .......:xO0Okxoolllcclodk0KXXKx:..';::;;;;,'.',,'.  ..  ....    O0Okkxxdc,;:ccccllodddddoc;,,;:cllooooooooolc:;,''''''';ldddddd
.:xOkl;,lKWN0koodOOOkkdcclc:,..''.....''''''''..          ..     ...     ...'cdO00000OOkxxxO00KKXXXKOl;,;:lllcc:;;:cc:,.  ..     ..... OOOkkxxdl::odxxxxxxxxdddoc;'',;cloooooooollc:;,''''''.';odddddd
  .odlc;lXN0kdx0K0OOkkdoool:'..''......'''''''..    ....  ..              ..;ldxk000000000KKKKKXXXNX0d:::cloooooooool:'.   ...    .... kkkkxxxdoccoxkxxxxxxxdxdoc;'''';cooooooollc:;,,''''''..;odddddx
   .;cl:cOXOkOKNXXKOkkxdoc:::,'.........'''''...   .......'.     ..        .;lodkO00KKKKKKKK0KKKXXNX0xc;;coddddddool:,..      ........ kkkkxxddolldxxxxxxxxdoll:,...'',:oooooollc::;,'''''''..,lodddxx
    .c:,;kNXKXNWNKOxxdoolc:cc;''......'''''''...  .....'',,.               .,cldxkO0KKKKKKK00KKXXXNXKkl:;cdxxxxxdol:;'..          .... kkkkxxddolcodxxxxxxxdlclc:;;,;:clloooollcc:;,,''''''''.':odddxx
    :d:''oNWNNWNKkdooolc::;;,'''......''..'''..    ....','.                .';codxkO0KKKKK00000KXXNXKkol::oxxxxdol:;,..          ..... Okkkxxdoolccoxxxxxxxxddddddollllllclllcc::;;,,'''''''...;lodddx
   .oko:,c0NNNN0kxxxxxdoc:;;,'.............'..   .....'.                   ..,codxkO0KKKKK0Oxc:codkxo;'',:oxxdddol:,'..          ...'. OOkkxxdool::ldxxxxxxxxddoollc::::::::cc:;;;,,''''''''...,:ldxxx
    .clllccxKNXkxxxxdoc;,,,,,'...........''......''.''.                    ..,:ldxkO0KXXXKKKOl;:ccl:....,ldxxxddoc;,..           ..... OOkxxdoool:,;ldxxxxxdolc:;,,,''''..'';::;;;,,''''''''...,:ldxxd
      .;l;.'dXKkdddxdolc;,,',,'.............  ,cc:;..            ..         .';coxkO0KXXXKKOxlc:;;:;. ..:oxxxxdol:;'..           ...'' OOkxxdolooc;,;odxxxdl:;;;;;;;;,,''''';c::;,,,'''''''....';ldxxd
      ,ll:''dXKkddxxxddlc:;;,,'...........    .;;..              ..         ..';cdkO0KK0Oxoc::ccccll;'..';ldddolc;,..           ....'' OOkxxdollol:,':odxdoc:clllcc:;;;,,,;;::;;,,,'''''''......'codxd
   .';cc:;''l0K0kdoooolc:;;,,'...........      .                 .           ..';ldkOOxl::;,,;;:ccll:,,'',,;:ccc;,..           .....': kkxxxdollllc;.':oddddddolc:::::::::::;;,,,,'''''''........;codd
.';;;;::,'''':dO0Okdol:;,,''............                                       ..,codolccc:;;::;;;;,,,,,'';;,;;;,..           ......., xxddxdoccool:'.'coddddddoooooooollcc:;;,,'''''............,cooo
cl;,,,;,''....';lkOOkxdl;,''.........                            ..             ..';looddddddddddddollc:;::c:;,'...           ........ xxddddocclolc,..':oodddddxxxxxddolcc:;,,''''..............,cllc
c;..''''.........'lxkxdoc;,,'''....                              ...              ..'coxkxxdddoc::;:::::cc:::;'...             ....... xxxddoolclolc;'...;coddddxxddddolc::,,'''.................':ccc
;'............... .,:clc;,'''....                                ',.                .':okOkkkxdolllcccccccc:;'...                 .... ddddooolclllc;,.....,:clooooollc:;,,''''..................,:ccc
................ ....''.......                          ..     , :,......  ...      ..,cdxkOOOxdddddddoll:,..                     ..'  oooooooolllll:,'.......',;:::;;,,''''''.........'''.......,:ccl
                                                                .'::'............       .';:llc::::::c::;'..                           ollllloolllllc;'..........'',,,,'''''''''...''''''''......,cclo
                                                                .':c,....'''......        ................                             oolooooollolcc;'..........',,;::::::;;;;,,''''''''''''....':lod

_________        _______________________ _                    ________________ _          _______ _       _______                        ______  _______ _______ _       _______ _______         _______ 
\__   __/\     /(  ____ )__   __(  ___  | (    /|             \__    _(  ___  | (    /|  (  ____ ( (    /(  ___  )\     /|              (  __  \(  ___  |  ____ ( (    /(  ____ (  ____ )\     /(  ____ \
   ) (  ( \   / ) (    )|  ) (  | (   ) |  \  ( |                )  ( | (   ) |  \  ( |  | (    \/  \  ( | (   ) | )   ( |              | (  \  ) (   ) | (    \/  \  ( | (    \/ (    )( \   / ) (    \/
   | |   \ (_) /| (____)|  | |  | |   | |   \ | |                |  | | |   | |   \ | |  | (_____|   \ | | |   | | | _ | |              | |   ) | (___) | (__   |   \ | | (__   | (____)|\ (_) /| (_____ 
   | |    \   / |     __)  | |  | |   | | (\ \) |                |  | | |   | | (\ \) |  (_____  ) (\ \) | |   | | |( )| |              | |   | |  ___  |  __)  | (\ \) |  __)  |     __) \   / (_____  )
   | |     ) (  | (\ (     | |  | |   | | | \   |                |  | | |   | | | \   |        ) | | \   | |   | | || || |              | |   ) | (   ) | (     | | \   | (     | (\ (     ) (        ) |
   | |     | |  | ) \ \____) (__| (___) | )  \  |             |\_)  ) | (___) | )  \  |  /\____) | )  \  | (___) | () () |              | (__/  ) )   ( | (____/\ )  \  | (____/\ ) \ \__  | |  /\____) |
   )_(     \_/  |/   \__|_______(_______)/    )_)             (____/  (_______)/    )_)  \_______)/    )_|_______|_______)              (______/|/     \(_______//    )_|_______//   \__/  \_/  \_______)
                                                                                                                                                                                  
");
      System.Console.WriteLine("Please squint at screen and choose a character\n1 = Tyrion, 2 = Jon Snow, 3 = Daenerys");
      string input = Console.ReadLine();
      if (input == "Hodor")
      {
        Hodor();
      }
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
            initialize("Tyrion");
            break;
          case 2:
            Console.Clear();
            initialize("Jon Snow");
            break;
          case 3:
            Console.Clear();
            initialize("Daenerys");
            break;
        }
      }
    }
    public string OS { get; set; }
    public void initialize(string playerChoice)
    {
      win = false;
      playing = true;
      Room room1 = new Room("Start", "Random room at King's landing");
      Room room2 = new Room("Hallway", "Long, dimly-lit hallway");
      Room room3 = new Room("Small council room", "conference table in the middle, the rest of the room is empty.");
      Room room4 = new Room("Library", "huge library, lots of books in here");
      Room room5 = new Room("Wardrobe room", "Huge walk-in closet with lots of clothes and jewelry");
      Room room6 = new Room("Throne Room", "Huge room with the iron throne in the middle of it");

      Item paper = new Item("Scroll", "says 'whoever has this paper is the rightful king'", "You unroll the scroll and read it to the people in the room.");
      Item key = new Item("Key", "Usually used to open doors", "Key used, it fits and unlocks the door!");
      Item dragons = new Item("Dragons", "they do pretty standard dragon stuff", "Dragons burn the door down");
      Item wine = new Item("Wine", "Half drank bottle of wine", "You drink the wine, and notice a key at the bottom of it. You use the key to unlock the door.");
      Item sword = new Item("Sword", "Like a knife but bigger", "You slice the door handle off");

      Player player = new Player(playerChoice);
      CurrentPlayer = player;
      room1.IsLocked = true;
      room5.IsLocked = true;
      room5.addRoomItem(paper);
      room6.addChallenge(paper);
      room5.addChallenge(key);
      room5.addRoomItem(key);

      switch (CurrentPlayer.PlayerName.ToLower())
      {
        case "tyrion":
          CurrentPlayer.addItem(wine);
          room1.addChallenge(wine);
          break;
        case "jon snow":
          CurrentPlayer.addItem(sword);
          room1.addChallenge(sword);
          break;
        case "daenerys":
          CurrentPlayer.addItem(dragons);
          room1.addChallenge(dragons);
          break;
      }
      room1.NearbyRoom(Directions.north, room2);
      room2.NearbyRoom(Directions.east, room3);
      room2.NearbyRoom(Directions.south, room1);
      room3.NearbyRoom(Directions.east, room4);
      room3.NearbyRoom(Directions.west, room2);
      room4.NearbyRoom(Directions.west, room3);
      room4.NearbyRoom(Directions.south, room5);
      room5.NearbyRoom(Directions.north, room4);
      room5.NearbyRoom(Directions.south, room6);
      room6.NearbyRoom(Directions.north, room5);

      CurrentRoom = room1;
      TellStory(CurrentPlayer.PlayerName.ToLower());
      StartGame();
    }
    public int sleep { get; set; }
    public void TellStory(string player)
    {
      System.Console.WriteLine("(To skip intro, type 'skip', otherwise press enter to begin.)");
      string intro = System.Console.ReadLine();
      if (intro.ToLower() == "skip")
      {
        sleep = 0;
      }
      else
      {
        sleep = 2000;
        if (OS.ToLower() == "w")
        {
          Console.Beep(700, 1100);
          Console.Beep(475, 1100);
          Console.Beep(550, 150);
          Console.Beep(620, 150);
          Console.Beep(700, 1000);
          Console.Beep(475, 850);
          Console.Beep(550, 150);
          Console.Beep(620, 150);
          Console.Beep(520, 2000);
          Console.Beep(620, 1000);
          Console.Beep(420, 800);
          Console.Beep(550, 150);
          Console.Beep(520, 150);
          Console.Beep(620, 1000);
          Console.Beep(420, 800);
          Console.Beep(550, 150);
          Console.Beep(520, 150);
          Console.Beep(460, 800);
        }
      }

      if (player == "tyrion")
      {
        Console.WriteLine(Environment.NewLine);
        System.Console.WriteLine("You are Tyrion Lannister.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You wake up and have no idea where you are.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("Your head hurts, and all you have on you is a half-full bottle of wine.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("As you slowly get your bearings, you start to recognize some things around you and piece together where you are.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You see a big sign on the wall and read it, it says:");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'you are at King's landing, the Lannisters put you in here'");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'dangit', you say under your breath, 'my family is so annoying.'");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You walk towards the door and try to open it, but it is locked.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'Nooooooooooooooooooo!' you scream at the top of your lungs");
        Thread.Sleep(sleep);
        Console.WriteLine(Environment.NewLine);
        System.Console.WriteLine("That brings you to now. Press any key to begin the game.");
        Console.ReadKey();
        Console.Clear();
        StartGame();
      }
      else if (player == "jon snow")
      {
        System.Console.WriteLine("You are Jon Snow.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You wake up and have no idea where you are.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("Your head hurts, and all you have on you is a sword.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("As you slowly get your bearings, you start to recognize some things around you and piece together where you are.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You see a big sign on the wall and read it, it says:");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'you are at King's landing, the Lannisters put you in here'");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'dangit', you say under your breath, 'The Lannisters are so annoying'");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You walk towards the door and try to open it, but it is locked.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'Nooooooooooooooooooo!' you scream at the top of your lungs");
        Thread.Sleep(sleep);
        System.Console.WriteLine("That brings you to now. Press any key to begin the game.");
        Console.ReadKey();
        Console.Clear();
        StartGame();
      }
      else if (player == "daenerys")
      {
        System.Console.WriteLine("You are Daenerys.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You wake up and have no idea where you are.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("Your head hurts, and all you have on you is your dragons.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("As you slowly get your bearings, you start to recognize some things around you and piece together where you are.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You see a big sign on the wall and read it, it says:");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'you are at King's landing, the Lannisters put you in here'");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'dangit', you say under your breath, 'The lannisters are so annoying.'");
        Thread.Sleep(sleep);
        System.Console.WriteLine("You walk towards the door and try to open it, but it is locked.");
        Thread.Sleep(sleep);
        System.Console.WriteLine("'Nooooooooooooooooooo!' you scream at the top of your lungs");
        Thread.Sleep(sleep);
        System.Console.WriteLine("That brings you to now. Press any key to begin the game.");
        Console.ReadKey();
        Console.Clear();
        StartGame();
      }

    }

    public bool playing = true;
    public bool win = false;
    //Setup and Starts the Game loop
    public void StartGame()
    {
      while (playing)
      {
        DrawRoom(CurrentRoom);
        GetUserInput();
      }
    }

    public void DrawRoom(Room room)
    {
      System.Console.WriteLine($"You are in {room.Name}: {room.Description}");

      System.Console.WriteLine(@"


            +-----------------------------------------+
            |               Commands:                 |
            |                                         |
            |•Go + (North, South, East, West) = Move  |
            |•Look = look around the room             |
            |•Inventory = View held items             |
            |•Take + Item name = Take item            |
            |•Use + Item name- Use item               |
            |•Quit - Leave game                       |
            |•Reset - Start a new game                |
            +-----------------------------------------+

      
      ");
    }
    public void youDie(object sender, EventArgs e)
    {
      if (win != true)
      {
        playing = false;
        System.Console.WriteLine("You die a horrible and painful death. Press any key to play again!");
        Console.ReadKey();
        Begin();

      }
    }

    public System.Timers.Timer DeathTimer { get; set; }

    public Room CurrentRoom { get; set; }
    //Gets the user input and calls the appropriate command
    public void GetUserInput()
    {
      if (CurrentRoom.Name == "Throne Room")
      {
        Console.Beep();
        System.Console.WriteLine("You have made it to the Throne Room!! People gasp as you enter.");
        Thread.Sleep(1000);
        System.Console.WriteLine("The king looks at you and says you have 5 seconds to explain yourself or you will be killed.");
        Thread.Sleep(1000);
        DeathTimer = new System.Timers.Timer();
        DeathTimer.Interval = 5000;
        DeathTimer.Elapsed += youDie;
        DeathTimer.Start();
      }
      System.Console.WriteLine($"What would you like to do");
      string input = System.Console.ReadLine();
      if (input.ToLower() == "hodor")
      {
        Hodor();
      }
      RouteInput(input);
      Console.Clear();
    }
    public void youDie(object sender, ElapsedEventArgs e)
    {
      if (win == false)
      {
        DeathTimer.Dispose();
        playing = false;
        win = false;
        System.Console.WriteLine("You died a horrible, painful death. Press enter to play again!");
      }
    }
    public void RouteInput(string input)
    {
      if (playing == false && win == false)
      {
        Reset();
      }
      string[] choice = input.Split(" ");
      string command = choice[0];
      string option = "";
      if (choice.Length > 1)
      {
        option = choice[1].ToLower();
      }
      switch (command.ToLower())
      {
        case "go":
          Go(option);
          break;
        case "look":
          Look();
          break;
        case "inventory":
          Inventory();
          break;
        case "take":
          TakeItem(option);
          System.Console.WriteLine($"{option}");
          break;
        case "use":
          if (CurrentRoom.Name == "Throne Room" && option.ToLower() == "scroll")
          {
            Winner();
          }
          UseItem(option);
          break;
        case "reset":
          Reset();
          break;
        case "quit":
          Quit();
          break;
        default:
          System.Console.WriteLine("Unrecognized input! Press any key to try again.");
          Console.ReadKey();
          GetUserInput();
          break;
      }

    }

    public void Winner()
    {
      win = true;
      playing = false;
      System.Console.WriteLine("You won, congrats. The king reads the scroll and concedes the throne to you. You are now protector of the realm and sit on the iron throne. Press enter to play again!");
      System.Console.ReadLine();
      Reset();
    }
    void Reset()
    {
      GameService newGame1 = new GameService();
      newGame1.Begin();
    }

    #region Console Commands

    //Stops the application
    void Quit()
    {
      Environment.Exit(0);
    }

    //Should display a list of commands to the console
    // void Help();

    //Validate CurrentRoom.Exits contains the desired direction
    //if it does change the CurrentRoom
    void Go(string direction)
    {
      Directions dir;
      switch (direction)
      {
        case "north":
          dir = (Directions)Enum.Parse(typeof(Directions), direction);
          break;
        case "south":
          dir = (Directions)Enum.Parse(typeof(Directions), direction);
          break;
        case "east":
          dir = (Directions)Enum.Parse(typeof(Directions), direction);
          break;
        case "west":
          dir = (Directions)Enum.Parse(typeof(Directions), direction);
          break;
        default:
          //INVALID
          return;
      }
      if (CurrentRoom.Exits.ContainsKey(dir))
      {
        if (CurrentRoom.IsLocked == false)
        {
          this.CurrentRoom = (Room)CurrentRoom.Exits[dir];
        }
        else
        {
          System.Console.WriteLine("Door is locked!");
          GetUserInput();
        }
      }
      else
      {
        System.Console.WriteLine($"There is no door on the {dir} side.");
        GetUserInput();
      }
    }

    //When taking an item be sure the item is in the current room 
    //before adding it to the player inventory, Also don't forget to 
    //remove the item from the room it was picked up in
    void TakeItem(string itemName)
    {
      if (CurrentRoom.RoomItems.Find(item => item.Name.ToLower() == itemName.ToLower()) is Item)
      {
        Item toAdd = (CurrentRoom.RoomItems.Find(item => item.Name.ToLower() == itemName.ToLower()));
        CurrentPlayer.addItem(toAdd);
        System.Console.WriteLine($"{toAdd.Name} Added to your inventory!");
        GetUserInput();
      }
      else
      {
        System.Console.WriteLine("oh my god it worked wow");
      }
    }

    //No need to Pass a room since Items can only be used in the CurrentRoom
    //Make sure you validate the item is in the room or player inventory before
    //being able to use the item
    void UseItem(string itemName)
    {
      if (CurrentPlayer.Inventory.Find(item => item.Name.ToLower() == itemName.ToLower()) is Item)
      {
        if (CurrentRoom.Challenge.Name.ToLower() == itemName.ToLower())
        {
          if (CurrentRoom.IsLocked == true)
          {
            CurrentRoom.IsLocked = false;
          }
          if (itemName.ToLower() == "scroll")
          {
            win = true;
            playing = false;
          }
          Item usedItem = CurrentPlayer.Inventory.Find(item => item.Name.ToLower() == itemName.ToLower());
          System.Console.WriteLine($"{usedItem.Used}");
          CurrentPlayer.removeItem(usedItem);
          System.Console.WriteLine("Press any key to continue");
          Console.ReadKey();
          Console.Clear();
          DrawRoom(CurrentRoom);
          GetUserInput();
        }
        else
        {
          System.Console.WriteLine("That item doesn't do anything here! Press any key to continue.");
          Console.ReadKey();
          Console.Clear();
          DrawRoom(CurrentRoom);
          GetUserInput();
        }
      }
      else
      {
        System.Console.WriteLine("That item is not in your inventory. Press any button to continue");
        Console.ReadKey();
        Console.Clear();
        DrawRoom(CurrentRoom);
        GetUserInput();
      }
    }

    void Hodor()
    {
      System.Console.WriteLine("Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor Hodor");
      Hodor();
    }

    //Print the list of items in the players inventory to the console
    void Inventory()
    {
      Console.Clear();
      DrawRoom(CurrentRoom);
      System.Console.WriteLine("\nInventory:\n");
      CurrentPlayer.Inventory.ForEach(item =>
      {
        System.Console.WriteLine($"{item.Name}: {item.Description}\n\n");
      });
      GetUserInput();
    }
    //Display the CurrentRoom Description, Exits, and Items
    void Look()
    {
      Console.Clear();
      DrawRoom(CurrentRoom);
      System.Console.WriteLine($"{CurrentRoom.Name}: {CurrentRoom.Description}");
      if (CurrentRoom.RoomItems.Count > 0)
      {
        System.Console.WriteLine("Items:");
        Console.WriteLine(Environment.NewLine);
        CurrentRoom.RoomItems.ForEach(item =>
        {
          System.Console.WriteLine($"{item.Name}: {item.Description}\n");
        });
      }
      else System.Console.WriteLine("No items in here!");
      GetUserInput();
    }

    #endregion
  }
}