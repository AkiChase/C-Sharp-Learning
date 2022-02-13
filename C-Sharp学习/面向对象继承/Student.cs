using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象继承
{
    // 继承 Person  派生类（子类）
    // 1.继承有单根性，只能有一个基类
    // 2.传递性,一次次继承的方法、属性、字段等等会继续传递下去  （可以参看类图 看不同类的关系）
    // 3.子类不会继承父类的构造函数，但是子类实例化时要先创建一个父类对象（默认调用无参的构造！！）
    // 4.析构时先调用子类的析构，再调用父类的析构
    // 5.Object是所有类的基类
    // 6.对于同名成员(包括字段)，子类中的会隐藏父类的，但如果是有意隐藏，需要在其中加入关键字new来明示
    // 注意和C++不同，子类父类同名函数可以重载

    // 可以通过 base.xxx来调用父类对象的方法、字段、属性等等（当然只能调用有权限的部分）
    // 通过 this.xxx调用子类对象的东西
    internal class Student : Person //同C++不同，没有继承方式
    {
        public new string _test;
        public void Test()
        {
            Console.WriteLine(_test);
            Console.WriteLine(base._test);
        }

        // 所以要写 base(xxxx)来显式调用父类的某一个构造函数
        public Student(string name, int age, char sex) : base(name, age, sex)
        {
            Console.WriteLine("Student构造函数");
            _test = name;
        }
        ~Student()
        {
            Console.WriteLine("Student析构函数");
        }

        public new void ShowInfo()
        {
            Console.WriteLine("Student重写（隐藏了）父类的ShowInfo！");
        }

        public void BaseShowInfo()
        {
            base.ShowInfo();
        }
    }
}
