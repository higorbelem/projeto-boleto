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
using RestSharp;
using ProjBoletos.modelos;
using Newtonsoft.Json;
using ProjBoletos.testes;
using System.Drawing.Printing;
using ProjBoletos.components.ParteCimaBoleto;
using ProjBoletos.telas.dialogs;
using System.Net.Mail;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace ProjBoletos.telas.mainPageControls.HomeTabs {
   public partial class TabRemessas : UserControl {

      private List<Remessa> remessas;

      Padding padding = new Padding(40, 20, 40, 40);
      int quantCards = 2;
      int spaceBetweenCards = 20;
      int cardHeight = 220;

      private Cedente cedente;
      public Panel panel;

      bool buscaCompleta = false;
      bool atualizacaoFlowCompleta = true;

      int indexMedicao = 0;
      int indexInicial = 0;
      int indexMax = Int32.MaxValue;
      int copias = 1;
      int copiasVar = 1;
      bool agrupado = false;

      public TabRemessas() {
         InitializeComponent();

         panel = panel1;
      }

      private void TabRemessas_Load(object sender, EventArgs e) {

         panel1.BackColor = Colors.bg;
         flowRemessas.BackColor = Colors.bg;
         BackColor = Colors.bg;

         var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
         cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);
         if (cedente == null) {
            Application.Exit();
         }

         updatePage();
      }

      private void atualizarCards(List<Remessa> remessas) {
         int remessasNaoEnviada = 0;
         int remessasNaoEnviadaHoje = 0;
         int remessasEnviada = 0;
         int remessasEnviadaHoje = 0;

         for (int i = 0; i < remessas.Count; i++) {
            if (remessas[i].enviado.Equals("1")) {
               remessasEnviada++;
               if (DateTime.Today.Year == remessas[i].data.Year && DateTime.Today.Month == remessas[i].data.Month && DateTime.Today.Day == remessas[i].data.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                  remessasEnviadaHoje++;     
               }
            } else {
               remessasNaoEnviada++;
               if (DateTime.Today.Year == remessas[i].data.Year && DateTime.Today.Month == remessas[i].data.Month && DateTime.Today.Day == remessas[i].data.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                  remessasNaoEnviadaHoje++;
               }
            }
         }

         mainCard1.title = "REMESSAS AGUARDANDO RETORNO";
         mainCard1.numString = remessasEnviada + "";
         mainCard1.notifString = remessasEnviadaHoje + "";
         mainCard1.ascentColor = Colors.noPrazo;

         mainCard2.title = "REMESSAS NÂO ENVIADAS";
         mainCard2.numString = remessasNaoEnviada + "";
         mainCard2.notifString = remessasNaoEnviadaHoje + "";
         mainCard2.ascentColor = Colors.pertoDeVencer;
      }

      public void updatePage() {
         buscaCompleta = false;
         var res = buscarRemessas(cedente.id);

         if (res == System.Net.HttpStatusCode.OK) {
            buscaCompleta = true;
            atualizarCards(remessas);
            atualizarFlow(remessas);
            //customListView.UpdateList(medicoes);
         }
      }

      public void atualizarFlow(List<Remessa> remessas) {

         if (buscaCompleta && atualizacaoFlowCompleta) {
            
            atualizacaoFlowCompleta = false;

            flowRemessas.Controls.Clear();

            if (remessas.Count > 0) {
               for (int i = 0; i < remessas.Count; i += 2) {

                  Panel panel = new Panel() {
                     Size = new Size(flowRemessas.Width, 360), //-15
                     Margin = new Padding(0)
                  };

                  System.Drawing.Rectangle rectPanel = new System.Drawing.Rectangle(0, 0, panel.Width / 2 - spaceBetweenCards / 2, panel.Height);
                  panel.Controls.Add(criaPanelRemessa(new Point(rectPanel.X, rectPanel.Y), new Size(rectPanel.Width, rectPanel.Height), remessas[i], 10));
                  if (i + 1 < remessas.Count) {
                     panel.Controls.Add(criaPanelRemessa(new Point(rectPanel.X + rectPanel.Width + spaceBetweenCards, rectPanel.Y), new Size(panel.Width / 2 - spaceBetweenCards / 2, panel.Height), remessas[i + 1], 10));
                  }

                  flowRemessas.Controls.Add(panel);
               }
            } else {
               flowRemessas.Controls.Add(new Label() {
                  Text = "Não há Remessas",
                  BackColor = Colors.bg,
                  ForeColor = Colors.primaryText,
                  Font = Fonts.mainBold10,
                  Location = new Point(0,0),
                  Size = new Size(flowRemessas.Width, 50),
                  TextAlign = ContentAlignment.MiddleCenter,
                  AutoSize = false,
                  Margin = new Padding(0)
               });
            }

            atualizacaoFlowCompleta = true;
         }
      }

      public Panel criaPanelRemessa(Point loc, Size size, Remessa remessa, int padding) {
         Panel panel = new Panel() {
            Location = loc,
            Size = size,
            BackColor = Colors.bg2,
            Margin = new Padding(0)
         };

         System.Drawing.Rectangle rectLabelTop = new System.Drawing.Rectangle(0,0,size.Width,20);
         string labelText = "";
         Color labelBackColor;
         if (remessa.enviado.Equals("1")) {
            labelText = "REMESSA AGUARDANDO RETORNO";
            labelBackColor = Colors.noPrazo;
         } else {
            labelText = "REMESSA NÂO ENVIADA";
            labelBackColor = Colors.pertoDeVencer;
         }
         panel.Controls.Add(new Label() {
            Text = labelText,
            BackColor = labelBackColor,
            ForeColor = Colors.bg,
            Font = Fonts.mainBold8,
            Location = new Point(rectLabelTop.X, rectLabelTop.Y),
            Size = new Size(rectLabelTop.Width, rectLabelTop.Height),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false,
            Margin = new Padding(0)
         });

         System.Drawing.Rectangle outsidePadding = new System.Drawing.Rectangle(padding,rectLabelTop.Y + rectLabelTop.Height, size.Width - padding*2, 0);

         System.Drawing.Rectangle rectLabelId = new System.Drawing.Rectangle(outsidePadding.X, outsidePadding.Y, 80, 60);
         panel.Controls.Add(new Label() {
            Text = "#" + remessa.id,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold12,
            Location = new Point(rectLabelId.X, rectLabelId.Y),
            Size = new Size(rectLabelId.Width, rectLabelId.Height),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false,
            Margin = new Padding(0)
         });

         System.Drawing.Rectangle rectLabelBanco = new System.Drawing.Rectangle(outsidePadding.X, outsidePadding.Y, outsidePadding.Width, 60);
         string labelBancoText = "";
         if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("001")) {
            labelBancoText = "BANCO DO BRASIL";
         } else if(cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("341")){
            labelBancoText = "ITAÚ";
         } else if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("237")){
            labelBancoText = "BRADESCO";
         }
         panel.Controls.Add(new Label() {
            Text = labelBancoText,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold14,
            Location = new Point(rectLabelBanco.X, rectLabelBanco.Y),
            Size = new Size(rectLabelBanco.Width, rectLabelBanco.Height),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false,
            Margin = new Padding(0)
         });

         Panel panelInfoData = new Panel() {
            Location = new Point(outsidePadding.X, rectLabelBanco.Y + rectLabelBanco.Height),
            Size = new Size(outsidePadding.Width, 30),
            Margin = new Padding(0)
         };
         panelInfoData.Controls.Add(new Label() {
            Text = "DARA DA REMESSAS",
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold10,
            Location = new Point(0, 0),
            Size = new Size(panelInfoData.Width/2, panelInfoData.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panelInfoData.Controls.Add(new Label() {
            Text = remessa.data.ToString("dd/MM/yyyy"),
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.main10,
            Location = new Point(panelInfoData.Width / 2, 0),
            Size = new Size(panelInfoData.Width / 2, panelInfoData.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panel.Controls.Add(panelInfoData);

         Panel panelInfoQuatBoletos = new Panel() {
            Location = new Point(outsidePadding.X, panelInfoData.Location.Y + panelInfoData.Height),
            Size = new Size(outsidePadding.Width, 30),
            Margin = new Padding(0)
         };
         panelInfoQuatBoletos.Controls.Add(new Label() {
            Text = "QUANTIDADE DE BOLETOS",
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold10,
            Location = new Point(0, 0),
            Size = new Size(panelInfoQuatBoletos.Width / 2, panelInfoQuatBoletos.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panelInfoQuatBoletos.Controls.Add(new Label() {
            Text = remessa.medicoes.Count + "",
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.main10,
            Location = new Point(panelInfoQuatBoletos.Width / 2, 0),
            Size = new Size(panelInfoQuatBoletos.Width / 2, panelInfoQuatBoletos.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panel.Controls.Add(panelInfoQuatBoletos);

         Panel panelInfoAgencia = new Panel() {
            Location = new Point(outsidePadding.X, panelInfoQuatBoletos.Location.Y + panelInfoQuatBoletos.Height),
            Size = new Size(outsidePadding.Width, 30),
            Margin = new Padding(0)
         };
         panelInfoAgencia.Controls.Add(new Label() {
            Text = "AGÊNCIA",
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold10,
            Location = new Point(0, 0),
            Size = new Size(panelInfoAgencia.Width / 2, panelInfoAgencia.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panelInfoAgencia.Controls.Add(new Label() {
            Text = cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).agencia,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.main10,
            Location = new Point(panelInfoAgencia.Width / 2, 0),
            Size = new Size(panelInfoAgencia.Width / 2, panelInfoAgencia.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panel.Controls.Add(panelInfoAgencia);

         Panel panelInfoConta = new Panel() {
            Location = new Point(outsidePadding.X, panelInfoAgencia.Location.Y + panelInfoAgencia.Height),
            Size = new Size(outsidePadding.Width, 30),
            Margin = new Padding(0)
         };
         panelInfoConta.Controls.Add(new Label() {
            Text = "CONTA",
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold10,
            Location = new Point(0, 0),
            Size = new Size(panelInfoConta.Width / 2, panelInfoConta.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panelInfoConta.Controls.Add(new Label() {
            Text = cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).conta,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.main10,
            Location = new Point(panelInfoConta.Width / 2, 0),
            Size = new Size(panelInfoConta.Width / 2, panelInfoConta.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panel.Controls.Add(panelInfoConta);

         Panel panelInfoCarteira = new Panel() {
            Location = new Point(outsidePadding.X, panelInfoConta.Location.Y + panelInfoConta.Height),
            Size = new Size(outsidePadding.Width, 30),
            Margin = new Padding(0)
         };
         panelInfoCarteira.Controls.Add(new Label() {
            Text = "CARTEIRA",
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold10,
            Location = new Point(0, 0),
            Size = new Size(panelInfoCarteira.Width / 2, panelInfoCarteira.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panelInfoCarteira.Controls.Add(new Label() {
            Text = remessa.medicoes[0].carteiraSelecionada,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.main10,
            Location = new Point(panelInfoCarteira.Width / 2, 0),
            Size = new Size(panelInfoCarteira.Width / 2, panelInfoCarteira.Height),
            TextAlign = ContentAlignment.MiddleLeft,
            AutoSize = false,
            Margin = new Padding(0)
         });
         panel.Controls.Add(panelInfoCarteira);

         Panel panelButtons = new Panel() {
            Location = new Point(outsidePadding.X, panelInfoCarteira.Location.Y + panelInfoCarteira.Height + 20),
            Size = new Size(outsidePadding.Width, 100),
            Margin = new Padding(0)
         };
         string btnTxt1 = "";
         string btnTxt2 = "";
         string btnTxt3 = "";
         string btnTxt4 = "";
         if (remessa.enviado.Equals("1")) {
            btnTxt1 = "ENVIAR POR EMAIL";
            btnTxt2 = "IMPRIMIR";
            btnTxt3 = "REMESSA NÂO FOI ENVIADA";
            btnTxt4 = "LER RETORNO";
         } else {
            btnTxt1 = "ENVIAR POR EMAIL";
            btnTxt2 = "IMPRIMIR";
            btnTxt3 = "REMESSA FOI ENVIADA";
            btnTxt4 = "ENVIAR ARQUIVO";
         }
         MeuButton mb1 = new MeuButton() {
            title = btnTxt1,
            Location = new Point(0, 0),
            Size = new Size(panelButtons.Width / 3, panelButtons.Height/2),
            Margin = new Padding(0)
         };
         mb1.Click += new EventHandler((object s1, EventArgs e1) => {

            EnviarEmailDialog enviarEmailDialog = new EnviarEmailDialog(cedente, remessa);
            enviarEmailDialog.ShowDialog();

         });
         panelButtons.Controls.Add(mb1);
         MeuButton mb2 = new MeuButton() {
            title = btnTxt2,
            Location = new Point(panelButtons.Width / 3, 0),
            Size = new Size(panelButtons.Width / 3, panelButtons.Height/2)
         };
         mb2.Click += new EventHandler((object s1, EventArgs e1) => {
            PrintDocument pDoc = new PrintDocument();
            //pDoc.DefaultPageSettings.PaperSize = new PaperSize("A4",850, (int)(850 * Math.Sqrt(2)));

            pDoc.PrintPage += new PrintPageEventHandler((object s2, PrintPageEventArgs e2) => {
               try {
                  new FullBoletoLayout(cedente, remessa.medicoes[indexMedicao]).print(e2.Graphics, e2.PageBounds);

                  bool hasMorePages = false;

                  if (agrupado) {

                     indexMedicao++;
                     if (indexMedicao < remessa.medicoes.Count && indexMedicao <= indexMax) {
                        hasMorePages = true;
                     }

                     e2.HasMorePages = hasMorePages;
                     if (!e2.HasMorePages) {
                        if (copiasVar > 1) {
                           copiasVar--;
                           e2.HasMorePages = true;
                        }
                        indexMedicao = indexInicial;
                     }

                  } else {

                     if (copiasVar > 1) {
                        copiasVar--;
                     } else {
                        indexMedicao++;
                        copiasVar = copias;
                     }

                     if (indexMedicao < remessa.medicoes.Count && indexMedicao <= indexMax) {
                        hasMorePages = true;
                     }

                     e2.HasMorePages = hasMorePages;
                     if (!e2.HasMorePages) {
                        indexMedicao = indexInicial;
                     }

                  }  
               } catch (Exception ex) {
                  MessageBox.Show(ex.Message);
               }
            });

            IEnumerable<PaperSize> paperSizes = pDoc.PrinterSettings.PaperSizes.Cast<PaperSize>();
            PaperSize sizeA4 = paperSizes.First<PaperSize>(size1 => size1.Kind == PaperKind.A4); // setting paper size to A4 size
            pDoc.DefaultPageSettings.PaperSize = sizeA4;
            pDoc.OriginAtMargins = false; //true = soft margins, false = hard margins

            //pDoc.DefaultPageSettings.Landscape = true;

            PrintDialog dlgPrinter = new PrintDialog();
            dlgPrinter.AllowSomePages = true;
            //dlgPrinter.UseEXDialog = true;
            //dlgPrinter.AllowCurrentPage = true;
            //dlgPrinter.AllowSelection = true;
            //dlgPrinter.ShowHelp = true;
            dlgPrinter.Document = pDoc;
            //dlgPrinter.PrinterSettings.DefaultPageSettings.Margins = new Margins(20, 20, 20, 20);
            //dlgPrinter.AllowPrintToFile = true;

            PrintPreviewDialog ppw = new PrintPreviewDialog();
            ppw.Document = pDoc;
            //ppw.MdiParent = this.MdiParent;
            ppw.WindowState = FormWindowState.Maximized;

            ToolStripButton b = new ToolStripButton();
            //b.Image = Properties.Resources.PrintIcon;
            //b.DisplayStyle = ToolStripItemDisplayStyle.Image;
            b.Click += (object s2, EventArgs e2) => {
               if (dlgPrinter.ShowDialog() == DialogResult.OK) {
                  copias = dlgPrinter.PrinterSettings.Copies;
                  copiasVar = copias;

                  agrupado = dlgPrinter.PrinterSettings.Collate;

                  if (dlgPrinter.PrinterSettings.PrintRange == PrintRange.AllPages) {
                     indexInicial = 0;
                     indexMax = remessa.medicoes.Count;
                  } else if (dlgPrinter.PrinterSettings.PrintRange == PrintRange.SomePages) {
                     indexInicial = dlgPrinter.PrinterSettings.FromPage;
                     indexMax = dlgPrinter.PrinterSettings.ToPage;
                  }

                  indexMedicao = indexInicial;

                  pDoc.Print();
               }
            };
            ((ToolStrip)(ppw.Controls[1])).Items.RemoveAt(0);
            ((ToolStrip)(ppw.Controls[1])).Items.Insert(0, b);

            ppw.ShowDialog();
         });
         panelButtons.Controls.Add(mb2);
         MeuButton mb3 = new MeuButton() {
            title = btnTxt3,
            Location = new Point((panelButtons.Width / 3) * 2, 0),
            Size = new Size(panelButtons.Width / 3, panelButtons.Height/2)
         };
         mb3.Click += new EventHandler((object s1, EventArgs e1) => {
            bool res = setarRemessasEnviada(remessa.id, !remessa.enviado.Equals("1"));
            if (res) {
               updatePage();
            }
         });
         panelButtons.Controls.Add(mb3);
         MeuButton mb4 = new MeuButton() {
            title = btnTxt4,
            Location = new Point(0, mb3.Location.Y + mb3.Height),
            Size = new Size(panelButtons.Width, panelButtons.Height/2)
         };
         mb4.Click += new EventHandler((object s1, EventArgs e1) => {
            if (remessa.enviado.Equals("1")) {

            } else {
               //MessageBox.Show(remessa.arquivoRemessa);
               EnviarRemessaDialog enviarRemessaDialog = new EnviarRemessaDialog(remessa, cedente);
               var res = enviarRemessaDialog.ShowDialog();

               if (res == DialogResult.OK) {
                  if (setarRemessasEnviada(remessa.id, !remessa.enviado.Equals("1"))) {
                     updatePage();
                  }
               }
            }
         });
         panelButtons.Controls.Add(mb4);
         panel.Controls.Add(panelButtons);

         return panel;
      }

      private System.Net.HttpStatusCode buscarRemessas(string idCedente) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getDadosRemessa.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("cedente-id", idCedente);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (!content.Equals("erro")) {
               remessas = JsonConvert.DeserializeObject<List<Remessa>>(content);

               return response.StatusCode;
            } else {
               remessas = new List<Remessa>();

               return response.StatusCode;
            }
         } else {
            MessageBox.Show("Houve um erro ao resgatar as remessas. Http status Code: " + response.StatusCode);
         }

         /*Properties.Settings.Default["cedenteAtual"] = "";
         Properties.Settings.Default["logado"] = false;
         Properties.Settings.Default.Save();

         this.Hide();
         Login login = new Login();
         //login.Closed += (s, args) => this.Close();
         login.Show();*/

         return response.StatusCode;
      }

      private bool setarRemessasEnviada(string idRemessa, bool enviada) {

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/setRemessaEnviada.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("id-remessa", idRemessa);
         request.AddParameter("enviada", enviada ? 1 : 0);

         var response = client.Post(request);

         var content = response.Content; // raw content as string


         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (!content.Equals("erro")) {
               return true;
            } else {
               return false;
            }
         } else {
            MessageBox.Show("Houve um erro. Http status Code: " + response.StatusCode);
         }

         return false;
      }

      private void TabRemessas_Resize(object sender, EventArgs e) {
         panel1.Location = new Point(0, 0);
         panel1.Size = new Size(ClientRectangle.Width, panel1.Height);
         panel1.MinimumSize = new Size(ClientRectangle.Width, 0);
         panel1.MaximumSize = new Size(ClientRectangle.Width, 0);

         System.Drawing.Rectangle newSize = new System.Drawing.Rectangle(padding.Left, padding.Top, panel1.Width - padding.Left - padding.Right, panel1.Height - padding.Top - padding.Bottom);

         int cardWidth = (newSize.Width - (spaceBetweenCards * (quantCards - 1))) / quantCards;

         mainCard1.Location = new Point(newSize.X, newSize.Y);
         mainCard1.Size = new Size(cardWidth, cardHeight);

         mainCard2.Location = new Point(newSize.X + cardWidth + spaceBetweenCards, newSize.Y);
         mainCard2.Size = new Size(cardWidth, cardHeight);

         flowRemessas.Size = new Size(newSize.Width, 80); //0
         flowRemessas.MinimumSize = new Size(newSize.Width, 0); //0
         flowRemessas.MaximumSize = new Size(newSize.Width, 0); //0
         flowRemessas.Location = new Point(newSize.X, mainCard1.Location.Y + mainCard1.Height + 20);

         atualizarFlow(remessas);
         //Console.WriteLine(flowRemessas.Controls.Count); 
      }
   }
}
