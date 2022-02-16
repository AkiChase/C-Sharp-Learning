using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 面向对象多态
{
    internal class LINQ查询
    {
        public static void Content()
        {
            /*
             LINQ查询
            LINQ是C＃和VB.NET中内置的结构化查询语法
            用于从不同类型的数据源（例如集合，ADO.Net DataSet，XML Docs，Web服务和MS SQL Server和其他数据库）中检索数据。
             */

            //数组查询
            string[] names = { "Bill", "Steve", "James", "Mohan" };

            // LINQ lambda方式
            // 用var 自动推断类型
            var query1 =
                names.Where(name => name.Contains('a'))
                .OrderByDescending(name => name) // OrderBy是升序
                .Select(name => name);

            // 非lambda方式
            var query2 = from name in names
                         where name.Contains('a')
                         orderby name descending // 逆序
                         select name;

            // 查询执行
            Console.WriteLine(string.Join(", ", query1));
            Console.WriteLine(string.Join(", ", query2));
        }
    }
}
