using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class AdicionarEditarClienteDialog : Form {

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      private int dialogMode;

      public static int DIALOG_MODE_ADICIONAR = 0;
      public static int DIALOG_MODE_EDITAR = 1;

      private Cedente cedente;

      private int itemCasaPadding = 5;

      public AdicionarEditarClienteDialog(Cedente cedente, int dialogMode) {
         InitializeComponent();

         this.dialogMode = dialogMode;
         this.cedente = cedente;

         labelTitle.Select();

         txtBoxDocumento.hint = "CPF";
         txtBoxEmail.hint = "EMAIL";
         txtBoxNome.hint = "NOME";
         if (dialogMode == DIALOG_MODE_ADICIONAR) {
            txtBoxDocumento.useHint = true;
            txtBoxEmail.useHint = true;
            txtBoxNome.useHint = true;
         } else if (dialogMode == DIALOG_MODE_EDITAR) {
            txtBoxDocumento.useHint = false;
            txtBoxEmail.useHint = false;
            txtBoxNome.useHint = false;
         }

         btnOk.title = "CONCLUIR";
      }

      private void AdicionarClienteDialog_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         panelTopBar.BackColor = Colors.bgDark2;
         panelTopBar.Location = new Point(ClientRectangle.X, ClientRectangle.Y);
         panelTopBar.Size = new Size(ClientRectangle.Width, 60);
         panelTopBar.Margin = new Padding(0);

         backButtonImg.Location = new Point(panelTopBar.Location.X + 20, panelTopBar.Location.Y + 20);
         backButtonImg.Size = new Size(panelTopBar.Height - 40, panelTopBar.Height - 40);

         if (dialogMode == DIALOG_MODE_ADICIONAR) {
            labelTitle.Text = "ADICIONAR CLIENTE";
         } else if (dialogMode == DIALOG_MODE_EDITAR) {
            labelTitle.Text = "EDITAR CLIENTE";
         }
         labelTitle.Location = new Point(panelTopBar.Location.X, panelTopBar.Location.Y);
         labelTitle.Size = new Size(panelTopBar.Width, panelTopBar.Height);
         labelTitle.TextAlign = ContentAlignment.MiddleCenter;
         labelTitle.Font = Fonts.mainBold14;
         labelTitle.ForeColor = Colors.bg;
         labelTitle.Margin = new Padding(0);

         labelCasas.Font = Fonts.mainBold12;
         labelCasas.ForeColor = Colors.headerText;
         labelCasas.TextAlign = ContentAlignment.MiddleCenter;

         flowCasas.Size = new Size(panel1.Width + SystemInformation.VerticalScrollBarWidth, panel1.Height);
         flowCasas.BackColor = Colors.bg2;
         flowCasas.Padding = new Padding(itemCasaPadding);

         txtBoxDocumento.BackColor = Colors.bg3;
         txtBoxEmail.BackColor = Colors.bg3;
         txtBoxNome.BackColor = Colors.bg3;
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

      private void btnOk_Click(object sender, EventArgs e) {
         if (txtBoxDocumento.isEmpty || txtBoxEmail.isEmpty || txtBoxNome.isEmpty) {
            MessageBox.Show("Algum campo esta vazio");
         } else {
            Loading loading = new Loading();
            loading.task = new Task(new Action(() => {
               var res = sendPhp(txtBoxNome.txtBox.Text, txtBoxDocumento.txtBox.Text, txtBoxEmail.txtBox.Text,dialogMode);

               loading.terminou = true;
               loading.terminouBem = res;
            }));
            var resDialog = loading.ShowDialog();

            if (resDialog == DialogResult.OK) {
               this.Close();
               this.DialogResult = DialogResult.OK;
            }
         }
      }

      private bool sendPhp(string nome, string documento, string email, int dialogMode) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/adicionarEditarSacado.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("id-cedente", cedente.id);
         request.AddParameter("nome", nome);
         request.AddParameter("documento", documento);
         request.AddParameter("email", email);
         request.AddParameter("dialog-mode", dialogMode);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            if (!content.Equals("erro")) {
               return true;
            } else {
               return false;
            }
         }

         return false;
      }

      private void btnAddCasa_Click(object sender, EventArgs e) {
         AdicionarEditarClienteCasaItem adicionarEditarClienteCasaItem = new AdicionarEditarClienteCasaItem() {
            Location = new Point(0, 0),
            Size = new Size(flowCasas.Width - 35,50)
         };
         adicionarEditarClienteCasaItem.btnDeletar.Click += new EventHandler((object s1, EventArgs e1) => {
            flowCasas.Controls.Remove(adicionarEditarClienteCasaItem);
         });
         flowCasas.Controls.Add(adicionarEditarClienteCasaItem);
         flowCasas.Controls.SetChildIndex(adicionarEditarClienteCasaItem, flowCasas.Controls.IndexOf(btnAddCasa));
      }
   }
}
