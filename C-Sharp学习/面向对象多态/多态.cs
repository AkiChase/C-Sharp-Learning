using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{
    #region 虚方法
    internal class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        //private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}

        //使用自动属性:编译器会自动补充一个私有字段（名称不定）,并补充get、set方法
        public string Name
        {
            get;
            set; //不声明set访问器时，仅能在构造函数中set
        }



        public virtual void SayHello() //标记 virtual 则此函数 可以 被子类重写
        {
            Console.WriteLine("我是人类, 我叫{0}", Name);
        }
    }

    internal class Chinese : Person
    {
        public Chinese(string name) : base(name) { }

        public override void SayHello() // override覆盖
        {
            Console.WriteLine("我是中国人, 我叫{0}", Name);
        }
    }

    internal class American : Person
    {
        public American(string name) : base(name) { }

        public override void SayHello()
        {
            Console.WriteLine("我是美国人, 我叫{0}", Name);
        }
    }
    #endregion

    #region 抽象类
    // 抽象类中可以写非抽象方法！！ 虽然抽象类不可以实例化，但其非抽象子类可以，所以可以调用父类的这个方法
    internal abstract class Animal
    {
        // 抽象属性
        public abstract string Type
        {
            get;
        }

        public void Test() //非抽象方法测试
        {
            Console.WriteLine("抽象类非抽象方法测试");
        }

        // 抽象方法子类必须重写
        public abstract void SaySomething();

    }

    internal class Cat : Animal
    {
        // 必须 override 抽象属性
        public override string Type
        {
            get { return "小猫"; }
        }

        // 必须 override 抽象方法
        public override void SaySomething()
        {
            Console.WriteLine("喵喵~");
        }
    }

    internal class Dog : Animal
    {
        // 必须 override 抽象属性
        public override string Type
        {
            get { return "修勾"; }
        }

        // 必须 override 抽象方法
        public override void SaySomething()
        {
            Console.WriteLine("汪汪汪!");
        }
    }

    #endregion

    #region 接口
    // 加上 interface关键字
    // 命名一般以I开头 able结尾
    // 默认就是public权限，低版本不能加权限修饰
    // 所有成员不能定义, 且不能加字段(因为是一种能力、规范)  接口当然也不能实例化
    // 但是可以加属性的定义（因为是方法）

    // 接口可以继承于接口（不能继承于类）！这样就可以把多个接口继承（集成）到一个子接口里
    // 那么需要多个接口的类就只需要继承这一个接口就行
    internal interface I拆家able
    {
        void 拆家();
        string Tttt // 这个不是自动属性！
        {
            get;
            set;
        }
    }

    //让一个类继承这个接口
    // 那么这个类中需要实现接口中定义的所有成员
    internal class 哈士奇 : Dog, I拆家able  // 注意基类必须写在接口前面
    {
        string I拆家able.Tttt // 显示实现接口中的属性（调用显示实现接口属性时必须把对象类型转为相应接口类型）
        {
            get { return "不管你说啥，就是可以"; }
            set { }
        }

        // 显式实现是为了避免多个接口中若存在相同的成员，所以加上接口前缀
        // 但调用时会更麻烦
        // 所以若无相同成员，尽量不用显式实现
        public void 拆家()
        {
            Console.WriteLine("我会拆家噢");
        }
    }


    #endregion

    internal class 多态
    {
        public static void Content()
        {
            // 让一个对象表现出多种的状态（类型）

            // 1. 虚方法 即在基类中用 virtual标记，派生类中用 override标记 使得子类重写虚方法

            Person[] persons = new Person[2];
            persons[0] = new Chinese("王宝强");
            persons[1] = new American("奥巴马");
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i].SayHello();
            }
            Console.WriteLine("----------------------");
            // 2. 抽象类(抽象方法)     （和C++纯虚不完全一样
            // 抽象类存在的意义就是其中可以定义抽象方法，抽象方法必须让子类重写
            // 抽象类无法实例化

            // 抽象类中可以定义非抽象方法，在子类对象中调用到
            // 甚至可以在抽象类中定义虚方法，子类视情况重写
            //Cat c = new Cat();
            //c.Test();

            Animal[] animals = { new Cat(), new Dog() };
            foreach (var item in animals)
            {
                Console.Write(item.Type); //抽象属性的多态
                item.SaySomething();
            }

            // 其实虚方法和抽象类两种方式的区别在于：父类是否需要实现这个方法

            // 简单工厂模式
            /*
             * 对于需要获取多种不同类型的对象
             * 可以定义一个抽象的父类，子类对父类内容进行重写
             * 而获取时就先令 父类 foo = null; foo = new 子类();
             * 这就是简单工厂模式（多态的应用）
             */


            Console.WriteLine("----------------------");

            /*
             * 3.接口
             * 类继承有单根性，即只能继承于一个 类   （一个类，不包括接口，即此外还能继承于接口）
             * 所以类需要多继承时就要考虑接口
             * 接口可以理解为一种规范、能力
             */

            哈士奇 hsq = new 哈士奇();
            hsq.SaySomething();
            hsq.拆家();
            // as的用法等同于 xxx is yyy_type ? (yyy_type)xxx : (yyy_type)null
            Console.WriteLine((hsq as I拆家able).Tttt); //显示实现调用很麻烦

        }
    }
}
