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
    class SingleObject
    {
        private SingleObject()
        {
        }

        //第一步 创建游戏对象
        //懒汉式单利设计模式 单例模式：构造函数私有化
        //单例类用来创建我们全局唯一的游戏对象
        private static SingleObject _singleObject = null;
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

        //将我们的敌人存储在泛型集合中
        List<EnemyTank> listEnemyTank = new List<EnemyTank>();
        List<EnemyBullet> listEnemyBullet = new List<EnemyBullet>();
        List<PlayerBullet> listPlayerBullet = new List<PlayerBullet>();
        List<Boom> listBoom = new List<Boom>();
        List<SmallBoom> listSmallBoom = new List<SmallBoom>();

        List<TankBorn> listTankBorn = new List<TankBorn>();
        List<Blood> listBlood = new List<Blood>();
        List<Wall> listWall = new List<Wall>();
        List<Grass> listGrass = new List<Grass>();
        List<SteelWall> listSteelWall = new List<SteelWall>();
        List<Water> listWater = new List<Water>();
        List<Symbol> listSymbol = new List<Symbol>();

        //is 和 as 操作
        /*
         * In general, the as operator is more efficient because it actually returns the cast value 
         * if the cast can be made successfully. The is operator returns only a Boolean value. 
         * It can therefore be used when you just want to determine an object's type but do not have 
         * to actually cast it.
         */
        //第二步 添加游戏对象
        public bool AddGameObject(GameObject go)
        {
            if (go is PlayerTank)
            {
                PT = go as PlayerTank;
                return true;
            }
            else if (go is EnemyTank)
            {
                listEnemyTank.Add(go as EnemyTank);
                return true;
            }
            else if (go is EnemyBullet)
            {
                //一次只能连发两颗子弹
                if (listEnemyBullet.Count() <= 1)
                {
                    listEnemyBullet.Add(go as EnemyBullet);
                    return true;
                } 
            }
            else if (go is PlayerBullet)
            {
                //一次只能连发两颗子弹 
                if (listPlayerBullet.Count() <= 1)
                {
                    listPlayerBullet.Add(go as PlayerBullet);
                    return true;
                }
               
            }
            else if (go is Boom)
            {
                listBoom.Add(go as Boom);
                return true;
            }
            else if (go is SmallBoom)
            {
                listSmallBoom.Add(go as SmallBoom);
                return true;
            }
            else if (go is TankBorn)
            {
                listTankBorn.Add(go as TankBorn);
                return true;
            }
            else if (go is Blood)
            {
                listBlood.Add(go as Blood);
                return true;
            }
            else if (go is Wall)
            {
                listWall.Add(go as Wall);
                return true;
            }
            else if (go is Grass)
            {
                listGrass.Add(go as Grass);
                return true;
            }
            else if (go is SteelWall)
            {
                listSteelWall.Add(go as SteelWall);
                return true;
            }
            else if (go is Water)
            {
                listWater.Add(go as Water);
                return true;
            }
            else if (go is Symbol)
            {
                listSymbol.Add(go as Symbol);
                return true;
            }
            return false;
        }


        //第三步：绘制游戏对象
        public void Draw(Graphics g)
        {
            Bitmap gameBackGround = new Bitmap(new Bitmap("backGround.jpg"));
            Bitmap bmp = new Bitmap(800,600);
            Graphics buffergs = Graphics.FromImage(bmp);

            Rectangle rect = new Rectangle(0, 0, 800, 600);
            buffergs.DrawImage(gameBackGround, rect);

            //画玩家坦克就一辆
            PT.Draw(buffergs);

            //画敌人坦克
            for (int i = 0; i < listEnemyTank.Count(); i++)
            {
                listEnemyTank[i].Draw(buffergs);
            }
            //画玩家子弹
            for (int i = 0; i < listPlayerBullet.Count(); i++)
            {
                listPlayerBullet[i].Draw(buffergs);
            }
            //画敌人子弹
            for (int i = 0; i < listEnemyBullet.Count(); i++)
            {
                listEnemyBullet[i].Draw(buffergs);
            }
            //画爆炸效果
            for (int i = 0; i < listBoom.Count(); i++)
            {
                listBoom[i].Draw(buffergs);
            }
            for (int i = 0; i < listTankBorn.Count(); i++)
            {
                listTankBorn[i].Draw(buffergs);
            }
            for (int i = 0; i < listSmallBoom.Count(); i++)
            {
                listSmallBoom[i].Draw(buffergs);
            }
            for (int i = 0; i < listBlood.Count(); i++)
            {
                listBlood[i].Draw(buffergs);
            }
            for (int i = 0; i < listWall.Count(); i++)
            {
                listWall[i].Draw(buffergs);
            }
            for (int i = 0; i < listGrass.Count(); i++)
            {
                listGrass[i].Draw(buffergs);
            }
            for (int i = 0; i < listSteelWall.Count(); i++)
            {
                listSteelWall[i].Draw(buffergs);
            }
            for (int i = 0; i < listWater.Count(); i++)
            {
                listWater[i].Draw(buffergs);
            }
            for (int i = 0; i < listSymbol.Count(); i++)
            {
                listSymbol[i].Draw(buffergs);
            }

            g.DrawImage(bmp, 0, 0);
        }

        public void RemoveGameObject(GameObject go)
        {
            if (go is Boom)
            {
                listBoom.Remove(go as Boom);
            }
            else if (go is PlayerBullet)
            {
                listPlayerBullet.Remove(go as PlayerBullet);
            }
            else if (go is EnemyBullet)
            {
                listEnemyBullet.Remove(go as EnemyBullet);
            }
            else if (go is EnemyTank)
            {
                listEnemyTank.Remove(go as EnemyTank);
            }
            else if (go is TankBorn)
            {
                listTankBorn.Remove(go as TankBorn);
            }
            else if (go is SmallBoom)
            {
                listSmallBoom.Remove(go as SmallBoom);
            }
            else if (go is Blood)
            {
                listBlood.Remove(go as Blood);
            }
            else if (go is Wall)
            {
                listWall.Remove(go as Wall);
            }
            else if (go is Grass)
            {
                listGrass.Remove(go as Grass);
            }
            else if (go is SteelWall)
            {
                listSteelWall.Remove(go as SteelWall);
            }
            else if (go is Water)
            {
                listWater.Remove(go as Water);
            }
            else if (go is Symbol)
            {
                listSymbol.Remove(go as Symbol);
            }
        }

        private int stopTime = 0;

        /// <summary>
        /// 碰撞检测
        /// </summary>
        public void IsCrash()
        {
            #region 玩家的子弹是否打到敌人身上
            for (int i = 0; i < listPlayerBullet.Count(); i++)
            {
                for (int j = 0; j < listEnemyTank.Count(); j++)
                {
                    if (listPlayerBullet[i].GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                    { 
                        listEnemyTank[j].Life -= listPlayerBullet[i].Power;
                        listEnemyTank[j].IsOver();

                        //listEnemyBullet.Remove(listEnemyBullet[j]);

                        //将玩家子弹移除
                        listPlayerBullet.Remove(listPlayerBullet[i]);
                        break;
                    }
                }
            }
            #endregion

            #region 敌人的子弹是否打到玩家身上
            for (int i = 0; i < listEnemyBullet.Count(); i++)
            {
                if (listEnemyBullet[i].GetRectangle().IntersectsWith(PT.GetRectangle()))
                {
                    PT.Life -= listEnemyBullet[i].Power;
                    PT.IsOver();

                    //将敌人子弹移除
                    listEnemyBullet.Remove(listEnemyBullet[i]);
                    break;
                }
            }
            #endregion

            #region 敌人的子弹与玩家子弹是否碰撞
            for (int i = 0; i < listPlayerBullet.Count(); i++)
            {
                for (int j = 0; j < listEnemyBullet.Count(); j++)
                {
                    if (listPlayerBullet[i].GetRectangle().IntersectsWith(listEnemyBullet[j].GetRectangle()))
                    {
                        //如果碰撞，则把两方子弹都移除
                        listEnemyBullet.Remove(listEnemyBullet[j]);
                        listPlayerBullet.Remove(listPlayerBullet[i]);
                        break;
                    }
                }
            }
            #endregion

            #region 玩家的子弹是否碰撞到墙壁
            for (int i = 0; i < listPlayerBullet.Count(); i++)
            {
                //一旦打到墙壁上，就播放图片，以及播放声音
                if (listPlayerBullet[i].X <= 0 || listPlayerBullet[i].X >= 750 
                    || listPlayerBullet[i].Y <= 0 || listPlayerBullet[i].Y >= 550)
                {
                    listPlayerBullet[i].BeHit();
                }
            }
            #endregion 

            #region 敌人的子弹是否碰撞到墙壁
            for (int i = 0; i < listEnemyBullet.Count(); i++)
            {
                if(listEnemyBullet[i].X <= 0 || listEnemyBullet[i].X >= 750
                    || listEnemyBullet[i].Y <= 0 || listEnemyBullet[i].Y >= 550)
                {
                    listEnemyBullet[i].BeHit();
                }
            }
            #endregion

            #region 玩家坦克与敌人坦克是否相撞
            for (int i = 0; i < listEnemyTank.Count(); i++)
            {
                if (PT.GetRectangle().IntersectsWith(listEnemyTank[i].GetRectangle()))
                {
                    PT.hitCheck = false;//不可移动
                    PT.X = PT.TankStopX();
                    PT.Y = PT.TankStopY();

                    //listEnemyTank[i].X = listEnemyTank[i].TankStopX();
                    //listEnemyTank[i].Y = listEnemyTank[i].TankStopY();
                }
                else
                {
                    PT.hitCheck = true;
                }
            }
            #endregion

            #region 玩家子弹是否打中砖墙
            for (int i = 0; i < listPlayerBullet.Count(); i++)
            {
                for (int j = 0; j < listWall.Count(); j++)
                {
                    //int ptx = listPlayerBullet[i].X + listPlayerBullet[i].Width/2;
                    //int pty = listPlayerBullet[i].Y + listPlayerBullet[i].Height/2;
                    //int wallx = listWall[j].X + listWall[j].Width / 2;
                    //int wally = listWall[j].Y + listWall[j].Height / 2;//分别存储子弹与每一块墙体的中心点

                    //if (Math.Abs(ptx - wallx) < 8 && Math.Abs(pty - wally) <= 16)//不精确？为啥？？？ PlayTank中误传坦克的宽高，调试得知
                    //{
                    //    listWall.Remove(listWall[j]);
                    //    //listWall[j] = null;
                    //    listPlayerBullet.Remove(listPlayerBullet[i]);//太过精确
                    //    break;
                    //}
                    if (listPlayerBullet[i].GetRectangle().IntersectsWith(listWall[j].GetRectangle()))
                    {
                        listWall.Remove(listWall[j]);
                        //listWall[j] = null;
                        listPlayerBullet.Remove(listPlayerBullet[i]);
                        break;
                    }
                }
            }
            #endregion

            #region 敌人坦克是否与钢铁墙碰撞
            for (int i = 0; i < listEnemyTank.Count(); i++)
            {
                for (int j = 0; j < listSteelWall.Count(); j++)
                {
                    if (listEnemyTank[i].GetRectangle().IntersectsWith(listSteelWall[j].GetRectangle()))
                    {
                        listEnemyTank[i].X = listEnemyTank[i].TankStopX();
                        listEnemyTank[i].Y = listEnemyTank[i].TankStopY();
                    }
                }
            }
            #endregion

            #region 敌人坦克是否与砖墙碰撞
            for (int i = 0; i < listEnemyTank.Count(); i++)
            {
                for (int j = 0; j < listWall.Count(); j++)
                {
                    if (listEnemyTank[i].GetRectangle().IntersectsWith(listWall[j].GetRectangle()))
                    {
                        listEnemyTank[i].X = listEnemyTank[i].TankStopX();
                        listEnemyTank[i].Y = listEnemyTank[i].TankStopY();
                    }
                }
            }
            #endregion

            #region 敌人坦克是否与水坑碰撞
            for (int i = 0; i < listEnemyTank.Count(); i++)
            {
                for (int j = 0; j < listWater.Count(); j++)
                {
                    if (listEnemyTank[i].GetRectangle().IntersectsWith(listWater[j].GetRectangle()))
                    {
                        listEnemyTank[i].X = listEnemyTank[i].TankStopX();
                        listEnemyTank[i].Y = listEnemyTank[i].TankStopY();
                    }
                }
            }
            #endregion
        } 
    }
}
