using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.testes {
    public partial class TESTE : UserControl {
        public TESTE() {
            InitializeComponent();
        }

        private void TESTE_Load(object sender, EventArgs e) {
            
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.DrawEllipse(new Pen(Color.Black, 2), new Rectangle(0, 0, 100, 100));
        }
    }
}
