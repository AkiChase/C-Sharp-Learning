//在外部的代码则是全局的
//外部可以使用空间内的类等等 但要用  命名空间.xxx来访问
//如 new 基础语法.KKK()


namespace 基础语法 //命名空间 不同文件可以用相同的命名空间
{
    internal class Program // Program类名不是固定的
    {
        static void Main(string[] args)
        {
            //new Chapter3().Content(); //3.变量、表达式、名称空间
            //new Chapter4().Content(); //4.流程控制
            new Chapter5().Content(); //5.变量的更多内容
        }
    }
}

