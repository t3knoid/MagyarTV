using HtmlAgilityPack;
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
    public class MediaKlikk
    {
        static private Channel M1 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv1live",
            Info = "https://www.mediaklikk.hu/m1-elo",
            Name = "M1",
            TVGuideEntry = "1",
        };

        static private Channel M2 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv2live",
            Info = "https://www.mediaklikk.hu/m2-elo",
            Name = "M2",
            TVGuideEntry = "2",
        };
        //static private Channel M3 => new Channel()
        //{
        //    IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv3live",
        //    Info = "https://www.mediaklikk.hu/m3-elo/",
        //    Name = "M3",
        //    TVGuideEntry = "153",
        //};
        static private Channel M4 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv4live",
            Info = "https://www.mediaklikk.hu/m4-elo/",
            Name = "M4",
            TVGuideEntry = "170",
        };
        static private Channel M5 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv5live",
            Info = "https://www.mediaklikk.hu/m5-elo",
            Name = "M5",
            TVGuideEntry = "176",
        };
        static private Channel Duna => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunalive",
            Info = "https://www.mediaklikk.hu/duna-elo",
            Name = "Duna",
            TVGuideEntry = "6",
        };
        static private Channel DunaWorld => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunaworldlive",
            Info = "https://www.mediaklikk.hu/duna-world-elo",
            Name = "Duna World",
            TVGuideEntry = "97",
        };

        private string standardError;
        public string StandardError { get { return standardError; } }

        public MediaKlikk()
        { }
        public Dictionary<string, Channel> GetChannels()
        {
            Dictionary<string, Channel> channels = new Dictionary<string, Channel>();
            channels.Add(M1.Name, M1);
            channels.Add(M2.Name, M2);
            //channels.Add(M3.Name, M3);
            channels.Add(M4.Name, M4);
            channels.Add(M5.Name, M5);
            channels.Add(Duna.Name, Duna);
            channels.Add(DunaWorld.Name, DunaWorld);
            return channels;
        }

        public List<string> GetChannelNames()
        {
            List<string> names = new List<string>();
            names.Add(M1.Name);
            names.Add(M2.Name);
            //names.Add(M3.Name);
            names.Add(M4.Name);
            names.Add(M5.Name);
            names.Add(Duna.Name);
            names.Add(DunaWorld.Name);

            return names;
        }

        public string GetChannelURI(Channel channel)
        {
            string streamURL = string.Empty;
            string scriptXpath = "/html/body/script[3]";
            string today = DateTime.Now.ToString("yyyyMMdd");
            string pathToCachedFile = Path.Combine(Path.GetTempPath(), "MagyarTV-StreamURL-" + channel.Name + "-" + DateTime.Now.ToString("yyyy-dd-M-HH") + ".html"); // Web page is fetched at the very least on top of each hour
            HtmlAgilityPack.HtmlDocument htmlDocument = HtmlAgilityPackEx.LoadFromCachedHtmlFile(pathToCachedFile);

            if (htmlDocument == null) // If there is no cached file, load it from the given URL
            {
                HtmlWeb browser = new HtmlWeb();
                htmlDocument = browser.Load(channel.IndexFeed);
                FileStream sw = new FileStream(pathToCachedFile, FileMode.Create);
                htmlDocument.Save(sw);
                sw.Close();
            }

            HtmlAgilityPack.HtmlNodeCollection script = htmlDocument.DocumentNode.SelectNodes(scriptXpath);

            try
            {
                string currentline = String.Empty;
                var x = script.ToList();
                string[] lines = x[0].InnerText.Split(new string[] { "\n" }, System.StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < lines.Length; i++)
                {
                    currentline = lines[i].Trim();
                    if (currentline.Contains("index.m3u8"))
                        break;
                }
                string[] url_parts = currentline.Split('"');
                streamURL = string.Format("https:{0}", url_parts[3].Replace("\\", ""));
            }
            catch (Exception ex)
            {
                throw;
            }

            return streamURL;
        }
    }
}

