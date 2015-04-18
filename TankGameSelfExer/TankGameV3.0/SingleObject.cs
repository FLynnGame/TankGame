using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace TankGameV1._0
{
    class SingleObject
    {
        private SingleObject()
        {

        }

        public static SingleObject _singleObject = null;
        public static SingleObject GetSingle()
        {
            if (_singleObject == null)
            {
                _singleObject = new SingleObject();
            }
            return _singleObject;
        }

        public PlayerTank PT
        {
            get;
            set;
        }

        List<EnemyTank> listEnemyTank = new List<EnemyTank>();
        List<PlayerBullet> listPlayerBullet = new List<PlayerBullet>();

        /// <summary>
        /// 添加游戏对象
        /// </summary>
        /// <param name="go"></param>
        public void AddGameObject(GameObject go)
        {
            if (go is PlayerTank)
            {
                PT = go as PlayerTank;
            }
            else if (go is EnemyTank)
            {
                listEnemyTank.Add(go as EnemyTank);
            }
            else if (go is PlayerBullet)
            {
                listPlayerBullet.Add(go as PlayerBullet);
            }
        }

        public void Draw(Graphics g)
        {
            PT.Draw(g);
            for (int i = 0; i < listEnemyTank.Count; i++)
            {
                listEnemyTank[i].Draw(g);
            }
            for (int i = 0; i < listPlayerBullet.Count; i++)
            {
                listPlayerBullet[i].Draw(g);
            }
        }

        public void RemoveGameObject(GameObject go)
        {
            if (go is EnemyTank)
            {
                listEnemyTank.Remove(go as EnemyTank);
            }
            if (go is PlayerBullet)
            {
                listPlayerBullet.Remove(go as PlayerBullet);
            }
        }
    }
}
