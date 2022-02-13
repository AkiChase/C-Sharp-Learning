using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Text;

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

    internal static class 其他补充
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
        private static void ShowListInfo(ArrayList l)
        {
            Console.WriteLine("集合大小为:{0}", l.Count);
            Console.WriteLine("集合容量为:{0}", l.Capacity);
        }

        public static void Content()
        {
            #region 引用另一个项目的类
            //1.在右侧引用内添加另一个项目  2.使用命名空间.类 (或者用using)
            //面向对象.Person p = new 面向对象.Person();
            #endregion

            #region 引用类型注意
            // 注意 string、自定义类、数组等等 都是属于引用类型 储存在内存的堆区
            // 即 string s = "123"   其中 "123"存在堆区  而s其实是"123"的地址，存在栈区
            // 所以函数中使用这些引用类型做参数时要注意！传入的都是引用(不需要指定ref)

            //int[] arr = { 1, 2 };
            //test(arr);
            //Console.WriteLine(arr[1]);

            //Test t = new Test();
            //test(t);
            //Console.WriteLine(t._test);
            #endregion

            #region 字符串
            /*
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

            //对于需要频繁改变、拼接的字符串 可以使用 StringBuilder 执行速度非常快，不需要每次都新建一个字符串
            //最后再ToString
            Stopwatch sw = new Stopwatch();  //Stopwatch 用于计时
            sw.Start();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                sb.Append(i);
            sw.Start();
            Console.WriteLine("耗时：{0}", sw.Elapsed);
            //s = sb.ToString();

            // String的一些方法
            s = "ABC啊啊啊CDE";
            Console.WriteLine(s.ToLower());
            if (s.Equals(s.ToLower(), StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("忽略大小写条件下，两字符串相等");
            }

            // 分割字符串
            string[] sArr = "1，，2，3，，4，5|6|7".Split(new char[] { '，', '|' }
            , StringSplitOptions.RemoveEmptyEntries); //匿名数组 移除空的元素（默认会保留空的元素）
            //  new[] {...}也可以指定推断类型

            // 替换
            s = "替换123为一二三";
            Console.WriteLine(s.Replace("123", "一二三"));

            // 截取
            Console.WriteLine(s.Substring(0, 2));


            //s.StartsWith();
            //s.EndsWith();
            int index = s.IndexOf("123");
            Console.WriteLine(index != -1 ? "找到了123" : "未找到123");
            // 若要查找第二个。需要调用两次indexof
            // 查找最后一个
            index = s.LastIndexOf("一二三");
            Console.WriteLine(index);

            //Trim TrimEnd TrimStart
            // 默认除去 换行、空格、制表
            // 可以用params参数替换默认
            Console.WriteLine("   \t\t\n a哦吼吼  \r\n".Trim());

            // string类的静态方法

            //判断是否为空的两种
            //string.IsNullOrEmpty(s);
            //string.IsNullOrWhiteSpace(s);

            // Join 方法 传入分隔符和params字符串数组
            Console.WriteLine(string.Join(" | ", "一", "尔尔", "闪闪闪"));
            */
            #endregion

            #region 文件读取
            //string path = @"xxx";
            //string[] lines = File.ReadAllLines(path, Encoding.Default);
            #endregion

            #region ArraryList 集合
            // 长度可变，类型随意(包括数组、集合）  也是引用类型
            // list每次扩容一般都是原有空间的2倍
            ArrayList list = new ArrayList();
            list.Add(1); list.Add(3.1415); list.Add("测试");

            list.AddRange(list); //将一个数组、集合 添加到当前list
            list.Insert(0, "啊啊啊");
            //list.InsertRange 类似 AddRange
            for (int i = 0; i < list.Count; i++)
                Console.WriteLine(list[i]);

            //list.Clear(); //清空
            //list.Remove("测试"); //删除第一个匹配项
            //list.RemoveAt(1); // 删除指定索引
            //list.RemoveRange(0, 2); //删除索引起的n个元素
            //list.Sort() // 排序，可以指定比较器，指定范围
            //list.Reverse() //反转
            //list.Contains("测试"); 返回bool

            ShowListInfo(list);
            

            #endregion

        }


    }
}
