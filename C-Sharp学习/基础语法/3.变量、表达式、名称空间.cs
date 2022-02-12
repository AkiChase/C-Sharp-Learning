using System;
using TTTT.TT;


namespace 基础语法 //可以多次使用，会合并
{
    public class KKK
    {
        public string t = "ccc";
    }
}

/// <summary>
/// 这是一个测试的命名空间
/// </summary>
namespace TTTT
{
    namespace TT //命名空间可以套命名空间
    {
        public class Bar
        {
            public string t = "bbb";

            void test()
            {
                string s = Convert.ToString(基础语法.Chapter5.Sex.woman);
            }
        }
    }
    public class Foo
    {
        public string t = "aaa";
    }
}

namespace 基础语法
{
    internal class Chapter3
    {
        public void Content()
        {
            Console.WriteLine(
    @"
@在字符串引号前
可以实现多行文本
");

            /*
             变量命名一般用驼峰法Camel
             类、命名空间命名则用Pascal(即每个单词首字母都大写)
             */

            // 虽然可以用中文变量名，但不建议
            int 数字 = 1;
            Console.WriteLine(数字);

            char ch = '男'; //c#使用unicode
            Console.WriteLine(ch);

            // String 是C++内的，string是关键字，但两者映射到的内容是相同的
            string s = "\"哦豁\"\t";
            s += @"""哦吼"" c:\abc\xxx.x"; //@""类似于python 中的 r"" 但两个引号才转义为一个引号
            // 可以使用_在任何数字中
            // \b表示退格键，但是放在字符串两端时无效
            // 在文本文件里: windows写入\n不会换行，需要\r\n

            Console.WriteLine($"关于字符转义: {s}"); //format方式2

            double d = 1.111_111_11;
            Console.WriteLine("_可以用在任何数字中（仅仅为了代码可读性):d={0}", d); //format方式1

            // 变量名可以以@开头 从而使用保留关键字 (不常用)
            int @int = 66;
            float f = 3.1f; //默认双浮点 结尾加上f才能表示单浮点
            Console.WriteLine($"浮点数:{f:0.0000000}  整数:{@int}");

            // 运算符
            int i1 = -1; // +i1 并不会改变i1的符号,因为+什么也不做，-i1会反转i1的符号
            // + 一元运算符最有用的地方 在于用来重载运算符
            Console.WriteLine($"反转符号:{-i1}");

            //获取用户输入
            Console.WriteLine("请输入一行话:");
            string words = Console.ReadLine();
            Console.WriteLine("你输入了:" + words); //不建议的format方式

            //Convert.Toxxx 进行类型转换 如Convert.toInt32 转为int（32位 4字节）
            Console.WriteLine("请输入数字:");
            Console.WriteLine($"转化为double:{Convert.ToDouble(Console.ReadLine())}");

            TTTT.Foo t = new TTTT.Foo(); // 访问其他命名空间
            Bar t2 = new Bar(); //若有using就不需要前缀了
            KKK t3 = new KKK();
            Console.WriteLine($"访问其他命名空间: {t.t}  {t2.t}  {t3.t}");
        }
    }
}
