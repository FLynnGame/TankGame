using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TankGameV1._0
{
    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    abstract class GameObject
    {
        #region 添加游戏对象要用到的属性
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Width
        {
            get;
            set;
        }
        public int Height
        {
            get;
            set;
        }
        public int Speed
        {
            get;
            set;
        }
        public int Life
        {
            get;
            set;
        }
        public Direction Dir
        {
            get;
            set;
        }
        #endregion

        //添加抽象方法，让子类去重写
        public abstract void Draw(Graphics g);

        //添加虚方法，子类可以重写，也可以不重写
        public virtual void Move()
        {
            switch (this.Dir)
            {
                case Direction.Up:
                    this.Y -= Speed;
                    break;
                case Direction.Down:
                    this.Y += Speed;
                    break;
                case Direction.Left:
                    this.X -= Speed;
                    break;
                case Direction.Right:
                    this.X += Speed;
                    break;
            }
            //加上边界检测
            if(this.X <= 0)
            {
                this.X = 0;
            }
            if (this.X >= TankClient.GameWidth)
            {
                this.X = TankClient.GameWidth;
            }
            if (this.Y <= 0)
            {
                this.Y = 0;
            }
            if (this.Y >= TankClient.GameHeight)
            {
                this.Y = TankClient.GameHeight;
            }
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
    }
}
