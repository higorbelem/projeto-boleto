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
    public partial class DetalhesEndereco : UserControl
    {

        private Rectangle rectHeader, rect1, rect2, rect3_1, rect3_2, rect4, rect5;
        private Rectangle rect1Padding, rect2Padding, rect3_1Padding, rect3_2Padding, rect4Padding, rect5Padding;

        private int radius;

        private int paddingLeftRight = 8;
        private int paddingTopBottom = 2;

        private string valor1 = "Fulano da Silva Pereira Santos";
        private string valor2 = "Rua paranaue, 255";
        private string valor3_1 = "São Roque";
        private string valor3_2 = "Itabuna/BA";
        private string valor4 = "456608-035";
        private string valor5 = "Proximo á nada";

        public DetalhesEndereco(Rectangle rect, int radius)
        {
            InitializeComponent();

            this.radius = radius;

            rectHeader = new Rectangle(rect.X,rect.Y,rect.Width, 20);
            rect1 = new Rectangle(rect.X,rectHeader.Y + rectHeader.Height, rect.Width, (rect.Height-rectHeader.Height)/5);
            rect2 = new Rectangle(rect.X, rect1.Y + rect1.Height, rect.Width, (rect.Height - rectHeader.Height) / 5);
            rect3_1 = new Rectangle(rect.X, rect2.Y + rect2.Height, rect.Width/2, (rect.Height - rectHeader.Height) / 5);
            rect3_2 = new Rectangle(rect3_1.X + rect3_1.Width, rect2.Y + rect2.Height, rect.Width - rect3_1.Width, (rect.Height - rectHeader.Height) / 5);
            rect4 = new Rectangle(rect.X, rect3_2.Y + rect3_2.Height, rect.Width, (rect.Height - rectHeader.Height) / 5);
            rect5 = new Rectangle(rect.X, rect4.Y + rect4.Height, rect.Width, (rect.Height - rectHeader.Height) / 5);

            rect1Padding = new Rectangle(rect.X + paddingLeftRight, rectHeader.Y + rectHeader.Height + paddingTopBottom, rect.Width - paddingLeftRight*2, ((rect.Height - rectHeader.Height) / 5) - paddingTopBottom*2);
            rect2Padding = new Rectangle(rect.X + paddingLeftRight, rect1.Y + rect1.Height + paddingTopBottom, rect.Width - paddingLeftRight * 2, ((rect.Height - rectHeader.Height) / 5) - paddingTopBottom * 2);
            rect3_1Padding = new Rectangle(rect.X + paddingLeftRight, rect2.Y + rect2.Height + paddingTopBottom, rect.Width / 2 - paddingLeftRight * 2, ((rect.Height - rectHeader.Height) / 5) - paddingTopBottom * 2);
            rect3_2Padding = new Rectangle(rect3_1.X + rect3_1.Width + paddingLeftRight, rect2.Y + rect2.Height + paddingTopBottom, rect.Width - rect3_1.Width - paddingLeftRight * 2, ((rect.Height - rectHeader.Height) / 5) - paddingTopBottom * 2);
            rect4Padding = new Rectangle(rect.X + paddingLeftRight, rect3_2.Y + rect3_2.Height + paddingTopBottom, rect.Width - paddingLeftRight * 2, ((rect.Height - rectHeader.Height) / 5) - paddingTopBottom * 2);
            rect5Padding = new Rectangle(rect.X + paddingLeftRight, rect4.Y + rect4.Height + paddingTopBottom, rect.Width - paddingLeftRight * 2, ((rect.Height - rectHeader.Height) / 5) - paddingTopBottom * 2);
        }

        private void DetalhesEndereco_Load(object sender, EventArgs e)
        {

        }

        public void render(Graphics g)
        {
            StringFormat formatHeader = new StringFormat();
            formatHeader.LineAlignment = StringAlignment.Center;
            formatHeader.Alignment = StringAlignment.Center;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Near;
            format.Alignment = StringAlignment.Near;

            StringFormat formatValor = new StringFormat();
            formatValor.LineAlignment = StringAlignment.Center;
            formatValor.Alignment = StringAlignment.Near;

            System.Drawing.Drawing2D.GraphicsPath path = RoundedRectangles.Create(rectHeader, radius,true,true,false,false);
            g.FillPath(new SolidBrush(Colors.boletoLines),path);
            g.DrawPath(new Pen(Colors.boletoLines, 1.5f), path);
            g.DrawString("Detalhes de Endereçamento", Fonts.mainBold8, new SolidBrush(Colors.bg), rectHeader, formatHeader);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f),rect1);
            g.DrawString("Nome", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1Padding, format);
            g.DrawString(valor1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect2);
            g.DrawString("Endereço", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2Padding, format);
            g.DrawString(valor2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect3_1);
            g.DrawString("Bairro", Fonts.main7, new SolidBrush(Colors.boletoLines), rect3_1Padding, format);
            g.DrawString(valor3_1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect3_1Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect3_2);
            g.DrawString("Cidade/UF", Fonts.main7, new SolidBrush(Colors.boletoLines), rect3_2Padding, format);
            g.DrawString(valor3_2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect3_2Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines, 1.5f), rect4);
            g.DrawString("CEP", Fonts.main7, new SolidBrush(Colors.boletoLines), rect4Padding, format);
            g.DrawString(valor4, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect4Padding, formatValor);

            path = RoundedRectangles.Create(rect5, radius, false, false, true, true);
            g.DrawPath(new Pen(Colors.boletoLines), path);
            g.DrawString("Referência", Fonts.main7, new SolidBrush(Colors.boletoLines), rect5Padding, format);
            g.DrawString(valor5, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect5Padding, formatValor);
        }
    }
}
