using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using TankGameV1._0.Properties;

namespace TankGameV1._0
{
    class BulletsFather:GameObject
    {
        private Image img = null;

        public int Power
        {
            get;
            set;
        }

        public BulletsFather(TankFather tf, int life, int speed, int power, Image img)
            : base(tf.X + tf.Width / 2 -6, tf.Y + tf.Height / 2-6, img.Width, img.Height, life, speed, tf.Dir)
        {
                this.img = img;
        }

        public override void Draw(Graphics g)
        {
            this.Move();
            g.DrawImage(img, this.X, this.Y);
        }

        public override void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Left:
                    this.X -= this.Speed;
                    break;
                case Direction.Right:
                    this.X += this.Speed;
                    break;
            }

            //将子弹移除边界
            if (this.X <= 0 || this.Y <= 0 || this.X >= 800 || this.Y >= 600)
            {
                SingleObject.GetSingle().RemoveGameObject(this);
            }
        }
    }
}
