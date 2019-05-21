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

        Padding padding = new Padding(40, 20, 40, 40);

        int cardHeight = 220;

        Rectangle newSize;

        public TabBoletos() {
            InitializeComponent();
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
            newSize = new Rectangle(padding.Left, padding.Top, Width - padding.Right * 2, Height - padding.Bottom * 2);

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
