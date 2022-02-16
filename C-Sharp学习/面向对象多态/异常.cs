using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{

    // 定义一个自定义异常
    public class MyException : Exception
    {
        public MyException(string message) : base(message) { }
        // 可以再附加更底层的异常信息，通过 e.InnerException来查看
        public MyException(string message, Exception inner) : base(message, inner) { }
    }

    internal class 异常
    {
        public static void Content()
        {
            int[] arr = { 1, 2, 3 };
            try
            {
                try
                {
                    Console.WriteLine(arr[6]);
                }
                catch (IndexOutOfRangeException e)
                {
                    //throw; 什么都不加则重新抛出原异常
                    Console.WriteLine(e.Message);
                    throw new MyException("自定义异常", e);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("原异常为:{0}", e.InnerException.Message);
            }


        }
    }
}
