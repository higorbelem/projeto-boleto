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

        int quantCards = 4;
        int spaceBetweenCards = 20;

        int padding = 25;

        Rectangle newSize;

        public HomeControl() {
            InitializeComponent();
            //Console.WriteLine("constr: " + Width);
        }

        private void HomeControl_Load(object sender, EventArgs e) {
            //Console.WriteLine("onload: " + Width);
            //int cardWidth = (this.Width / quantCards) - (spaceBetweenCards / 2);
            
            mainCard1.title = "Recentes";
            mainCard1.numString = "23";
            mainCard1.notifString = "2";
            mainCard1.ascentColor = ColorTranslator.FromHtml("#31efa1");
            
            mainCard2.title = "Perto do vencimento";
            mainCard2.numString = "9";
            mainCard2.notifString = "0";
            mainCard2.ascentColor = ColorTranslator.FromHtml("#ff794d");
            
            mainCard3.title = "Atrasadas";
            mainCard3.numString = "3";
            mainCard3.notifString = "0";
            mainCard3.ascentColor = ColorTranslator.FromHtml("#d83b63");

            mainCard4.title = "Boletos à imprimir";
            mainCard4.numString = "41";
            mainCard4.notifString = "9";
            mainCard4.ascentColor = ColorTranslator.FromHtml("#705bb2");

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
            tabBoletos.Margin = new Padding(20, 0, 0, 0);

            newSize = new Rectangle(padding, padding + tabMenu.Height, Width - padding * 2, Height - padding * 2);
            
            int cardWidth = (newSize.Width - (spaceBetweenCards*(quantCards-1))) / quantCards;

            mainCard1.Location = new Point(newSize.X,newSize.Y);
            mainCard1.Size = new Size(cardWidth, mainCard1.Size.Height);

            mainCard2.Location = new Point(newSize.X + cardWidth + spaceBetweenCards, newSize.Y);
            mainCard2.Size = new Size(cardWidth, mainCard2.Size.Height);

            mainCard3.Location = new Point(newSize.X + cardWidth * 2 + spaceBetweenCards * 2, newSize.Y);
            mainCard3.Size = new Size(cardWidth, mainCard3.Size.Height);

            mainCard4.Location = new Point(newSize.X + cardWidth * 3 + spaceBetweenCards * 3, newSize.Y);
            mainCard4.Size = new Size(cardWidth, mainCard4.Size.Height);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            //e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0,0,Width,Height));
            //e.Graphics.FillRectangle(new SolidBrush(Color.Red),newSize);
        }

        private void bringClickedTab(string control) {
            if (control.Equals("home")) {
                homeControl.Visible = true;
                configControl.Visible = false;
                btnHome.selected = true;
            } else {
                btnHome.selected = false;
            }

            if (control.Equals("config")) {
                homeControl.Visible = false;
                configControl.Visible = true;
                btnConfig.selected = true;
            } else {
                btnConfig.selected = false;
            }

            btnHome.Invalidate();
            btnConfig.Invalidate();
        }
    }
}
