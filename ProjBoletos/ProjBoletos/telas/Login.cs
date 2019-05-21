using Impactro.Cobranca;
using Newtonsoft.Json;
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
            meuTextboxSenha.hint = "SENHA";
            meuTextboxSenha.isPassword = true;

            box1.radius = 3;
            box1.shadowSize = 5;

            this.KeyDown += new KeyEventHandler(Login_KeyDown);
        }

        private void Login_Load(object sender, EventArgs e) {
            //meuTextboxCnpj.Focus();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                if (buttonTeste1.Focused) {
                    buttonTeste1_click(sender, e);
                }
            }
        }

        private bool logar(string cnpj, string senha) {
            var client = new RestClient("http://localhost/projeto-boletos-server/logarCedente.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("text/plain");
            request.AddParameter("cnpj", cnpj);
            request.AddParameter("senha", senha);

            var response = client.Post(request);
            var content = response.Content; // raw content as string

            if (!content.Equals("erro")) {
                //CedenteInfo cedente = JsonConvert.DeserializeObject<CedenteInfo>(content);

                Properties.Settings.Default["cedenteAtual"] = content;
                Properties.Settings.Default["logado"] = true;
                Properties.Settings.Default.Save();

                return true;
            }

            Properties.Settings.Default["cedenteAtual"] = "";
            Properties.Settings.Default["logado"] = false;
            Properties.Settings.Default.Save();
            return false;
        }

        public void buttonTeste1_click(object sender, EventArgs e) {
            bool result = logar(meuTextboxCnpj.txtBox.Text, meuTextboxSenha.txtBox.Text);
            Console.WriteLine(result);

            if (result) {
                this.Hide();
                MainPage mainPage = new MainPage();
                mainPage.Closed += (s, args) => this.Close();
                mainPage.Show();
            }

            Console.WriteLine(meuTextboxCnpj.txtBox.Text);
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
