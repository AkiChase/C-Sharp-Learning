using System;

namespace 基础语法
{
    internal class Chapter5
    {

        // 枚举类型的变量
        //枚举列表中的每个符号代表一个整数值，一个比它前面的符号大的整数值
        //默认情况下，第一个枚举符号的值是 0
        private enum Sex
        {
            woman = 0, // =0可以省略
            man //省略了=1
        };

        public void Content()
        {
            //类型转换 有隐式转换和显式转换
            // 编译器的隐式转换要求数据转换后精度不下降等等（要求安全的转换）
            double num1 = 3.14159;
            //int num2 = num1; 报错 此处只能显式转换
            int num2 = 333;
            num1 = num2; //此处成功隐式转换
            Console.WriteLine("num1={0}  num2={1}", num1, num2);

            //显式转换（强制转换）
            num1 = 1.123;
            num2 = (int)num1; //会丢失额外的数据，兼容的仅丢失精度，不兼容如会溢出的就不一定了
            Console.WriteLine("num1={0}  num2={1}", num1, num2);

            //通过checked可以检测转换是否溢出，若有需要再具体看
            //若用Convert转换时就会进行溢出检查，所以不兼容的会报错

            // 枚举有点像一个双向的字典
            Console.WriteLine($"Sex.man = {((int)Sex.man)}");
            Console.WriteLine($"1 = {((Sex)1)}");



        }
    }
}
