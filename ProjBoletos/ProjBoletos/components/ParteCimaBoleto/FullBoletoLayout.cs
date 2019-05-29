using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.modelos;
using Impactro.Cobranca;

namespace ProjBoletos.components.ParteCimaBoleto
{
    public partial class FullBoletoLayout : UserControl
    {

        public int padding = 50;

        public FullBoletoLayout()
        {
            InitializeComponent();
        }

        public void MakeBoleto(Cedente cedente, Medicao medicao)
        {
            parteCimaBoleto1.MakeBoleto(cedente);

            Conta contaSelecionada = null;
            foreach (Conta conta in cedente.contas)
            {
                if (conta.id == medicao.contaSelecionadaIndex)
                {
                    contaSelecionada = conta;
                    break;
                }
            }

            if (contaSelecionada == null)
            {
                MessageBox.Show("", "Algum erro ocorreu, tente novamente mais tarde", MessageBoxButtons.OK);
            }
            else
            {
                boletoForm1.MakeBoleto(Cedente.makeCedenteInfo(cedente, contaSelecionada, medicao.carteiraSelecionada, ""), Sacado.makeSacadoInfo(medicao.sacado, medicao.casa), geraBoleto());
            }
        }

        public BoletoInfo geraBoleto()
        {
            //criar o boleto aqui
            return new BoletoInfo();
        }

        private void FullBoletoLayout_Load(object sender, EventArgs e)
        {
            FullBoletoLayout_Resize(sender, e);
        }

        private void FullBoletoLayout_Resize(object sender, EventArgs e)
        {

            //Rectangle newSize = new Rectangle(padding, padding, Width - padding * 2, (int)((Width - padding * 2)*Math.Sqrt(2)));

            //flowLayoutPanel1.Location = new Point(0,0);
            //flowLayoutPanel1.Size = new Size(ClientRectangle.Width, ClientRectangle.Width);

            //flowLayoutPanel1.MaximumSize = new Size(ClientRectangle.Width - SystemInformation.VerticalScrollBarWidth, 0);

            parteCimaBoleto1.Location = new Point(0,0);
            parteCimaBoleto1.Size = new Size(Width, (int)(Width * Math.Sqrt(2) *0.57));

            boletoForm1.Boleto.ExibeReciboSacado = false;
            boletoForm1.Location = new Point(0, parteCimaBoleto1.Height + parteCimaBoleto1.Location.Y);
            boletoForm1.Size = new Size(Width, (int)(Width * Math.Sqrt(2) * 0.43));
            boletoForm1.Boleto.Escala = (Width) / 170d;

            Console.WriteLine(parteCimaBoleto1.Location.X + " " + parteCimaBoleto1.Location.Y);

            parteCimaBoleto1.Invalidate();
            boletoForm1.Invalidate();
        }

        private void FullBoletoLayout_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
