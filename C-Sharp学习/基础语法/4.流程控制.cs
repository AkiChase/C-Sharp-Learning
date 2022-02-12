using System;

namespace 基础语法
{
    internal class Chapter4
    {
        /// <summary>
        /// 显示a,b变量的值
        /// </summary>
        /// <param name="a">第一个布尔值</param>
        /// <param name="b">第二个布尔值</param>
        private void ShowAandB(bool a, bool b)
        {
            Console.WriteLine($"a = {a}\tb = {b}");
        }

        public void Content()
        {
            bool a = true;
            bool b = false;
            ShowAandB(a, b);

            // 布尔运算符 注意&&的优先级高于||  此外&&具有逻辑优化，若左边为false不再计算右边
            bool c;
            c = a && b;
            Console.WriteLine(c);

            // 位运算符 &,|,^,~,<<,>>   &=,|=,^=等等
            // 其中^是异或
            /*
            A = 0011 1100
            B = 0000 1101
            -----------------
            A&B = 0000 1100
            A|B = 0011 1101
            A^B = 0011 0001
            ~A  = 1100 0011
             */

            //三元运算符
            Console.WriteLine(c ? "c为true" : "c为false");
            // 一行可以不加{}
            if (c)
                Console.WriteLine("c为true");
            else
                Console.WriteLine("c为false");

            Console.WriteLine("输入数字:");
            int num;
            num = Convert.ToInt32(Console.ReadLine());
            // 会依次比较case的条件，满足则进入
            switch (num) // C#中 强制要求break 无法连续运行case
            {
                case 0:
                    Console.WriteLine("你输入了0");
                    break;
                case 1:
                    Console.WriteLine("你输入了1");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("你输入了2或3");
                    break;
                default:
                    Console.WriteLine("你输入了0、1、2、3之外的数字");
                    break;
            }


            //do while循环
            Console.WriteLine("do while循环");
            num = 0;
            do
            {
                Console.Write("num={0}\t", num);
            } while (num++ < 4);

            //while循环 略
            Console.WriteLine("\nfor循环：");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("i={0}\t", i);
            }

            Console.WriteLine();
        }
    }
}
