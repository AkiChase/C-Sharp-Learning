using System;

namespace 基础语法
{
    internal class Chapter6
    {
        public int _number = 0; //类的字段

        void Test() // 私有的 非静态的
        {
            _number++;
            Console.WriteLine("这是一个测试函数,_number:{0}", _number);
        }

        public int Add(int a, int b)
        {
            return a + b;
        }

        //当需要返回多个不同类型的值时，考虑out关键字来修饰形参

        public void OutTest(int a, out int num, out string name)
        {
            // out 参数要求 附加了out关键字的形参必须为其 赋值
            // 因为 out 参数并不会将实参的值传入！！
            num = a + 100;
            name = $"num = {num}";
        }


        public void RefTest(ref int a)
        {
            a = 1234;
        }

        //在方法声明中的 params 关键字之后不允许任何其他参数
        //并且在方法声明中只允许一个 params 关键字
        public string Join(string sep, params int[] arr)
        {
            string res = null;
            for (int i = 0; i < arr.Length; i++)
            {
                res += arr[i] + sep;
            }
            return res.Substring(0, res.Length - sep.Length);
        }

        private void ReloadTest(int a)
        {
            Console.WriteLine("ReloadTest(int a)");
        }
        private void ReloadTest(out int a)
        {
            a = 666;
            Console.WriteLine("ReloadTest(out int a)");
        }
        //private void ReloadTest(out int a); // 不允许仅仅out和ref区别的重载

        private static int _times = 1;
        private void 方法的递归()
        {
            Console.WriteLine("第{0}次调用", _times);
            if (++_times >= 5)
                return;
            方法的递归();
            Console.WriteLine("最终结束:{0}", _times);
        }

        public void Content()
        {
            Test();

            #region out的使用
            int num = 0;
            string s = "无";
            Console.WriteLine("num = {0}  s={1}", num, s);


            OutTest(566, out num, out s); // 函数内使用到out形参的值，但传入的确实是引用
            // OutTest(566, int out n1, string out s1); 也可以在参数列表中声明，更加简洁
            Console.WriteLine(num);
            Console.WriteLine(s);

            // TryParse()函数就使用了out
            bool flag = int.TryParse("121aa", out num);
            if (flag)
                Console.WriteLine("转化成功, num={0}", num);
            else
                Console.WriteLine("转化失败, num被覆盖为:{0}", num);

            #endregion

            #region ref的使用
            // ref的使用相对更简洁，类似c++的&,只是在参数列表就要标明ref
            // 但是方法外就需要对其赋值！！！没赋值的不能用
            RefTest(ref num);
            Console.WriteLine("num = {0}", num);
            #endregion

            #region params的使用
            // params
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            Console.WriteLine(Join(", ", nums)); // 可以直接传入一个数组
            Console.WriteLine(Join(", ", 9, 8, 7, 6)); // 也可以传入多个元素构成一个数组
                                                       // 甚至可以不传入 params修饰的参数
            #endregion

            #region 函数重载
            // 函数重载 同C++
            // 参数类型不同或者个数不同（与返回值无关）
            // 注意 out ref也会引起重载，但仅仅out和ref修饰存在区别的，不允许重载
            ReloadTest(1);
            ReloadTest(out int n1);
            Console.WriteLine(n1);
            #endregion


            #region 方法的递归
            //方法自己调用自己，会立即进入新的方法
            // 而每次return 都会回到上一次调用方法的地方
            方法的递归(); //函数名甚至都可以用中文
            #endregion
        }
    }
}
