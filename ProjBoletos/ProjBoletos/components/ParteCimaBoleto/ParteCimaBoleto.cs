using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.components.ParteCimaBoleto;
using ProjBoletos.modelos;
using System.Drawing.Drawing2D;

namespace ProjBoletos {
    public partial class ParteCimaBoleto : UserControl {

        private Cedente cedente;

        private int cornersRadius = 10;

        private int spaceBetweenElements = 7;

        private BoletoHeader boletoHeader;
        private DetalhesFatura detalhesFatura;
        private DetalhesEndereco detalhesEndereco;
        private IdentificacaoFaturamento identificacaoFaturamento;
        private GraficoBarrasBoleto barrasBoleto;
        private DetalhesCobrancas detalhesCobrancas;

        public ParteCimaBoleto() {
            InitializeComponent();
        }

        private void ParteCimaBoleto_Resize(object sender, EventArgs e)
        {
            setSizes(ClientRectangle);
        }

        private void ParteCimaBoleto_Load(object sender, EventArgs e) {

        }

        public void MakeBoleto(Cedente cedente)
        {
            this.cedente = cedente;
        }

        public void print(Graphics g, Rectangle rect) {
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            setSizes(rect);
            paint(g);
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            paint(e.Graphics);
        }

        private void setSizes(Rectangle rect)
        {
            Rectangle rectBoletoHeader = new Rectangle(1, 15, rect.Width - 2, (int)(rect.Height * 0.1));
            boletoHeader = new BoletoHeader(rectBoletoHeader, cedente);

            Rectangle rectDetalhesFatura = new Rectangle(1, rectBoletoHeader.Y + rectBoletoHeader.Height + spaceBetweenElements, rect.Width - 2, (int)(rect.Height * 0.07));
            detalhesFatura = new DetalhesFatura(rectDetalhesFatura, cornersRadius);

            Rectangle rectDetalhesEndereco = new Rectangle(1, rectDetalhesFatura.Y + rectDetalhesFatura.Height + spaceBetweenElements, ((rect.Width - 2) / 2) - spaceBetweenElements / 2, (int)(rect.Height * 0.3));
            detalhesEndereco = new DetalhesEndereco(rectDetalhesEndereco, cornersRadius);

            Rectangle rectIdentificacaoFaturamento = new Rectangle(rectDetalhesEndereco.X + rectDetalhesEndereco.Width + spaceBetweenElements, rectDetalhesFatura.Y + rectDetalhesFatura.Height + spaceBetweenElements, ((rect.Width - 2) / 2) - spaceBetweenElements / 2, (int)(rect.Height * 0.19));
            identificacaoFaturamento = new IdentificacaoFaturamento(rectIdentificacaoFaturamento, cornersRadius);

            Rectangle rectGraficoBarrasBoleto = new Rectangle(1, rectDetalhesEndereco.Y + rectDetalhesEndereco.Height + spaceBetweenElements, ((rect.Width - 2) / 2) - spaceBetweenElements / 2, (int)(rect.Height * 0.2));
            barrasBoleto = new GraficoBarrasBoleto(rectGraficoBarrasBoleto, cornersRadius);

            Rectangle rectDetalhesCobrancas = new Rectangle(rectGraficoBarrasBoleto.X + rectGraficoBarrasBoleto.Width + spaceBetweenElements, rectIdentificacaoFaturamento.Y + rectIdentificacaoFaturamento.Height + spaceBetweenElements, ((rect.Width - 2) / 2) - spaceBetweenElements / 2, (int)(rect.Height * 0.31));
            detalhesCobrancas = new DetalhesCobrancas(rectDetalhesCobrancas, cornersRadius);
        }

        private void paint(Graphics g) {
            //e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(1,1,ClientRectangle.Width-2,ClientRectangle.Height-2));

            g.FillRectangle(new SolidBrush(Color.White), new Rectangle(1, 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2));

            boletoHeader.render(g);
            detalhesFatura.render(g);
            detalhesEndereco.render(g);
            identificacaoFaturamento.render(g);
            barrasBoleto.render(g);
            detalhesCobrancas.render(g);
        }
    }
}
