using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{

    #region  自定义事件、带参数
    internal class MyTestEvevt
    {
        //声明委托
        //其实这个sender不是必须的
        //若需要访问sender内的成员时，才需要加上这个sender
        //触发事件时的sender不一定要是this，可以是任何对象

        //只是这样是符合规范的（符合 .NET 准则）
        public delegate void TestHandler(object sender, TestEventArgs e);

        // 事件声明
        // 声明一下事件的名字为TestEvent 会触发TestHandler类型的回调函数(委托)
        // 之后就可以给TestEvent事件添加具体的回调函数（当然这个回调函数必须和委托类型一致）
        public event TestHandler TestEvent;

        // 定义事件参数类
        public class TestEventArgs
        {
            // 构造函数
            public TestEventArgs(string foo) { Foo = foo; }
            // 重载构造函数
            public TestEventArgs(int bar) { Bar = bar; }
            public TestEventArgs(string foo, int bar) { Foo = foo; Bar = bar; }

            public string Foo { get; set; } = "aaa"; //设置默认值
            public int Bar { get; set; } = 666;
        }

        public string Name { get; set; }
        // 定符合TestHandler委托的函数
        public void SomeFunc(object sender, TestEventArgs arg)
        {
            Console.WriteLine((sender as MyTestEvevt).Name);
            Console.WriteLine("触发事件:函数1,参数Foo:{0}", arg.Foo);
        }

        public void SomeFunc2(object sender, TestEventArgs arg)
        {
            Console.WriteLine("触发事件:函数2,参数Bar:{0}", arg.Bar);
        }

        public void SomeFunc3(object sender, TestEventArgs arg)
        {
            Console.WriteLine("触发事件:函数3,参数Foo:{0}, 参数Bar:{1}", arg.Foo, arg.Bar);
        }

        public void CallEvent()
        {
            //此处把
            TestEvent(this, new TestEventArgs(123));
        }

        public void DoSomeThing()
        {
            Console.WriteLine("做了什么什么什么");
            Console.WriteLine("在某某某情况下，触发事件");
            TestEvent(this, new TestEventArgs(123));
        }

    }
    #endregion

    #region 使用内置 EventHandler<>事件
    // 如果用这种方式把事件单独写一个类 sender一般没什么用
    // 可以考虑把事件相关内容写进需要用到事件的类中
    internal class SomeEvent
    {
        // EventHandler是无参委托 里面需要的EventArgs不能绑定参数
        public event EventHandler XxxNoArgEvent;

        // EventHandler<MyArg>等同于
        // delegate void System.EventHandler <MyArg>(object sender, MyArg e)
        public event EventHandler<MyArg> XxxWithArgEvent;

        // 定义参数类
        // MyArg可以继承于EventArgs（比较规范,当然不继承也能运行）
        public class MyArg
        {
            public MyArg(int num, string name) // 构造函数
            {
                Num = num;
                Name = name;
            }

            public int Num { get; set; }
            public string Name { get; set; }
        }

        //为了在类外能触发事件，定义触发方法
        public void InvokeNoArgEvent()
        {
            // 基本等同于if (xxx !=null){XxxNoArgEvent(this, ...)}
            // Invoke与多线程有关，这里先不管
            XxxNoArgEvent?.Invoke(this, new EventArgs());
        }

        public void InvokeWithArgEvent(int num, string name)
        {
            XxxWithArgEvent?.Invoke(this, new MyArg(num, name));
        }

        public void SomeFunc()
        {
            Console.WriteLine("调用了类内方法");
        }

    }


    #endregion

    internal class 事件
    {
        // 事件 大致等于 回调

        public static void Content()
        {
            //使用自定义事件
            #region 使用自定义事件
            // 为了能使用MyTestEvevt类中的事件，需要实例化MyTestEvevt
            // 当然可以把MyTestEvevt类中的事件等等都直接写在能直接访问的地方，就可以不需要实例化
            MyTestEvevt myTestEventIns = new MyTestEvevt();
            // 为该事件添加函数
            myTestEventIns.TestEvent += new MyTestEvevt.TestHandler(myTestEventIns.SomeFunc);
            myTestEventIns.TestEvent += new MyTestEvevt.TestHandler(myTestEventIns.SomeFunc2);
            myTestEventIns.TestEvent += new MyTestEvevt.TestHandler(myTestEventIns.SomeFunc3);

            //在使用事件时如果事件的定义和调用不在同一个类中，实例化的事件只能出现在 += 或者 -= 操作符的左侧
            //所以只能在事件所在的类中触发事件
            myTestEventIns.DoSomeThing();
            #endregion

            #region 使用内置 EventHandler<>事件
            SomeEvent xxxEvent = new SomeEvent();
            xxxEvent.XxxNoArgEvent += CallBackNoArg;
            // 用匿名方法的形式添加事件回调
            xxxEvent.XxxNoArgEvent += (sender, e) => { Console.WriteLine("匿名方法的形式添加回调"); };

            xxxEvent.XxxWithArgEvent += CallBackWithArg;

            //这里写什么什么情况下，触发事件
            xxxEvent.InvokeNoArgEvent();
            Console.WriteLine("--------------------");
            xxxEvent.InvokeWithArgEvent(666, "测试");


            #endregion
        }

        private static void CallBackWithArg(object sender, SomeEvent.MyArg e)
        {
            (sender as SomeEvent).SomeFunc();
            Console.WriteLine("事件传参:num={0}, name={1}", e.Num, e.Name);
        }

        private static void CallBackNoArg(object sender, EventArgs e)
        {
            //这儿的e没啥用

            // 可以调用对象内的成员
            (sender as SomeEvent).SomeFunc();
            Console.WriteLine("无参数事件");
        }
    }
}
