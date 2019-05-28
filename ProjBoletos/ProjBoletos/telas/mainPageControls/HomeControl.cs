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

            medicoesCustomScrollbar.backgroundColor = Color.White;
            medicoesCustomScrollbar.color = ColorTranslator.FromHtml("#3289d8");
            medicoesCustomScrollbar.btnsColor = ColorTranslator.FromHtml("#2575c1");
            medicoesCustomScrollbar.Size = new Size(10, tabMedicoesWindow.Height);
            medicoesCustomScrollbar.Location = new Point(Width - 10, tabMedicoesWindow.Location.Y);
            medicoesCustomScrollbar.Minimum = 0;
            medicoesCustomScrollbar.Maximum = tabMedicoesWindow.panel.Size.Height;
            medicoesCustomScrollbar.LargeChange = medicoesCustomScrollbar.Maximum / medicoesCustomScrollbar.Height + tabMedicoesWindow.Height;
            medicoesCustomScrollbar.SmallChange = 15;
            medicoesCustomScrollbar.Value = Math.Abs(tabMedicoesWindow.AutoScrollPosition.Y);

            tabBoletosWindow.Location = new Point(0, tabMenu.Height);
            tabBoletosWindow.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - tabMenu.Height);

            boletosCustomScrollbar.backgroundColor = Color.White;
            boletosCustomScrollbar.color = ColorTranslator.FromHtml("#3289d8");
            boletosCustomScrollbar.btnsColor = ColorTranslator.FromHtml("#2575c1");
            boletosCustomScrollbar.Size = new Size(10, tabBoletosWindow.Height);
            boletosCustomScrollbar.Location = new Point(Width - 10, tabBoletosWindow.Location.Y);
            boletosCustomScrollbar.Minimum = 0;
            boletosCustomScrollbar.Maximum = tabBoletosWindow.panel.Size.Height;
            boletosCustomScrollbar.LargeChange = boletosCustomScrollbar.Maximum / boletosCustomScrollbar.Height + tabBoletosWindow.Height;
            boletosCustomScrollbar.SmallChange = 15;
            boletosCustomScrollbar.Value = Math.Abs(tabBoletosWindow.AutoScrollPosition.Y);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0,0,Width,Height));
            //e.Graphics.FillRectangle(new SolidBrush(Color.Red),newSize);
        }

        private void bringClickedTab(string control) {
            if (control.Equals("medicoes")) {
                tabMedicoesWindow.Visible = true;
                medicoesCustomScrollbar.Visible = true;
                tabBoletosWindow.Visible = false;
                boletosCustomScrollbar.Visible = false;
                tabMedicoes.selected = true;
            } else {
                tabMedicoes.selected = false;
            }

            if (control.Equals("boletos")) {
                tabMedicoesWindow.Visible = false;
                medicoesCustomScrollbar.Visible = false;
                tabBoletosWindow.Visible = true;
                boletosCustomScrollbar.Visible = true;
                tabBoletos.selected = true;
            } else {
                tabBoletos.selected = false;
            }

            tabMedicoes.Invalidate();
            tabBoletos.Invalidate();
        }

        private void tabMedicoes_Click(object sender, EventArgs e) {
            tabMedicoesWindow.updateCustomViewList();
            bringClickedTab("medicoes");
        }

        private void tabBoletos_Click(object sender, EventArgs e) {
            tabBoletosWindow.updateCustomViewList();
            bringClickedTab("boletos");
        }

        private void tabBoletos_Load(object sender, EventArgs e) {

        }

        private void medicoesCustomScrollbar_Scroll(object sender, EventArgs e) {
            tabMedicoesWindow.AutoScrollPosition = new Point(0, medicoesCustomScrollbar.Value);
            medicoesCustomScrollbar.Invalidate();
            Application.DoEvents();
        }

        private void tabMedicoesWindow_Scroll(object sender, ScrollEventArgs e) {
            
        }

        private void tabMedicoesWindow_MouseWheel(object sender, MouseEventArgs e) {
            medicoesCustomScrollbar.Value = tabMedicoesWindow.VerticalScroll.Value;
            medicoesCustomScrollbar.Invalidate();
            Application.DoEvents();
        }

        private void tabBoletosWindow_MouseWheel(object sender, MouseEventArgs e) {
            boletosCustomScrollbar.Value = tabBoletosWindow.VerticalScroll.Value;
            boletosCustomScrollbar.Invalidate();
            Application.DoEvents();
        }

        private void boletosCustomScrollbar_Scroll(object sender, EventArgs e) {
            tabBoletosWindow.AutoScrollPosition = new Point(0, boletosCustomScrollbar.Value);
            boletosCustomScrollbar.Invalidate();
            Application.DoEvents();
        }
    }
}
