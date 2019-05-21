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
    public partial class MainCard : UserControl {

        public Color normalColor = ColorTranslator.FromHtml("#434549");
        public string title = "";
        public string numString = "";
        public string notifString = "";

        public Color ascentColor = ColorTranslator.FromHtml("#3289d8");

        /*public Color onEnterColor = ColorTranslator.FromHtml("#494b50");
        public Color onClickColor = ColorTranslator.FromHtml("#56585d");

        Color atualColor;*/

        public MainCard() {
            InitializeComponent();
        }

        private void MainCard_Load(object sender, EventArgs e) {
            //atualColor = normalColor;

            icon.BackColor = ColorTranslator.FromHtml("#434549");
            icon.Image = new Bitmap(Properties.Resources.icon_boleto);
            icon.Size = new Size(150, 150);
            icon.Location = new Point((Width/2)-(icon.Width/2), (Height / 2) - (icon.Height / 2) + 20);
            icon.Visible = false;
        }

        /*protected override void OnMouseEnter(EventArgs e) {
            atualColor = onEnterColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e) {
            atualColor = normalColor;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent) {
            atualColor = onClickColor;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent) {
            atualColor = onEnterColor;
            Invalidate();
        }*/

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);

            e.Graphics.FillRectangle(new SolidBrush(normalColor),new Rectangle(0,0,Width,Height));

            int notifPadding = 20;
            Rectangle notifRect = new Rectangle(Width - 30 - notifPadding, notifPadding, 30, 30);

            StringFormat sfNotif = new StringFormat();
            sfNotif.LineAlignment = StringAlignment.Center;
            sfNotif.Alignment = StringAlignment.Center;

            if (!notifString.Equals("0")) {
                e.Graphics.FillEllipse(new SolidBrush(ColorTranslator.FromHtml("#e6353e")), notifRect);
                
                e.Graphics.DrawString(notifString, new Font("Ebrima", 10, FontStyle.Bold), new SolidBrush(Color.White), notifRect, sfNotif);
            }

            Size imgSize = new Size(110,110);
            Rectangle imgRect = new Rectangle((Width / 2) - (imgSize.Width / 2), (Height / 2) - (imgSize.Height / 2) + 20, imgSize.Width, imgSize.Height);
            e.Graphics.DrawImage(new Bitmap(Properties.Resources.icon_boleto_500x500),imgRect);
            
            StringFormat sfImgNumber = new StringFormat();
            sfImgNumber.LineAlignment = StringAlignment.Center;
            sfImgNumber.Alignment = StringAlignment.Center;
            e.Graphics.DrawString(numString, new Font("Ebrima", 35, FontStyle.Bold), new SolidBrush(ascentColor), imgRect, sfImgNumber);


            Rectangle tituloRect = new Rectangle(20,notifRect.Y,Width-notifRect.Width-notifPadding,notifRect.Height);
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(title, new Font("Ebrima", 14), new SolidBrush(Color.White), tituloRect, sf);

            e.Graphics.FillRectangle(new SolidBrush(ascentColor), new Rectangle(0,Height-10,Width,10));
        }
    }
}
