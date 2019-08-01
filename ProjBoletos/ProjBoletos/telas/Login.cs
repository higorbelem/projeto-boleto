using Impactro.Cobranca;
using Newtonsoft.Json;
using ProjBoletos.components;
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

namespace ProjBoletos.telas {
   public partial class Login : Form {
      public Login() {
         InitializeComponent();

         meuTextboxCnpj.hint = "CNPJ";
         meuTextboxCnpj.mask = "00,000,000/0000-00";
         meuTextboxSenha.hint = "SENHA";
         meuTextboxSenha.isPassword = true;

         buttonTeste1.title = "LOGAR";

         box1.radius = 3;
         box1.shadowSize = 5;

         this.KeyDown += new KeyEventHandler(Login_KeyDown);
      }

      private void Login_Load(object sender, EventArgs e) {
         //meuTextboxCnpj.txtBox.Mask = "00,000,000/0000-00";
         //meuTextboxCnpj.txtBox.Mask = "99.999.999/9999-99";
         //meuTextboxCnpj.Focus();
      }

      private void Login_KeyDown(object sender, KeyEventArgs e) {
         if (e.KeyCode == Keys.Enter) {
            //if (buttonTeste1.Focused) {
            buttonTeste1_click(sender, e);
            //}
         }
      }

      private bool logar(string cnpj, string senha) {
         //MessageBox.Show(cnpj + " " + senha);
         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getCedente.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("cnpj", cnpj);
         request.AddParameter("senha", senha);

         var response = client.Post(request);
         var content = response.Content; // raw content as string

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            //CedenteInfo cedente = JsonConvert.DeserializeObject<CedenteInfo>(content);

            //if (!content.Contains("erro-login")) {
            if (content.Split(';')[0].Contains("ok")) {
               //MessageBox.Show(content);
               Properties.Settings.Default["cedenteAtual"] = content.Trim().Remove(0, 3);
               Properties.Settings.Default["logado"] = true;
               Properties.Settings.Default.Save();

               return true;
            } else {
               return false;
            }
         } else {
            return false;
         }
      }

      public void buttonTeste1_click(object sender, EventArgs e) {
         if (!meuTextboxCnpj.isEmpty && !meuTextboxSenha.isEmpty) {

            string cnpj = meuTextboxCnpj.getValue();
            string senha = meuTextboxSenha.getValue();

            Loading loading = new Loading();
            loading.task = new Task(new Action(() => {
               bool result = logar(cnpj, senha);

               loading.terminou = true;
               loading.terminouBem = result;
            }));

            var res = loading.ShowDialog();

            if (res == DialogResult.OK) {
               this.Hide();
               MainPage mainPage = new MainPage();
               mainPage.Closed += (s, args) => this.Close();
               mainPage.Show();
            } else {
               labelErroLogin.Visible = true;
               labelErroConexao.Visible = false;
               labelErroVazio.Visible = false;

               Properties.Settings.Default["cedenteAtual"] = "";
               Properties.Settings.Default["logado"] = false;
               Properties.Settings.Default.Save();
            }
         } else {
            labelErroVazio.Visible = true;
            labelErroLogin.Visible = false;
            labelErroConexao.Visible = false;
         }
      }

      public static bool IsNullOrEmpty(String value) {
         return (value == null || value.Length == 0);
      }

      private void label1_Click(object sender, EventArgs e) {

      }

      private void groupBox1_Enter(object sender, EventArgs e) {

      }

      private void box1_Load(object sender, EventArgs e) {

      }

      private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) {

      }

      private void buttonTeste1_Load(object sender, EventArgs e) {

      }
   }
}
