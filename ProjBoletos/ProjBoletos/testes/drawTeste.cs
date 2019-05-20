using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.testes {
    public partial class drawTeste : Form {
        public drawTeste() {
            InitializeComponent();
        }

        private void drawTeste_Load(object sender, EventArgs e) {
           
        }

        private void drawTeste_Paint(object sender, PaintEventArgs e) {

        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            Graphics graphicsObj = this.CreateGraphics();

            Pen myPen = new Pen(System.Drawing.Color.Black, 1);

            graphicsObj.DrawRectangle(myPen, new Rectangle(20, 20, 250, 200));
            graphicsObj.DrawRectangle(myPen, new Rectangle(270, 20, 250, 200));
        }
    }
}
