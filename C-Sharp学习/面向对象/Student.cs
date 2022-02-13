using System;

namespace 面向对象
{
    // 静态类中 只允许静态成员
    // Console类就是静态类
    // 如果经常需要使用的类，而这个类就是作为工具类，可以考虑设置为静态
    // 静态类在整个项目中资源共享（存在静态存储区）

    public static class Student
    {
        //private string _name; //无法声明 非静态（实例）成员
        private static string _name;
        public static string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public static void ShowInfo()
        {
            Console.WriteLine("静态学生类：我的名字是{0}", Name); // 即 Student.Name
        }

    }
}
