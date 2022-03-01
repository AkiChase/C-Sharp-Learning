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

namespace 控件学习2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListView控件.ItemsSource = GetUserInfo();
            DataGrid控件.ItemsSource = GetUserInfo();
        }

        private List<UserInfo> GetUserInfo()
        {
            List<UserInfo> list = new List<UserInfo>();
            for (int i = 0; i < 5; i++)
            {
                UserInfo user = new UserInfo();
                user.UserName = $"用户asdfgh{i + 1}";
                user.UserId = 1000000000 + i;
                user.Age = 20 + i;
                user.State = i % 2 == 0;
                list.Add(user);
            }
            return list;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            新窗口 newWindow = new 新窗口();
            newWindow.Show();
        }
    }

    public class UserInfo
    {
        public string UserName { get; set; }
        public int Age { get; set; }
        public int UserId { get; set; }
        public bool State { get; set; }
    }
}
