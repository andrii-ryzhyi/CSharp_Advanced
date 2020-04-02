﻿using System;
using System.Collections.Generic;
using System.Linq;

using static ITEA_Collections.Common.Extensions;

namespace IteaDelegates.IteaMessanger
{
    public delegate void OnMessage(Message message);
    public delegate void OnSend(object sender, OnSendEventArgs e);

    public class Account : INotifyable
    {
        public string Username { get; private set; }
        public List<Message> Messages { get; set; }

        public event OnSend OnSend;

        public OnMessage NewMessage { get; set; }

        public Account(string username)
        {
            Username = username;
            Messages = new List<Message>();
            NewMessage += OnNewMessage;
        }

        public Message CreateMessage(string text, INotifyable to)
        {
            var message = new Message(this, to, text);
            Messages.Add(message);
            return message;
        }

        public void Subscribe(Group group)
        {
            group.AddUser(this);
            group.InboxMessage += (sender, e) => this.NewMessage(e.Msg);
        }

        public void Send(Message message)
        {
            message.Send = true;
            message.To.Messages.Add(message);
            message.To.OnNewMessage(message);
            OnSend?.Invoke(this, new OnSendEventArgs(message.ReadMessage(this), message.From.Username, message.To.Username));
        }

        public void OnNewMessage(Message message)
        {
            if (message.Send)
                Console.WriteLine($"OnNewMessage:   Username: {this.Username} From: {message.From.Username}: {message.Preview}", ConsoleColor.DarkYellow);
        }

        public void ShowDialog(string username)
        {
            List<Message> messageDialog = Messages
                .Where(x => x.To.Username.Equals(username) || x.From.Username.Equals(username))
                .Where(x => x.Send)
                .OrderBy(x => x.Created)
                .ToList();
            string str = $"Dialog with {username}";
            ToConsole($"---{str}---");
            foreach (Message message in messageDialog)
            {
                ToConsole($"{(message.From.Username.Equals(username) ? username : Username)}: {message.ReadMessage(this)}",
                    message.From.Username.Equals(username) ? ConsoleColor.Cyan : ConsoleColor.DarkYellow);
            }
            ToConsole($"---{string.Concat(str.Select(x => "-"))}---");
        }
    }
}
