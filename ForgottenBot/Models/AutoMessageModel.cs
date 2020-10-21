using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ForgottenBot.Models
{
    public class AutoMessageModel
    {
        public ulong ServerID { get; set; }

        public int MessageCount { get; set; }
        public ulong ChannelID { get; set; }
        public List<string> Messages { get; set; }
        public bool ResetCounter { get; set; }
        public int Counter { get; set; }

        public AutoMessageModel()
        {
        }
    }
}
