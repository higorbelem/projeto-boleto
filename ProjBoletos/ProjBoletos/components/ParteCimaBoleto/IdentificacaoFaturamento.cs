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
    public partial class IdentificacaoFaturamento : UserControl
    {

        private Rectangle rectHeader, rect1_1, rect1_2, rect1_3, rect1_4, rect2_1, rect2_2, rect2_3, rect2_4, rect3_1, rect3_2;
        private Rectangle rect1_1Padding, rect1_2Padding, rect1_3Padding, rect1_4Padding, rect2_1Padding, rect2_2Padding, rect2_3Padding, rect2_4Padding, rect3_1Padding, rect3_2Padding;

        private int radius;

        private int paddingLeftRight = 8;
        private int paddingTopBottom = 2;

        private string valor1_1 = "asdasd";
        private string valor1_2 = "asdasd";
        private string valor1_3 = "asdasd";
        private string valor1_4 = "asdasd";
        private string valor2_1 = "asdasd";
        private string valor2_2 = "asdasd";
        private string valor2_3 = "asdasd";
        private string valor2_4 = "asdasd";
        private string valor3_1 = "asdasd";
        private string valor3_2 = "asdasd";

        public IdentificacaoFaturamento(Rectangle rect, int radius)
        {
            InitializeComponent();

            this.radius = radius;

            rectHeader = new Rectangle(rect.X, rect.Y, rect.Width, 20);
            rect1_1 = new Rectangle(rect.X,rectHeader.Y + rectHeader.Height, rect.Width/4, (rect.Height - rectHeader.Height) / 3);
            rect1_2 = new Rectangle(rect1_1.X + rect1_1.Width, rectHeader.Y + rectHeader.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect1_3 = new Rectangle(rect1_2.X + rect1_2.Width, rectHeader.Y + rectHeader.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect1_4 = new Rectangle(rect1_3.X + rect1_3.Width, rectHeader.Y + rectHeader.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect2_1 = new Rectangle(rect.X, rect1_1.Y + rect1_1.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect2_2 = new Rectangle(rect2_1.X + rect2_1.Width, rect1_1.Y + rect1_1.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect2_3 = new Rectangle(rect2_2.X + rect2_2.Width, rect1_1.Y + rect1_1.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect2_4 = new Rectangle(rect2_3.X + rect2_3.Width, rect1_1.Y + rect1_1.Height, rect.Width / 4, (rect.Height - rectHeader.Height) / 3);
            rect3_1 = new Rectangle(rect.X, rect2_1.Y + rect2_1.Height, rect.Width / 2, (rect.Height - rectHeader.Height) / 3);
            rect3_2 = new Rectangle(rect3_1.X + rect3_1.Width, rect2_1.Y + rect2_1.Height, rect.Width / 2, (rect.Height - rectHeader.Height) / 3);

            rect1_1Padding = new Rectangle(rect.X + paddingLeftRight, rectHeader.Y + rectHeader.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight*2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect1_2Padding = new Rectangle(rect1_1.X + rect1_1.Width + paddingLeftRight, rectHeader.Y + rectHeader.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect1_3Padding = new Rectangle(rect1_2.X + rect1_2.Width + paddingLeftRight, rectHeader.Y + rectHeader.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect1_4Padding = new Rectangle(rect1_3.X + rect1_3.Width + paddingLeftRight, rectHeader.Y + rectHeader.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect2_1Padding = new Rectangle(rect.X + paddingLeftRight, rect1_1.Y + rect1_1.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect2_2Padding = new Rectangle(rect2_1.X + rect2_1.Width + paddingLeftRight, rect1_1.Y + rect1_1.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect2_3Padding = new Rectangle(rect2_2.X + rect2_2.Width + paddingLeftRight, rect1_1.Y + rect1_1.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect2_4Padding = new Rectangle(rect2_3.X + rect2_3.Width + paddingLeftRight, rect1_1.Y + rect1_1.Height + paddingTopBottom, rect.Width / 4 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect3_1Padding = new Rectangle(rect.X + paddingLeftRight, rect2_1.Y + rect2_1.Height + paddingTopBottom, rect.Width / 2 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
            rect3_2Padding = new Rectangle(rect3_1.X + rect3_1.Width + paddingLeftRight, rect2_1.Y + rect2_1.Height + paddingTopBottom, rect.Width / 2 - paddingLeftRight * 2, (rect.Height - rectHeader.Height) / 3 - paddingTopBottom * 2);
        }

        private void IdentificacaoFaturamento_Load(object sender, EventArgs e)
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

            System.Drawing.Drawing2D.GraphicsPath path = RoundedRectangles.Create(rectHeader, radius, true, true, false, false);
            g.FillPath(new SolidBrush(Colors.boletoLines), path);
            g.DrawPath(new Pen(Colors.boletoLines, 1.5f), path);
            g.DrawString("Identificação do Faturamento", Fonts.mainBold8, new SolidBrush(Colors.bg), rectHeader, formatHeader);

            g.DrawRectangle(new Pen(Colors.boletoLines),rect1_1);
            g.DrawString("Leitura Atual", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1_1Padding, format);
            g.DrawString(valor1_1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1_1Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect1_2);
            g.DrawString("Leitura Anterior", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1_2Padding, format);
            g.DrawString(valor1_2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1_2Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect1_3);
            g.DrawString("Consumo", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1_3Padding, format);
            g.DrawString(valor1_3, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1_3Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect1_4);
            g.DrawString("Esgoto (%)", Fonts.main7, new SolidBrush(Colors.boletoLines), rect1_4Padding, format);
            g.DrawString(valor1_4, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect1_4Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect2_1);
            g.DrawString("Data da Leitura", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2_1Padding, format);
            g.DrawString(valor2_1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2_1Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect2_2);
            g.DrawString("Ocorrência", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2_2Padding, format);
            g.DrawString(valor2_2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2_2Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect2_3);
            g.DrawString("Média", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2_3Padding, format);
            g.DrawString(valor2_3, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2_3Padding, formatValor);

            g.DrawRectangle(new Pen(Colors.boletoLines), rect2_4);
            g.DrawString("Cód. Deb. Auto.", Fonts.main7, new SolidBrush(Colors.boletoLines), rect2_4Padding, format);
            g.DrawString(valor2_4, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect2_4Padding, formatValor);

            path = RoundedRectangles.Create(rect3_1, radius, false, false, true, false);
            g.DrawPath(new Pen(Colors.boletoLines), path);
            g.DrawString("N°.Hidrômetro", Fonts.main7, new SolidBrush(Colors.boletoLines), rect3_1Padding, format);
            g.DrawString(valor3_1, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect3_1Padding, formatValor);

            path = RoundedRectangles.Create(rect3_2, radius, false, false, false, true);
            g.DrawPath(new Pen(Colors.boletoLines), path);
            g.DrawString("Categoria de Consumo", Fonts.main7, new SolidBrush(Colors.boletoLines), rect3_2Padding, format);
            g.DrawString(valor3_2, Fonts.mainBold10, new SolidBrush(Colors.boletoTextValor), rect3_2Padding, formatValor);
        }
    }
}
