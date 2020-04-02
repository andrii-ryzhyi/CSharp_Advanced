using System;
using System.Collections.Generic;
using System.Text;

namespace IteaDelegates.IteaMessanger
{
    public interface INotifyable
    {
        List<Message> Messages { get; set; }
        string Username { get; }
        void OnNewMessage(Message message, bool mode);
    }
}
