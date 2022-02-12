using System;

namespace 基础语法
{
    internal class Chapter5
    {

        // 枚举类型的变量
        // 默认情况下，枚举中的每个元素的基础类型是int。可以使用冒号指定另一种整数值类型
        //枚举列表中的每个符号代表一个整数值，一个比它前面的符号大的整数值
        //默认情况下，第一个枚举符号的值是 0
        public enum Sex //默认访问权限是 public  默认的类型是int //但是嵌套类型会将默认变为private
        {
            woman = 0, // =0可以省略
            man //省略了=1
        };

        private struct Mydata //默认访问权限也是public 但也有嵌套类型的影响
        {
            // 加上_表明这是字段不是变量（规范）
            public string _name; //注意每一个都要加上public，默认访问权限是private（可以看做嵌套类型导致）
            public Sex _sex;
        }

        public void Content()
        {
            #region 类型转换 有隐式转换和显式转换
            // 编译器的隐式转换要求数据转换后精度不下降等等（要求安全的转换）
            double num1 = 3.14159;
            //int num2 = num1; 报错 此处只能显式转换
            int num2 = 333;
            num1 = num2; //此处成功隐式转换
            Console.WriteLine("num1={0}  num2={1}", num1, num2);

            //注意两个int的运算还是得到int 如10/3 = 3
            Console.WriteLine(10 / 3);
            Console.WriteLine("{0:0.0000}", (double)10 / 3); //至少需要一个double 将整个表达式提升为double精度
            // ToString也能直接保留位数
            double num3 = 3.666666666666;
            Console.WriteLine(num3.ToString("0.00"));


            //显式转换（强制转换）
            num1 = 1.123;
            num2 = (int)num1; //会丢失额外的数据，兼容的仅丢失精度，不兼容如会溢出的就不一定了
            Console.WriteLine("num1={0}  num2={1}", num1, num2);

            Console.WriteLine("int最大范围值：{0}", int.MaxValue);

            //通过checked可以检测转换是否溢出，若有需要再具体看
            //若用Convert工厂转换时就会进行溢出检查等等，所以不兼容的会报错

            //可以用 xxx.Parse 将字符串转化为xxx （Convert也是调用了xxx.Parse）
            double.Parse("132.123");

            // 可以使用xxx.TryParse(string， out) //尝试转换为int
            int n1;
            bool flag = int.TryParse("123", out n1);
            if (flag)
                Console.WriteLine("转换成功:{0}", n1);
            else
                Console.WriteLine("转换失败！");

            #endregion

            #region 变量的作用域仅仅在括号内
            //int index = 1;
            //while (index-->0)
            //{
            //    int newInt = 666;
            //}
            //Console.WriteLine(newInt); //所以此处无法访问 newInt
            #endregion

            #region 异常捕获
            //异常捕获  catch可以不写
            string s = "aaa";
            try
            {
                int newInt = Convert.ToInt32(s);
            }
            catch (InvalidCastException e) //捕获此类型
            {
                Console.WriteLine(e);
                Console.WriteLine("\"aaa\"无法转化为数字");
            }
            catch //可以捕获任意类型
            {
                Console.WriteLine("\"aaa\"无法转化为数字~");
            }
            finally
            {
                Console.WriteLine("不论是否有异常都运行");
            }
            #endregion

            // 随机数
            Random r = new Random(); //不填参数 默认使用time种子
            Console.WriteLine("非负随机整数：{0}", r.Next());
            Console.WriteLine("1-10随机整数：{0}", r.Next(1, 10));
            Console.WriteLine("1-0随机double：{0}", r.NextDouble());

            // 常量
            const int cNum = 666;
            Console.WriteLine("常量{0}", cNum);

            #region 枚举
            // 常见的用法就是把枚举类型当作一个常量类型来使用
            // 若不需要枚举具体的值，那么可以像字符串一样使用
            // 若用到枚举的值，可以像双向字典一样使用
            Console.WriteLine($"Sex.man = {((int)Sex.man)}");
            Console.WriteLine($"1 = {((Sex)1)}"); //若转化不了的，会输出原来的值
            Sex sex = Sex.woman;
            Console.WriteLine($"sex = {sex}"); // 会输出woman  枚举类型可以转化为字符串类型

            // 基本所有的类型都能转化为string
            // 字符串类型可以用枚举的Parse来解析为通用枚举类型，然后再显示转化为自己的枚举类型
            // 通用枚举类型当然可以直接ToString
            // 从值和名都能解析
            // 若不存在能解析的，会报错（可以用TryParse）
            Console.WriteLine((Sex)Enum.Parse(typeof(Sex), "woman"));
            Console.WriteLine((Sex)Enum.Parse(typeof(Sex), "1"));
            #endregion

            #region struct 结构体
            Mydata md;
            md._name = "aaa";
            md._sex = Sex.man;
            Console.WriteLine("结构体md: _name字段：{0}\t_sex字段: {1}", md._name, md._sex);
            #endregion

            #region 数组
            int[] nums = new int[10]; // 会初始化为0 不能动态扩容！
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i + 10;
            }

            //string[] 默认值为null  bool[]为false
            Mydata[] datas = new Mydata[3]; //自定义类型也可以

            int[] nums2 = { 1, 2, 3, 2, 3, 6, 0, -1 }; // 等同于 new int[3]{1,2,3}  int[3]的3可以省略
            //int[] nums3 = new int [10]{ 1, 2, 3 }; 这样是不行的，指定值就要全部指定

            string s2 = "一二三四五"; // string 可以作为一个每个元素为只读的数组
            Console.WriteLine($"{s2[0]}, {s2[1]}, {s2[2]}");

            //数组两个方法 升序 反转
            Array.Sort(nums2);
            Array.Reverse(nums2);

            for (int i = 0; i < nums2.Length; i++)
            {
                Console.Write($"{nums2[i]} ");
            }
            Console.WriteLine();


            #endregion

        }
    }
}
