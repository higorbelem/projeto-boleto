using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class EnviarRemessaDialog : Form {

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      private Remessa remessa;
      private Cedente cedente;

      private string caminhoArquivo = "";
      private string nomeArquivo = "";

      public EnviarRemessaDialog(Remessa remessa, Cedente cedente) {
         InitializeComponent();

         this.remessa = remessa;
         this.cedente = cedente;

         try {
            // If the directory doesn't exist, create it.
            if (!Directory.Exists("remessas")) {
               Directory.CreateDirectory("remessas");
            }

            nomeArquivo = "remessa" + remessa.id + ".txt";

            if (File.Exists("remessas\\" + nomeArquivo)) {
               File.Delete("remessas\\" + nomeArquivo);
            }

            File.Create("remessas\\" + nomeArquivo).Close();
            using (StreamWriter sw = File.AppendText("remessas\\" + nomeArquivo)) {
               sw.Write(remessa.arquivoRemessa);
            }
            /*else {
               // File.WriteAllText("FILENAME.txt", String.Empty); // Clear file
               using (StreamWriter sw = File.AppendText("remessas\\" + nomeArquivo)) {
                  sw.Write(remessa.arquivoRemessa);
               }
            }*/

            //caminhoArquivo = Path.GetDirectoryName(Application.ExecutablePath).Replace(@"bin\debug\", string.Empty) + "/remessas/" + fileName;
            caminhoArquivo = Path.GetDirectoryName(Application.ExecutablePath) + "\\remessas\\";

         } catch (Exception e) {
            //MessageBox.Show(e.ToString(), "Erro ao criar o arquivo");
            labelErro.Visible = true;
         }

      }

      private void EnviarRemessaDialog_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         toolTip1.AutoPopDelay = 5000;
         toolTip1.InitialDelay = 1000;
         toolTip1.ReshowDelay = 500;
         toolTip1.ShowAlways = true;
         toolTip1.SetToolTip(this.btnCopiar, "Copia o caminho para o clipboard (Ctrl + c)");

         panelTopBar.BackColor = Colors.bgDark2;
         panelTopBar.Location = new Point(ClientRectangle.X, ClientRectangle.Y);
         panelTopBar.Size = new Size(ClientRectangle.Width, 60);
         panelTopBar.Margin = new Padding(0);

         backButtonImg.Location = new Point(panelTopBar.Location.X + 20, panelTopBar.Location.Y + 20);
         backButtonImg.Size = new Size(panelTopBar.Height - 40, panelTopBar.Height - 40);

         labelTitle.Text = "REMESSA #" + remessa.id;
         labelTitle.Location = new Point(panelTopBar.Location.X, panelTopBar.Location.Y);
         labelTitle.Size = new Size(panelTopBar.Width, panelTopBar.Height);
         labelTitle.TextAlign = ContentAlignment.MiddleCenter;
         labelTitle.Font = Fonts.mainBold14;
         labelTitle.ForeColor = Colors.bg;
         labelTitle.Margin = new Padding(0);

         textBoxRemessa.Text = remessa.arquivoRemessa;

         btnCopiar.title = "COPIAR";
         btnAbrirSite.title = "ABRIR SITE DO BANCO";
         btnAbrirArquivo.title = "ABRIR LOCAL DO ARQUIVO";
         btnJaEnviei.title = "JÀ ENVIEI O ARQUIVO";

         textBoxCaminho.BackColor = Colors.bg3;
         textBoxCaminho.txtBox.ReadOnly = true;
         textBoxCaminho.txtBox.Text = caminhoArquivo + nomeArquivo;
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

      protected override CreateParams CreateParams {
         get {
            const int CS_DROPSHADOW = 0x20000;
            CreateParams cp = base.CreateParams;
            cp.ClassStyle |= CS_DROPSHADOW;
            return cp;
         }
      }

      private void btnCopiar_Click(object sender, EventArgs e) {
         Clipboard.SetText(textBoxCaminho.txtBox.Text);

         //toolTip1.Show(toolTip1.GetToolTip(btnCopiar), btnCopiar, 10000);
         //Loading loading = new Loading();
         //loading.ShowDialog(this);
         //loading.Close();
      }

      private void btnAbrirSite_Click(object sender, EventArgs e) {
         if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("001")) {
            Process.Start("https://www.bb.com.br");
         } else if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("341")) {
            Process.Start("https://www.itau.com.br/index.html");
         } else if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("237")) {
            Process.Start("https://banco.bradesco");
         }
      }

      private void btnAbrirArquivo_Click(object sender, EventArgs e) {
         Process.Start(caminhoArquivo);
      }

      private void btnJaEnviei_Click(object sender, EventArgs e) {
         this.Close();
         this.DialogResult = DialogResult.OK;
      }

      protected override void WndProc(ref Message m) {
         const UInt32 WM_NCACTIVATE = 0x0086;

         if (m.Msg == WM_NCACTIVATE && m.WParam.ToInt32() == 0) {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
         } else {
            base.WndProc(ref m);
         }
      }
   }
}
