using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TankGameV1._0.Properties;
using System.Media;

namespace TankGameV1._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //初始化游戏
            InitialGame();
        }

       public void InitialGame()
       {
           this.Size = new Size(800, 600);
           this.BackColor = Color.Black;

           //控制窗口大小不可改变
           this.MaximumSize = new Size(800, 600);
           this.MinimumSize = new Size(800, 600);

           SingleObject.GetSingle().AddGameObject(new PlayerTank(200,200,15,10,Direction.Down));
           SetEnemyTank();

           InitialMap();
       }

       Random rdm = new Random();

       /// <summary>
       /// 初始化敌人坦克对象
       /// </summary>
       public void SetEnemyTank()
       {
            for(int i=0; i<8; i++)
            {
                SingleObject.GetSingle().AddGameObject(new EnemyTank
                    (rdm.Next(0, this.Width), rdm.Next(0, this.Height), rdm.Next(0, 3), Direction.Down));
            }
       }

       public void InitialMap()
       {
           #region 画砖头
           for (int i = 0; i < 10; i++)
           {
               SingleObject.GetSingle().AddGameObject(new Wall(30 + i*15,100));//T 的一横
               SingleObject.GetSingle().AddGameObject(new Wall(97,100 + i*15));//T 的一竖

               SingleObject.GetSingle().AddGameObject(new Wall(195+i*7,235-i*15));//A 的一撇
               SingleObject.GetSingle().AddGameObject(new Wall(258 + i*7,100 + i*15));//A 的一捺
           }

           for (int i = 0; i < 6; i++)
           {
               SingleObject.GetSingle().AddGameObject(new Wall(225 + i*15,190));//A 的一横
           }

           for (int i = 0; i < 10; i++)
           {
               SingleObject.GetSingle().AddGameObject(new Wall(351 + i*7,235 - i*15));//N 的三笔
               SingleObject.GetSingle().AddGameObject(new Wall(414 + i*7,100 + i*15));
               SingleObject.GetSingle().AddGameObject(new Wall(477 + i*7,235 - i*15));

               SingleObject.GetSingle().AddGameObject(new Wall(570, 100 + i * 15));//K的三笔
               SingleObject.GetSingle().AddGameObject(new Wall(570 + i*8, 160 - i * 8));
               SingleObject.GetSingle().AddGameObject(new Wall(570 + i*9, 160 + i * 9));
           }
           
           #endregion

           #region 画草地
           SingleObject.GetSingle().AddGameObject(new Grass(0, 441));
           for (int i = 0; i < 2; i++)
           {
               SingleObject.GetSingle().AddGameObject(new Grass(i * 30, 471));
               SingleObject.GetSingle().AddGameObject(new Grass(30 + i*30, 501));
               SingleObject.GetSingle().AddGameObject(new Grass(60 + i * 30, 531));

               SingleObject.GetSingle().AddGameObject(new Grass(664 + i * 30, 535));
               SingleObject.GetSingle().AddGameObject(new Grass(694 + i * 30, 505));
               SingleObject.GetSingle().AddGameObject(new Grass(724 + i * 30, 475));
           }
           SingleObject.GetSingle().AddGameObject(new Grass(754, 445));
           #endregion

           #region 画钢铁墙
           for (int i = 0; i < 4; i++)
           {
               SingleObject.GetSingle().AddGameObject(new SteelWall(i * 15, 547));
               SingleObject.GetSingle().AddGameObject(new SteelWall(i * 15, 532));

               SingleObject.GetSingle().AddGameObject(new SteelWall(769 - i * 15, 550));
               SingleObject.GetSingle().AddGameObject(new SteelWall(769 - i * 15, 535));
           }
           for (int i = 0; i < 2; i++)
           {
               SingleObject.GetSingle().AddGameObject(new SteelWall(i * 15, 517));
               SingleObject.GetSingle().AddGameObject(new SteelWall(i * 15, 502));

               SingleObject.GetSingle().AddGameObject(new SteelWall(769 - i * 15, 520));
               SingleObject.GetSingle().AddGameObject(new SteelWall(769 - i * 15, 505));
           }
           #endregion

           #region 画水
           SingleObject.GetSingle().AddGameObject(new Water(500,300));
           SingleObject.GetSingle().AddGameObject(new Water(530, 300));
           SingleObject.GetSingle().AddGameObject(new Water(500, 330));
           SingleObject.GetSingle().AddGameObject(new Water(530, 330));
           #endregion

           #region 鹰

           SingleObject.GetSingle().AddGameObject(new Symbol(362, 515));

           int tmp = 332;
           for (int i = 0; i < 8; i++)
           {
               tmp++;
               SingleObject.GetSingle().AddGameObject(new Wall(tmp+ i*15, 485));
               SingleObject.GetSingle().AddGameObject(new Wall(tmp + i * 15, 501));
           }
           tmp = 516;
           for (int i = 0; i < 3; i++)
           {
               tmp++;
               SingleObject.GetSingle().AddGameObject(new Wall(333, tmp + i*15));
               SingleObject.GetSingle().AddGameObject(new Wall(349, tmp + i * 15));
           }
           for (int i = 0; i < 3; i++)
           {
               SingleObject.GetSingle().AddGameObject(new Wall(429, 517 + i*16));
               SingleObject.GetSingle().AddGameObject(new Wall(445, 517 + i * 16));
           }
           #endregion
       }

        /// <summary>
        /// 当窗口需要重绘时触发
        /// </summary>
        /// <param name="sender">触发当前这个事件的对象</param>
        /// <param name="e">执行这个方法所需要的资源</param>
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }

        /// <summary>
        /// 定义KeyDown 与KeyUp事件 用于处理组合键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().PT.KeyDown(e);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().PT.KeyUp(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //强制窗口刷新
            this.Invalidate();

            SingleObject.GetSingle().IsCrash();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //让控件不闪烁
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);

            SoundPlayer sp = new SoundPlayer(Resources.start);
            //sp.Play();
        }
    }
}
