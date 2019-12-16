using Chat.Core.Enums;
using Chat.Core.EventArguments;
using Chat.Core.Interfaces;
using Chat.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chat.Core.Server
{
    class MemoryStorage:IStorage
    {
        private static MemoryStorage storage;

        private MemoryStorage()
        {

        }

        public static MemoryStorage GetInstance()
        {
            if (storage == null)
                storage = new MemoryStorage();
            return storage;
        }
        private List<Message> messages = new List<Message>();
        private List<UserModel> users = new List<UserModel>();
        public event EventHandler<MessageEventArgs> OnMessageAdd;
        public event EventHandler<MessageEventArgs> OnSuccesSend;
        public event EventHandler<MessageEventArgs> OnFailedSend;
        public event EventHandler<MessageEventArgs> OnMessageRemove;

        public void AddMessage(Message message)
        {
            messages.Add(message);
        }

        public void AddUser(UserModel user)
        {
            users.Add(user);
        }

        public Message GetMessage(int id)
        {
            return messages.Where(m => m.messageId == id).FirstOrDefault();
        }

        public IEnumerable<Message> GetMessages(int count = 0, int startposition = 0)
        {
            var t_messages = messages.Skip(startposition).ToList();
            if (count != 0)
                return t_messages.Take(count).ToList();
            return t_messages;
        }

        public UserModel GetUser(string login)
        {
            return users.Where(u => u.userLogin == login).FirstOrDefault();
        }

        public UserModel GetUser(long id)
        {
            return users.Where(u => u.userID == id).FirstOrDefault();
        }

        public IEnumerable<UserModel> GetUsers(int count = 0, int startposition = 0)
        {
            var t_users = users.Skip(startposition).ToList();
            if (count != 0)
                return t_users.Take(count).ToList();
            return t_users;
        }

        public void RemoveMessage(Message message)
        {
            var mes = messages.Where(m => m.messageId == message.messageId).FirstOrDefault();
            messages.Remove(mes);
            OnMessageRemove?.Invoke(this, new MessageEventArgs(message));
        }

        public void RemoveUser(UserModel user)
        {
            var _user = users.Where(m => m.userID == user.userID).FirstOrDefault();
            users.Remove(_user);
        }

        public void SetMessageStatus(long messageid, MessageStatus status)
        {
            messages.First(m => m.messageId == messageid).messageStatus = status;
        }

        public void SetMessageStatus(Message message, MessageStatus status)
        {
            messages.First(m => m.messageId == message.messageId).messageStatus = status;
        }

        public void SetMessageStatus(List<long> ids, MessageStatus status)
        {
            foreach (long id in ids)
                messages.First(m => m.messageId == id).messageStatus = status;
        }

        public void SetMessageStatus(List<Message> messages, MessageStatus status)
        {
            foreach (Message _m in messages)
                messages.First(m => m.messageId == _m.messageId).messageStatus = status;
        }

        public void SetUserStatus(long userId, UserStatus status)
        {
            users.First(u => u.userID == userId).userStatus = status;
        }

        public void SetUserStatus(UserModel user, UserStatus status)
        {
            users.First(u => u.userID == user.userID).userStatus = status;
        }

        public void SetUserStatus(List<long> ids, UserStatus status)
        {
            foreach (long id in ids)
                users.First(m => m.userID == id).userStatus = status;
        }

        public void SetUserStatus(List<UserModel> users, UserStatus status)
        {
            foreach (UserModel id in users)
                users.First(m => m.userID == id.userID).userStatus = status;
        }
    }
}
