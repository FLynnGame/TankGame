using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TankGameV1._0
{
    class TankFather:GameObject
    {
        private Image[] imgs = new Image[] { };
        //需要传进来的值
        public TankFather(int x, int y, int life, int speed, Direction dir, Image[] imgs)
            : base(x, y, imgs[0].Width, imgs[0].Height, life, speed, dir)//传给父类的值
        {
            this.imgs = imgs;
        }

        /// <summary>
        /// 根据方向画出对应的坦克图片
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
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
            }
        }
    }
}
