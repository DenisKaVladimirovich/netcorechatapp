using Chat.Core.Model;
using System;

namespace Chat.Core.EventArguments
{
    public class MessageEventArgs:EventArgs
    {
        public Message message { get;}

        public MessageEventArgs(Message _message) {
            message = _message;
        }
    }
}