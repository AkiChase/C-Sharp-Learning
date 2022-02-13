using System;

namespace 面向对象
{
    public class Person // 类名一般使用帕斯卡命名法
    {
        #region 字段
        // 在C#中称为字段 字段命名一般加上_ 使用驼峰法
        // Field
        //public string _name;
        //public int _age;
        //public char _sex;
        #endregion

        #region 属性
        // 属性是字段的扩展，存在的目的是保护字段，对字段的读和取进行限定
        // 属性的本质是两个 方法 ：get set
        // 所以将字段设置为private，将属性设置为public，实现字段的保护
        // 只有get叫只读属性，只有set叫只写属性

        // Properties
        private string _name;
        public string Name
        {
            get
            {
                Console.WriteLine("调用了Name.get()");
                return _name;
            }  //取该 字段 值时 应该用属性
            set
            {
                Console.WriteLine("调用了Name.set()");
                _name = value;
            } //给该 字段 赋值 应该用属性 = xxx;
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

        #region 方法
        //方法
        //Method
        public void showInfo()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"我的名字是{this.Name}"); //调用Name的get方法
            Console.WriteLine($"我的年龄是{this.Age}");
            Console.WriteLine($"我的性别是{this.Sex}");
            Console.WriteLine($"我的国家是{Person.Nation}"); // 可以调用类的静态成员
            Console.WriteLine("----------------------");

            Person.ShowInfo(); // 可以调用类的静态成员
        }
        #endregion

        #region 静态方法、字段、属性
        // 静态的属于整个类，不属于某个对象
        // 必须要用类名来调用，不允许用对象调用（与c++不同）
        // 静态成员只能调用静态的方法、字段、属性等等，无法使用非静态的成员
        // 非静态函数却可以调用静态的内容（当然需要用类名来调用）
        private static string _nation;
        public static string Nation
        {
            get { return _nation; }
            set { _nation = "中国"; }
        }

        public static void ShowInfo()
        {
            Console.WriteLine("People类的国家是:{0}", Nation);
        }

        #endregion
    }
}
