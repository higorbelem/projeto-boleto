using Impactro.Cobranca;
using Impactro.Layout;
using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.testes;
using ProjBoletos.utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class GerarRemessaDialog : Form {

      private List<Remessa> remessas;
      private Form parentForm;
      private Cedente cedente;

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      public GerarRemessaDialog(List<Remessa> remessas, Cedente cedente, Form parentForm) {
         InitializeComponent();

         this.remessas = remessas;
         this.parentForm = parentForm;
         this.cedente = cedente;
      }

      public void refresh() {
         flowLayoutPanel1.Controls.Clear();
         GerarRemessaDialog_Load(null, null);

         if (flowLayoutPanel1.Controls.Count == 0) {
            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void GerarRemessaDialog_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         panelTopBar.BackColor = Colors.bgDark2;
         panelTopBar.Location = new Point(ClientRectangle.X, ClientRectangle.Y);
         panelTopBar.Size = new Size(ClientRectangle.Width, 60);
         panelTopBar.Margin = new Padding(0);

         backButtonImg.Location = new Point(panelTopBar.Location.X + 20, panelTopBar.Location.Y + 20);
         backButtonImg.Size = new Size(panelTopBar.Height - 40, panelTopBar.Height - 40);

         labelTitle.Text = "REMESSAS";
         labelTitle.Location = new Point(panelTopBar.Location.X, panelTopBar.Location.Y);
         labelTitle.Size = new Size(panelTopBar.Width, panelTopBar.Height);
         labelTitle.TextAlign = ContentAlignment.MiddleCenter;
         labelTitle.Font = Fonts.mainBold14;
         labelTitle.ForeColor = Colors.bg;
         labelTitle.Margin = new Padding(0);

         btnGerarTodos.BackColor = Colors.bg3;
         btnGerarTodos.title = "GERAR TODAS";
         btnGerarTodos.cornerRadius = 20;
         btnGerarTodos.Location = new Point((ClientRectangle.Width / 2) - (btnGerarTodos.Width / 2), panelTopBar.Location.Y + panelTopBar.Height + 10);

         flowLayoutPanel1.BackColor = Colors.bg3;
         flowLayoutPanel1.Location = new Point(ClientRectangle.X, btnGerarTodos.Location.Y + btnGerarTodos.Height + 10);
         flowLayoutPanel1.Size = new Size(ClientRectangle.Width + SystemInformation.VerticalScrollBarWidth, ClientRectangle.Height - flowLayoutPanel1.Location.Y);

         int indexI = 0;
         foreach (Remessa remessa in remessas) {
            FlowLayoutPanel flow = new FlowLayoutPanel() {
               BackColor = Colors.bg2,
               Size = new Size(flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth, 0),
               MinimumSize = new Size(flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth, 0),
               MaximumSize = new Size(flowLayoutPanel1.Width - SystemInformation.VerticalScrollBarWidth, 0),
               AutoSize = true,
               Margin = new Padding(0, 5, 0, 5)
            };

            Label labelRemessa = new Label() {
               Size = new Size(flow.Width, 30),
               Text = "Remessa " + (indexI + 1),
               ForeColor = Colors.primaryText,
               Font = Fonts.mainBold14,
               TextAlign = ContentAlignment.MiddleCenter,
               Margin = new Padding(0)
            };

            FlowLayoutPanel flowContaCarteiraLabel = new FlowLayoutPanel() {
               Size = new Size(flow.Width, 0),
               MinimumSize = new Size(flow.Width, 0),
               MaximumSize = new Size(flow.Width, 0),
               AutoSize = true,
               FlowDirection = FlowDirection.LeftToRight,
               Margin = new Padding(0)
            };
            flowContaCarteiraLabel.Controls.Add(new Label() {
               Size = new Size(flowContaCarteiraLabel.Width / 2 - 10, 30),
               Text = "Conta: " + remessa.conta.conta,
               ForeColor = Colors.primaryText,
               Font = Fonts.main12,
               TextAlign = ContentAlignment.MiddleCenter,
               Margin = new Padding(0)
            });
            flowContaCarteiraLabel.Controls.Add(new Label() {
               Size = new Size(flowContaCarteiraLabel.Width / 2 - 10, 30),
               Text = "Carteira: " + remessa.carteira,
               ForeColor = Colors.primaryText,
               Font = Fonts.main12,
               TextAlign = ContentAlignment.MiddleCenter,
               Margin = new Padding(0)
            });

            flow.Controls.Add(labelRemessa);
            flow.Controls.Add(flowContaCarteiraLabel);
            flow.Controls.Add(new Separator() {
               Size = new Size(flow.Width - 30, 10),
               Margin = new Padding(15, 0, 15, 0)
            });

            int indexJ = 0;
            foreach (Medicao medicao in remessa.medicoes) {
               Panel panel = new Panel() {
                  BackColor = Colors.bg2,
                  Size = new Size(flow.Width - 30, 70),
                  Margin = new Padding(15, 5, 15, 5)
               };

               Panel panelDetalhesMedicao = new Panel() {
                  Location = new Point(panel.Location.X, panel.Location.Y),
                  Size = new Size((int)(panel.Width * 0.8), panel.Height),
               };
               panelDetalhesMedicao.Controls.Add(new Label() {
                  Location = new Point(panelDetalhesMedicao.Location.X, panelDetalhesMedicao.Location.Y),
                  Size = new Size(flowContaCarteiraLabel.Width, panelDetalhesMedicao.Height / 2),
                  Text = medicao.sacado.nome,
                  ForeColor = Colors.primaryText,
                  Font = Fonts.mainBold10,
                  TextAlign = ContentAlignment.BottomLeft,
                  Margin = new Padding(0)
               });
               panelDetalhesMedicao.Controls.Add(new Label() {
                  Location = new Point(panelDetalhesMedicao.Location.X, panelDetalhesMedicao.Location.Y + panelDetalhesMedicao.Height / 2),
                  Size = new Size(flowContaCarteiraLabel.Width, panelDetalhesMedicao.Height / 2),
                  Text = medicao.casa.rua + ", " + medicao.casa.numero,
                  ForeColor = Colors.primaryText,
                  Font = Fonts.mainBold10,
                  TextAlign = ContentAlignment.TopLeft,
                  Margin = new Padding(0)
               });

               MeuButton btnVer = new MeuButton() {
                  title = "VER",
                  Size = new Size((int)(panel.Width * 0.2), panel.Height / 2),
                  Location = new Point(panelDetalhesMedicao.Location.X + panelDetalhesMedicao.Width, panel.Location.Y + (panel.Height / 2) - (panel.Height / 4))
               };
               btnVer.Click += new EventHandler((object s1, EventArgs e1) => {
                  BoletoForm boletoForm = new BoletoForm(medicao);
                  boletoForm.ShowDialog(this);
               });

               panel.Controls.Add(panelDetalhesMedicao);
               panel.Controls.Add(btnVer);

               flow.Controls.Add(panel);
               flow.Controls.Add(new Separator() {
                  Size = new Size(flow.Width - 30, 10),
                  Margin = new Padding(15, 0, 15, 0)
               });
               indexJ++;
            }

            MeuButton btnGerarRemessa = new MeuButton() {
               title = "GERAR REMESSA",
               cornerRadius = 20,
               Size = new Size(flow.Width - 240, 40),
               Margin = new Padding(120, 0, 120, 15)
            };
            btnGerarRemessa.Click += new EventHandler((object s1, EventArgs e1) => {
               var remessaTxt = gerarRemessa(remessa);

               bool res = enviarRemessaServer(remessaTxt, remessa.medicoes);

               if (res) {
                  remessas.Remove(remessa);
                  refresh();
               }
            });

            flow.Controls.Add(btnGerarRemessa);

            flowLayoutPanel1.Controls.Add(flow);
            indexI++;
         }
      }

      /*protected override void OnPaintBackground(PaintEventArgs e) {
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         GraphicsPath path = RoundedRectangles.Create(new Rectangle(0, 0, ClientRectangle.Width, ClientRectangle.Height), 5, true, true, true, true);

         e.Graphics.FillPath(new SolidBrush(Colors.bg3), path);
      }*/

      public string gerarRemessa(Remessa remessa) {
         LayoutBancos r = new LayoutBancos();
         r.Init(Cedente.makeCedenteInfo(cedente, remessa.conta, remessa.carteira, ""));
         r.Lote = 55;
         //r.Lote = CobUtil.GetInt(txtLote.Text);
         //r.ShowDumpLine = chkDump.Checked;

         foreach (Medicao medicao in remessa.medicoes) {
            BoletoInfo boletoInfo = modelos.Boleto.makeBoleto(cedente, medicao);

            r.Add(boletoInfo, Sacado.makeSacadoInfo(medicao.sacado, medicao.casa));
         }

         /*try {
            // If the directory doesn't exist, create it.
            if (!Directory.Exists("remessas")) {
               Directory.CreateDirectory("remessas");
            }

            string fileName = "remessa" + remessa.conta.conta + "_" + remessa.carteira + ".txt";

            if (!File.Exists("remessas/" + fileName)) {
               File.Create("remessas/" + fileName).Close();
               using (StreamWriter sw = File.AppendText("remessas/" + fileName)) {
                  sw.Write(r.Remessa());
               }
            } else {
               // File.WriteAllText("FILENAME.txt", String.Empty); // Clear file
               using (StreamWriter sw = File.AppendText("remessas/" + fileName)) {
                  sw.Write(r.Remessa());
               }
            }
         } catch (Exception e) {
            MessageBox.Show(e.ToString(), "Erro ao criar o arquivo");
         }*/

         return r.Remessa();
      }

      private void btnGerarTodos_Click(object sender, EventArgs e) {

         bool todasRemessasGeradas = true;

         foreach (Remessa remessa in remessas) {
            string remessaString = gerarRemessa(remessa);

            if (todasRemessasGeradas) {
               todasRemessasGeradas = enviarRemessaServer(remessaString, remessa.medicoes);
            } else {
               enviarRemessaServer(remessaString, remessa.medicoes);
            }
         }

         if (todasRemessasGeradas) {
            this.DialogResult = DialogResult.OK;
            this.Close();
         }

         /*StringBuilder stringBuilder = new StringBuilder();
         foreach (Remessa remessa in remessas) {
            stringBuilder.Append(gerarRemessa(remessa));
         }

         MessageBox.Show(stringBuilder.ToString());*/
      }

      protected override CreateParams CreateParams {
         get {
            const int CS_DROPSHADOW = 0x20000;
            CreateParams cp = base.CreateParams;
            cp.ClassStyle |= CS_DROPSHADOW;
            return cp;
         }
      }

      private void backButtonImg_Click(object sender, EventArgs e) {
         this.Close();
         this.DialogResult = DialogResult.Cancel;
      }

      private void panelTopBar_MouseDown(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
         }
      }

      private bool enviarRemessaServer(string remessa, List<Medicao> medicoes) {
         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/gerarRemessa.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("arquivo-remessa", remessa);

         foreach (Medicao medicao in medicoes) {
            request.AddParameter("id-boletos[]", medicao.id);
         }
         //request.AddParameter("id-boletos[]", 10);

         var response = client.Post(request);

         var content = response.Content; // raw content as string
         
         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (!content.Equals("erro")) {
               return true;
            } else {
               return false;
            }
         }

         return false;
      }

      /*protected override void WndProc(ref Message m) {
         const UInt32 WM_NCACTIVATE = 0x0086;

         if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0) {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
         } else {
            base.WndProc(ref m);
         }
      }*/
   }
}
