using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p;
            p = new Person();
            p.Name = "张三";
            p.Age = 123;
            p.Sex = '？'; //通过属性对字段的保护，避免非法值

            Person.Nation = "a"; //通过属性赋值静态字段
            p.showInfo();

            Console.WriteLine("-------------------------");

            // 静态类无法实例化
            Student.Name = "啊啊啊";
            Student.ShowInfo();

            Console.WriteLine("-------------------------");
            Teacher t = new Teacher("里昂", 66);
            t.ShowInfo();
            t = null; //因为t不再指向原来的对象了，自动垃圾回收无用的对象
            

        }
    }
}
