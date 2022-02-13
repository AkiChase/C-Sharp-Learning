using System;

namespace 面向对象
{
    internal class Teacher
    {
        #region 构造函数
        // 只要重载了构造函数，编译器就不会自动补充一个默认无参构造了
        public Teacher()
        {
            Console.WriteLine("构造函数重载");
        }

        public Teacher(string name, int age, char sex)
        {
            Name = name; Age = age; Sex = sex;
            Console.WriteLine("Teacher(string name, int age, char sex) 构造函数");
        }

        // 使用this来调用另一个构造函数，减少不必要的代码冗余
        // 当然这个要视情况使用
        public Teacher(string name, int age) : this(name, age, '女')
        {
            //Name = name; Age = age; // 代码冗余
            Console.WriteLine("Teacher(string name, int age) 构造函数");
        }

        #endregion

        #region 析构函数
        /*
        一个类只能有一个析构函数，若未自己写，编译器会自动补充
        无法继承或重载析构函数
        无法调用析构函数。它们是被自动调用的
        析构函数既没有修饰符，也没有参数
         */
        ~Teacher()
        {
            Console.WriteLine("调用了Teacher的析构函数");
        }

        #endregion

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
