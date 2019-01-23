using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    static public class Channels
    {
        static private Channel M1 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv1live",
            Name = "M1",
        };

        static private Channel M2 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv2live",
            Name = "M2",
        };
        static private Channel M4 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv4live",
            Name = "M4",
        };
        static private Channel M5 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv5live",
            Name = "M5",
        };
        static private Channel Duna => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunalive",
            Name = "Duna",
        };
        static private Channel DunaWorld => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunaworldlive",
            Name = "Duna World",
        };

        static public Dictionary<string, Channel> GetChannels()
        {
            Dictionary<string, Channel> channels = new Dictionary<string, Channel>();
            channels.Add(M1.Name, M1);
            channels.Add(M2.Name, M2);
            channels.Add(M4.Name, M4);
            channels.Add(M5.Name, M5);
            channels.Add(Duna.Name, Duna);
            channels.Add(DunaWorld.Name, DunaWorld);
            return channels;
        }

        static public List<string> GetChannelNames()
        {
            //Dictionary<string, Channel> channels = GetChannels();

            //List<string> names = new List<string>();
            //foreach (KeyValuePair<string, Channel> ch in channels)
            //{
            //    names.Add(ch.Value.Name);
            //}

            List<string> names = new List<string>();
            names.Add(M1.Name);
            names.Add(M2.Name);
            names.Add(M4.Name);
            names.Add(M5.Name);
            names.Add(Duna.Name);
            names.Add(DunaWorld.Name);

            return names;
        }
    }
}
