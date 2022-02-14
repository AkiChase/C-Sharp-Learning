using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{
    internal class 泛型
    {

        public static void Content()
        {
            #region List泛型
            // 用法等同于 ArryList 但是只能储存同类的元素
            // 可以转化为数组

            List<int> list = new List<int>();
            list.Add(1);
            list.AddRange(new int[] { 2, 3, 4, 5 });

            int[] newArr = list.ToArray();
            //newArr.ToList(); //两者可以互相转换
            
            Console.WriteLine(string.Join(", ", newArr));

            #endregion

            #region 装箱 拆箱
            // 发生装箱、拆箱的前提是类型转化的两者存在继承关系

            // 将值类型转化为引用类项就是装箱
            int n = 10;
            object o = n;
            // 将引用类型转化为值类型是拆箱
            int n2 = (int)o;

            // 对于 ArraryList
            // 每次Add要求传入的都是object(属于引用类型)，若我们传入了值类型，那么编译器会补充对其进行装箱的操作
            // 所以效率更低
            // 而List<int> 每次Add要求传入的就是int 不需要装箱
            #endregion

            #region Dictionary泛型
            // 用法基本等同于Hashtable
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("啊啊", "asd");
            dict.Add("oo", "asd");
            dict["123"] = "666";


            // 对于Dictionary遍历，比Hashtable更方便
            // 可以使用 KeyValuePair<> 范型
            //foreach (KeyValuePair<string, string> kv in dict)
            //    Console.WriteLine($"键:{kv.Key}  值:{kv.Value}");
            foreach (var kv in dict) //用var推断类型
                Console.WriteLine($"键:{kv.Key}  值:{kv.Value}");



            #endregion
        }
    }
}
