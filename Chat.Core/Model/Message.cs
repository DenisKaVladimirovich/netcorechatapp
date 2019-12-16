using System;

namespace Chat.Core.Model
{
    public class Message
    {
        public long messageId { get; set; }
        public string text { get; set; }
        public UserModel sender { get; set; }
        public UserModel reciever { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public Enums.MessageStatus messageStatus { get; set; }
    }
}
