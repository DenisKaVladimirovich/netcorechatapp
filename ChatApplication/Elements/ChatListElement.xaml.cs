using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChatApplication.Elements
{
    /// <summary>
    /// Логика взаимодействия для ChatListElement.xaml
    /// </summary>
    public partial class ChatListElement : UserControl
    {
        public string userName { get; set; } = "Empty";
        public string lastMessage { get; set; } = "Empty";
        public Brush statusBrush { get; set; } = Brushes.Red;
        public DateTime lastMessageTime { get; set; }
        public ChatListElement()
        {
            InitializeComponent();
        }


        /// <summary>
        /// /
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        /// <param name="lastMessage">Последнее сообщение</param>
        /// <param name="status">Статус сети 0 - оффлайн, 1 - онлайн</param>
        public ChatListElement(string name, string lastMessage, int status)
        {
            InitializeComponent();
            UserName.Text = userName = name;
            LastMessage.Text = this.lastMessage = lastMessage;
            StatusColor.Fill = statusBrush = status == 1 ? Brushes.Green : Brushes.Red;
        }
    }
}
