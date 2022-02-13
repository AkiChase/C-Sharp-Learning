using System;


namespace 面向对象继承
{

    internal class Program
    {
        static void Main(string[] args)
        {
            其他补充.Content();
            #region 继承的使用
            /*
            //Student st = new Student("小白", 66, 'a');
            //st.ShowInfo();
            //st.Test();
            //st.BaseShowInfo(); // 通过base调用父类成员
            #endregion

            #region 里氏转换
            // 1. 父类可以被子类赋值，在参数里若接收父类参数，则可以传入一个子类
            Person p = new Student("学习", 12, '男');
            p.ShowInfo(); // 那么调用的就是父类的相关函数了
                          //p.BaseShowInfo(); 无法调用  子类的成员会被隐藏（无法调用）

            // 2.如果这个父类是被子类赋值的，那么可以将其强转为子类
            // 经常用is as判断 父子能否转换

            // is 返回的是 bool
            //if (p is Student)
            //{
            //    Student st = (Student)p;
            //    st.ShowInfo();
            //    st.BaseShowInfo();
            //}
            //else
            //{
            //    Console.WriteLine("无法转换");
            //}

            // as 能转换返回对象，不能则返回null
            Student t = p as Student;
            if (t == null)
            {
                Console.WriteLine("无法转换");
            }
            else
            {
                Student st = (Student)p;
                st.ShowInfo();
                st.BaseShowInfo();
            }


            */
            #endregion
        }


    }
}
