using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TankGameV1._0
{
    abstract class TankFather:GameObject
    {
        private Image[] imgs = { };

        public TankFather(int x, int y, Image[] imgs, int speed, int life,Direction dir)
            :base(x, y, imgs[0].Width,imgs[0].Height,speed,life,dir)
        {
            this.imgs = imgs;
        }

        

        public int bornTime = 0;
        public bool isMove = false;

        public override void Draw(Graphics g)
        {
            bornTime++;
            if (bornTime % 20 == 0)
            {
                isMove = true;
            }
            if (isMove)
            {
                switch (this.Dir)
                {
                    case Direction.Up:
                        g.DrawImage(imgs[0], this.X, this.Y);
                        break;
                    case Direction.Down:
                        g.DrawImage(imgs[1], this.X, this.Y);
                        break;
                    case Direction.Left:
                        g.DrawImage(imgs[2], this.X, this.Y);
                        break;
                    case Direction.Right:
                        g.DrawImage(imgs[3], this.X, this.Y);
                        break;
                    default: break;
                }
            }
        }
        public abstract void Fire();

        public abstract void IsOver();

        public abstract void Born();

        public abstract void DrawBlood();
    }
}
