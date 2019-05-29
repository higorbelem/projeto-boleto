using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.components.ParteCimaBoleto;
using ProjBoletos.modelos;
using System.Drawing.Drawing2D;

namespace ProjBoletos {
    public partial class ParteCimaBoleto : UserControl {

        private Cedente cedente;

        private int cornersRadius = 10;

        private int spaceBetweenElements = 15;

        public ParteCimaBoleto() {
            InitializeComponent();
        }

        private void ParteCimaBoleto_Load(object sender, EventArgs e) {

        }

        public void MakeBoleto(Cedente cedente)
        {
            this.cedente = cedente;
        }

        public void print(Graphics g) {
            paint(g);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(1,1,ClientRectangle.Width-2,ClientRectangle.Height-2));

            e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2));
            paint(e.Graphics);
        }

        private void paint(Graphics g) {
            Rectangle rectBoletoHeader = new Rectangle(1, 15, ClientRectangle.Width - 2, (int)(ClientRectangle.Height * 0.1));
            new BoletoHeader(rectBoletoHeader, cedente).render(g);

            Rectangle rectDetalhesFatura = new Rectangle(1, rectBoletoHeader.Y + rectBoletoHeader.Height + spaceBetweenElements, ClientRectangle.Width - 2, (int)(ClientRectangle.Height * 0.07));
            new DetalhesFatura(rectDetalhesFatura,cornersRadius).render(g);

            Rectangle rectDetalhesEndereco = new Rectangle(1, rectDetalhesFatura.Y + rectDetalhesFatura.Height + spaceBetweenElements, ((ClientRectangle.Width - 2)/2) - spaceBetweenElements/2, (int)(ClientRectangle.Height * 0.3));
            new DetalhesEndereco(rectDetalhesEndereco, cornersRadius).render(g);
        }
    }
}
