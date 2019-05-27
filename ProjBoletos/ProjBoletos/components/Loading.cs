using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ProjBoletos.utils;
using System.Timers;
using System.Reflection;

namespace ProjBoletos.components
{
    public partial class Loading : UserControl
    {

        System.Timers.Timer timer;
        int angle = 0;

        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            BackColor = Colors.bg2;

            label1.BackColor = Colors.bg2;
            label1.ForeColor = Colors.primaryText;

            timer = new System.Timers.Timer(8); //~60 FPS
            timer.AutoReset = true;
            timer.SynchronizingObject = this;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
            
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            angle += 5;

            if (angle > 360)
            {
                angle = 0;
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            int x = ClientRectangle.Width / 2;
            int y = ClientRectangle.Height / 2;
            
            int length = 70;

            Point point1 = new Point(x, y);

            int sizeElipse = 20;
            int sizeElipseDimin = 0;

            for (double i = angle; i > -360; i-=22.5) {
                Point point2 = new Point((int)(x + Math.Cos(Radian(i)) * length), (int)(y + Math.Sin(Radian(i)) * length));
                e.Graphics.FillEllipse(new SolidBrush(Colors.accent1), new Rectangle(point2.X - ((sizeElipse - sizeElipseDimin) / 2), point2.Y - ((sizeElipse - sizeElipseDimin) / 2), (sizeElipse - sizeElipseDimin), (sizeElipse - sizeElipseDimin)));
                sizeElipseDimin += 1;
            }

            label1.Location = new Point((ClientRectangle.Width/2)-(label1.Width/2), (int)(y + Math.Sin(Radian(90)) * length) + 20);

            /*StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            e.Graphics.DrawString("Aguarde...", new Font("Ebrima", 12, FontStyle.Bold), new SolidBrush(Colors.primaryText), new Rectangle(0, (int)(y + Math.Sin(Radian(90)) * length),ClientRectangle.Width,70), sf);
            */

            e.Graphics.Dispose();

            //e.Graphics.DrawLine(new Pen(Color.Black),point1,point2);
            //e.Graphics.DrawLine(new Pen(Color.Black),new Point(ClientRectangle.Width/2,ClientRectangle.Height/2),EndPoint(90));
        }

        private double Radian(double angle) { return (Math.PI / 180.0) * angle; }
    }
}
