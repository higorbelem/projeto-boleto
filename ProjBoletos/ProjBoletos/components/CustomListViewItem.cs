using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.testes;
using ProjBoletos.utils;
using System.Drawing.Drawing2D;
using ProjBoletos.modelos;

namespace ProjBoletos.components {
    public partial class CustomListViewItem : UserControl {

        private List<string[]> valores;

        public bool isCabecalho = false;
        public Color circleColor = Color.Transparent;

        public Medicao medicao;

        public CustomListViewItem() {
            InitializeComponent();

            valores = new List<string[]>();
        }

        private void CustomListViewItem_Load(object sender, EventArgs e) {
            btn.title = "GERAR";
            btn.cornerRadius = 2;

        }

        public void addValor(string valor, string scale) {
            valores.Add(new string[] { valor, scale });
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle circleRect = new Rectangle(0, 0, ClientRectangle.Height, ClientRectangle.Height);

            if (isCabecalho) {
                btn.Visible = false;
            }
            else{
                e.Graphics.FillEllipse(new SolidBrush(circleColor), new Rectangle(circleRect.X + 17, circleRect.Y + 17, circleRect.Width - 34, circleRect.Height - 34));
            }

            btn.Size = new Size(100,ClientRectangle.Height - 10);
            btn.Location = new Point(ClientRectangle.Width-btn.Width,5);

            Rectangle newSize = new Rectangle(circleRect.Width,0,ClientRectangle.Width - btn.Width - circleRect.Width,ClientRectangle.Height);

            //e.Graphics.FillRectangle(new SolidBrush(Color.Red),new Rectangle(0,0,ClientRectangle.Width,ClientRectangle.Height));
            int sizeColumns = newSize.X;
            int lastWidth = 0;
            float scalesSum = 0;

            for (int i = 0; i < valores.Count; i++) {
                scalesSum += float.Parse(valores[i][1]);
            }

            for (int i = 0 ; i < valores.Count; i++) {
                Rectangle rectangle = new Rectangle(sizeColumns ,0,(int)((newSize.Width / scalesSum) * float.Parse(valores[i][1])), newSize.Height);
                lastWidth = rectangle.Width;
                //e.Graphics.FillRectangle(new SolidBrush(Color.Red), rectangle);

                int stringMargin = 10; 
                Rectangle stringRectangle = new Rectangle(rectangle.X + stringMargin, rectangle.Y,rectangle.Width - stringMargin*2, rectangle.Height);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Near;
                e.Graphics.DrawString(valores[i][0], new Font("Ebrima", 10, FontStyle.Bold), new SolidBrush(Colors.primaryText), stringRectangle, sf);

                sizeColumns += rectangle.Width;
            }

            /*if (lastWidth < ClientRectangle.Width) {

            }*/

        }

        private void btn_Click(object sender, EventArgs e){
            
        }
    }
}
