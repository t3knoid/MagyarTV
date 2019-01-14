using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    static public class Channels
    {
        static public Channel M1 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv1live",
            Name = "M1",
        };

        static public Channel M2 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv2live",
            Name = "M2",
        };
        static public Channel M4 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv4live",
            Name = "M4",
        };
        static public Channel M5 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv5live",
            Name = "M5",
        };
        static public Channel Duna => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunalive",
            Name = "Duna",
        };
        static public Channel DunaWorld => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunaworldlive",
            Name = "Duna",
        };        
    }
}
