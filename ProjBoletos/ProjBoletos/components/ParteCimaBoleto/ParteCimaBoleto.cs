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

namespace ProjBoletos {
    public partial class ParteCimaBoleto : UserControl {


        public ParteCimaBoleto() {
            InitializeComponent();
        }

        private void ParteCimaBoleto_Load(object sender, EventArgs e) {

        }

        public void print(Graphics g) {
            paint(g);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(1,1,ClientRectangle.Width-2,ClientRectangle.Height-2));

            e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2));
            paint(e.Graphics);
        }

        private void paint(Graphics g) {
            new BoletoHeader(new Rectangle(1,15,ClientRectangle.Width - 2 , (int)(ClientRectangle.Height*0.1))).render(g);
        }
    }
}
