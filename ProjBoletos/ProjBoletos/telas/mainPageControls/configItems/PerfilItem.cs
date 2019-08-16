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
      public PerfilItem() {
         InitializeComponent();

         txtBoxNome.hint = "Nome";
         txtBoxCnpj.hint = "Cnpj";
         txtBoxCnpj.mask = "00,000,000/0000-00";
         txtBoxContato.hint = "Contato";
         txtBoxContato.mask = "(00) 00000-0000";
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
      }

      private void PerfilItem_Load(object sender, EventArgs e) {
         //PerfilItem_Resize(sender,e);

         labelEndereco.Text = "Endereço";
         labelEndereco.Font = Fonts.mainBold12;
         labelEndereco.ForeColor = Colors.primaryText;

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
      }

      private void panel1_Paint(object sender, PaintEventArgs e) {

      }

      public void resize() {
         PerfilItem_Resize(null, null);
      }

      public bool uploadImage(string imagePath) {
         try {
            var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
            Cedente cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);

            if (cedente == null) {
               Application.Exit();
            }

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
            }
         }

      }
   }
}
