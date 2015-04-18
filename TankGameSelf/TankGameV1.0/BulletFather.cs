using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using TankGameV1._0.Properties;
using System.Media;

namespace TankGameV1._0
{
    abstract class BulletFather:GameObject
    {
        private Image img = null;
        public Image Img
        {
            get { return img;}
            set {img = value;}
        }
        
        public int Power
        {
            get;
            set;
        }

        public BulletFather(TankFather tf, int speed, int life, int power, Image img)
            : base(tf.X + tf.Width/2-6 , tf.Y + tf.Height / 2 -6, img.Width, img.Height, speed, life, tf.Dir)
        {
            this.img = img;
        }

        /// <summary>
        /// 重写Move方法，父类中的有针对坦克的坐标控制，需要重写
        /// </summary>
        public override void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    Y -= Speed;
                    break;
                case Direction.Down:
                    Y += Speed;
                    break;
                case Direction.Left:
                    X -= Speed;
                    break;
                case Direction.Right:
                    X += Speed;
                    break;
            }
        }

        public override void Draw(Graphics g)
        {
            this.Move();
            g.DrawImage(img, this.X, this.Y);
        }

        /// <summary>
        /// 子弹是否击中物体
        /// </summary>
        public abstract void BeHit();

    }
}
