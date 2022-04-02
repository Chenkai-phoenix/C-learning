// See https://aka.ms/new-console-template for more information
//----飞行棋游戏
/*
 * step1:画游戏头
 * step2:地图初始化（给数组初始化）；设置为全局数组通过静态字段
 * step2.1:数值代表各个关卡的图形（0：方块，1：幸运轮盘；2：地雷；3：陷阱；4：时空隧道）
 * step2.2:地图加载关卡数值
 * step2.3:地图加载关卡图形
 * step3：画完整地图（地图初始化完成）
 * step4:输入玩家姓名
 * step5：清屏 console.clear();
 * 生成随机数：Random r1 = new Random();     int i = r.next(1,6);  
 * step6：游戏逻辑：
 * （1）A B相踩退6格
 * （2）方块安全
 * （3）幸运轮盘：1：互换位置；2，炮击对方后退6格
 * （4）地雷：自身后退6格
 * （5）陷阱：轮空一回合
 * （6）时空隧道：前进10格
 */
namespace _Demo4
{
    class Program
    {
        public static int[] _maps = new int[100];   //空地图
        public static string[] _playerName = new string[2];//_playerName存放两个玩家的姓名
        public static int[] _playerPos = new int[2];    //_playerPos[0]表示玩家A坐标，_playerPos[1]表示玩家B坐标
        public static bool[] _runTurn = new bool[2]; //存放两个玩家的运行开关，true表示可以运行，false表示不可以
        static void Main(string[] args)
        {
            MapInit();  //加载数据，关卡位置
            GameTitle();
            InputName();
            Console.Clear(); //清屏
            GameTitle();
            OutputName();
            DrawMap();  //画地图
            //
            while (_playerPos[0] <= 99 && _playerPos[1] <= 99)
            {
                //true运行游戏，false的时候将false置为true，相当于轮空一轮
                if (_runTurn[0] == true)
                {
                    GameRuler(0);   //一号玩家游戏过程
                }
                else
                {
                    _runTurn[0] = true;
                }
                if (_playerPos[0] == 99)
                {
                    GameOver(_playerName[0]);
                    break;
                }
                //true运行游戏，false的时候将false置为true，相当于轮空一轮
                if (_runTurn[1] == true)
                {
                    GameRuler(1);   //二号玩家游戏过程
                }
                else
                {
                    _runTurn[1] = true;
                }
                if (_playerPos[1] == 99)
                {
                    GameOver(_playerName[1]);
                    break;
                }
            }
        }
        //游戏头
        public static void GameTitle()
        {
            Console.BackgroundColor = ConsoleColor.Black;   //Console.BackgroundColor(),控制台背景色
            Console.ForegroundColor = ConsoleColor.Blue;    //Console.ForegroundColor()，控制台前景色
            Console.WriteLine("********************");
            Console.WriteLine("********************");
            Console.WriteLine("********************");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("******飞行棋********");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("********************");
            Console.WriteLine("********************");
            Console.WriteLine("********************");
            Console.ForegroundColor = ConsoleColor.White;
        }

        //地图初始化
        public static void MapInit()
        {
            //各个关卡的位置
            int[] luckyTurn = { 6, 23, 40, 55, 69, 83 };    //幸运轮盘位置
            int[] landMine = { 55, 13, 17, 33, 38, 50, 64, 80, 94 };    //地雷位置
            int[] pause = { 9, 27, 60, 93 };    //暂停
            int[] timeTunnel = { 20, 25, 45, 63, 72, 88, 90 };  //时空隧道
            //地图加载关卡数值
            MapSet(luckyTurn, 1);
            MapSet(landMine, 2);
            MapSet(pause, 3);
            MapSet(timeTunnel, 4);
            //地图加载关卡图形
        }

        //关卡数值加载方法
        public static void MapSet(int[] arry, int type)  //arry关卡位置，type关卡类型
        {
            for (int i = 0; i < arry.Length; i++)
            {
                _maps[arry[i]] = type;
            }

        }

        //画关卡图形，返回i位置的关卡类型或者是A,B
        public static string DrawCheckPoints(int i)

        {
            string str = "";
            if (_playerPos[0] == _playerPos[1] && _playerPos[0] == i)   //玩家AB坐标相等且都在地图上，则显示<>;
            {
                str = "<>";
            }
            else if (_playerPos[0] == i)    //AB坐标不相等，A在地图位置显示A
            {
                str = "A";
            }
            else if (_playerPos[1] == i)    //AB坐标不相等，B在地图位置显示B
            {
                str = "B";
            }
            else
            {
                switch (_maps[i])
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.White;
                        str = "口";
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        str = "＠";
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Red;
                        str = "×";
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Green;
                        str = "＃";
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        str = "卍";
                        break;
                    default:
                        break;
                }
            }
            return str;
        }

        //画地图图形
        public static void DrawMap()
        {
            Console.WriteLine("＠：幸运轮盘；×：地雷；＃：暂停；卍：时空隧道");
            //第一横行输出
            for (int i = 0; i <= 29; i++)
            {
                Console.Write(DrawCheckPoints(i));
            }
            Console.WriteLine();//换行
            //第一竖行输出,(数组第31行到36行)
            for (int i = 30; i <= 34; i++)
            {
                for (int j = 0; j < 29; j++)
                {
                    Console.Write("  ");
                }
                Console.Write(DrawCheckPoints(i));
                Console.WriteLine();
            }
            //第二横行输出
            for (int i = 64; i >= 35; i--)
            {
                Console.Write(DrawCheckPoints(i));
            }
            Console.WriteLine();//换行
            //第二竖行输出
            for (int i = 65; i <= 69; i++)
            {
                Console.Write(DrawCheckPoints(i));
                for (int j = 1; j < 30; j++)
                {
                    Console.Write("  ");
                }
                Console.WriteLine();
            }
            //第三横行输出
            for (int i = 70; i <= 99; i++)
            {
                Console.Write(DrawCheckPoints(i));
            }
            Console.WriteLine();
        }

        //玩家姓名输入
        public static void InputName()
        {
            do
            {
                Console.WriteLine("请输入玩家A的姓名");
                _playerName[0] = Console.ReadLine();
                if (_playerName[0] == "")
                {
                    Console.WriteLine("玩家姓名不能为空,不能重名请重新输入！");
                }
            }
            while (_playerName[0] == "");
            do
            {
                Console.WriteLine("请输入玩家B的姓名");
                _playerName[1] = Console.ReadLine();
                if (_playerName[1] == "" || _playerName[1] == _playerName[0])
                {
                    Console.WriteLine("玩家姓名不能为空，不能重名请重新输入！");
                }
            }
            while (_playerName[1] == "" || _playerName[1] == _playerName[0]);
        }

        //玩家姓名输出
        public static void OutputName()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("玩家1姓名是{0}：", _playerName[0]);
            Console.WriteLine("玩家2姓名是{0}：", _playerName[1]);
        }

        //玩家位置限定
        public static void PlayerPosConst()
        {
            if (_playerPos[0] < 0)
                _playerPos[0] = 0;
            if (_playerPos[0] > 99)
                _playerPos[0] = 99;
            if (_playerPos[1] < 0)
                _playerPos[1] = 0;
            if (_playerPos[1] > 99)
                _playerPos[1] = 99;
        }

        //游戏逻辑
        public static void GameRuler(int playernum)
        {
            int diceNum = 0;
            Random r1 = new Random();   //Random随机类
            Console.WriteLine("{0}按任意键开始掷骰子", _playerName[playernum]);
            Console.ReadKey(true);  //Console.ReadKey(true);输入的按键不在控制台显示
            diceNum = r1.Next(1, 6);    //调用随机数对象
            Console.WriteLine("{0}投掷的点数是{1}", _playerName[playernum], diceNum);
            _playerPos[playernum] = _playerPos[playernum] + diceNum;    //根据随机点数移动
            Console.WriteLine("{0}按任意键开始行动", _playerName[playernum]);
            Console.ReadKey(true);
            PlayerPosConst(); //判断位置是否在地图上
                              //规则1
            if (_playerPos[playernum] == _playerPos[1 - playernum])
            {
                Console.WriteLine("{0}踩到了玩家{1}，玩家{2}后退6格", _playerName[playernum], _playerName[1 - playernum], _playerName[1 - playernum]);
                _playerPos[1 - playernum] = _playerPos[1 - playernum] - 6;
            }
            //规则2
            else
            {
                switch (_maps[_playerPos[playernum]])
                {
                    case 0:
                        Console.WriteLine("玩家{0}踩到放格啥事都没发生。", _playerName[playernum]);
                        Console.ReadKey(true);
                        break;
                    case 1:
                        Console.WriteLine("玩家{0}踩到幸运轮盘,1.与对方交换位置；2.炮击对方使其后退10格。", _playerName[playernum]);
                        string luckyChoose = "";
                        do
                        {
                            luckyChoose = Console.ReadLine();
                            if (luckyChoose == "1")
                            {
                                int tump = _playerPos[playernum];
                                _playerPos[playernum] = _playerPos[1 - playernum];
                                _playerPos[1 - playernum] = tump;
                                Console.WriteLine("选择与对方交换位置");
                                break;
                            }
                            else if (luckyChoose == "2")
                            {
                                _playerPos[1 - playernum] = _playerPos[1 - playernum] - 6;
                                Console.WriteLine("炮击对方使其后退10格。");
                                break;
                            }
                            else
                                Console.WriteLine("输入错误请重新输入！");
                        } while (luckyChoose != "1" || luckyChoose != "2");
                        Console.ReadKey(true);
                        break;
                    case 2:
                        Console.WriteLine("玩家{0}踩到地雷,后退6格。", _playerName[playernum]);
                        _playerPos[playernum] = _playerPos[playernum] - 6;
                        Console.ReadKey(true);
                        break;
                    case 3:
                        Console.WriteLine("玩家{0}踩到陷阱，暂停一回合。", _playerName[playernum]);
                        _runTurn[playernum] = false;
                        Console.ReadKey(true);
                        break;
                    case 4:
                        Console.WriteLine("玩家{0}踩到时空隧道，前进10格。", _playerName[playernum]);
                        _playerPos[playernum] = _playerPos[playernum] + 10;
                        Console.ReadKey(true);
                        break;
                }
            }
            Console.WriteLine("{0}行动完毕", _playerName[playernum]);
            Console.WriteLine("当前位置是{0}", _playerPos[playernum]);
            Console.ReadKey(true);
            PlayerPosConst(); //判断位置是否在地图上
                              //刷新
            Console.Clear();
            DrawMap();
        }

        //游戏结束
        public static void GameOver(string winerName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("胜利者是{0}", winerName);

            Console.ReadKey();
        }
    }
}