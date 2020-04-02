using System;
using System.Collections.Generic;
using System.Text;

namespace IteaDelegates.IteaMessanger
{
    public class GroupMessageEventArgs : EventArgs
    {
        public Message Msg { get; set; }

        public GroupMessageEventArgs(Message msg)
        {
            Msg = msg;
        }
    }
}
