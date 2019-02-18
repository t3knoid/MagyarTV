﻿using System;
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
        };

        static private Channel M2 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv2live",
            Info = "https://www.mediaklikk.hu/m2-elo",
            Name = "M2",
        };
        static private Channel M3 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv3live",
            Info = "https://www.mediaklikk.hu/m3-elo/",
            Name = "M3",
        };
        static private Channel M4 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv4live",
            Info = "https://www.mediaklikk.hu/m4-elo/",
            Name = "M4",
        };
        static private Channel M5 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv5live",
            Info = "https://www.mediaklikk.hu/m5-elo",
            Name = "M5",
        };
        static private Channel Duna => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunalive",
            Info = "https://www.mediaklikk.hu/duna-elo",
            Name = "Duna",
        };
        static private Channel DunaWorld => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunaworldlive",
            Info = "https://www.mediaklikk.hu/duna-world-elo",
            Name = "Duna World",
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
            channels.Add(M3.Name, M3);
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
            names.Add(M3.Name);
            names.Add(M4.Name);
            names.Add(M5.Name);
            names.Add(Duna.Name);
            names.Add(DunaWorld.Name);

            return names;
        }

        public string GetChannelURI(string feed)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            string cmd = Path.Combine(currentDirectory, "parsers", "mediaklikk.py");

            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = String.Format("{0}\\Python37\\Python.exe", currentDirectory);
                start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, "-i " + feed);
                start.WorkingDirectory = System.IO.Path.Combine(currentDirectory, "Python37");
                start.UseShellExecute = false;// Do not use OS shell
                start.CreateNoWindow = true; // We don't need new window
                start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
                start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)

                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        standardError = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                        string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                        return result;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}

