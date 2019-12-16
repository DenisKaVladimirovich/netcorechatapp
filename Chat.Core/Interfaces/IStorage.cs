using Chat.Core.Enums;
using Chat.Core.EventArguments;
using Chat.Core.Model;
using System;
using System.Collections.Generic;

namespace Chat.Core.Interfaces
{
    public interface IStorage
    {
        /// <summary>
        /// Добавление сообщения в базу данных
        /// </summary>
        /// <param name="message">Сообщение пользователю</param>
        void AddMessage(Message message);
        void AddUser(UserModel user);
        void RemoveMessage(Message message);
        void RemoveUser(UserModel user);
        UserModel GetUser(string login);
        UserModel GetUser(long id);
        IEnumerable<UserModel> GetUsers(int count = 0, int startposition = 0);
        Message GetMessage(int id);
        IEnumerable<Message> GetMessages(int count = 0, int startposition = 0);
        void SetMessageStatus(long messageid, MessageStatus status);
        void SetMessageStatus(Message message, MessageStatus status);
        void SetMessageStatus(List<long> ids, MessageStatus status);
        void SetMessageStatus(List<Message> messages, MessageStatus status);
        void SetUserStatus(long userId, UserStatus status);
        void SetUserStatus(UserModel user, UserStatus status);
        void SetUserStatus(List<long> ids, UserStatus status);
        void SetUserStatus(List<UserModel> messages, UserStatus status);
        event EventHandler<MessageEventArgs> OnMessageAdd;
        event EventHandler<MessageEventArgs> OnSuccesSend;
        event EventHandler<MessageEventArgs> OnFailedSend;
        event EventHandler<MessageEventArgs> OnMessageRemove;


    }
}
