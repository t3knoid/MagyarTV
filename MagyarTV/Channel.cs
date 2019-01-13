using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    class Channel
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string URI { get; set; }
        public string IndexFeed { get; set; }
        public bool IsRecording { get; set; }
        public bool IsPlaying { get; set; }
        public VideoMetadata StreamInfo { get; set; }
    }
}
