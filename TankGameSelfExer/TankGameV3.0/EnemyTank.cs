using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using TankGameV1._0.Properties;

namespace TankGameV1._0
{
    class EnemyTank:TankFather
    {
        //三种坦克
        private static Image[] imgs1 = {
                                   Resources.enemy1U,
                                   Resources.enemy1D,
                                   Resources.enemy1L,
                                   Resources.enemy1R,
                               };
        private static Image[] imgs2 = {
                                    Resources.enemy2U,
                                    Resources.enemy2D,
                                    Resources.enemy2L,
                                    Resources.enemy2R
                                };
        private static Image[] imgs3 = {
                                    Resources.enemy3U,
                                    Resources.enemy3D,
                                    Resources.enemy3L,
                                    Resources.enemy3R
                                };

        private static int _speed = 0;
        private static int _life = 0;

        public int EnemyType
        {
            get;
            set;
        }

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

        public EnemyTank(int x, int y, int speed, int life, int type,Direction dir)
            : base(x, y, SetLife(type), SetSpeed(type), dir, imgs1)
        {
            EnemyType = type;
        }

        public override void Draw(Graphics g)
        {
            this.Move();
            switch (EnemyType)
            {
                case 0:
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
                    break;
                case 1:
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
                    break;
                case 2:
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
                    break;
            }
        }

        //变成静态的，在内存中就是唯一的
        static Random rdm = new Random();
        public override void Move()
        {
            base.Move();

            if (rdm.Next(0, 100) < 6)
            {
                switch (rdm.Next(0, 3))
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
        }

        public override void Fire()
        {
            throw new NotImplementedException();
        }
    }
}
