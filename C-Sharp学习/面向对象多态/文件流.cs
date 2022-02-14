using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace 面向对象多态
{
    [Serializable] // 表示类可以被序列化，但类就不能被继承了
    internal class Person2
    {
        public Person2(string name)
        {
            Name = name;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void SayHello()
        {
            Console.WriteLine("我是人类, 我叫{0}", Name);
        }
    }


    internal class 文件流
    {
        /// <summary>
        /// 复制文件,覆盖目标位置
        /// </summary>
        /// <param name="source">源文件</param>
        /// <param name="target">目标位置</param>
        public static void CopyFile(string source, string target)
        {
            using (FileStream fsRead = new FileStream(source, FileMode.Open, FileAccess.Read))
            {
                byte[] buf = new byte[1024 * 1024]; //1M每次

                // 覆盖 target
                using (FileStream fsWrite = new FileStream(target, FileMode.Create, FileAccess.Write))
                {
                    while (true)
                    {
                        int r = fsRead.Read(buf, 0, buf.Length);
                        if (r == 0)
                            break;
                        fsWrite.Write(buf, 0, r);
                    }
                }

            }
        }

        public static void Content()
        {
            #region FileStream 操作字节
            // 读文件
            //  打开文件  FileMode打开模式  FileAccess权限 Read、Write、ReadWrite

            //FileStream fs = new FileStream("../测试.txt", FileMode.Open, FileAccess.Read);
            //byte[] buf = new byte[1024 * 1024]; //1M的空间
            //int r = fs.Read(buf, 0, buf.Length); //返回实际读取到的字节数
            //string s = Encoding.UTF8.GetString(buf, 0, r);
            //Console.WriteLine(s);
            //fs.Close();
            //fs.Dispose();

            // 使用 using() 省去Closs Dispose步骤
            using (FileStream fs = new FileStream("../测试.txt", FileMode.Open, FileAccess.Read))
            {
                byte[] _buf = new byte[1024 * 1024]; //1M的空间
                int _r = fs.Read(_buf, 0, _buf.Length); //返回实际读取到的字节数
                string _s = Encoding.UTF8.GetString(_buf, 0, _r);
                Console.WriteLine(_s);
            }
            Console.WriteLine("文件读取完成!");

            //写文件
            // 若要覆盖文件则使用Create(等效于：如果文件不存在，则使用 CreateNew；否则使用 Truncate)
            using (FileStream fs = new FileStream("../测试.txt", FileMode.Create, FileAccess.Write))
            {
                string _s = "这是要写入\n的内容";
                byte[] _buf = Encoding.UTF8.GetBytes(_s);
                fs.Write(_buf, 0, _buf.Length);
            }
            Console.WriteLine("文件写入完成!");

            // 实现文件复制
            //CopyFile(@"C:\Users\如初\Pictures\壁纸\ヒトこもる.jpg", @"C:\Users\如初\Desktop\test.jpg");
            //Console.WriteLine("文件复制完成");
            #endregion

            #region StreamReader StreamWriter
            using (StreamReader sr = new StreamReader("../测试.txt"))
            {
                while (!sr.EndOfStream)
                    Console.WriteLine(sr.ReadLine());
            }

            using (StreamWriter sw = new StreamWriter("../测试.txt")) //默认覆盖文件
            {
                sw.WriteLine("测试一下");
            }
            #endregion

            #region 序列化和反序列化  将对象转化为二进制文件
            using (FileStream fsWriter = new FileStream("../序列化对象.txt", FileMode.Create, FileAccess.Write))
            {
                Person2 p = new Person2("李明");
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fsWriter, p); //序列化并保存
            }
            Console.WriteLine("序列化成功!");

            using (FileStream fsReader = new FileStream("../序列化对象.txt", FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Person2 p2 = (Person2)bf.Deserialize(fsReader);
                p2.SayHello();
            }

            #endregion

        }
    }
}
