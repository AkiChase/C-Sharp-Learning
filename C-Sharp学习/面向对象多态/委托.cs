using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{
    internal class 委托
    {
        //delegate 是一种可用于封装命名或匿名方法的引用类型。
        //委托类似于 C++ 中的函数指针
        // 经常用于需要将某函数作为参数传入，然后再调用传入的函数的行为（回调等等）
        public delegate void MyDelegate(string s);
        public delegate int MyDelegate2(int i);


        static void Func1(string s)
        {
            Console.WriteLine("这是函数1, {0}", s);
        }

        static void Func2(string s)
        {
            Console.WriteLine("这是函数2, {0}", s);
        }

        static void SomeFunc(MyDelegate md, string words)
        {
            Console.WriteLine("这是某个函数, 会执行传入的委托");
            md(words);
        }

        public static void Content()
        {
            MyDelegate md1 = new MyDelegate(Func1);
            MyDelegate md2 = new MyDelegate(Func2);
            SomeFunc(md1, "第一句话");
            SomeFunc(md2, "第二句话");

            Console.WriteLine("--------------------");

            // 相同类型的委托可被合并
            // 执行委托时会按顺序执行委托列表
            MyDelegate md = md1 + md2;
            SomeFunc(md, "第三句话");
            Console.WriteLine("--------------------");

            // 使用lambda表达式 创造函数 并添加到委托
            MyDelegate md3 = (string s) => { Console.WriteLine("lambda表达式创造的匿名函数: {0}", s); };
            SomeFunc(md3, "匿名函数委托");
            Console.WriteLine("--------------------");

            // 直接创建匿名函数
            MyDelegate2 md4 = (int num) =>
            {
                num += 666;
                return num;
            };
            Console.WriteLine(md4(111));

            Console.WriteLine("--------------------");
            //为了方便的使用匿名函数，其实C#内置了一些委托类型

            //Action 委托 是void类型的泛形委托
            //<>内填的是传入参数的类型
            //Action至少0个参数，至多16个参数，无返回值
            Action<string, string> ac = new Action<string, string>(
                (string s, string s2) => { Console.WriteLine("使用内置Action委托, {0}, {1}", s, s2); }
                );
            ac("测试1", "测试2");
            Action ac2 = new Action(() => { Console.WriteLine("无参数Action"); });
            ac2();
            Console.WriteLine("--------------------");

            // Func委托 是有返回值的泛型委托
            // Func至多16个参数（不包括返回值），根据返回值泛型返回。必须有返回值，不可void
            Func<int> func1 = new Func<int>(() => { return 666; });
            Console.WriteLine(func1());
        }
    }
}
