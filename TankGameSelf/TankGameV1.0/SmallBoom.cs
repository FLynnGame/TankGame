using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TankGameV1._0.Properties;
using System.Drawing;
using System.Media;

namespace TankGameV1._0
{
    class SmallBoom:GameObject
    {
         //爆炸的两张图片
        private Image[] imgs = {
                                   Resources.blast1,
                                   Resources.blast3,
                               };

        public SmallBoom(int x,int y)
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
