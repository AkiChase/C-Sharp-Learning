using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞行棋
{
    internal class Program
    {
        public static void ShowGame()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|********************|");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|********************|");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|*******飞行棋*******|");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|********************|");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("|********************|");
        }


        static void Main(string[] args)
        {
            ShowGame(); // static方法只能调用static方法
        }
    }
}
