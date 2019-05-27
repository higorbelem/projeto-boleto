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

namespace ProjBoletos.components {
    public partial class Box : UserControl {

        public int radius = 20;
        public int shadowSize = 10;
        public Color color = Color.White;

        public Box() {
            InitializeComponent();
            this.BackColor = Color.Transparent;
        }

        private void Box_Load(object sender, EventArgs e) {
              
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle  rectangle = drawShadow(shadowSize, e);

            //Rectangle rectangle = new Rectangle(1, 1, this.Size.Width - 2, this.Size.Height - 2);

            GraphicsPath path = RoundedRectangles.Create(rectangle, radius);

            Brush brush = new SolidBrush(color);

            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(new Pen(brush), path);

            e.Graphics.Dispose();
        }

        private Rectangle drawShadow(int tamanho, PaintEventArgs e) {
            Rectangle rectangleAtual = new Rectangle(1, 1, this.Size.Width - 2, this.Size.Height - 2);

            int alpha = 10;
            Color color = Color.FromArgb(alpha, 0, 0, 0);

            float variant = 5 / tamanho;

            for (int i = 0; i < tamanho; i++) {
                GraphicsPath shadowPath = RoundedRectangles.Create(rectangleAtual,radius+i);
                //e.Graphics.DrawPath(new Pen(color), shadowPath);
                e.Graphics.FillPath(new SolidBrush(color), shadowPath);

                rectangleAtual.X += 2;
                rectangleAtual.Y += 2;
                rectangleAtual.Width -= 4;
                rectangleAtual.Height -= 4;

                alpha = (int)(alpha + variant);
                color = Color.FromArgb(alpha,0,0,0);
            }

            return rectangleAtual;
        }

        private void Box_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
