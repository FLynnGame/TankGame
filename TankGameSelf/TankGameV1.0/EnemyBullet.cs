using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using TankGameV1._0.Properties;
using System.Media;

namespace TankGameV1._0
{
    class EnemyBullet:BulletFather
    {
        private static Image img = Resources.enemymissile;
        public EnemyBullet(TankFather tf, int speed, int life, int power)
            : base(tf, speed, life, power, img)
        {

        }


        public override void BeHit()
        {
            //如果子弹击中物体
            //播放小爆炸图片
            //播放击中物体小爆炸声音
            //移除子弹对象

            SingleObject.GetSingle().AddGameObject(new SmallBoom(this.X, this.Y));

            SoundPlayer sp = new SoundPlayer(Resources.hit);
            sp.Play();

            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}
