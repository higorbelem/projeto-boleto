using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.utils;

namespace ProjBoletos.components.ParteCimaBoleto
{
    public partial class DetalhesFatura : UserControl{

        Rectangle rect1, rect2, rect3, rect4, rect5;
        Rectangle rect1Padding, rect2Padding, rect3Padding, rect4Padding, rect5Padding;

        private string valor1 = "123123";
        private string valor2 = "123123";
        private string valor3 = "123123";
        private string valor4 = "1213";
        private string valor5 = "123123";

        private int paddingLeftRight = 8;
        private int paddingTopBottom = 2;

        private int radius;

        public DetalhesFatura(Rectangle rect, int radius)
        {
            InitializeComponent();

            this.radius = radius;

            rect1 = new Rectangle(rect.X, rect.Y, rect.Width / 5, rect.Height);
            rect2 = new Rectangle(rect1.X + rect1.Width, rect.Y, rect.Width / 5, rect.Height);
            rect3 = new Rectangle(rect2.X + rect2.Width, rect.Y, rect.Width / 5, rect.Height);
            rect4 = new Rectangle(rect3.X + rect3.Width, rect.Y, rect.Width / 5, rect.Height);
            rect5 = new Rectangle(rect4.X + rect4.Width, rect.Y, rect.Width / 5, rect.Height);

            rect1Padding = new Rectangle(rect.X + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
            rect2Padding = new Rectangle(rect1.X + rect1.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
            rect3Padding = new Rectangle(rect2.X + rect2.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
            rect4Padding = new Rectangle(rect3.X + rect3.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
            rect5Padding = new Rectangle(rect4.X + rect4.Width + paddingLeftRight, rect.Y + paddingTopBottom, (rect.Width / 5) - paddingLeftRight * 2, rect.Height - paddingTopBottom * 2);
        }

        public void render(Graphics g)
        {
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;

            StringFormat formatValor = new StringFormat();
            formatValor.LineAlignment = StringAlignment.Center;
            formatValor.Alignment = StringAlignment.Center;

            System.Drawing.Drawing2D.GraphicsPath path = RoundedRectangles.Create(rect1, radius, true, false, true, false);
            g.DrawPath(new Pen(Colors.boletoLines,1.5f), path);
            g.DrawString("Inscrição", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1Padding, format);
            g.DrawString(valor1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect2);
            g.DrawString("N°. Fatura", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2Padding, format);
            g.DrawString(valor2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect3);
            g.DrawString("Mês Referencia", Fonts.main7, new SolidBrush(Colors.boletoLines), rect3Padding, format);
            g.DrawString(valor3, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect3Padding, formatValor);

            g.FillRectangle(new SolidBrush(Colors.bg3), rect4);
            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect4);
            g.DrawString("Vencimento", Fonts.main7, new SolidBrush(Colors.boletoLines), rect4Padding, format);
            g.DrawString(valor4, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect4Padding, formatValor);

            path = RoundedRectangles.Create(rect5, radius, false,true,false,true);
            g.FillPath(new SolidBrush(Colors.bg3), path);
            g.DrawPath(new Pen(Colors.boletoLines, 1.5f), path);
            g.DrawString("Total da Conta", Fonts.main7, new SolidBrush(Colors.boletoLines), rect5Padding, format);
            g.DrawString(valor5, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect5Padding, formatValor);
        }

        private void DetalhesFatura_Load(object sender, EventArgs e)
        {
            
        }
    }
}
