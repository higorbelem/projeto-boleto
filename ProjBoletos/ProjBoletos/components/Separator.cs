using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.components {
    public partial class Separator : UserControl {

        public Color color = ColorTranslator.FromHtml("#898c92");

        public Separator() {
            InitializeComponent();
        }

        private void Separator_Load(object sender, EventArgs e) {

        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawLine(new Pen(color),new Point(0,Height/2),new Point(Width,Height/2));
        }
    }
}
