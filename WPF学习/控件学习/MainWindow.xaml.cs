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

namespace 控件学习
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region 动态添加元素
            // 动态添加元素
            RadioButton rdoBtn = new RadioButton();
            rdoBtn.Content = "测试";
            rdoBtn.GroupName = "Radio组";
            // 需要使用Name
            Radio区.Children.Add(rdoBtn);

            //修改图片链接
            动态img地址.Source = new BitmapImage(new Uri("imgs/2.png", UriKind.Relative));
            #endregion
            #region ComboBox
            //用自定义对象作为ComboBox选项

            //指定数据源时 不能动态添加和移除（只能先取出数据源修改，再重新赋于）
            //ComboBo选项.ItemsSource = Person.getPersonList();
            ComboBo选项.SelectedValuePath = "Id"; //项的值的路径
            ComboBo选项.DisplayMemberPath = "Name"; //项的文本的路径
            //var t = ComboBo选项.Items[3]; //可以取出原对象


            foreach (var item in Person.getPersonList())
            {
                ComboBo选项.Items.Add(item);
            }
            ComboBo选项.Items.RemoveAt(0); //只有使用items时才能动态添加和移除，使用ItemsSource不能

            //还能通过 DataContext = list 然后列表上 ItemSource="{Binding}" //不写路径使用根对象

            ComboBo选项.SelectedIndex = 2;
            #endregion

        }

        public class Person
        {
            public Person(string name, int id) { Name = name; Id = id; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int Test { get; set; } = 123;
            public static List<Person> getPersonList()
            {
                List<Person> list = new List<Person>();
                list.Add(new Person("a", 1));
                list.Add(new Person("b", 2));
                list.Add(new Person("c", 3));
                list.Add(new Person("d", 4));
                return list;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem p = (sender as ComboBox).SelectedItem as ComboBoxItem;
            if (p == null || p.Tag == null)
                return;
            MessageBox.Show(p.Tag.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task.Run(() => //新开一个线程
            {
                (sender as Button).Dispatcher?.Invoke(() => { (sender as Button).IsEnabled = false; });
                // 要使用控件自己的线程调度器来执行操作，否则执行无效，或者会报错
                for (int i = 1; i <= 100; i++)
                {
                    进度条.Dispatcher?.Invoke(() => { 进度条.Value = i; });
                    Thread.Sleep(50);
                }
                (sender as Button).Dispatcher?.Invoke(() => { (sender as Button).IsEnabled = true; });
            });

        }
    }
}
