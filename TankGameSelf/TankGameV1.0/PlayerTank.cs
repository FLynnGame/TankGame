using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using TankGameV1._0.Properties;
using System.Media;

namespace TankGameV1._0
{
    class PlayerTank : TankFather
    {
        private static Image[] imgs = {
            Resources.p1tankU,
            Resources.p1tankD,
            Resources.p1tankL,
            Resources.p1tankR
        };
        
        public PlayerTank(int x,int y,int speed,int life,Direction dir)
            : base(x, y, imgs, speed, life, dir)
        {
            Born();
        }


        //**************************处理的不好，尚待改进**********************//
        //定义四个方向
        private bool bW = false, bA = false, bS = false, bD = false, bJ = false;
        private bool fire = false;
        public bool hitCheck = true;
        //public bool kaiGua = false;//用于开挂
        //this.Dir = Dir
        //保存旧坐标
        private int oldX = 0, oldY = 0;


        public void DecideDirection()
        {
            if ((bW && !bA && !bS && !bD && !bJ) || (bW && !bA && !bS && !bD && bJ))//Up
            //如果只是按了W，或者按了W与开火键J 同样向上
            {
                this.Dir = Direction.Up;
            }
            else if ((!bW && !bA && bS && !bD && !bJ) || (!bW && !bA && bS && !bD && bJ))//Down
            {
                this.Dir = Direction.Down;
            }
            else if ((!bW && bA && !bS && !bD && !bJ) || (!bW && bA && !bS && !bD && bJ))//Left
            {
                this.Dir = Direction.Left;
            }
            else if ((!bW && !bA && !bS && bD && !bJ) || (!bW && !bA && !bS && bD && bJ))//Right
            {
                this.Dir = Direction.Right;
            }
            else if(!bW && !bA && !bS && !bD && bJ) //只是按了J键
            {
                this.fire = true;
            }
            //else if (bW && bA && bS && bD)//如果wasd全部按下即进入开挂模式
            //{
            //    this.kaiGua = true;
            //}

        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    bW = true;
                    break;
                case Keys.A:
                    bA = true;
                    break;
                case Keys.S:
                    bS = true;
                    break;
                case Keys.D:
                    bD = true;
                    break;
                case Keys.J:
                    bJ = true;
                    Fire(); 
                    break;
                default: 
                    break;
            }
            
            DecideDirection();
            if (!fire && hitCheck)//当我只按了J键 且未碰撞 不移动
            {
                oldX = this.X;
                oldY = this.Y;

                base.Move();

                //DrawBlood();
            }
        }


        //public void Gua()
        //{
        //    if (SingleObject.GetSingle().AddGameObject(new PlayerBullet(this, 20, 10, 1)))
        //    {
        //        //开火前播放开火的声音
        //        SoundPlayer sp = new SoundPlayer(Resources.fire);
        //        sp.Play();
        //    }
        //}
        /// <summary>
        /// 保存坦克的旧坐标
        /// </summary>
        /// <returns></returns>
        public int TankStopX()
        {
            return oldX;
        }

        public int TankStopY()
        {
            return oldY;
        }

        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    bW = false;
                    break;
                case Keys.A:
                    bA = false;
                    break;
                case Keys.S:
                    bS = false;
                    break;
                case Keys.D:
                    bD = false;
                    break;
                case Keys.J:
                    bJ = false;
                    fire = false;
                    break;
                default:
                    break;
            }
        }

        public override void Fire()
        {
            //检查是否创建成功
            if (SingleObject.GetSingle().AddGameObject(new PlayerBullet(this, 20, 10, 1)))
            {
                //开火前播放开火的声音
                SoundPlayer sp = new SoundPlayer(Resources.fire);
                sp.Play();
            }
        }

        public override void IsOver()
        {

            SoundPlayer sp = new SoundPlayer(Resources.hit);
            sp.Play();

            SingleObject.GetSingle().AddGameObject(new Boom(this.X, this.Y));
            //SingleObject.GetSingle().RemoveGameObject(this);
        }

        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }

        public override void DrawBlood()
        {
            SingleObject.GetSingle().AddGameObject(new Blood(this.X, this.Y-20, this.Life, 3));//默认可以挨三炮
        }
    }
}
