using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.components.ParteCimaBoleto {
    class Logo {

        private int x, y;
        private int width, height;

        public Logo(int x, int y, int width, int height) {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void render(Graphics g) {
            /*StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;*/

            GraphicsPath path = RoundedRectangles.Create(x, y, width, height , 50, true, true, false, false);
            g.DrawPath(Pens.Black, path);

            //e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(x, y, width, height));
            //e.Graphics.DrawString("HIDROQUÍMICA", new System.Drawing.Font("Arial", 12,FontStyle.Bold) ,new SolidBrush(Color.Black), new PointF(x, y));
            //e.Graphics.DrawString("CONSULTORIA EM \nTRATAMENTO DE \nÁGUAS EFLUENTES", new System.Drawing.Font("Arial", 8), new SolidBrush(Color.Black), new PointF(x, y+20));

        }

    }
}
