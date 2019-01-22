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
    static public class Channels
    {
        static private Channel M1 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv1live",
            Name = "M1",
            URI = GetChannelURI("https://player.mediaklikk.hu/playernew/player.php?video=mtv1live"),
        };

        static private Channel M2 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv2live",
            Name = "M2",
            URI = GetChannelURI("https://player.mediaklikk.hu/playernew/player.php?video=mtv2live"),
        };
        static private Channel M4 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv4live",
            Name = "M4",
            URI = GetChannelURI("https://player.mediaklikk.hu/playernew/player.php?video=mtv4live"),
        };
        static private Channel M5 => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=mtv5live",
            Name = "M5",
            URI = GetChannelURI("https://player.mediaklikk.hu/playernew/player.php?video=mtv5live"),
        };
        static private Channel Duna => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunalive",
            Name = "Duna",
            URI = GetChannelURI("https://player.mediaklikk.hu/playernew/player.php?video=dunalive"),
        };
        static private Channel DunaWorld => new Channel()
        {
            IndexFeed = "https://player.mediaklikk.hu/playernew/player.php?video=dunaworldlive",
            Name = "Duna World",
            URI = GetChannelURI("https://player.mediaklikk.hu/playernew/player.php?video=dunaworldlive"),
        };

        static private string GetChannelURI(string feed)
        {
            var currentAssembly = Assembly.GetEntryAssembly();
            var currentDirectory = new FileInfo(currentAssembly.Location).DirectoryName;
            string cmd = Path.Combine(currentDirectory, "Python", "getURI.py");

            try
            {
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = "C:\\Python37\\Python.exe";
                start.Arguments = string.Format("\"{0}\" \"{1}\"", cmd, "-i " + feed);
                start.UseShellExecute = false;// Do not use OS shell
                start.CreateNoWindow = true; // We don't need new window
                start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
                start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)
                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string stderr = process.StandardError.ReadToEnd(); // Here are the exceptions from our Python script
                        string result = reader.ReadToEnd(); // Here is the result of StdOut(for example: print "test")
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

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
