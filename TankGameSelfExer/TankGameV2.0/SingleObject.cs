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

        //List<PlayerTank> listPlayerTank = new List<PlayerTank>();

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
        }

        public void Draw(Graphics g)
        {
            PT.Draw(g);
        }
    }
}
