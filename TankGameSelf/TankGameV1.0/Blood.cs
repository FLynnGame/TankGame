using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TankGameV1._0.Properties;
using System.Drawing;


namespace TankGameV1._0
{
    class Blood:GameObject
    {
        private int x, y, life,type;
        public Blood(int x, int y, int life,int type)
            :base(x,y)
        {
            this.x = x;
            this.y = y;
            this.life = life;
            this.type = type;
        }

        private static Image[] imgs = {
                                   Resources.current_blood_full,
                                   Resources.current_blood_bar_one,
                                   Resources.current_blood_bar_two,
                                   Resources.current_blood_bar_half
                               };

        /// <summary>
        /// 根据坦克类型以及剩余血量，画不同的血条
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            switch (type)
            {
                case 0:
                    g.DrawImage(imgs[0], this.x, this.y);
                    break;
                case 1:
                    {
                        switch (life)
                        {
                            case 2:
                                g.DrawImage(imgs[0], this.x, this.y);
                                break;
                            case 1:
                                g.DrawImage(imgs[3], this.x, this.y);
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        switch (life)
                        {
                            case 3:
                                g.DrawImage(imgs[0], this.x, this.y);
                                break;
                            case 2:
                                g.DrawImage(imgs[2], this.x, this.y);
                                break;
                            case 1:
                                g.DrawImage(imgs[1], this.x, this.y);
                                break;
                        }
                    }
                    break;
            }
            //画完成就移除
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
