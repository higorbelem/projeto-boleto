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
    public partial class GraficoBarrasBoleto : UserControl
    {

        private Rectangle rect;

        private Rectangle rectHeader, rectBody, rectBodyPadding;

        private int radius;

        private List<string[]> valores = new List<string[]>() {
            new string[]{"7","02/19"},
            new string[]{"9","03/19"},
            new string[]{"6","04/19"},
            new string[]{"7","05/19"},
            new string[]{"7","06/19"},
            new string[]{"9","07/19"},
            new string[]{"9","08/19"},
            new string[]{"7","09/19"},
            new string[]{"10","10/19"},
            new string[]{"7","11/19"},
            new string[]{"7","12/19"},
            new string[]{"6","01/20"}
        };

        public GraficoBarrasBoleto(Rectangle rect, int radius)
        {
            InitializeComponent();

            this.rect = rect;
            this.radius = radius;
            
            rectHeader = new Rectangle(rect.X, rect.Y, rect.Width, 20);
            rectBody = new Rectangle(rect.X,rectHeader.Y + rectHeader.Height,rect.Width,rect.Height-rectHeader.Height);

            rectBodyPadding = new Rectangle(rect.X + 5, rectHeader.Y + rectHeader.Height + 5, rect.Width - 10, rect.Height - rectHeader.Height - 10);
        }

        private void GraficoBarrasBoleto_Load(object sender, EventArgs e)
        {

        }

        public void render(Graphics g){
            StringFormat formatHeader = new StringFormat();
            formatHeader.LineAlignment = StringAlignment.Center;
            formatHeader.Alignment = StringAlignment.Center;

            System.Drawing.Drawing2D.GraphicsPath path = RoundedRectangles.Create(rectHeader, radius, true, true, false, false);
            g.FillPath(new SolidBrush(Colors.boletoLines), path);
            g.DrawPath(new Pen(Colors.boletoLines, 1), path);
            g.DrawString("Consumo dos últimos 12 meses", Fonts.mainBold8, new SolidBrush(Colors.bg), rectHeader, formatHeader);

            path = RoundedRectangles.Create(rectBody, radius, false, false, true, true);
            g.DrawPath(new Pen(Colors.boletoLines, 1), path);

            int xAtual = rectBodyPadding.X;
            int maiorValor = 0;

            foreach (string[] valor in valores){
                int x = int.Parse(valor[0]);
                if (x > maiorValor){
                    maiorValor = x;
                }
            }

            foreach (string[] valor in valores){
                rect = new Rectangle(xAtual, rectBodyPadding.Y, rectBodyPadding.Width / 12, rectBodyPadding.Height);

                int tamanhoAtual = (int.Parse(valor[0]) * rect.Height) / maiorValor;

                renderBarra(g, rect,valor[0], valor[1],tamanhoAtual);

                xAtual = rect.X + rect.Width;
            }
        }

        private void renderBarra(Graphics g, Rectangle rect, string valor, string data, int tamanho)
        {
            g.DrawString(valor, Fonts.main7, new SolidBrush(Colors.boletoLines), new Rectangle(rect.X, rect.Y, rect.Width, 10), new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
            g.DrawString(data, Fonts.main7, new SolidBrush(Colors.boletoLines), new Rectangle(rect.X, rect.Y + rect.Height - 10, rect.Width, 10), new StringFormat()
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Center
            });
            g.FillRectangle(new SolidBrush(Colors.boletoLines), new Rectangle(rect.X + 10, rect.Y + (rect.Height - tamanho) + 10, rect.Width - 20, rect.Height - (rect.Height - tamanho) - 20));
        }
    }
}
