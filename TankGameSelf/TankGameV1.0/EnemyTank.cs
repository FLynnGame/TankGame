using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TankGameV1._0.Properties;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace TankGameV1._0
{
    class EnemyTank:TankFather
    {
        //敌人坦克1
        private static Image[] imgs1 = {
                                          Resources.enemy1U,
                                          Resources.enemy1D,
                                          Resources.enemy1L,
                                          Resources.enemy1R
                                      };
        //敌人坦克2
        private static Image[] imgs2 = {
                                           Resources.enemy2U,
                                           Resources.enemy2D,
                                           Resources.enemy2L,
                                           Resources.enemy2R
                                       };
        //敌人坦克3
        private static Image[] imgs3 = {
                                           Resources.enemy3U,
                                           Resources.enemy3D,
                                           Resources.enemy3L,
                                           Resources.enemy3R
                                       };

        //敌人坦克的速度
        private static int _speed;
        //敌人坦克的生命
        private static int _life;
        
        /// <summary>
        /// 根据坦克的种类，设定不同的速度
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0:
                    _speed = 5;
                    break;
                case 1:
                    _speed = 6;
                    break;
                case 2:
                    _speed = 7;
                    break;
            }
            return _speed;
        }

        /// <summary>
        /// 设定敌人坦克的生命值，根据不同坦克类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    _life = 1;
                    break;
                case 1:
                    _life = 2;
                    break;
                case 2:
                    _life = 3;
                    break;
            }
            return _life;
        }

        public int EnemyTankType
        {
            get;
            set;
        }

        /// <summary>
        /// 坦克速度和生命值不能写死
        /// </summary>
        public EnemyTank(int x,int y,int type,Direction dir)
            : base(x, y, imgs1,SetSpeed(type), SetLife(type), dir)
        {
            this.EnemyTankType = type;

            //一new出对象，我就加载闪烁星星
            Born();

           
        }


        private int StopTime = 0;
        private bool isStop = false;

        //声明静态 保证计数不会清零
        private static int currentTankNum = 8;//初始坦克数
        private static int deadTankNum = 0;
        private int oldX = 0, oldY = 0;

        //判断当前是否可以移动
        //public bool cantMove = true;

        //绘制我们的坦克
        public override void Draw(Graphics g)
        {
            StopTime++;
            if (StopTime % 20 == 0)
            {
                isStop = true;
            }

            //一绘制就开始移动
            if (isStop)
            {
                Move();
                switch (this.EnemyTankType)
                {
                    case 0:
                        {
                            switch (this.Dir)
                            {
                                case Direction.Up:
                                    g.DrawImage(imgs1[0], this.X, this.Y);
                                    break;
                                case Direction.Down:
                                    g.DrawImage(imgs1[1], this.X, this.Y);
                                    break;
                                case Direction.Left:
                                    g.DrawImage(imgs1[2], this.X, this.Y);
                                    break;
                                case Direction.Right:
                                    g.DrawImage(imgs1[3], this.X, this.Y);
                                    break;
                            }
                        }
                        break;
                    case 1:
                        {
                            switch (this.Dir)
                            {
                                case Direction.Up:
                                    g.DrawImage(imgs2[0], this.X, this.Y);
                                    break;
                                case Direction.Down:
                                    g.DrawImage(imgs2[1], this.X, this.Y);
                                    break;
                                case Direction.Left:
                                    g.DrawImage(imgs2[2], this.X, this.Y);
                                    break;
                                case Direction.Right:
                                    g.DrawImage(imgs2[3], this.X, this.Y);
                                    break;
                            }
                        }
                        break;
                    case 2:
                        {
                            switch (this.Dir)
                            {
                                case Direction.Up:
                                    g.DrawImage(imgs3[0], this.X, this.Y);
                                    break;
                                case Direction.Down:
                                    g.DrawImage(imgs3[1], this.X, this.Y);
                                    break;
                                case Direction.Left:
                                    g.DrawImage(imgs3[2], this.X, this.Y);
                                    break;
                                case Direction.Right:
                                    g.DrawImage(imgs3[3], this.X, this.Y);
                                    break;
                            }
                        }
                        break;
                }
            }
        }

        static Random rdm = new Random();

        public override void Move()
        {
            oldX = this.X;
            oldY = this.Y;

            //先移动，再给一个很小的概率去改变方向
            base.Move();

            //马上画血条
            DrawBlood();
            if (rdm.Next(0, 100) < 5)
            {
                switch (rdm.Next(0, 4))
                {
                    case 0:
                        this.Dir = Direction.Up;
                        break;
                    case 1:
                        this.Dir = Direction.Down;
                        break;
                    case 2:
                        this.Dir = Direction.Left;
                        break;
                    case 3:
                        this.Dir = Direction.Right;
                        break;
                }
            }
            
            //坦克一遍走，一遍发子弹
            if (rdm.Next(0, 100) < 1)
            {
                Fire();
            }
            
        }

        //返回旧的坐标
        public int TankStopX()
        {
            return oldX;
        }

        public int TankStopY()
        {
            return oldY;
        }

        /// <summary>
        /// 用于开火
        /// </summary>
        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyBullet(this, 10, 10, 1));
        }


        //当坦克死亡后，让其有一定几率复活
        public override void IsOver()
        {
            //表示已死
            if (this.Life == 0)
            {
                //击中后播放爆炸后就移除你
                SingleObject.GetSingle().AddGameObject(new Boom(this.X, this.Y));
                SingleObject.GetSingle().RemoveGameObject(this);
                //SingleObject.GetSingle().RemoveGameObject(Blood);
                //播放爆炸的声音
                SoundPlayer sp = new SoundPlayer(Resources.boom);
                sp.Play();

                deadTankNum++;
                currentTankNum--;

                //先用一定概率出生，后再判断剩余坦克数
                if (rdm.Next(0, 100) >= 50)
                {
                    SingleObject.GetSingle().AddGameObject(new EnemyTank(rdm.Next(0, 800),
                        rdm.Next(0, 550), rdm.Next(0, 2), Direction.Down));

                    currentTankNum++;
                }

                //当屏幕上坦克少于2个的时候，随机增加几个坦克
                if (currentTankNum < 2)
                {
                    //MessageBox.Show("almost none ");
                    for (int i = 0; i < rdm.Next(1, 3); i++)
                    {
                        SingleObject.GetSingle().AddGameObject(new EnemyTank(rdm.Next(0, 800),
                            rdm.Next(0, 550), rdm.Next(0, 2), Direction.Down));

                        currentTankNum++;
                    }
                }

                //当打死坦克数大于15，提示可以进入下一关
                //新的BUG 当加上MessageBox,就会引发越界错误！
                //尚未解决！！！
                if (deadTankNum >= 3)
                {
                    //MessageBox.Show("You Win!!!");
                    
                }


            }
            else//击中但是未死
            {
                SoundPlayer sp = new SoundPlayer(Resources.hit);
                sp.Play();
            }
        }

        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }

        public override void DrawBlood()
        {
            SingleObject.GetSingle().AddGameObject(new Blood(this.X , this.Y - 20, this.Life, this.EnemyTankType));
        }
    }
}
