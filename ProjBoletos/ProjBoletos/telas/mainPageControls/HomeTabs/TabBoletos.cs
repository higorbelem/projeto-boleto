using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.mainPageControls.HomeTabs {
    public partial class TabBoletos : UserControl {

        int quantCards = 3;
        int spaceBetweenCards = 20;
        int cardHeight = 220;

        Padding padding = new Padding(40, 20, 40, 40);

        public Panel panel;

        public TabBoletos() {
            InitializeComponent();

            panel = panel1;
        }

        private void TabBoletos_Load(object sender, EventArgs e) {
            mainCard1.title = "Boletos recentes";
            mainCard1.numString = "41";
            mainCard1.notifString = "10";
            mainCard1.ascentColor = ColorTranslator.FromHtml("#31efa1");

            mainCard2.title = "Boletos perto de vencer";
            mainCard2.numString = "0";
            mainCard2.notifString = "0";
            mainCard2.ascentColor = ColorTranslator.FromHtml("#ff794d");

            mainCard3.title = "Boletos atrasados";
            mainCard3.numString = "2";
            mainCard3.notifString = "0";
            mainCard3.ascentColor = ColorTranslator.FromHtml("#d83b63");
        }

        private void TabBoletos_Resize(object sender, EventArgs e) {
            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(ClientRectangle.Width, panel1.Height);
            panel1.MinimumSize = new Size(ClientRectangle.Width, 0);
            panel1.MaximumSize = new Size(ClientRectangle.Width, 0);

            Rectangle newSize = new Rectangle(padding.Left,padding.Top,panel1.Width - padding.Left - padding.Right, panel1.Height - padding.Top - padding.Bottom);

            int cardWidth = (newSize.Width - (spaceBetweenCards * (quantCards - 1))) / quantCards;

            mainCard1.Location = new Point(newSize.X, newSize.Y);
            mainCard1.Size = new Size(cardWidth, cardHeight);

            mainCard2.Location = new Point(newSize.X + cardWidth + spaceBetweenCards, newSize.Y);
            mainCard2.Size = new Size(cardWidth, cardHeight);

            mainCard3.Location = new Point(newSize.X + cardWidth * 2 + spaceBetweenCards * 2, newSize.Y);
            mainCard3.Size = new Size(cardWidth, cardHeight);
        }
    }
}
