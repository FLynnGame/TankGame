using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankGameV1._0
{
    public partial class TankClient : Form
    {
        public TankClient()
        {
            InitializeComponent();
            InitialGame();
        }

        public static int GameWidth = 800, GameHeight = 600;

        public void InitialGame()
        {
            //窗口的大小
            this.Size = new Size(GameWidth, GameHeight);

            //使窗口不可拖动大小
            this.MaximumSize = new Size(GameWidth, GameHeight);
            this.MinimumSize = new Size(GameWidth, GameHeight);

            //不显示窗口最大化及最小化按钮
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Text = "TankGame";
            
            this.BackColor = Color.Black;

            SingleObject.GetSingle().AddGameObject(new PlayerTank(200, 200, 1, 10, Direction.Down));
        }

        private void TankClient_KeyDown(object sender, KeyEventArgs e)
        {
            SingleObject.GetSingle().PT.KeyDown(e);
        }

        private void TankClient_Paint(object sender, PaintEventArgs e)
        {
            SingleObject.GetSingle().Draw(e.Graphics);
        }

        //双缓冲减少闪烁
        private void TankClient_Load(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint, true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
