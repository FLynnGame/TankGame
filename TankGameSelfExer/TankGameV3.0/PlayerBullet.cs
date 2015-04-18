using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using TankGameV1._0.Properties;

namespace TankGameV1._0
{
    class PlayerBullet:BulletsFather
    {
        //载入子弹图片
        private static Image img = Resources.tankmissile;

        public PlayerBullet(TankFather tf, int life, int speed, int power)
            : base(tf, life, speed, power, img)
        {
            this.Power = power;
        }
    }
}
