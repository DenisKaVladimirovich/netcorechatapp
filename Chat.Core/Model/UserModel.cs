using Chat.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Core.Model
{
    public class UserModel
    {
        public long userID { get; set; }
        public string userName { get; set; }
        public string userLastName { get; set; }
        public string userLogin { get; set; }
        public string userPwd { get; set; }
        public DateTime createdAt { get; set; }
        public string userImage { get; set; }
        public UserStatus userStatus { get; set; }



        public override string ToString()
        {
            return $"id:{userID};name:{userLogin};createdat:{createdAt.ToString("dd:MMMM:yyyy")}";
        }
    }
}
