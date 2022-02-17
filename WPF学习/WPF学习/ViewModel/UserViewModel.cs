using WPF学习.Model;
using WPF学习.Common;
using System.Windows.Media;
using System.Windows.Input;
using System.Windows;
using System;
using System.Collections.ObjectModel;

namespace WPF学习.ViewModel
{
    internal class UserViewModel : ViewModelBase
    {
        public UserViewModel()
        {
            User = new User(this);
        }

        #region 属性
        // 这里转成了枚举数组
        public User.Gender[] GenderArr { get; } = (User.Gender[])Enum.GetValues(typeof(User.Gender));


        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
            }
        }

        private ObservableCollection<User> _userList = new ObservableCollection<User>();
        public ObservableCollection<User> UserList
        {
            get { return _userList; }
            set
            {
                _userList = value;
                OnPropertyChanged(nameof(UserList));
            }
        }

        private Brush _color = Brushes.Orange;
        public Brush Color
        {
            get { return _color; }
            set
            {
                _color = Brushes.Red;
                OnPropertyChanged(nameof(Color));
            }
        }
        #endregion

        #region ConfirmCommand
        // 写好需要执行的函数和判断是否执行
        //当然也可以在new DelegateCommand处使用匿名函数
        private void ConfirmCommandAction(object parm)
        {
            UserList.Add((User)User.Clone());
            OnPropertyChanged(nameof(UserList));
        }

        private bool ConfirmCommandCanExcute(object parm)
        {
            return !string.IsNullOrEmpty(User.Name);
        }

        private ICommand _confirmCommand;

        public ICommand ConfirmCommand
        {
            get
            {
                if (_confirmCommand == null) //按需初始化
                {
                    _confirmCommand = new DelegateCommand(ConfirmCommandAction, ConfirmCommandCanExcute);
                    //_confirmCommand.CanExecuteChanged += (sender, e) => { MessageBox.Show("监听到状态变化事件"); };
                }
                return _confirmCommand;
            }
            set { _confirmCommand = value; }
        }
        #endregion


        #region ClearCommand
        // 只读 （每次读并不会new一个新的）
        public ICommand ClearCommand => new DelegateCommand((parm) =>
        {
            User.Sex = User.Gender.女;
        });
        #endregion

        // 封装主动触发CanExecute的方法，用于主动更新状态
        public void RaiseCommandCanExcute()
        {
            ConfirmCommand.CanExecute(null);
        }
    }
}
