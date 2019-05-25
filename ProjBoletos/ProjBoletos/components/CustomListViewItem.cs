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
    public partial class CustomListViewItem : UserControl {

        private List<string[]> valores;

        public CustomListViewItem() {
            InitializeComponent();

            valores = new List<string[]>();
        }

        private void CustomListViewItem_Load(object sender, EventArgs e) {

        }

        public void addValor(string valor, string scale) {
            valores.Add(new string[] { valor, scale });
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            //e.Graphics.FillRectangle(new SolidBrush(Color.Red),new Rectangle(0,0,ClientRectangle.Width,ClientRectangle.Height));
            int sizeColumns = 0;
            int lastWidth = 0;
            float scalesSum = 0;

            for (int i = 0; i < valores.Count; i++) {
                scalesSum += float.Parse(valores[i][1]);
            }

            for (int i = 0 ; i < valores.Count; i++) {
                Rectangle rectangle = new Rectangle(sizeColumns ,0,(int)((ClientRectangle.Width / scalesSum) * float.Parse(valores[i][1])),ClientRectangle.Height);
                lastWidth = rectangle.Width;
                //e.Graphics.FillRectangle(new SolidBrush(Color.Red), rectangle);

                int stringMargin = 10; 
                Rectangle stringRectangle = new Rectangle(rectangle.X + stringMargin, rectangle.Y,rectangle.Width - stringMargin*2, rectangle.Height);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(valores[i][0], new Font("Ebrima", 10, FontStyle.Bold), new SolidBrush(Color.Black), stringRectangle, sf);

                sizeColumns += rectangle.Width;
            }

            /*if (lastWidth < ClientRectangle.Width) {

            }*/

        }
    }
}
