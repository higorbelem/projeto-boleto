using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BoletoForm2;
using Impactro;
using ProjBoletos.testes;
using System.Net.Http;
using Impactro.Cobranca;
using System.IO;
using Newtonsoft.Json;
using Impactro.Layout;
using Impactro.WindowsControls;
using RestSharp;
using System.Drawing.Printing;
using ProjBoletos.modelos;
using ProjBoletos.components.ParteCimaBoleto;

namespace ProjBoletos {
    public partial class Form1 : Form {

        List<Sacado> sacados = new List<Sacado>();
        CedenteInfo cedente = new CedenteInfo();

        int nRegI = 0;
        int nRegJ = 0;

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

            /*var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
            cedente = JsonConvert.DeserializeObject<CedenteInfo>(cedenteJson);

            var sacadoJson = getAllSacadoAsync(cedente.Id);
            List<SacadoInfo> sacadoInfos = JsonConvert.DeserializeObject<List<SacadoInfo>>(sacadoJson);

            int qBol = 1;
            foreach(SacadoInfo sacadoInfo in sacadoInfos) {
                sacados.Add(new Sacado(sacadoInfo, new List<BoletoInfo> {
                    criarBoleto(qBol+"", "1543", 200+(qBol*20), new DateTime(2019, 06, 20)),
                    criarBoleto((qBol+1)+"", "1543", 200+((qBol+1)*20), new DateTime(2019, 06, 20))
                }));
                qBol += 2;
            }*/

            //so para mostrar na tela 
            //boletoForm1.MakeBoleto(cedente,sacados[0].sacado,sacados[0].boletos[0]);

            //Form frm = new frmBasico();
            //frm.ShowDialog();
            /*Form form = new drawTeste();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Show(); };
            form.Show();
            this.Hide();*/
        }

        private string getAllSacadoAsync(string id) {
            var client = new RestClient("http://localhost/projeto-boletos-server/getAllSacado.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("text/plain");
            request.AddParameter("id", id);

            var response = client.Post(request);
            var content = response.Content; // raw content as string

            return content;
        }

        private BoletoInfo criarBoleto(string id, string nossoNumero, double valor, DateTime vencimento) {
            BoletoInfo objBoleto = new BoletoInfo();

            objBoleto.NossoNumero = nossoNumero;
            objBoleto.NumeroDocumento = nossoNumero + id;
            objBoleto.ParcelaNumero = 1;
            objBoleto.ParcelaTotal = 1;
            objBoleto.Quantidade = 1;
            objBoleto.ValorUnitario = valor;
            objBoleto.ValorDocumento = objBoleto.Quantidade * objBoleto.ValorUnitario;
            objBoleto.DataDocumento = DateTime.Now;
            objBoleto.DataVencimento = vencimento;
            objBoleto.Especie = Especies.RC;
            objBoleto.DataDocumento = DateTime.Now.AddDays(-2);     // Por padrão é  a data atual, geralmente é a data em que foi feita a compra/pedido, antes de ser gerado o boleto para pagamento
            objBoleto.DataProcessamento = DateTime.Now.AddDays(-1); // Por padrão é a data atual, pode ser usado como a data em que foi impresso o boleto
            objBoleto.PercentualMulta = 0.02; // 2.0% no mês
            objBoleto.PercentualMora = 0.001; // 0.1% valor percentual ao dia...
            objBoleto.DataPagamento = objBoleto.DataVencimento.AddDays(60);
            objBoleto.CalculaMultaMora = true;
            objBoleto.Instrucoes = "Todas as informações deste bloqueto são de exclusiva responsabilidade do cedente";
            objBoleto.Especie = Especies.DS;
            objBoleto.LocalPagamento = "Pague Preferencialmente no BANCO NOSSA CAIXA S.A. ou na rede bancária até o vencimento";

            return objBoleto;
            /*boletoForm1.MakeBoleto(cedenteInfo, sacadoInfo, objBoleto);

            Console.WriteLine("Codigo de barras: " + boletoForm1.Boleto.CodigoBarras);
            Console.WriteLine("Linha digitável: " + boletoForm1.Boleto.LinhaDigitavel);*/
        }

        private void boletoForm1_Load(object sender, EventArgs e) {
            
        }

        private async void button1_Click(object sender, EventArgs e) {
            PrintDocument pDoc = new PrintDocument();
            pDoc.PrintPage += new PrintPageEventHandler(pDoc_PrintPageUnico);

            //pDoc.DefaultPageSettings.Landscape = true;

            PrintDialog dlgPrinter = new PrintDialog();
            PrintPreviewDialog ppw = new PrintPreviewDialog();
            ppw.Document = pDoc;
            ppw.MdiParent = this.MdiParent;
            ppw.WindowState = FormWindowState.Maximized;
            ppw.Show();

            //pDoc.Print(); //imprimir diretamente
        }

        void pDoc_PrintPageUnico(object sender, PrintPageEventArgs e) {
            try {

                //FullBoletoLayout fullBoletoLayout = new FullBoletoLayout();
                //fullBoletoLayout.MakeBoleto()
                //fullBoletoLayout.print(e.Graphics);

               /* ParteCimaBoleto parteCimaBoleto = new ParteCimaBoleto();
                parteCimaBoleto.Size = new System.Drawing.Size(300, 160);
                parteCimaBoleto.print(e.Graphics);

                BoletoForm bol = new BoletoForm();
                //bol.Location = new System.Drawing.Point(5, parteCimaBoleto.Location.Y + parteCimaBoleto.Size.Height);
                bol.Boleto.ExibeReciboSacado = false;
                bol.MakeBoleto(cedente, sacados[nRegI].sacado, sacados[nRegI].boletos[nRegJ]);
                bol.PrintType = PrintTypes.Documet;
                bol.Print(e.Graphics, parteCimaBoleto.Size.Height);

                if (nRegJ + 1 < sacados[nRegI].boletos.Count) {
                    nRegJ++;
                    e.HasMorePages = true;
                } else {
                    if (nRegI + 1 < sacados.Count) {
                        nRegI++;
                        nRegJ = 0;
                        e.HasMorePages = true;
                    } else {
                        e.HasMorePages = false;
                    }
                }
                
                if (!e.HasMorePages) nRegI = 0;*/

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
