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
            paint(e.Graphics);
        }

        private void paint(Graphics g) {
            new Logo(10, 10, 800, 640).render(g);
        }
    }
}
