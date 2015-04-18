using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TankGameV1._0.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace TankGameV1._0
{
    class PlayerTank:TankFather
    {
        private static Image[] imgs = {
                                   Resources.p1tankU,
                                   Resources.p1tankD,
                                   Resources.p1tankL,
                                   Resources.p1tankR
                               };

        public PlayerTank(int x, int y, int life, int speed, Direction dir)
            : base(x, y, life, speed, dir, imgs)
        {

        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    this.Dir = Direction.Up;
                    base.Move();
                    break;
                case Keys.S:
                    this.Dir = Direction.Down;
                    base.Move();
                    break;
                case Keys.A:
                    this.Dir = Direction.Left;
                    base.Move();
                    break;
                case Keys.D:
                    this.Dir = Direction.Right;
                    base.Move();
                    break;
            }
        }
    }
}
