using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.utils;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class AdicionarEditarMedidorVisualizador : Form {

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      private int dialogMode;
      private MedidorVisualizador medidorVisualizador;
      private Cedente cedente;

      public static int DIALOG_MODE_ADICIONAR = 0;
      public static int DIALOG_MODE_EDITAR = 1;

      public AdicionarEditarMedidorVisualizador(Cedente cedente, MedidorVisualizador medidorVisualizador, int dialogMode) {
         InitializeComponent();

         this.dialogMode = dialogMode;
         this.cedente = cedente;
         this.medidorVisualizador = medidorVisualizador;

         labelTitle.Select();

         txtBoxCpf.hint = "CPF";
         txtBoxCpf.mask = "000,000,000-00";
         txtBoxSenha.hint = "SENHA";
         txtBoxSenha.isPassword = true;
         txtBoxSenhaConfirma.hint = "CONFIRME A SENHA";
         txtBoxSenhaConfirma.isPassword = true;
         txtBoxNome.hint = "NOME";
         if (dialogMode == DIALOG_MODE_ADICIONAR) {
            txtBoxCpf.useHint = true;
            txtBoxSenha.useHint = true;
            txtBoxNome.useHint = true;
            txtBoxSenhaConfirma.useHint = true;
         } else if (dialogMode == DIALOG_MODE_EDITAR) {
            txtBoxCpf.useHint = false;
            txtBoxSenha.useHint = false;
            txtBoxNome.useHint = false;
            txtBoxSenhaConfirma.useHint = false;
         }

         btnOk.title = "CONCLUIR";

      }

      private void AdicionarEditarMedidorVisualizador_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         panelTopBar.BackColor = Colors.bgDark2;
         panelTopBar.Location = new Point(ClientRectangle.X, ClientRectangle.Y);
         panelTopBar.Size = new Size(ClientRectangle.Width, 60);
         panelTopBar.Margin = new Padding(0);

         backButtonImg.Location = new Point(panelTopBar.Location.X + 20, panelTopBar.Location.Y + 20);
         backButtonImg.Size = new Size(panelTopBar.Height - 40, panelTopBar.Height - 40);

         if (dialogMode == DIALOG_MODE_ADICIONAR) {
            labelTitle.Text = "ADICIONAR";
         } else if (dialogMode == DIALOG_MODE_EDITAR) {
            labelTitle.Text = "EDITAR";
         }
         labelTitle.Location = new Point(panelTopBar.Location.X, panelTopBar.Location.Y);
         labelTitle.Size = new Size(panelTopBar.Width, panelTopBar.Height);
         labelTitle.TextAlign = ContentAlignment.MiddleCenter;
         labelTitle.Font = Fonts.mainBold14;
         labelTitle.ForeColor = Colors.bg;
         labelTitle.Margin = new Padding(0);

         if (dialogMode == DIALOG_MODE_EDITAR) {
            txtBoxNome.txtBox.Text = medidorVisualizador.nome;
            txtBoxCpf.txtBox.Text = medidorVisualizador.cpf;
            txtBoxSenha.txtBox.Text = medidorVisualizador.senha;
            txtBoxSenha.txtBox.PasswordChar = '*';
            txtBoxSenhaConfirma.txtBox.Text = medidorVisualizador.senha;
            txtBoxSenhaConfirma.txtBox.PasswordChar = '*';
            if (medidorVisualizador.tipo.Equals("medidor")) {
               radioButtonMedidor.Checked = true;
            }else if (medidorVisualizador.tipo.Equals("visualizador")) {
               radioButtonVisualizador.Checked = true;
            }
            //txtBoxSenha.isPassword = false;
            //txtBoxSenhaConfirma.Visible = false;
         }

         txtBoxCpf.BackColor = Colors.bg3;
         txtBoxSenha.BackColor = Colors.bg3;
         txtBoxSenhaConfirma.BackColor = Colors.bg3;
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

      private void panelTopBar_Paint(object sender, PaintEventArgs e) {

      }

      private void panelTopBar_MouseDown(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
         }
      }

      private void backButtonImg_Click(object sender, EventArgs e) {
         this.Close();
         this.DialogResult = DialogResult.Cancel;
      }

      private void btnOk_Click(object sender, EventArgs e) {
         bool camposVazios = txtBoxCpf.isEmpty || txtBoxSenha.isEmpty || txtBoxNome.isEmpty || txtBoxSenhaConfirma.isEmpty;
         bool senhasDivergem = !txtBoxSenha.txtBox.Text.Equals(txtBoxSenhaConfirma.txtBox.Text);
         bool tipoNaoSelecionado = !(radioButtonMedidor.Checked || radioButtonVisualizador.Checked);
         bool cpfNaoCompleto = !txtBoxCpf.txtBox.MaskCompleted;

         if (camposVazios || senhasDivergem || tipoNaoSelecionado || cpfNaoCompleto) {
            StringBuilder stringBuilder = new StringBuilder();
            if (camposVazios) {
               stringBuilder.Append("campos vazios");
            } else if(cpfNaoCompleto) {
               stringBuilder.Append("cpf não completo");
            }
            if (senhasDivergem) {
               if (camposVazios || cpfNaoCompleto) {
                  stringBuilder.Append(" e ");
               }
               stringBuilder.Append("senhas diferentes");
            }
            if (tipoNaoSelecionado) {
               if (senhasDivergem || camposVazios || cpfNaoCompleto) {
                  stringBuilder.Append(" e ");
               }
               stringBuilder.Append("escolha um tipo de conta");
            }

            stringBuilder.Append(".");

            stringBuilder[0] = (stringBuilder[0] + "").ToUpper().ToCharArray()[0];

            string message = stringBuilder.ToString();
            
            MessageBox.Show(message);

         } else {
            string tipo = radioButtonMedidor.Checked ? radioButtonMedidor.Text.ToLower() : radioButtonVisualizador.Checked ? radioButtonVisualizador.Text.ToLower() : "erro";
            Loading loading = new Loading();
            loading.task = new Task(new Action(() => {
               var res = sendPhp(txtBoxNome.txtBox.Text, txtBoxCpf.getValue(), txtBoxSenha.txtBox.Text, tipo, dialogMode);

               loading.terminou = true;
               loading.terminouBem = res;
            }));
            var resDialog = loading.ShowDialog();

            if (resDialog == DialogResult.OK) {
               this.Close();
               this.DialogResult = DialogResult.OK;
               if (dialogMode == DIALOG_MODE_ADICIONAR) {
                  MessageBox.Show("Inserido com sucesso.");
               } else if (dialogMode == DIALOG_MODE_EDITAR) {
                  MessageBox.Show("Editado com sucesso.");
               }
            } else {
               MessageBox.Show("Houve algum erro, tente novamente.");
            }
         }
      }

      private bool sendPhp(string nome, string cpf, string senha,string tipo , int dialogMode) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/adicionarMedidorVisualizador.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("id-cedente", cedente.id);
         if (medidorVisualizador != null) {
            request.AddParameter("id-medidor", medidorVisualizador.id);
         } else {
            request.AddParameter("id-medidor", "-1");
         }
         request.AddParameter("nome", nome);
         request.AddParameter("cpf", cpf);
         request.AddParameter("senha", senha);
         request.AddParameter("tipo", tipo);
         request.AddParameter("dialog-mode", dialogMode);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;
         //Console.WriteLine(content);

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            //MessageBox.Show(content);
            if (content.Trim().Equals("ok")) {
               return true;
            } else {
               return false;
            }
         }

         return false;
      }
   }
}
