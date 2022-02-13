using System;


namespace 面向对象继承
{

    public class Test
    {
        public string _test;
        public Test()
        {
            Console.WriteLine("构造函数");
        }
    }

    internal class Program
    {

        #region 测试引用类型
        static void test(int[] arr)
        {
            arr[1] = 666;
        }

        static void test(Test t)
        {
            t._test = "aaa";
        }
        #endregion

        static void Main(string[] args)
        {
            #region 引用另一个项目的类
            //1.在右侧引用内添加另一个项目  2.使用命名空间.类 (或者用using)
            //面向对象.Person p = new 面向对象.Person();
            #endregion

            #region 引用类型注意
            // 注意 string、自定义类、数组等等 都是属于引用类型 储存在内存的堆区
            // 即 string s = "123"   其中 "123"存在堆区  而s其实是"123"的地址，存在栈区
            // 所以函数中使用这些引用类型做参数时要注意！传入的都是引用(不需要指定ref)

            int[] arr = { 1, 2 };
            test(arr);
            Console.WriteLine(arr[1]);

            Test t = new Test();
            test(t);
            Console.WriteLine(t._test);
            #endregion

            #region 字符串
            // 字符串一旦创建就无法修改
            // 所以之后的每次改变（+=拼接等等）都会产生一个新对象
            // 对于不可变类型
            // 因为旧值依旧会保留一段时间（等到GC判定后自动回收）
            // 所以会使内存有极大开销，也会给GC造成回收负担，性能也比可变集合差的多。

            // 而相同的字符串会共享同一个内存（都指向同一块空间）


            // 字符串类似 const char[] 只读char数组
            // 所以修改某几个字符的方法：转化为char[] 然后修改，然后新建字符串
            string s = "一二三四五";
            Console.WriteLine(s);
            char[] chArr = s.ToCharArray();
            chArr[0] = '嘿';
            s = new string(chArr);
            Console.WriteLine(s);

            #endregion


        }
    }
}
