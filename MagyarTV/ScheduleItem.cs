using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagyarTV
{
    public class ScheduleItem
    {
        public string ChannelToRecord { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Dictionary<string, bool> DaysToRecord { get; set; }
        public bool Repeat { get; set; }
    }
}
