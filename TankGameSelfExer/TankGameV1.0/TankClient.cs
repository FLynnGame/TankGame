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

            
            this.BackColor = Color.Black;
        }
    }
}
