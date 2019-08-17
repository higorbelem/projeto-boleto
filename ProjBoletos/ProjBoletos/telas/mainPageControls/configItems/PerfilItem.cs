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
using System.IO;
using System.Net;
using ProjBoletos.modelos;
using Newtonsoft.Json;
using ProjBoletos.components;
using RestSharp;

namespace ProjBoletos.telas.mainPageControls.configItems {
   public partial class PerfilItem : UserControl {

      Cedente cedente;

      public PerfilItem() {
         InitializeComponent();

         var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
         cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);

         if (cedente == null) {
            Application.Exit();
         }

         txtBoxBairro.useHint = false;
         txtBoxRua.useHint = false;
         txtBoxNumero.useHint = false;
         txtBoxCep.useHint = false;
         txtBoxCidade.useHint = false;
         txtBoxUf.useHint = false;
         txtBoxCnpj.useHint = false;
         txtBoxNome.useHint = false;
         txtBoxEmail.useHint = false;
         txtBoxContato.useHint = false;

         txtBoxNome.hint = "Nome";
         txtBoxCnpj.hint = "Cnpj";
         txtBoxCnpj.mask = "00,000,000/0000-00";
         txtBoxContato.hint = "Contato";
         txtBoxEmail.hint = "Email";
         txtBoxCep.hint = "CEP";
         txtBoxCep.mask = "00000-000";
         txtBoxCidade.hint = "Cidade";
         txtBoxBairro.hint = "Bairro";
         txtBoxRua.hint = "Rua";
         txtBoxNumero.hint = "Número";
         txtBoxUf.hint = "UF";
         txtBoxUf.mask = "LL";

         btnSalvar.title = "SALVAR";
         btnFile.title = "ALTERAR LOGO";
      }

      private void PerfilItem_Load(object sender, EventArgs e) {
         //PerfilItem_Resize(sender,e);

         labelEndereco.Text = "Endereço";
         labelEndereco.Font = Fonts.mainBold12;
         labelEndereco.ForeColor = Colors.primaryText;

         txtBoxBairro.BackColor = Colors.bg2;
         txtBoxRua.BackColor = Colors.bg2;
         txtBoxNumero.BackColor = Colors.bg2;
         txtBoxCep.BackColor = Colors.bg2;
         txtBoxCidade.BackColor = Colors.bg2;
         txtBoxUf.BackColor = Colors.bg2;
         txtBoxCnpj.BackColor = Colors.bg2;
         txtBoxNome.BackColor = Colors.bg2;
         txtBoxEmail.BackColor = Colors.bg2;
         txtBoxContato.BackColor = Colors.bg2;

         txtBoxBairro.txtBox.Text = cedente.bairro;
         txtBoxRua.txtBox.Text = cedente.rua;
         txtBoxNumero.txtBox.Text = cedente.numero;
         txtBoxCep.txtBox.Text = cedente.cep;
         txtBoxCidade.txtBox.Text = cedente.cidade;
         txtBoxUf.txtBox.Text = cedente.uf;
         txtBoxCnpj.txtBox.Text = cedente.cnpj;
         txtBoxNome.txtBox.Text = cedente.nome;
         txtBoxEmail.txtBox.Text = cedente.email;
         txtBoxContato.txtBox.Text = cedente.contato;

      }

      private void PerfilItem_Resize(object sender, EventArgs e) {

         Rectangle rectWithPadding = new Rectangle(20, 20, ClientRectangle.Width - 40, ClientRectangle.Height - 40);

         txtBoxNome.Location = new Point(rectWithPadding.X, rectWithPadding.Y);
         txtBoxNome.Size = new Size(rectWithPadding.Width, 35);

         txtBoxCnpj.Location = new Point(rectWithPadding.X, txtBoxNome.Location.Y + txtBoxNome.Height + 5);
         txtBoxCnpj.Size = new Size(rectWithPadding.Width, 35);

         txtBoxContato.Location = new Point(rectWithPadding.X, txtBoxCnpj.Location.Y + txtBoxCnpj.Height + 5);
         txtBoxContato.Size = new Size(rectWithPadding.Width, 35);

         txtBoxEmail.Location = new Point(rectWithPadding.X, txtBoxContato.Location.Y + txtBoxContato.Height + 5);
         txtBoxEmail.Size = new Size(rectWithPadding.Width, 35);

         labelEndereco.Location = new Point(rectWithPadding.X + 50, txtBoxEmail.Location.Y + txtBoxEmail.Height + 10);

         txtBoxCidade.Location = new Point(rectWithPadding.X, labelEndereco.Location.Y + labelEndereco.Height + 5);
         txtBoxCidade.Size = new Size((rectWithPadding.Width / 2) - 5, 35);

         txtBoxBairro.Location = new Point(txtBoxCidade.Location.X + txtBoxCidade.Width + 5, labelEndereco.Location.Y + labelEndereco.Height + 5);
         txtBoxBairro.Size = new Size((rectWithPadding.Width / 2) - 5, 35);

         txtBoxRua.Location = new Point(rectWithPadding.X, txtBoxCidade.Location.Y + txtBoxCidade.Height + 5);
         txtBoxRua.Size = new Size((int)(rectWithPadding.Width * 0.8) - 5, 35);

         txtBoxNumero.Location = new Point(txtBoxRua.Location.X + txtBoxRua.Width + 5, txtBoxCidade.Location.Y + txtBoxCidade.Height + 5);
         txtBoxNumero.Size = new Size((int)(rectWithPadding.Width * 0.2) - 5, 35);

         txtBoxUf.Location = new Point(rectWithPadding.X, txtBoxRua.Location.Y + txtBoxRua.Height + 5);
         txtBoxUf.Size = new Size((int)(rectWithPadding.Width * 0.2) - 5, 35);

         txtBoxCep.Location = new Point(txtBoxUf.Location.X + txtBoxUf.Width + 5, txtBoxRua.Location.Y + txtBoxRua.Height + 5);
         txtBoxCep.Size = new Size((int)(rectWithPadding.Width * 0.8) - 5, 35);

         btnFile.Size = new Size(270, 45);
         btnFile.Location = new Point((rectWithPadding.Width / 4) - (btnFile.Width / 2), txtBoxUf.Location.Y + txtBoxUf.Height + 15);

         btnSalvar.Size = new Size(270, 45);
         btnSalvar.Location = new Point(((rectWithPadding.Width / 4) * 3) - (btnSalvar.Width / 2), txtBoxUf.Location.Y + txtBoxUf.Height + 15);

         this.Height = btnSalvar.Location.Y + btnSalvar.Height + 20;
      }

      private void panel1_Paint(object sender, PaintEventArgs e) {

      }

      public void resize() {
         PerfilItem_Resize(null, null);
      }

      public static PerfilItem tryParse(Control control) {
         PerfilItem perfilItem;
         try {
            perfilItem = (PerfilItem)control;
         } catch (Exception e) {
            return null;
         }
         return perfilItem;
      }

      public bool uploadImage(string imagePath) {
         try {

            FtpWebRequest ftpReq = (FtpWebRequest)WebRequest.Create("ftp://localhost/imgs/logos/logo-cedente-" + cedente.id + ".png");

            ftpReq.UseBinary = true;
            ftpReq.Method = WebRequestMethods.Ftp.UploadFile;
            ftpReq.Credentials = new NetworkCredential("boletos", "123");

            byte[] b = File.ReadAllBytes(@imagePath);
            ftpReq.ContentLength = b.Length;
            using (Stream s = ftpReq.GetRequestStream()) {
               s.Write(b, 0, b.Length);
            }

            FtpWebResponse ftpResp = (FtpWebResponse)ftpReq.GetResponse();

            if (ftpResp != null) {
               if (ftpResp.StatusDescription.StartsWith("226")) {
                  MessageBox.Show("Imagem enviada.");
                  return true;
                  //Console.WriteLine("File Uploaded.");
               }
            }
         } catch (Exception e) {
            MessageBox.Show(e.ToString());
            Console.WriteLine(e.ToString());
            return false;
         }

         return false;
      }

      private void btnSalvar_Click(object sender, EventArgs e) {
         if (txtBoxBairro.isEmpty || txtBoxCep.isEmpty || txtBoxCidade.isEmpty || txtBoxCnpj.isEmpty || txtBoxContato.isEmpty || txtBoxEmail.isEmpty || txtBoxNome.isEmpty || txtBoxNumero.isEmpty || txtBoxRua.isEmpty || txtBoxUf.isEmpty) {
            MessageBox.Show("Algum campo está vazio");
         } else {
            Loading loading = new Loading();
            loading.task = new Task(new Action(() => {
               bool result = salvarDados(txtBoxUf.getValue(), txtBoxCidade.getValue(), txtBoxBairro.getValue(), txtBoxRua.getValue(), txtBoxNumero.getValue(), txtBoxCep.getValue(), txtBoxNome.getValue(), txtBoxCnpj.getValue(), txtBoxContato.getValue(), txtBoxEmail.getValue());

               loading.terminou = true;
               loading.terminouBem = result;
            }));

            var res = loading.ShowDialog();

            if (res == DialogResult.OK) {
               if (MessageBox.Show("Dados salvos.\nO programa irá reiniciar.", "", MessageBoxButtons.OK) == DialogResult.OK) {
                  MainPage mainPage = new MainPage();
                  mainPage.Show();
                  this.FindForm().Hide();
               }
            } else {
               MessageBox.Show("houve algum erro.");
            }
         }
      }

      private bool salvarDados(string uf, string cidade, string bairro, string rua, string numero, string cep, string nome, string cnpj, string contato, string email) {
         //MessageBox.Show(cnpj + " " + senha);
         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/salvarPerfilCedente.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("id-cedente", cedente.id);
         request.AddParameter("uf", uf);
         request.AddParameter("cidade", cidade);
         request.AddParameter("bairro", bairro);
         request.AddParameter("rua", rua);
         request.AddParameter("numero", numero);
         request.AddParameter("cep", cep);
         request.AddParameter("nome", nome);
         request.AddParameter("cnpj", cnpj);
         request.AddParameter("contato", contato);
         request.AddParameter("email", email);

         var response = client.Post(request);
         var content = response.Content; // raw content as string

         Console.WriteLine(content);

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (content.Split(';')[0].Contains("ok")) {
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

      private void btnFile_Click(object sender, EventArgs e) {
         OpenFileDialog fileDialog = new OpenFileDialog();

         DialogResult dialogResult = fileDialog.ShowDialog();

         if (dialogResult == DialogResult.OK) {
            Stream fileStream = fileDialog.OpenFile();
            if (fileStream != null) {
               string fileName = fileDialog.FileName;
               string extension = fileName.Split('.').Last();
               if (extension.Equals("png") || extension.Equals("jpg")) {
                  if (fileStream.Length <= 100000) {
                     Loading loading = new Loading();
                     loading.task = new Task(new Action(() => {
                        bool result = uploadImage(fileName);

                        loading.terminou = true;
                        loading.terminouBem = result;
                     }));

                     var res = loading.ShowDialog();

                     if (res == DialogResult.OK) {
                        MainPage mainPage = (MainPage)FindForm();
                        mainPage.resetLogo();
                     }
                  } else {
                     MessageBox.Show("Imagem muito grande.\nMáximo : 100KB\nImagem escolhida : " + fileStream.Length / 1000.0 + "KB");
                  }
               } else {
                  MessageBox.Show("Extensão inválida.\nSomente jpg e png são aceitos.");
               }
            }
         }

      }
   }
}
