using ProjBoletos.modelos;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.components.ParteCimaBoleto{
    class BoletoHeader : UserControl{

        public Rectangle rect;
        private Rectangle leftRect;
        private Rectangle centerRect;
        private Rectangle rightRect;

        private Cedente cedente;

        public BoletoHeader(Rectangle rect,Cedente cedente) {
            this.rect = rect;
            leftRect = new Rectangle(rect.X,rect.Y,rect.Width/4,rect.Height);
            centerRect = new Rectangle(leftRect.X + leftRect.Width, rect.Y, rect.Width / 4*2, rect.Height);
            rightRect = new Rectangle(centerRect.X + centerRect.Width, rect.Y, rect.Width / 4*1, rect.Height);

            this.cedente = cedente;
        }

        public BoletoHeader(Cedente cedente)
        {
            this.cedente = cedente;
        }

        public void setRect(Rectangle rect){
            this.rect = rect;
            leftRect = new Rectangle(rect.X, rect.Y, rect.Width / 4, rect.Height);
            centerRect = new Rectangle(leftRect.X + leftRect.Width, rect.Y, rect.Width / 4 * 2, rect.Height);
            rightRect = new Rectangle(centerRect.X + centerRect.Width, rect.Y, rect.Width / 4 * 1, rect.Height);
        }

        public void render(Graphics g) {
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Center;

            /*GraphicsPath path = RoundedRectangles.Create(x, y, width, height , 50, true, true, false, false);
            g.DrawPath(Pens.Black, path);*/

            //e.Graphics.DrawRectangle(new Pen(Color.Black, 1), new Rectangle(x, y, width, height));
            //e.Graphics.DrawString("HIDROQUÍMICA", new System.Drawing.Font("Arial", 12,FontStyle.Bold) ,new SolidBrush(Color.Black), new PointF(x, y));
            //e.Graphics.DrawString("CONSULTORIA EM \nTRATAMENTO DE \nÁGUAS EFLUENTES", new System.Drawing.Font("Arial", 8), new SolidBrush(Color.Black), new PointF(x, y+20));

            /*g.DrawRectangle(new Pen(Color.Red),leftRect);
            g.DrawRectangle(new Pen(Color.Red), rightRect);
            g.DrawRectangle(new Pen(Color.Red), centerRect);*/

            Bitmap imgLogo = new Bitmap(Properties.Resources.logo2);
            Size imgLogoSize = new Size(leftRect.Height*(imgLogo.Width/imgLogo.Height),leftRect.Height);
            g.DrawImage(imgLogo, new Rectangle((leftRect.Width/2)-(imgLogoSize.Width/2) + 5, leftRect.Y + 5, imgLogoSize.Width - 10, imgLogoSize.Height - 10));

            g.DrawString(cedente.nome, Fonts.mainBold10, new SolidBrush(Color.Black),new Rectangle(centerRect.X,centerRect.Y,centerRect.Width,centerRect.Height/4) ,format);
            g.DrawString(cedente.rua + ", " + cedente.numero + " - " + cedente.bairro + " - CEP: " + cedente.cep, Fonts.main8, new SolidBrush(Color.Black), new Rectangle(centerRect.X, centerRect.Y + (centerRect.Height / 4), centerRect.Width, centerRect.Height / 4), format);
            g.DrawString(cedente.cidade + "/" + cedente.uf, Fonts.main8, new SolidBrush(Color.Black), new Rectangle(centerRect.X, centerRect.Y + (centerRect.Height / 4)*2, centerRect.Width, centerRect.Height / 4), format);
            g.DrawString("CNPJ: " + cedente.cnpj, Fonts.main8, new SolidBrush(Color.Black), new Rectangle(centerRect.X, centerRect.Y + (centerRect.Height / 4) * 3, centerRect.Width, centerRect.Height / 4), format);

            g.DrawString("RECLAMAÇÔES E SUGESTÕES", Fonts.mainBold10, new SolidBrush(Color.Black), new Rectangle(rightRect.X,rightRect.Y,rightRect.Width,rightRect.Height/2), new StringFormat() { LineAlignment = StringAlignment.Far , Alignment = StringAlignment.Center });
            g.DrawString(cedente.contato, Fonts.mainBold12, new SolidBrush(Color.Black), new Rectangle(rightRect.X, rightRect.Y + (rightRect.Height / 2), rightRect.Width, rightRect.Height / 2), new StringFormat() { LineAlignment = StringAlignment.Near, Alignment = StringAlignment.Center });
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BoletoHeader
            // 
            this.Name = "BoletoHeader";
            this.Load += new System.EventHandler(this.BoletoHeader_Load);
            this.ResumeLayout(false);

        }

        private void BoletoHeader_Load(object sender, EventArgs e)
        {

        }
    }
}
