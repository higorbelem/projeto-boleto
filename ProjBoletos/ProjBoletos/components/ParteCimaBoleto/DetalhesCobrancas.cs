using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.utils;

namespace ProjBoletos.components.ParteCimaBoleto
{
    public partial class DetalhesCobrancas : UserControl
    {

        Rectangle rect;

        private int radius;
        private float lineWidth;

        public DetalhesCobrancas(Rectangle rect, int radius, float lineWidth)
        {
            InitializeComponent();

            this.rect = rect;
            this.radius = radius;
            this.lineWidth = lineWidth;
        }

        private void DetalhesCobrancas_Load(object sender, EventArgs e)
        {

        }

        public void render(Graphics g)
        {
            System.Drawing.Drawing2D.GraphicsPath path = RoundedRectangles.Create(rect, radius, true, true, true, true);
            g.DrawPath(new Pen(Colors.boletoLines, lineWidth), path);
        }
    }
}
