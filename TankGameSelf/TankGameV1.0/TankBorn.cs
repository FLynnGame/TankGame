using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using TankGameV1._0.Properties;

namespace TankGameV1._0
{
    class TankBorn:GameObject
    {
        //导入闪烁图片
        private Image[] imgs = {
                                   Resources.born1,
                                   Resources.born2,
                                   Resources.born3,
                                   Resources.born4
                               };

        public TankBorn(int x, int y)
            : base(x, y)
        {

        }

        private int timer = 0;
        public override void Draw(Graphics g)
        {
            timer++;
            for (int i = 0; i < imgs.Length; i++)
            {
                switch (timer % 10)
                {
                    case 1:
                        g.DrawImage(imgs[0], this.X, this.Y);
                        break;
                    case 3:
                        g.DrawImage(imgs[1], this.X, this.Y);
                        break;
                    case 5:
                        g.DrawImage(imgs[2], this.X, this.Y);
                        break;
                    case 7:
                        g.DrawImage(imgs[3], this.X, this.Y);
                        break;
                }
            }

            //一播放完成，我就移除图片
            if (timer % 20 == 0)
            {
                SingleObject.GetSingle().RemoveGameObject(this);
            }
        }


    }
}
