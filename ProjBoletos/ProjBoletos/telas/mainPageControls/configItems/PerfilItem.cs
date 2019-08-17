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
         txtBoxNome.Size = new Size(rectWithPadding.Width, 50);

         txtBoxCnpj.Location = new Point(rectWithPadding.X, txtBoxNome.Location.Y + txtBoxNome.Height + 5);
         txtBoxCnpj.Size = new Size(rectWithPadding.Width, 50);

         txtBoxContato.Location = new Point(rectWithPadding.X, txtBoxCnpj.Location.Y + txtBoxCnpj.Height + 5);
         txtBoxContato.Size = new Size(rectWithPadding.Width, 50);

         txtBoxEmail.Location = new Point(rectWithPadding.X, txtBoxContato.Location.Y + txtBoxContato.Height + 5);
         txtBoxEmail.Size = new Size(rectWithPadding.Width, 50);

         labelEndereco.Location = new Point(rectWithPadding.X + 50, txtBoxEmail.Location.Y + txtBoxEmail.Height + 10);

         txtBoxCidade.Location = new Point(rectWithPadding.X, labelEndereco.Location.Y + labelEndereco.Height + 5);
         txtBoxCidade.Size = new Size((rectWithPadding.Width / 2) - 5, 50);

         txtBoxBairro.Location = new Point(txtBoxCidade.Location.X + txtBoxCidade.Width + 5, labelEndereco.Location.Y + labelEndereco.Height + 5);
         txtBoxBairro.Size = new Size((rectWithPadding.Width / 2) - 5, 50);

         txtBoxRua.Location = new Point(rectWithPadding.X, txtBoxCidade.Location.Y + txtBoxCidade.Height + 5);
         txtBoxRua.Size = new Size((int)(rectWithPadding.Width * 0.8) - 5, 50);

         txtBoxNumero.Location = new Point(txtBoxRua.Location.X + txtBoxRua.Width + 5, txtBoxCidade.Location.Y + txtBoxCidade.Height + 5);
         txtBoxNumero.Size = new Size((int)(rectWithPadding.Width * 0.2) - 5, 50);

         txtBoxUf.Location = new Point(rectWithPadding.X, txtBoxRua.Location.Y + txtBoxRua.Height + 5);
         txtBoxUf.Size = new Size((int)(rectWithPadding.Width * 0.2) - 5, 50);

         txtBoxCep.Location = new Point(txtBoxUf.Location.X + txtBoxUf.Width + 5, txtBoxRua.Location.Y + txtBoxRua.Height + 5);
         txtBoxCep.Size = new Size((int)(rectWithPadding.Width * 0.8) - 5, 50);

         btnFile.Size = new Size(270, 50);
         btnFile.Location = new Point((rectWithPadding.Width / 4) - (btnFile.Width / 2), txtBoxUf.Location.Y + txtBoxUf.Height + 15);

         btnSalvar.Size = new Size(270, 50);
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
