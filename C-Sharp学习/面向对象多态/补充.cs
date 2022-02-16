using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{
    #region 部分类
    /*
     * 多个部分类编译时会合并为一个类（其实就是为了多文件、多人编写）
     * 当然，不同部分类中是不能有重复的（因为本质是一个类，当然不能重复）
     */

    internal partial class PartClass
    {
        public void Test() { }
    }

    internal partial class PartClass
    {
        //public void Test() { } //报错
    }

    #endregion

    #region 密封类
    /*
     * 密封类不能被继承！但是可以继承于其他类
     */
    internal sealed class SealedClass : Cat { }

    #endregion

    #region 重写类的ToString方法
    internal class ToStringOverride
    {
        public override string ToString()
        {
            return "这是重写的ToString";
        }
    }


    #endregion

    internal static class 补充
    {
        public delegate void TestDelegate(int n);
        public delegate int TestDelegate2(int n);
        public static void Content()
        {
            Console.WriteLine(new ToStringOverride().ToString());

            TestDelegate t1 = delegate (int num) { Console.WriteLine("aaa"); }; //使用delegate写匿名函数

            // delegate关键字可以省略, 甚至变量类型也可以省略（因为根据委托类型推断）
            TestDelegate t2 = (num) => { Console.WriteLine("bbb"); }; // 使用lamda表达式写匿名函数

            // 若需要返回值，甚至可以省略return 但此时也要去掉{}括号（不能执行多条语句）
            TestDelegate2 t3 = (num) => num + 100;
            Console.WriteLine(t3(123));
        }
    }
}
