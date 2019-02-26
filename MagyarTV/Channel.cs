using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Scripting.Hosting;

namespace MagyarTV
{
    public class Channel
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string URI { get; set; }
        public string IndexFeed { get; set; }
        public string Info { get; set; }
        public bool IsRecording { get; set; }
        public bool IsPlaying { get; set; }
        public VideoMetadata StreamInfo { get; set; }
        public string TVGuideEntry { get; set; }
    }

}
