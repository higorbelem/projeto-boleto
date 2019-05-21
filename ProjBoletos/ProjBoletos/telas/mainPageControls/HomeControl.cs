using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.mainPageControls {
    public partial class HomeControl : UserControl {

        public HomeControl() {
            InitializeComponent();
            //Console.WriteLine("constr: " + Width);
        }

        private void HomeControl_Load(object sender, EventArgs e) {
            //Console.WriteLine("onload: " + Width);
            //int cardWidth = (this.Width / quantCards) - (spaceBetweenCards / 2);
            bringClickedTab("medicoes");

            tabMenu.BackColor = ColorTranslator.FromHtml("#e6e6e6");

            tabMedicoes.normalColor = ColorTranslator.FromHtml("#e6e6e6");
            tabMedicoes.onEnterColor = ColorTranslator.FromHtml("#d9d9d9");
            tabMedicoes.onClickColor = ColorTranslator.FromHtml("#cccccc");
            tabMedicoes.title = "Medições";

            tabBoletos.normalColor = ColorTranslator.FromHtml("#e6e6e6");
            tabBoletos.onEnterColor = ColorTranslator.FromHtml("#d9d9d9");
            tabBoletos.onClickColor = ColorTranslator.FromHtml("#cccccc");
            tabBoletos.title = "Boletos";
        }

        private void HomeControl_Resize(object sender, EventArgs e) {

            tabMenu.Location = new Point(0,0);
            tabMenu.Size = new Size(ClientRectangle.Width, 70);

            tabMedicoes.Size = new Size(150,tabMenu.Height);
            tabMedicoes.Margin = new Padding(20, 0, 0, 0);

            tabBoletos.Size = new Size(150, tabMenu.Height);
            //tabBoletos.Margin = new Padding(20, 0, 0, 0);

            tabMedicoesWindow.Location = new Point(0,tabMenu.Height);
            tabMedicoesWindow.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - tabMenu.Height);

            tabBoletosWindow.Location = new Point(0, tabMenu.Height);
            tabBoletosWindow.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - tabMenu.Height);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0,0,Width,Height));
            //e.Graphics.FillRectangle(new SolidBrush(Color.Red),newSize);
        }

        private void bringClickedTab(string control) {
            if (control.Equals("medicoes")) {
                tabMedicoesWindow.Visible = true;
                tabBoletosWindow.Visible = false;
                tabMedicoes.selected = true;
            } else {
                tabMedicoes.selected = false;
            }

            if (control.Equals("boletos")) {
                tabMedicoesWindow.Visible = false;
                tabBoletosWindow.Visible = true;
                tabBoletos.selected = true;
            } else {
                tabBoletos.selected = false;
            }

            tabMedicoes.Invalidate();
            tabBoletos.Invalidate();
        }

        private void tabMedicoes_Click(object sender, EventArgs e) {
            bringClickedTab("medicoes");
        }

        private void tabBoletos_Click(object sender, EventArgs e) {
            bringClickedTab("boletos");
        }

        private void tabBoletos_Load(object sender, EventArgs e) {

        }
    }
}
