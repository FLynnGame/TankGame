using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_画线
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int i = 0;

        private void button1_Click(object sender, EventArgs e)
        {

            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.Black);
            Point p1 = new Point(30, 30);
            Point p2 = new Point(90, 90);

            g.DrawLine(pen, p1, p2);
        }

        //不断往上画东西，不会擦掉原来的东西
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            i++;
            label1.Text = i.ToString();

            Graphics g = this.CreateGraphics();

            Pen pen = new Pen(Color.Black);
            Point p1 = new Point(100, 100);
            Point p2 = new Point(200, 200);

            g.DrawLine(pen, p1, p2);

            Rectangle rect = new Rectangle(20, 30, 50, 50);
            SolidBrush brush = new SolidBrush(Color.Red);
            g.FillEllipse(brush, rect);
        }
    }
}

