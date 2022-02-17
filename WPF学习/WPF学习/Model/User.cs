using System;
using WPF学习.Common;
using WPF学习.ViewModel;

namespace WPF学习.Model
{
    internal class User : ViewModelBase, ICloneable
    {
        public User(UserViewModel vm) { _userViewModel = vm; Sex = Gender.男; }

        public enum Gender { 男, 女 } //性别枚举

        #region 属性
        // userViewModel实例
        private UserViewModel _userViewModel;


        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                _userViewModel?.RaiseCommandCanExcute(); //触发CanExcute更新
            }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private Gender _sex;

        public Gender Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                OnPropertyChanged(nameof(Sex));
            }
        }

        public object Clone()
        {
            User user = new User(_userViewModel)
            {
                Name = Name,
                Age = Age,
                Sex = Sex
            };
            return user;
        }


        #endregion

    }
}
