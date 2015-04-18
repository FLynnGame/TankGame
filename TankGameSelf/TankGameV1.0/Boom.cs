using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using TankGameV1._0.Properties;

namespace TankGameV1._0
{
    class Boom : GameObject
    {
        //爆炸的八张图片
        private Image[] imgs = {
                                   Resources.blast1,
                                   Resources.blast2,
                                   Resources.blast3,
                                   Resources.blast4,
                                   Resources.blast5,
                                   Resources.blast6,
                                   Resources.blast7,
                                   Resources.blast8,
                               };

        public Boom(int x,int y)
            :base(x,y)
        {

        }

        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length; i++)
            {
                g.DrawImage(imgs[i], this.X-50, this.Y-50);
            }

            //爆炸完成就去除你
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
