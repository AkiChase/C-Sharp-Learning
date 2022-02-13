using System;

namespace 面向对象继承
{
    internal class Person
    {
        public Person(string name, int age, char sex)
        {
            Name = name; Age = age; Sex = sex;
            Console.WriteLine("Person构造函数");
        }
        ~Person()
        {
            Console.WriteLine("Person析构函数");
        }

        public string _test = "测试";

        #region 属性
        private string _name;
        public string Name
        {
            get
            { return _name; }
            set
            { _name = value; }
        }
        private int _age;
        public int Age
        {
            get { return _age; }
            set { _age = (value > 100 || value < 0) ? 0 : value; }
        }

        private char _sex;
        public char Sex
        {
            get { return _sex; }
            set
            {
                if (value != '男' && value != '女')
                    _sex = '男';
                else
                    _sex = value;
            }
        }
        #endregion

        public void ShowInfo()
        {
            Console.WriteLine($"我的名字是{Name}");
            Console.WriteLine($"我的年龄是{Age}");
            Console.WriteLine($"我的性别是{Sex}");
        }

    }
}
