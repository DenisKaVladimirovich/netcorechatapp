using ChatApplication.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace ChatApplication
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ChatListElement> chats = new List<ChatListElement>();
        public MainWindow()
        {
            InitializeComponent();
            chats.Add(new ChatListElement("Denis", "Hello chmo", 1));
            chats.Add(new ChatListElement("Vasya", "Hey pidr", 0));
            chats.Add(new ChatListElement());
            chats.Add(new ChatListElement());
            chatsList.ItemsSource = chats;


            

        }

        private void ListViewItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ChatListElement item = (ChatListElement)sender;// (sender as ListViewItem).DataContext;
            if (item != null)
                MessageBox.Show(item.LastMessage.Text);
            chatsList.ItemsSource = null;
            chatsList.Items.Clear();
            MessageBox.Show(string.Join(";", chats.Select(p=>p.lastMessageTime).ToArray()));
            chats[3].lastMessageTime = DateTime.UtcNow + TimeSpan.FromSeconds(20);
            chats[2].lastMessageTime = DateTime.UtcNow + TimeSpan.FromSeconds(15);
            chats[1].lastMessageTime = DateTime.UtcNow + TimeSpan.FromSeconds(12);
            chats[0].lastMessageTime = DateTime.UtcNow + TimeSpan.FromSeconds(18);
            chatsList.ItemsSource = chats.OrderBy(c => c.lastMessageTime).ToList();
            MessageBox.Show(string.Join(";", chats.Select(p => p.lastMessageTime).ToArray()));

        }





    }
}
