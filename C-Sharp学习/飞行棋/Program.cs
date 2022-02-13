using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 飞行棋
{
    internal class Program
    {
        private static int[] _map = new int[100];
        private static int[] _playerPos = new int[2];
        private static string[] _playerName = new string[2];
        private static Random _random = new Random();

        /// <summary>
        /// 显示游戏开始界面
        /// </summary>
        private static void ShowGame()
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

        /// <summary>
        /// 地图初始化
        /// </summary>
        private static void MapInit()
        {
            int[] luckeyTurn = { 6, 23, 40, 55, 69, 83 }; //幸运轮盘☉:1
            int[] landMine = { 5, 13, 17, 33, 38, 50, 64, 80, 94 }; //地雷 ⚛
            int[] pause = { 9, 27, 60, 93 }; //暂停 ⊗
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 }; //时空隧道 卐
            for (int i = 0; i < luckeyTurn.Length; i++)
                _map[luckeyTurn[i]] = 1;
            for (int i = 0; i < landMine.Length; i++)
                _map[landMine[i]] = 2;
            for (int i = 0; i < pause.Length; i++)
                _map[pause[i]] = 3;
            for (int i = 0; i < timeTunnel.Length; i++)
                _map[timeTunnel[i]] = 4;
            // 0:☐
        }

        /// <summary>
        /// 画地图的一格
        /// </summary>
        /// <param name="index">当前格的坐标</param>
        private static void DrawBox(int index)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (_playerPos[0] == _playerPos[1] && _playerPos[0] == index)
                Console.Write("<>");
            else if (_playerPos[0] == index)
                Console.Write("A");
            else if (_playerPos[1] == index)
                Console.Write("B");
            else
            {
                switch (_map[index])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("□");
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("☉");
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("▲");
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("■");
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("卐");
                        break;
                }
            }
        }

        /// <summary>
        /// 绘制游戏地图
        /// </summary>
        private static void ShowMap()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("玩家{0}:用A表示，当前坐标{2}\n玩家{1}:用B表示，当前坐标{3}",
                _playerName[0], _playerName[1], _playerPos[0], _playerPos[1]);
            Console.WriteLine("图例：幸运轮盘：☉\t地雷：▲\t暂停：■\t时空隧道：卐");
            //第一行
            for (int i = 0; i < 30; i++)
                DrawBox(i);

            Console.WriteLine();

            //第一列
            for (int i = 30; i < 35; i++)
            {
                for (int j = 0; j < 29; j++)
                    Console.Write("  ");
                DrawBox(i);
                Console.WriteLine();
            }

            //第二行
            for (int i = 64; i >= 35; i--)
                DrawBox(i);

            Console.WriteLine();

            //第二列
            for (int i = 65; i <= 69; i++)
            {
                DrawBox(i);
                Console.WriteLine();
            }

            //第三行
            for (int i = 70; i <= 99; i++)
                DrawBox(i);

            Console.WriteLine();
        }

        /// <summary>
        /// 创建两个玩家（姓名）
        /// </summary>
        private static void CreatePlayer()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("请输入玩家A的姓名");
            _playerName[0] = Console.ReadLine();
            while (_playerName[0] == "")
            {
                Console.WriteLine("姓名不可为空！请重新输入");
                _playerName[0] = Console.ReadLine();
            }

            Console.WriteLine("请输入玩家B的姓名");
            _playerName[1] = Console.ReadLine();
            while (true)
            {
                if (_playerName[1] == "")
                    Console.WriteLine("姓名不可为空！请重新输入");
                else if (_playerName[1] == _playerName[0])
                    Console.WriteLine("姓名重复！请重新输入");
                else
                    break;
                _playerName[1] = Console.ReadLine();
            }
        }

        private static bool PlayGame(int playerIndex, out bool stopFlag)
        {
            stopFlag = false;
            int playerIndex2 = playerIndex == 0 ? 1 : 0;

            Console.WriteLine("-----------玩家{0}的回合-----------", _playerName[playerIndex]);
            Console.WriteLine("按任意键开始投骰子");
            Console.ReadKey(true);
            int step = _random.Next(1, 8);
            Console.WriteLine("玩家{0}:投出了{1}", _playerName[playerIndex], step);
            _playerPos[playerIndex] += step;

            if (_playerPos[playerIndex] >= 99)
            {
                Console.Clear();
                ShowMap();
                Console.WriteLine("玩家{0}:到达终点！游戏结束！", _playerName[playerIndex]);
                return false;
            }
            else if (_playerPos[playerIndex] == _playerPos[playerIndex2])
            {
                Console.WriteLine("玩家{0}:踩到了玩家{1}，玩家{1}退6格",
                    _playerName[playerIndex], _playerName[playerIndex2]);
                _playerPos[playerIndex2] -= 6;
            }
            else
            {
                switch (_map[_playerPos[playerIndex]])
                {
                    case 0:
                        Console.WriteLine("玩家{0}:踩到了普通方块，安全！", _playerName[playerIndex]);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}:踩到了幸运轮盘！", _playerName[playerIndex]);
                        Console.WriteLine("请选择：1.交换位置  2.轰炸对方");

                        while (true)
                        {
                            string choice = Console.ReadLine();
                            if (choice == "1")
                            {
                                Console.WriteLine("玩家{0}选择与玩家{1}交换位置",
                                    _playerName[playerIndex], _playerName[playerIndex2]);
                                int tmp = _playerPos[0];
                                _playerPos[0] = _playerPos[1];
                                _playerPos[1] = tmp;
                                break;
                            }
                            else if (choice == "2")
                            {
                                Console.WriteLine("玩家{0}选择轰炸玩家{1}，玩家{1}退6格",
                                    _playerName[playerIndex], _playerName[playerIndex2]);
                                _playerPos[playerIndex2] -= 6;
                                break;
                            }
                            else
                                Console.WriteLine("请输入1或2!");
                        }
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}:踩到了地雷，退6格！", _playerName[playerIndex]);
                        _playerPos[playerIndex] -= 2;
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}:踩到了暂停，暂停一回合！", _playerName[playerIndex]);
                        stopFlag = true;
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}:踩到了时空隧道，前进十格！", _playerName[playerIndex]);
                        _playerPos[playerIndex] += 10;
                        break;
                }
            }

            // 修正负数坐标
            for (int i = 0; i < 2; i++)
            {
                if (_playerPos[i] < 0)
                    _playerPos[i] = 0;
            }

            Console.WriteLine("输入任意键开始移动");
            Console.ReadKey(true);
            // 刷新游戏地图
            Console.Clear();
            ShowMap();

            return true;
        }

        static void Main(string[] args)
        {
            ShowGame(); // static方法只能调用static方法
            MapInit();
            CreatePlayer();

            Console.Clear(); //清屏
            ShowMap();

            bool playerStopFlag = false;
            bool playerStopFlag2 = false;
            while (true)
            {
                if (!playerStopFlag) //不处于暂停状态
                {
                    if (!PlayGame(0, out playerStopFlag))
                        break;
                }
                else
                {
                    Console.WriteLine("玩家{0}处于暂停状态，跳过该回合！", _playerName[0]);
                    playerStopFlag = false;
                }

                if (!playerStopFlag2) //不处于暂停状态
                {
                    if (!PlayGame(1, out playerStopFlag2))
                        break;
                }
                else
                {
                    Console.WriteLine("玩家{0}处于暂停状态，跳过该回合！", _playerName[1]);
                    playerStopFlag2 = false;
                }
            }
            Console.WriteLine("欢迎下次游戏~~~");
            Console.ReadKey(true);
        }
    }
}
