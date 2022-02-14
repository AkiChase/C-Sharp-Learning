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
        public static void Content()
        {
            Console.WriteLine(new ToStringOverride().ToString());
        }
    }
}
