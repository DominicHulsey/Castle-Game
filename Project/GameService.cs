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
      if (OS.ToLower() == "w")
      {
        Console.Beep(700, 900);
        Console.Beep(475, 900);
        Console.Beep(550, 150);
        Console.Beep(620, 150);
        Console.Beep(700, 800);
        Console.Beep(475, 650);
        Console.Beep(550, 150);
        Console.Beep(620, 150);
        Console.Beep(520, 1800);
        Console.Beep(620, 800);
        Console.Beep(420, 600);
        Console.Beep(550, 150);
        Console.Beep(520, 150);
        Console.Beep(620, 800);
        Console.Beep(420, 600);
        Console.Beep(550, 150);
        Console.Beep(520, 150);
        Console.Beep(460, 600);
      }
      Console.ReadKey();
      Console.Clear();
      ChoosePlayer();
    }

    public void ChoosePlayer()
    {
      System.Console.WriteLine(@"


                                                                         ....'',,'',;;;;,'.''..                                                       
                                                                  ..',,;:llllc;,,,,;:;;:::::c::;;;'                                                   
                                             .;lc:c:;;;;;;;;;clc:::cc::::;,,,,,;;;;::,''.........;cc:,.                                               
                                             'cc,',;;;,,,;lollccc::::;;;;,,,,,;;;;,''.........  ...,cdoc;''',,,''..                                   
                                            .:lodxxddolccclolc::c:;:;,,,''''',,,,'.......   .......'';::::;;:lll:,,,,'.                               
                                            .''';ldxxdol:;;;,''',,,'......''''................ .....'''''''....',''',;;;;'.                           
                                                'ldddc::;,,,,'',,'''''''','..................     .....'''..........''.';cl;.                         
                                              .cO0xoc::c::;,'',;,,''''..'.........''...........       ...'................,,,..                       
                                            'lk00ko:;clc:;,,',:c,'..''.........'''................. ..  ..................  .....                     
                                          .ck0000kolcc:;;,,;::c:'.......''....',........................ ...'.............     ....                   
                                      .''cO00KK0kdlc:c::::;:;,;;''.......'''.''..............................'............        ...                 
                                     'd0KKK000Okxdolccccc:;,,',,'....'....',,'......................       .......... .....        ...                
                                ,lcldOOO0OOOOkkdxdlllccc:;,,''.'..'''.....'''..'''''''.....                   ........  ....        ...               
                                .::lk00kxkkOkkxloollcccc;'..''.''','....',,,'',,,,''.....                          ....  ...         ....             
                                  .o0KOxkkOOkxxollcc:lo:..''....','.....'''''.',,''''....  ...                       .... ..          ....            
                                'oOK0kddkkO0xodl:cllloc'.,,....'''............',,,',,.................            .    .....       .  ......          
                             .cokkdoolllooxOdol:;:ccol;',,....','''...'....''''',,,,'.......................     ...    ..          ......,,.         
                            'kXOxolllodolcoxlc:,,,,:lc:;,''..'',,,'.','..',,,'.',,,'..........''...............  ....  ...           .....,c,.        
                            :KN0kkkxxxxdllxxc;'.';::::;'','.',,;;,''''..',,,,'',,,''....''''''''',,,,,'''....... ....                 ..  .:l;.       
                            ;O0kxdooddooldko;'',;::;:;'.',''',;::;,'...';;,,,'',;,''''''''',,,,,;;;;,,,,,''..... ....                     ..;:'.      
                           ;OKOxdolddldxOko;,;;::;::;,..''''';cc:,..''';;;,'''',;,'',,,,,,,;;;:::::;;;;,,,'..... ....                      .';'...    
                         .o00OxddoddoxOOOxc;;::c::;;,.''...',:c:;,..',,,'''..'',,,,,;;;;;:::::c::::;;;;,,,''..... ....       ..             ..'',;'   
                         ;ddkkxddddox00kdo:,;:cc::;,''''',;:clc;,,'''''....''',,,;;;;:::cccccccc::::::;;,,,'.....  ...       ..              ..';:;.  
                          ;kKOddkOxdxOkdoc,,:cc:;,,'',,,;:::c:;;,''''.....'',,;;::::::cccccccccc::::::;;,,,'.....    ..       ...   ......    ..,:;.  
                          c00kdk00Okkkdlc:;;;;;,,,;;::;,,;;;,,;,,,''.''''',,;::cllcccccclcccccc:::c::;;;;,''...... ... .     ...   .............':,   
                         .x00OkO0kkxdolc:;,,,;:::c:;::;,;;;;;;:;,,''',,,,,;::lllllccclllllcccccc::::;;;;,,,''...... ....    ....................';.   
                         'OXK00kxdoooolc;,,:cc:;::::ccc:cc::::::,'..',,;::ccllllllccllllllllcccccc::::;;,,'''......  ......................... .':'   
                         'OXKKOxollodxo;,;:lc:::::::;:::cc::;;;,'.',;::cclllloooolcloooooolllccccc:::;;,,,''.......     ........      ..........,:,.  
                         ,OXXKOkxooolc;;:lolccccllllccccc:;,,,,,,;::clllllloodddoc:lddoooooocccccc:::;,,'''........      ....          .........';:.  
                        .lKK00OOOkxol::clolllolccllcccllc:::;::cclllloddollodxxdl:;cdxdooodlc:ccc:::;;'.............   .....           ..........;;.  
                        .dOxdxkO0kololcloollddlcclllloolcclccllooddodddddooodxdoc:;cdxdooooc:ccc::;;,'..............   ....          . ..........',.  
                        .cxdddxkOkdolc:coolooollloooollccc:::ccclooodddoooodxdlll:;:dddolllcccc:;,,,''..''..........     ..        ...............,.  
                        ,xxxkxdoxOkxoc;:loooollldddoolcc:::::;;,,,;::::ccllolccol:;:ddolcc::::;,,,,,,,''............             .................;;. 
                       .lxdxOkooOOkkdc:cccclooodkkddoolcc:;''........'',;;;;;;cll:,:ooc:;;,''''..''..................            .................:c. 
                       ,dooxkxxO0kkOocl:,;coddxkOkkxdoc:;,''....''.....',,,,,;clc;,:lc:,'..............................          ................':o:.
                      .ddlddxkO0kodxollc;cldxkO0Okkdc;;:ol;,..';:;,,''';clllllolc;,;:;,.......        .................          ...............,:cl:.
                      cOxodOOkodoloxxddolloxk0KKOkxoloddkkdlccclc:,,;;:coxkkkxxoc:::;,'............. ..................          .....  ........,;;c' 
                      ckocoxxdloddxxdo:;:clx0XXK0OOOO0Oxoooolcc:;;,,;:ldxk000kxdlcc:;,........,::''. ..................          ...............';:;  
                     .xOkdcloc:oxdolc;,;;:oOKNXK00KKKK0Okxdolc::;;;;coxkO0OOkoc:;;;,,''.......;ll:'....',,..............    ...  ...............';'   
                     ;OKKkodc,;ldc;,,;:;;cxKNNNXKK0000OOOkkxdolc::clxkO000kxdc;,',,'''''....,,;;::;,;;,,,'..............    ...................',.    
                     :Okkddxoccc:,'',:c;;o0NWWNNXK000OOOOOkxdolcclxkO0000Okxdl:;;;,''','....,,,,,,'''''.................     ..................,,     
                     :kdoloxxoc:lo:,;::;:xXNWWWNXK00OOOOkkxdoolodkOO000Okxdolc::;,'...'''...',,,,,,,'''.................     .................',.     
                     ;kkxoooooloddl;,,,,:kNWWWWNX00OOOkkkxddddxkkOOO000Oxdolllc:;,'.....'''''',,,,,,,,''''.............        ...............'.      
                     .d00xlllooocc;,''',cONWWWWNX0OkkkkxxxxxddxkkOOO0KKOkdooool:,'..........''',,,,,,,'''''............       ..       ...'..'.       
                     .dKX0ooxxlcc:;;'.',l0WWWMWNK0kkxxxdxdddxkOOOOO0KXK0Oxooool:,''..........''''''',''''''............                 ..'...        
                      :0KNXOxookklcl;';cdKWWWWWNK0kxdoolodxkO0OOkk0KK0OOkdllllc;,,''..........''''''''''''''''''''....                   .'.          
                      .:dOKXXOkkd:;;',::oXMMWWNK0OkdlcclxOOOOOOkxkOxlccoolc:::;,''''''...........'''''''''''''''''....                   ...          
                        .,cdO00Odc;,'',;dNMMWNK0OkxlcldxOO0OOOkxxkxo;',:cc::;;'.....',,'..........'''''''''',''''....       .....  .      .,;.        
                           .o0Okdol;'''cOWMMNKOkkxoldOOOO0OOkkkkkkkdlccodollc,.....',;,'...........''''''''',''''....      ..... ....     .,..        
                            ,kxo:ldo:,'cKWMWK0Okxook0KXXK0OOkkkkkkkxdodxxdolc,'.....''..............''''''''''''.....       ..  .......   .'.         
                            .cdoccodl;,,dNMNKOkkddkKXNNXXK0000Okkkxxxdddolc::;;;,'...........''......'''''''''''......       ..........  ..,.         
                              .:lcclcc;,lKWN0OkxkOKXNWNXXXXKK0Okkkkxxddoc:::::c:,'............'.......''''''''''......      ..............:c.         
                                :oc:,,,':0WNK0OOKXXNWNNNNNX0Okxxxxxxdxdoc;;;:ccc;'''..............''''''''''''''......     ........',,...'o:          
                                :o:;'''':OWNXXXXXXNWWWWWNKOkxxxxxxdooooolc::cll:;,''.............''''''.'''''''''.....    ....  ..',;'..'cc.          
                               'xx:;,'..'xWWNNNNXXNWWWWNKOxddoollc::;:::cccc::;;,,,,'............'''''...'''''''....    ....   ....'..',::.           
                              .oKkl:;'...cXWWWWNNNWWWNX0kxolllllooollc::;,,,,'...',,'''...........''.......'''''.          ..........,::'             
                              ;0Xkc::,...;OWWWWNXNWWNX0kxdddxxkxkkxxxdoc:;;;;,,''................''........'''''.     ...   .......;:,.               
                              ,0Xkxo:;,..,oKNWWXXNWNX0kxxxxxxxxxxxddxdlccc::::;,''........................'''''.           ......';;.                 
                               :OOkOOkdllold0NWNXNNN0kxxxxkkxxxxxdool:,',,,,,,;,''........................''''.  ..   .......'..,l,                   
                                .clldxxxxo;';xXNNNNX0xdxxxxxxxxxdolc:;''''''',,,'......................''''''.  .':,...''''....;:,                    
                                   ..';lo;....:ONNNX0kxddddxddxdolc:;,,,''''''''''''..................''''''.    .','...;c:'.''..                     
                                     'ooc;..'..oNNNX0kxddddxxxxxdollllc;,,'''',,,,''...................'''..     .;xkdlllc;''.                        
                                    :ddlc:'.,..xWNXK0kxddddxkkxxxddddolcc:;,,,,;;,,'.......................       .cxkdc,'..                          
                                  .coollcc;..''xWWNK0kxddddxxxxxxdddollcc:;;;,,,,,,'......................         .,;'...                            
                                .,clccclc;,'..'oXWXXKOxddddddddddodolccc::;;;,,,,''......................           ..                                
                             .';cllc:clc;,,,'..;kXXK000kxoooolloolllcc::;;;;,,'''.......................             ..                               
                           .:c;,:c:;:cc;'','''..:k0000000Okdlc::ccc:::;;;,,,,'........................                ..                              
                        .;loc;,';:;:::,''''''''..'cdO0000000Oxdlcc:;,,,,,''''.......................                   ..                             
                    ..,:ldoc:;,',;;;;;'''''''.......;lkO00000OOkxdolc:;,''.......................                        ..                           
                 .':clllll:'',,'';,,,''..''...........,cxOO0OOOkkxxxdoc:;,'''''''..............                           ..                          
             ..,;:::cccllc'..'''.','''...'...............:dkOOOkkxxxddol:;,,,'''''''........                                 ..                       
          ..,;:;,,,,;;:cc,....''...'.................... .,lxkkkkxxdddolc;,,''''''''.....                                      ....                   
       .';;;;;,'''',,;::;'....'''.....'.................  ..,codddddollc:,'''''''''.....                                          ..                  
   ..,:c:;,;;,'...'',,,;,......''.......................   ...';clllcc:;,''...''......                                               ....             
.';c:::;,',,,'......'',,'...............................   .......',,,''.............                                                   ...           
cc:;;;;'.'''''.......','..........'.....................   ........................                                                      ...    
                                                                                                  
                                                                                                  
                                   _________        _______________________ _                   
                                   \__   __/\     /(  ____ )__   __(  ___  | (    /|            
                                      ) (  ( \   / ) (    )|  ) (  | (   ) |  \  ( |            
                                      | |   \ (_) /| (____)|  | |  | |   | |   \ | |            
                                      | |    \   / |     __)  | |  | |   | | (\ \) |            
                                      | |     ) (  | (\ (     | |  | |   | | | \   |            
                                      | |     | |  | ) \ \____) (__| (___) | )  \  |            
                                      )_(     \_/  |/   \__|_______(_______)/    )_)            
                                   
                                                                                 ... ..... .;clc:lxc                                                  
                                                                .,,;::;,'''.',;;;;c::locll;clooolll;.                                                 
                                                       ..,;;:;;cdddoddollolc::;;,;;:cllllc:;:cloollc;.                                                
                                                 .;cclodxxddl:;::clloolccc:;,,''.',;:ccclll:,,:lolllc:;....                                           
                                  .......      .:lx0K0xoc:;,,,,,,,,;;:cccllllc:;,,'',::ccoooc;;cc::cccc:;;,,,..                                       
                               .,;:c:::::,'''',coxkxolc:::;'.........',,;;cclllllcc:,,,;cldddl:col;,;:c:;;;,;::;.....                                 
                             .,;:dO0Oxol:;;:::;,;;;;,,,'',,,'.....',,,'....',:ccclodo:,',:ldxocclol;',;;;;::;cooc,'''.                                
                           ..';:xWWNK0Odc::c:;,,;:::;;,,,,,,;;;;;;;;:ccc;'....',:cldxo:,'';lll::cll:'..';:;:::::::c:,,,;;.                            
                         .;:;:;c0XOocllcccc:;,,;;;,,;;;,,;;;:::;;,''',:cll:,'....,;codl;,'';c:;,;clc,...',,;;:;;,;cl:'.;c,.                           
                         .;,'cc:dxc,,,,;;;;;'''''...'''.''.''''........',;:::,.....':ll:,',;;;,'';:c;'...'',;;;,'',:l:..,;.                           
                         ':,.,;'';;;;;;:;;,,'................'.....     ..''','..  ..',;,'',;;,..',;:'.....';;;'.,c:cl,..,;,.                         
                        .::,cl;....,;::::;''................'',,,,''..   .........   ......,,,'....,;'......;;'..,l:;l:'...,;,.                       
                    ....'',:oo:',,;;;:;,,,''...................',,,,''..   .......     .....''.....','......''...'c,;c:''''.'cc.                      
                .',;c:'..,::,'''',;;::::;,'''''......'''...........','..    ......      ....... .................',',:;..';'.;lc'                     
                .,;,..':ll:;,'.......'',,''.........''....        ...'..     ....       .......  ...... ....... ....,,...';'..',:;..                  
                .;:'.:xkdc;'.....       ..... .......               ....                .. ...  .......   ....  ................',::.                 
                 ;o;,oxl,.......             .....                                         .    .....     .      .............''''';:,.               
               ..cd;','.........................                                                ...              ............;c;'...;lc'              
          ..,;;;;,'....''''...................                                       ...                           .........,:;......:lcc:.           
       ':,'';;,'......';,,,'.............                             ..          .......    ...                  ...    ...'.  ......;ccc;.          
     .c0x;':lc,......,;;;,,'..............          .....              .............'''''.......          .              ...    ...  ..,;;c:.         
     .dd,'oxc.......;;;,,''..''''',,,'.....       ........         .............'''',,,,,,.............                        ...    ..',ldc'.       
   'coo;.:dl,.....';;,,,''.....'',;;,'...  ............       .... ...........,,;;,,;;:ccc;,''''''.......                      ..      ...,lxkd;      
 'lOOd:.'cc,......';,'''........''.....  ...........         .',;,'...........';;;;:clloollcccc:;,,''.....      .                     ...'',cdOx'     
,dOxl;'',cc'..... .''.','..              .........         .':lodddl:::;;;;;,,,;clloddxxxxxxxxxdlc::;;,'.....                         .....',:ox;     
cxo:,;cl:,,.....   ...........        .........          ..;oxkO00KK0OkxxdddolccoddxkOOO000000OOkdollc::;,'....                      .......';od:.    
c::ldoc:'..............'''...................          ..'cdkO0KXXXXXXXXKK0OkxxxkOOO000KKKKKKKK00Okxddolc;,''...                     .......',:do;.   
:cdOkc.....'..........',;;;::;;,''....             ....':oxO0KXXXXXXXXNNXXXKK0000000KKKKKKXKKKKKK0Okxxdolc:;,'....                    .......,,:dxl.  
lldkl'....''.....',,,,;;;;;;;,'........          ....,:ldkO0KXXXXXXXXXXXXXXKKKKKKKKKKKKKKKKKKKKKK00Okxdolc::;;,'...                ..  ...'...'';do.  
xddc'....'........''.........                  ...';:lodxO00KKKKKXXXXXXXXXKKKKKKKKKKKKKKKKKKKKKKK0OOkxxdolcc::;,'...                ..  ...'.....:c.  
ko:'...'........''........                   ..,;cllodxkkOO00KKKKKKXXXXXXXKKKKKKKKKKKKKKK00000KK00OOkkxxdollcc:;,'...                ..  ..''....',.  
l,...',.......,;'........                   .';:clodxxkOO000KKKKXXXXXXXXXXXXXXXKKKKKKKKKKKKK00000OOkkkxxddollc:;,'....                .    ...''..',. 
..',,,...  ..,:;.........                  .',:clodxkkOO00KKXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKK000Okkkkxxddolllc:;,'...                 .     ......'. 
'',,,...  ..';:,........                 ..',;:cldxkkkOO0KKKXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXKKK00Okkkxxddoollc:;,'...                .       ...'',,.
;'';'... ....,;'......                 ...',;:lodxkkOOO00KKKKKXXXXXXXXXXXXXXXXXXXXXXXXXXXXKKKKKK00OOkkkxxddoolc::;,....               ... ..    ...,:l
,..,'........,,....  ..               ...,;;:lodkkOOO000KKKKKKKKXXXXXXXXXXXXXXKKKKXXXXXXXXXKKK000OOkkkkkxdddolcc:;,'...                ... ..   ..'.:d
'.............,........              ..';:::lodxkkOO0KKKKXXXXXXXXXNNNNNXXXXXXXXXXXXXXXXXXXXXKKK00OOOOOkkxxddollc:;,'...                ... ...   .,.'l
.'.............'.   ...  ......     ...,;:clodxkkkO0KKKKKXXXXXXXXXXXXXXXXKKKKKKKXXXXXXXXXXXXXXKKK00OOOkkkxxddolc:;,'....               ... ....  ..'.'
...........  ...'.   ...........    ...,;:lodxkkO00KKKKKXXXXXXXXXXXXXXKKKKK0000KKKXXXXXXXXXXXXKKK00OOOkkkxxddolc:;,'....               ...  .'.  .....
..'..... .. ......    ....'''','..  ...,:loxkkOO0KKKKXXXXXXXXXXXXXXXXXKKK000000000KKKXXXXXXXKKKK00OOOOkkkxxddolcc:;,'...               ...  ...  .... 
........ .. ....        ...'',,;,..  ..,codxkOOO000KKKXXXXXXXXXXKKKKKKK00000OOOOO000KKKKKKKKKK00OOOOOOOkkxxxxdoolc:;,'...               ..  ..    ..  
....''.........           ....',''.  ..,:clcc:ccccclloxkkkOO00OO0O00000OOOOOOkkkOOO000000KK00OOOOOOOOOkkxxddolclolc:,'...               ..  .  .  .. .
....'.........            .........  ..,,,'.............'''',;;;:loddxxxxkkkkkkkkkkOOOOOOkkxdoooollllc:;;,''''';:cc:;'...              ..         ....
..............          ..........    .,,,,,,;,,,,,''.............',;:coddxxxxxxxxkkkkxdolc;,''.................',;;,'...             ..          .',.
......   ......        .........     .';::ccc::;,,''..............'''',:looddddddddxddoc:,'..............'''',,,,,,,''...            .            .',.
......   ......     . ..'....       .',::::;;,,'...    .    ......'',,;:clloooooooooll:;,'....... ..........',;;;;;,''...        .      ..        ..'.
'.....  ...............''..        .',;:cc:;;'......  ...  .'........',;cllooooolllc:;,''....   ..    .........',;;,,'...       ..     ...       .....
..,'..  .....''...  ...'..       ..',;:loooool;...,'      .:ol:,....''',:looddddol:;'.......... ...   .::,.......''',''..      ..     .''.       ...  
','..  .....,,,'.    .....      ..',;:ldxxxxxxdc;;::,'...'cddoc:,',;cc::ldxkOO0Okdl;.........''..  ...;lc,........''','..     ...     ..'..      ...  
,'.........',''..      ..''... ...''';lxOOOOkkkxoc::ccc::ccccc:::::cllloxO0KKXXK0Oxc'......'',;;;,',,;:;,''......''',,'..     ...     .......    ..   
'.........','...        .',,,''......;lkO0000OOOkxdoolccc:::cccccllooodkOKKXXXXXK0ko,.....,;::::;;;;;;;;;,,''''''',,,,'...    ...      .......   .... 
... ........'...          ..........':oxkO00K0000OOOkkkkxdddoooooddxkOO00KXXXXXXK0Ox:''',',;cllccc:::::;;;;,,'',,;::;,''..    ...          ...    ....
 ........  ..........          ....',coxkOO0000000000000OOkxddxxkO0KKKKKKKXXXNNXXKOkl;,,;;,,:cloooolllcc::;,,,;:lllc:;,...    ...           ...  .....
 .......     ......           .....,:lodxkkO000000000OOOOOOkOO0KKXXKKKKKKKXXXNNXXK0ko:;;:::::ccllloolllccccccloddolc:;,....    ...            ........
........                .      ...';coodddxkO00000000000000KKKKXXXXKKKKKKKXXXNNNXK0kdc:;:::ccllllooollllooooddddoolc:;'...      ....           ...'...
..........   ...        ..      ..,:clooodxkkO000KKKKKKKKKKKKKKKKKKKKKKKKKXXXNNNXK0Oxl:;;;:ccloooooooodddddddoooolc:;,....        .......  ...........
................         ..     ..,;clooodxkkOO00KKKKKKKKKKKKKKKKK00KKKKKKXXXNNNXX0Oxl:;,;;:coodddddddxxxddddololc:;,'....           ....... ......''.
...............           .     ..,;:cllodxkkkOO00KKKKKKKXKKKKKKK000000KKXXXXNNNXXKOxo:;,,;:lodxxxxxxxxxxddddolccc:,''...             ..      ......''
.......                    .    ..';:clloddxxkkOO00KKKKKKKKKKKKKK0OO0KKKKXXXXNNNXXXKOxoc;,,;codxxxxxxxxxxdddooc:::;,'....                    ........'
   ....                         ..',;:clooddxxkkO000KKKKKKKKKKKK00O0XXXXKXXXNWWNXXXKOxdooc;,:ldxxxxxxxxxdddoolc;;;,'.....                    .........
    ..                           ..',;clloodxxkkOO000KKKKKKKKKKKOO0KKKKKKKXNNWWNXXX0Odloooc;;ldxxxxxxxxddddolc:;,,,'....                   .....'.....
......                           ..',;:cloddxxkkOO000KKKKKKKKKK0O00Okxxdxk00KXXKK0Okdl:;;::;;codxxxxxdddddoolc:;,,,'....                   .....''....
.......                          ...',;cloddxxkkOOO00KKKKKKXKK000Okdl:,'',codkkkxdoc;'...''',codxxxxddddddoolc:;,'''...                     .....,,...
........               .         ...',;:clodxxkkOO000KKKKKXXKKKKKKOdc;...',;:lolc:,..  ....';lddxxxxdddddoollc:;,''...                      ......,'..
.... ....           ...          ...',::cloodxkkOOO00KKXXXXXKKXXXXK0kdc::cllllcc;..   ....,:lddxxxxxxxdddoolc:;,,'....                       .''......
............        ..            ...';::clodxkkOOO0KKXXXXXXXXXXXXK0kxlllccllllc;..   ...,cdxxxxxxxxxddooollc:;,,'...                        ..''..'..
       ..........                 ....,;:clodxkkOO00KKXXXXXXXXXXK0kdol:::,,'',;:;'.    ..':oxkkkxxxxxddolllcc:;,,'..                          ...','.'
      .........                    ...';:ccldxkkkOO0KKXXXXXKK00Oxoc:c:cc:;,''';::,.........;codxkkxxxdoollc::;,,'...                       ......'''''
    ...  .....   .                  ...',,;codxkkOO0KKXXKK0kxxdoc;;;:ccccoodollool:,''.....';:codxxddoollcc:;;,'...                      ...........',
  ......  ....   ..                 .....';:cldxkOO00KK0kxdllcc:,';:cc:::lodxkkkkdl:;;,,,,'',;;;:looolllcc:;;,'...                     ...........',;:
........   ...                       .....';:codkOOOOOkdoc::;,,,,;;;;,,,;;:::cllc:;,,,,,,,,,,,;;,;:ccccc::;;,'...                      .... ......;cl:
..........                             ....,;:codxkkxdlc:;;,,,;;,''..'''''''',,,,''.......',,,,,'',;;::::;;,.....                      ...........';cc
... .......                             .....';:lodxdlcc::::cc::;,,;::;;,''''''''...''''''...';;;,,,,,;;;;,'....                       ..... ......';,
..  ..''....  ...                        ......,:coddoolloodddddolllddxxdddddddolllllllc:;,',;:ccc;,,,;,,,'....                        ....  ........'
......''.........                           ....';clooooddddddxxxxdddddxxxxxxxxddddoollc::::ccccccc:;;;,'.....                         ....  .........
......'''........                             ....,;clodddxxxxxddddxxxdddoolllllllcccccc::cccc:::ccc:;,,'.....                         ..... .........
......',,'.......                                ...;clodxkkkkxdddddddool:;,,,,,,,,;;;:::::cc:::::c:;,'......                            ..  .........
....',,;,....'''..                               ....,cldxkOOkkxxxxdddolc:;;,,,,,,,;;;:::::cc::::::;,........                                 ........
''',;:;,'.''.';;'..               ...              ...,cloxkOOOOOkkkkkxxdddoooooolccccc::cccccccc:;,'..  ..                                  .........
,',;::;,'.''',:c;'..    ....       ....             ...';codxOO00OOOO0OOOOkkxxkkkxxxddddooooollc:;,'..                                     ..  ...,,''
,,;:cc:,'...',:cc,.... ......      ....               ...,:cldxkOOO00000kxdddodxxxxxxxxxxdolllc;'....                                      ..    ..,;;
',;::cc;;,...,:cl:,............     .....               ....,:cllodxkkxxdolllclloolloooolcc::;'...                                             .......
'',;:cc::;'..':llc:'.......'''...  ........                ..''',;ccccc:::::;;;;;;:::;::;,'''..                                                .......
'.',;:c:;,'...;clc:,........,,,''...........                 .....'''''..',,,'''',,,'''''......                                            .    ......
...',:c;,''...,:cc:,.........'',,;,..........                   ............................                                              ...   ..''''
...';:c:,,'...,cll;'...........',::;..........                              ...... ..     .        ..                                     ..... ..'''.
...,:cc:;;,'..,coc,.............',::'..........                                                  ....                                        ......''.
...,:cc:;;,...;loc,..........'...';:,..........                                               ......                                          ......''
...';cc:;;,'.':odl;'........','..';:;'.... ......  .                                       .........                                          ........                          
                                    ________________ _          _______ _       _______                      
                                    \__    _(  ___  | (    /|  (  ____ ( (    /(  ___  )\     /|             
                                       )  ( | (   ) |  \  ( |  | (    \/  \  ( | (   ) | )   ( |             
                                       |  | | |   | |   \ | |  | (_____|   \ | | |   | | | _ | |             
                                       |  | | |   | | (\ \) |  (_____  ) (\ \) | |   | | |( )| |             
                                       |  | | |   | | | \   |        ) | | \   | |   | | || || |             
                                    |\_)  ) | (___) | )  \  |  /\____) | )  \  | (___) | () () |             
                                    (____/  (_______)/    )_)  \_______)/    )_|_______|_______)             
                                   
                                   
                                                        ..',;:;:ccc:::;,'''''..''.',,'...                                                             
                                                  ..,coxxkkkkkxxxxxxxxxxxxxxxdol:;;;:;:;,,''...                                                       
                                               ':oxkOkkxxxxxxxxdxxdddddooooooolc;;,,,,,,,,;;:::;,'...                                                 
                                           .:okKXXKOkkkkkxxxxxdddddddddolcccccc:;,,,,,,,;;;:::cccccc:;'..                                             
                                       .,oOKXNNXXXK0OOOkxxxxxdddooooooooolc:::;;,,,,;;:;;;:::::::cccllcc:,'..                                         
                                    .:d0KXXXXXK00Okkkxxxxxxxxxxxxxddoolllllcc:;;,,;;;::::::ccccc:::cclllc:::;,..                                      
                                  ,dKNNXXXXK0Okkxxxddddddddddddddddddooollllcc:;,,;;::ccccccccclcc:::::ccc:::;;;'.                                    
                                ,xKNXKKK00Okkkxxxxxdddddddddddddooooooolllllcc::;;;::cccccccccllllcc:;;;;:::;;;;,;,.                                  
                              ,dKXXK0OkkOOOOOOkxxdddddoooddddddddooooolllcccc::::::::cccccccclllllllc::;,,;;;;;;,,',,.                                
                            .dKXXK0OkkkkOOOOOkxddooooooooooooooooooooollllcc::;::::::::::cccccclllolllc::;,,,,,,,,,'',,.                              
                           'kXXK0OOOOkkkkxxxxddoollllllllllllllllllllllcccccc::::::::::::cccccccclloollcccc;,,,,,,,,,''''.                            
                          ,kKK00Okkkkkxxxdddoolllllccccllllllcccccccccccccccc:::::::::::ccccccc::cclooollclc:;,,,,,,,,'''''.                          
                        .c0K0OOOkkkxxxdddoollllccccccccclccccccccccccccc:::::::::::::c::::ccclccc::ccloolccclc:,,,,,,,,,'''',.                        
                       'dKK0OOkkkxxdddoooolllccccccccccllllllllllllllcc:::;;;:::::c:::::::::ccllcc::::clllccccc:,,,'',,,,'''',.                       
                     .cOK000Okkkxxddoooolllccccccccllloooooooooooolllllc:::::::::::::::::::::ccclcc::;;:ccc:cccc:,,,,'',,,'''','.                     
                    ;kKK000Okkxxddooolllcccllllllloooodddooooooooooolllccc::::::::::::::::::::cccccc:;,,;:::::::c:;,,,,,,,,''''''.                    
                  .o0XXXK0Okxddoooollllllllloooooooddddddddddooooooollllccc:::::::::c:::::::::::::::::;,,,;;;;:::::;,,,,,,,,''''',.                   
             .   .kXNNXK0kxdoooolllllllllloooodddddddddddddddddddoooollllccc:::::::::::::::cc::::::::::;;,,;;;;;;:c:;,,,,,,,,'''',,.                  
                .dNNNXKOkdoooollllllllooooddddddddddddddddddddddddooooolllccc::;;::::::::::ccccc::::::::;;,,,,;;;;:c:;,,,,,,,,'''',,.                 
               .lXXXX0Oxdoolllllllooooddddxxxxxxxxxxxxxxxddddddddddoooolllccc:::;;;;;:;;;;::ccccc::;;;::::;,,,,,;;;:::,,,,,,,,,'''',;.                
               :0K00Okxdoollccloooddddxxxxxxxxxxxxxxxxxxxxxxdddddddooooolllccc::;;;;;;;;;;;;::cccccc::;;;::;,,,,,,;;::;,,,,,;;,,'''',,'               
              ;OKK00kxdoolccclooddxxxxkkkkkkkkkxxxxxxxxxxxxxxxdddddooooolllllcc::;;;;,;;;;;,,;;::ccc:::;;;;:;;,,,,,;;::;,,,,,;;;,'''',,.              
             ,OXXK0kxdoolc:cloddxxxkkkkkkkkkkkkkkkxxxxxxxxxxxxxdddddoooolllllccc::;;;;,,,,,,,,,;;::cc:::;;;;::;,,,,;;;::;,,,,,;;;,'''',,.             
            'kXXK0Okxdolc::coddxxkkkkkkOkkkkkkkkkkkkkkkkkxxxxxdddddddoooolllllcc:::;;;,,,,,,,,,,,,;::ccc::;;;;:;;,,;;;;::;,,,,,;;;,'''',,'            
           .xXK0Okkxxdlc::codxxxkkkkkkkOOOOkkkkkkkkkkkkkkxxxxxxdddddddoooollllcc:::;;;,,,,'''','',;;:ccccc::;;:::;;,;;,;::;,,,,,;;,,''',,,.           
          .oKK0Okxxxxoc::clddxxkkkkkkkkkOOkkkkkkkkkkkkkkkkxxxxxxxdddddoooolllllc::::;;;,,,,''''''',,;:::ccc::::::::;;;;;;::;,,,,,,,,,,'',,,.          
          :0K00Oxxxxxo:;:codxxxxkkkkkkkkkkkkkkkOkkkkkkkkkkkkkxxxxdddddoooolllllcc:::;;;;,,,'''''''''',;;;:::::;::cc:;;;;;:::;,,,,,,;,,,,,,,;'         
         ,OX00Okxxxxxo:,;codxxxxkkkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxxddddoooollccc:::;;;;,,,,,''''''''''',,;;:::::;;:cc:;;;;:::;;,,,,,;;,,,,,,,;'        
        .dXK00Okkxxkxl:,;coxxxxxxkkkkkkkkkkkkkkkkkkkkkkkkkkkkxxxdddolllc::;;;;,,,,'''''........'''''''',,;::c:::::ccc:;;;:::::;,,,,,;,,,,,,,,;.       
        c0K00Okkkxkxdl;,:ldxxxxxxxkkkkkkkkkkkkkkkkkkkkkkkkxxddoolc::;;,,,''''''......''''.........''''''',,;:cc::ccclc:;;;::::;;,,,,,,,,,,,,,,;'      
       'kK000Okkkxxxdl;,:ldxxxxxxxkkkkkkkkxxxxkkkkxxxxxxxxddolc:;;;,'''''''''''',,;;;:::;,,'.......'''''''',;:cc::ccllc:;;:::::;,,,,,,,,,,,,,,,;.     
       l0K000OOkxxxxdc;,:loddddddooolllooodddxxxxxxxxxxxdddolc::;;;,'''',,,,,;;::ccc:::::;;,''......''''''',;:ccc:cclllc:;;::::;,,,,,,,,,,,,,,,,,.    
      ;OK0000OOkkkxxdc;,;clllccc:::::::::cllodxxxxxxddddddollcc::;;,,,,,,;:::::::::::::::;;,,''.....''''''',,;:ccc:cllllc:;;:::;;,;,,,,,,,,,,',,,,'   
     'kKK0000OOkxkxdoc,';::::::;;;::;;:::ccloddddxddddddooolcc::;,,,,,,;;:::::::::::::::;;;,,'''...''''''',,,,;::cccllllllc:::c:;,,,,,,,,,,,,',,,,,'. 
     lKKK0000OOkxkxdo:'',;:ccllcccccccccclllooddddddddddoolc:;,,',,,;;;;::ccc::;;;;;;,,,;,,,''''...''''''',,,,;;::ccllllollc::c:;,,,,,,,,,,,,,,,,,,;,.
    ,OXKK000OOOkxkxdo:'';codxdddoolllcccccccllodddxxxxddolc:,''.',;;;;;:::;;;,..'...'''''''''......''''',',,',,;;:cclllloollc::c:;,,,,,,,,,,,,,,,,,;;;
   .oKXKK000OOkkxxxdoc''coddddooolllccccccccccllodxxxxxdol:,'..',;;;,,,''......................'''''',,,,,,,''',,;:cllllooollccc:;;;,,,,,,,,,,,,,;;;;:
   :0KKKK000OOkkxxxdoc,,cloooollcc:::::::::ccccllodxkkxdlc;,'.',,,;;;,..'.';;'....','.........''''',,,,,,,,,,''',,;clolllooolcccc:;;,,,,,,;;,,,;;;;;;;
  'kKK00K0000Okkkxxdol,':cllllcc:::cccc:::::::cllodxxkxdoc;,''',;;;:,''cc,','..''';;;,''....''',,,,;;;;,,,,,,,'',,;clodoloooollccc:;,,,,,,,;;;,,;;;;;;
 .oKK0000000OOkkxxxdol;',:ccc::::;;,''''',,;;;:clodxxxxdoc;,'',;;;;,',;loc;,,''',,;;,,'.'',,;;;:::;;;;;;,,,,,,,',,;:lodoloddoolccc:;,,,,,,,;;;;;;;;;;:
 ;OK00000000OOkkxxxddl:'';::;;;,'........';;,,;:codxxxdooc:,,,,;;:::cccccc:::::;;;,,,,,,;;::cccccc:::;;;,,,,,,,,'',:ldddoodddoolllc:;;;;;,,,;;;;;;;;::
.dKK00000000OOkkxxxddo:'.,;,,,'.....;;'',;loc:;:codddddolc:;,,,;;;:looooollllccc:::::ccccllllllccc::;;;,,,,,,,,,'',;ldddoodxxdoolllc;,;;;;,,;;;;;;;;;:
;OKK00O00000OOOkxxxxdoc,.',,'...';;,,''',:llcccllddddddolc:;,,,;;;:clloddddddoooooooooooolllllllcc::;,,,,,,,,,,,'',;codddodxxddoolllc;;;;,;;;;;;;;;;;;
dKKK00OOO000OOOkkxxxdol;'.,,,'',;cc:;,,;;::cccoodddddddolc:;,,,,;;:::clodddddddoooodoooooooolllcc::;;,,,''''',,'''',:ldddddxxddooooolc;;;;,;;;,;::;;;;
OK000OOOO00OOOkkkxxxxdoc,',;;;;;;::::;:::ccloddxxddddddolc:;,,,,;;::ccclloooooooddddddoooooollcc:;;,,,'''''''''''''';loooddxxdddddoool:;;;;;,,;;;::::;
00000OOOOO0OOkkkkxxxxdol;',;cclllllcccclloddxxxxdddddddolc:;,'',,;::cclllllllooooooooooooolllcc::;,,,''''''''''''.'';coooddddddddddooll:;;;;;,;;;:::;:
0K00OOOOOOOOOkkkxxxxxdoo:,;:clodddddddddxxxxxxxdddddddoolc:;,''',,;:cllllllllooooooooooolllccc::;;,,''''''''''''...';coooddddoddddddoool:;;::;;;;:::::
000OOOOOOOOOkkkxxxxxxdool;;clodxxxxxxxxxxxxxxxxxddddddoollc;,''''',;:llooooooooooooooolllllcc::;;,,,''''''''''''...';codddddoooddddxdolll::::::;:::::;
0OOOOOkOOkkkkkxxxxxxxdddl::clodxkkkkkxxxxxxxxxxxddddxxdoolc;,''''''',:lloooooooooooooollllcc::;;,,,''''''''''''....';lddddddooodxxxddolllc:cccc;;;;::;
0OOOOOOOkkkkkkxkxxxxddddoc:loodxxxxxxxxxxxddxxxxdxxxxxdoc:;,,'''''''',:loodooooooooolllllcc::;;;,,'''''''''''''.....,ldddoddooddxxxdddolllc:ccc:;;;;::
OOkOOOOkkkkkkkxxxxdxxdddoc:lodxxxxxxxxxxxxxxxxxxdddddolc;,,'...''''''',:loddddooooollllcccc::;;,,''''''''''''''.....'cddoooddoodxxdddddololccclc::;;::
OkOOOOOkkkkkkkkxxxddxdoodl:lodxxkxxxxxxxxxxxxxxdolllll:;,'.......'''.',:looodddoooolllllcc:::;;,'''''''''''''''.....':loododddddxxxxddddololclllc::;;;
OO00OOOkkkkkkkxxxxddddoodocclodxxxxxxxxxxxxxxxxxoc;,;::;,'......'',,;:cllooooodoooolllcccc::;;,,,'''''''''''''''.....;clooodxdddxxxxxdddoloocclll:::;;
OO00OOkkkkkkkkxxxxddddooooccloddxxxxxxxxxxxxkkxxdlc:coolc:ccc:;;:cclllllllllooooollllccccc::;;,,,'''''''''''''''.'...'clloddxxddxxxxxddxdooolclllc::::
OO00OOOOOkkkkkxxxxdddoooooc:clodxxxxxxxxxxxxkxxxxdodddxdoodddolllllllllllllllllllllcccc::::;;,,,,'''''''''''''''......:lloddxxddddxxxxdxxdloocclllc:::
0000OOOOOkkkkkxxxxxddoooooc::clddxxxxxxxxxxxxxxxxxxxxxxddddxdollllllllccccccccccccccc:::::;;;,,,,''''''''''''''.......;ccloodxdoddxkkkxxxxooolcclll:;:
0OOO00OOOOkkkkxxxxxdooooooc:::coddxxxxxxxxxxxxxxxxxxxxdooodddollccccccccccccccccccc:::;;;;;;,,,,'''''''''''''''.......,:cloodxddxxdxkkxxxxdddocccllc::
0OOO0000OOkkkkxxxxxdooooool:;;:codxxxxxxxxxxxxxxxddddddooollllccc:::::::::::::cccc:::;;;;;;,,,,,,''''''''''''''.......,::coodxxxxxddxkkxxxxdddlc:cll::
00OOO000OOkkkkxxddddooooool:,,;:lodxxxxxxxxxxxxddddooolccc:::::;;;,,,,,,,,,,,;;::::::;;;;;;;,,,,,''''''''''''''......',;:clodxkxxxdddxkkxddxddocc:clc:
00OOO0O0OOOkkxxxddddoloooooc,,,,:lddxxxxxxxxdddddolccc:;;;,,,,,'''.............',:cc::;;;;;;,,,,,''''''''''''''......',;::codxkkxxdoddxxxxddddolc::cc:
00OO0OOOOOOkkxxxdddolloooloc;,,',coddxxxxxxxddddlc:;;,,'''....''''''''..........':ccc:;;;;;,,,,,'''''''''''''''.......';:ccldxkkkxdooodxxxdddddocc::::
0OOO0OOOOOOkkxxddddolllooool:;,'',coddxxxxxxdddo:,'',,,;;;:::ccccc:;;,,,,''',,,;:ccc:::;;;,,,,,'''''''''''''''.........,:cloodxkkxdoooodxxxddddolc::::
OO00OOOOOOOOkxxddddollloooolc;,'.';coddddxxxdol:,',;ccllllollollc::;;,,,,,,,,,;::cc::;;;;,,,,,,''''''''''''''...........;clodddxxxxdoooddddddddolc:::;
OOOOOOOOkkOOkxxxxddolllloollc:;,'.';lddddxxxdl:;;:clllllllcccc::;;;;;,,,,,;;;;;::::;;;;;,,,,''''''''''''''''.............;clodddxxxdoooodddddooollc:;;
kOOkkkOkkkOkxxxxxxdollcloolclc;,'..':ldddxxddooooddooollc:;;,,,,,;;;;;;;;;;;;::::;;;,,,,,,,''''''''''''''''..............';cloddddxddooloooodooollc;;;
kkkkkkkkkkkkxdxxxddollccloollc:;'...':odddxdddddxddddoolc::::::::cccccc:::::::::;;;;,,,,,,,''''''''''''''................',;:loddddddoolloooooolllc:;;
xxxxxxxxxxxxddxxxddolcccloollll:,....':odddddddddddddooollllllllllooolllccccc:::;;;,,,,,,'''''''''''''...................';;:codoooddoolccoooolllcc:;;
xxxxxxxxxxxdddxxxddolccclodololc;.....,codddddddddddddddoooddddddddddooollccc:::;;;,,,,''''''''''''......................';:clooolloooolccloooollcc:;;
xxxxxxxxxxxdddddddoolc::lodollol;'.....,coddddddddddddddddxxxxxxxxxxddoollccc::;;;;,,,''''''''...........................',:codolclllllllcclooollc::;;
xxxxxxxxxxxdddddddolll::codolool:,'.....':loooddddddddddxxxxxxxxxxxxddoollccc::;;,,,'''''''''.............................';coolcccllllllcccloollc:;;;
kkkkkxkkxxxxdddddooollc:cooolooc:;''.....';coooddddddddxxxxxxxxxdxxddoollccc:;;,,,'''''''.................................';cllccccclllllccccloolc:;;;
OOOOkkkxxkkxdddddooollc:coollll::;'''......':loodddddddddxxxddddddddoollcc::;,,'''''''''..................................';clcccccclllllcccclloolc::;
OOkkkkxxxxxxddodddoollccclollcc::;,''........,:cloooodddddddddoooooolllcc:;;,,''''''''''..................................';cccccccccllllccccclllllc::
kkxxxxdddddddoooddooollcclollccc::;,'..........',:ccllooooooooollllllcc:;,,,''''''''''....................................':c::cccccllolllccccllllllll
xxdddooooooooooooooooollcloolccc:::,'..............',;:cclllllccc::::;;,,''''''''''''.................''''................':c::ccccclooolllccllllllooo
xxddoooooooooolllloddolllllloollc::;,'.................',,;;;;;;;,,,,,'''''''''''...................'''''''..............',:c::cllclloodollcclooollodx
ddddoooolllllllllloddolllllloolooc;;;'.....................'''''''''''...........................''''''''''...............,:c:cclllloodxdolllloddddddx
dddddooolllllllllllooollcllolllldo:;;,.....................''',,,,,,,,,''''''''..............'''''''''''''''..............,cccclloooodxxxdlcllodxkkkxx
dddddoooolllloooollooollclloolcclo:,,,'....................''',,;;;;;;;;;;;,,,,,,,,'''''''''''''''''''''''''''''..........':llclloddodxxkxolclodxkOOkk
dddddoooooollooooolooollcclool:;:cc,','....................''',;;:::::::cc:::::::;;;;;,,,,''''''''''''''''''''''''........';cllloddxdddkkkxolclodkkOOk
ddddddddooooloooooooooolcccloc;,;::;''''...................''',,;::ccccccllcccccccc::::;;;;,,,,,,,'',,,,,,,'''''''.........':llloddxxddxkkkxolclodkkkk
xxdddddddddooodoooooooolcccllc;,,;::,''''..................''',,;;:ccclllllllllllllllccc:::;;,,,,,,,,,,,,,,,''''''..........,clloddxxdodxkkkxdlllodxkx
xxdddddddxddoddooooooolcccllc;,,,,::;,''''..................'',,;;::ccllllllllllllllllllcc::;;;;;;;;;;;;;;,,,,''''..........';clloddddoddxkkkxdolllodx
xxdxxdddxxddddddoolloolccllc:;,,,,;:;;,''...................'',,;;::cclllllllllllllllllllccc::;;;;;::::::;;;,,,''''.........',:lloddddddddxxOkxxdlllld
xxxdddxxxxxdddddoollolccclc::,,,,,;:;;,''...................'',,,;::cccllllllooolllllllllllcc:::::::ccc:::;;;,,,'''.........'',:loddddddddddxkkkxdllok
xxddxxxxxxxddddooooollccllc:;,,,,,;::;,,'''.................''',,;;::ccclllllllllloooooollllcccccccccccc:::;;;,,''''..........',codddddddddddxkkkdoodk
xxxxxkkkxxddddddoooolllclcc:;,,;,,;::;,'''.''...............''',,;;::ccclllllllllooooooooollllccllllllcccc::;;,,,'''..........'';lddxxddddddddxxxxdddx
xxxxkkkxxxxxxxxxdoooolllllc::;,;;,;::;,''''.''..............'',,;;;:::ccllllllllllloooooooooollllllllllccc:::;;,,,''''.........';codxxdddxxxxxxxxxdddo
kxxkkkkxxxxxxxkxddddoolllllc:;,;:;;:c:;,'''..''.............'',,;;:::ccclllllllllllooooooooooolllllllllllcc::;;;,,'''''........',;codxdddxxxxxddddddol
kkkkkkkkxkkxxkkkxddddoooooolc:;;::;:lcc;''''..'''...........'',,;:::ccccllllllllloooooooooooooollllllllllccc::;;,,,'''''....'..';;;codxdddxxxxddddxdlc
OOkkkOkkkkkxxkkkkxddxdoooodolc:::::clol:,'''..''''.'........'',;;:::ccclllllllllooooooooooooooollllllllllccc::;;;,,,''''''''''',;;,;codxdddddddddxxdl:
kkkkOOOkkkkkkkxxkkxdxxdoodddolcc:::codoc;'','.'..''''......''',;;::ccccllllooooooooooooooooooooooooooooollcc:::;;,,,,,'''''''',,::;;::loddooooodxkxoc:
dxxkkOOOOkkkxxxxkkxxdxxddddxdlcc::::lddl;,',''''.'','......'',,;::cccllllloooooooooollllooooooooooooodoollcc::::;;,,,,,,,''',,,;:c:::;:codooooooxkxoc:
odddxkOOOkxxxdxxdxkxddxxdddxdoccc;;;codl:,,,,',,'.','.....'',,;;::cclllloooooooooolllllllloooooodddddddoolcccc:::;;;;;,,,,,,;;;;::ccc::clooollloxxdoc:
oodddxxkkkxxdddxddxkxdddddoddocc:;,,;cdo:;,,,,''''''''...''',;;::cccllloooooooooollllllllloooooddddddddoollcccc:::;;;;;,,,,;;;;;:ccccccllooolloodddolc
ooodddddxxxxddoddodxxddoooooodlc:;,'':ooc;;,,,,''''''''''''',;;::cccllloooooooooollllllllllooodddxxxxxddoollcccc:::::;;;;;;;;;;;:cllcllloodooooooooooo
ooddxdddddddddooddooddooooollooc:;,'.,col:,,,,,,,'''''''''',,;;::ccllllooooooooooollllllllooodddxxxxxxxddollccccc:::::;;;;;;;;;::cllllloodddddddoooodd
oodxxdddddddddooodoooooollllclll::,'.':lo:,,,,,,,'''''''''',,;;::ccllloooooooddoooolllllllooodddxxkkkxxddolllccccc:::::;;;:::;;::colllooodxxxxddoooodx
                                     ______  _______ _______ _       _______ _______         _______ 
                                    (  __  \(  ___  |  ____ ( (    /(  ____ (  ____ )\     /(  ____ \
                                    | (  \  ) (   ) | (    \/  \  ( | (    \/ (    )( \   / ) (    \/
                                    | |   ) | (___) | (__   |   \ | | (__   | (____)|\ (_) /| (_____ 
                                    | |   | |  ___  |  __)  | (\ \) |  __)  |     __) \   / (_____  )
                                    | |   ) | (   ) | (     | | \   | (     | (\ (     ) (        ) |
                                    | (__/  ) )   ( | (____/\ )  \  | (____/\ ) \ \__  | |  /\____) |
                                    (______/|/     \(_______//    )_|_______//   \__/  \_/  \_______)








");
      System.Console.WriteLine("Please scroll to view characters, then type selection.\n1 = Tyrion, 2 = Jon Snow, 3 = Daenerys");
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