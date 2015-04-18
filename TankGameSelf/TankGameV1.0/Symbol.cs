using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Drawing;
using TankGameV1._0.Properties;

namespace TankGameV1._0
{
    class Symbol:GameObject
    {
        private static Image img = Resources.symbol;

        public Symbol(int x, int y)
            : base(x, y, img.Width, img.Height)
        {

        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.X, this.Y);
        }
    }
}
