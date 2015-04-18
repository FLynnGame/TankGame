using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TankGameV1._0.Properties;
using System.Drawing;

namespace TankGameV1._0
{
    class Wall:GameObject
    {
        private static Image img = Resources.wall;
        public Wall(int x, int y)
            : base(x, y,img.Width,img.Height)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.X, this.Y);
        }
    }
}
