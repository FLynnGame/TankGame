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
        Right,
        Stop
    }
    abstract class GameObject
    {
        #region 游戏对象的属性
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

        public GameObject(int x, int y, int width, int height, int speed, int life, Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Speed = speed;
            this.Life = life;
            this.Dir = dir;
        }

        public abstract void Draw(Graphics g);

        public virtual void Move()
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
                default: break;
            }
            if (X < 0)
            {
                X = 0;
            }
            if (Y < 0)
            {
                Y = 0;
            }
            if (X >= 720)
            {
                X = 720;
            }
            if (Y >= 500)
            {
                Y = 500;
            }

        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }

        //WHY    重载构造函数???
        public GameObject(int x, int y)
            : this(x, y, 0, 0, 0, 0, 0)
        {

        }

        public GameObject(int x, int y, int width, int height)
            : this(x, y, width, height, 0, 0, 0)
        {

        }
    }
}
