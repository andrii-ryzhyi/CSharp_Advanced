using System;
using System.Collections.Generic;
using System.Text;

namespace IteaDelegates.IteaMessanger
{
    public delegate void InboxMessageHandler(object sender, GroupMessageEventArgs e);
    public class Group : INotifyable
    {
        public event InboxMessageHandler InboxMessage;
        public List<Message> Messages { get; set; }
        public string Username { get; set; }

        private List<Account> Subscribers;
        public Group(string name)
        {
            Username = name;
            Subscribers = new List<Account>();
            Messages = new List<Message>();
        }

        public void OnNewMessage(Message message, bool silentMode = false)
        {
            InboxMessage?.Invoke(this, new GroupMessageEventArgs(message));
        }
        public void AddUser(Account account)
        {
            Subscribers.Add(account);
        }
    }
}
