using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    public class Streams
    {
        public string ProgramID { get; set; }
        public string Bandwidth { get; set; }
        public string Codecs { get; set; }
        public string Resolution { get; set; }
        public string Page { get; set; }
        public Uri Uri { get; set; }
    }
}
