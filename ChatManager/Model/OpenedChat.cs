using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatManager.Model
{
    internal class OpenedChat
    {
        public Process ChatWindow { get; set; }
        public string TargetId { get; set; }
    }
}
