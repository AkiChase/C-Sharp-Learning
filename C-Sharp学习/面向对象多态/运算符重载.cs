using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{
    internal class Foo
    {
        public Foo(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        //运算符重载 语法类似于C++
        //注意一定要 public static

        //二元运算符
        public static Foo operator +(Foo f1, Foo f2)
        {
            return new Foo(f1.Name + "|" + f2.Name, f1.Age + f2.Age);
        }

        //一元运算符
        //注意修改的是引用类型
        public static Foo operator -(Foo f)
        {
            f.Age = -f.Age;
            return f;
        }

        // 重写ToString()
        public override string ToString()
        {
            return $"Name={Name}, Age={Age}";
        }
    }

    internal class 运算符重载
    {
        public static void Content()
        {
            Foo f1 = new Foo("测试", 1);
            Foo f2 = new Foo("啊啊", 2);
            Console.WriteLine(f1);
            Console.WriteLine(f2);
            Foo f3 = f1 + f2;
            Console.WriteLine(f3);
            Console.WriteLine(-f3);
            //注意f3的变化
            Console.WriteLine(f3);

        }
    }
}
