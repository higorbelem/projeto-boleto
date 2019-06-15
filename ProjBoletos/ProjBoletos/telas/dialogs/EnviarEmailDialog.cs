using iTextSharp.text;
using iTextSharp.text.pdf;
using ProjBoletos.components.ParteCimaBoleto;
using ProjBoletos.modelos;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class EnviarEmailDialog : Form {

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      private Cedente cedente;
      private Remessa remessa;

      public EnviarEmailDialog(Cedente cedente, Remessa remessa) {
         InitializeComponent();

         this.cedente = cedente;
         this.remessa = remessa;

         txtBoxSenha.hint = "Senha";
         txtBoxSenha.isPassword = true;

         btnEnviar.title = "ENVIAR";
      }

      private void EnviarEmailDialog_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         panelTopBar.BackColor = Colors.bgDark2;
         panelTopBar.Location = new Point(ClientRectangle.X, ClientRectangle.Y);
         panelTopBar.Size = new Size(ClientRectangle.Width, 60);
         panelTopBar.Margin = new Padding(0);

         backButtonImg.Location = new Point(panelTopBar.Location.X + 20, panelTopBar.Location.Y + 20);
         backButtonImg.Size = new Size(panelTopBar.Height - 40, panelTopBar.Height - 40);

         labelTitle.Text = "ENVIAR BOLETOS POR EMAIL";
         labelTitle.Location = new Point(panelTopBar.Location.X, panelTopBar.Location.Y);
         labelTitle.Size = new Size(panelTopBar.Width, panelTopBar.Height);
         labelTitle.TextAlign = ContentAlignment.MiddleCenter;
         labelTitle.Font = Fonts.mainBold14;
         labelTitle.ForeColor = Colors.bg;
         labelTitle.Margin = new Padding(0);

         label1.TextAlign = ContentAlignment.MiddleCenter;
         label1.Font = Fonts.mainBold12;
         label1.ForeColor = Colors.primaryText;
         label1.Text = "Insira a senha do email para enviar";

         txtBoxEmail.BackColor = Colors.bg3;
         txtBoxEmail.txtBox.ReadOnly = true;
         txtBoxEmail.txtBox.Text = cedente.email;

         txtBoxSenha.BackColor = Colors.bg3;
      }

      private void EnviarEmailDialog_Resize(object sender, EventArgs e) {

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

      private void btnEnviar_Click(object sender, EventArgs e) {
         if (!txtBoxSenha.isEmpty) {
            MailAddress from = new MailAddress(cedente.email, cedente.nome);
            //smtp.gmail.com     smtp.office365.com    smtp.live.com   smtp-mail.outlook.com
            SmtpClient mailClient = new SmtpClient("smtp-mail.outlook.com");
            mailClient.Port = 587;
            mailClient.UseDefaultCredentials = false;
            mailClient.EnableSsl = true;
            mailClient.Credentials = new System.Net.NetworkCredential(cedente.email, txtBoxSenha.txtBox.Text);
            

            //cc.Add(new MailAddress("Someone@domain.topleveldomain", "Name and stuff")); 
            SendEmail(mailClient, from, remessa);
         } else {
            MessageBox.Show("Campo de senha vazio");
         }
      }

      protected void SendEmail(SmtpClient mailClient, MailAddress _from, Remessa remessa) {

         foreach (Medicao medicao in remessa.medicoes) {
            //SmtpClient mailClient = new SmtpClient(mailHost);
            MailMessage msgMail;
            msgMail = new MailMessage();
            msgMail.From = _from;
            msgMail.To.Add(medicao.sacado.email);
            msgMail.Subject = "asdas";
            msgMail.Body = "asdadasd";
            msgMail.IsBodyHtml = true;
            msgMail.Attachments.Add(new Attachment(criarPdf(medicao)));

            mailClient.SendCompleted += new SendCompletedEventHandler((object sender, AsyncCompletedEventArgs args) => {
               
            });

            //mailClient.Send(msgMail);
            try {
               mailClient.Send(msgMail);

            }catch (SmtpException ex) {
               Console.WriteLine("{0}", ex.StatusCode);
               if (ex.StatusCode == SmtpStatusCode.MustIssueStartTlsFirst) {
                  MessageBox.Show("Senha e/ou email incorretos" + cedente.email + "  " + txtBoxSenha.txtBox.Text, "Falha ao mandar email");
               }else if (ex.StatusCode == SmtpStatusCode.GeneralFailure) {
                  MessageBox.Show("Verifique sua internet","Falha ao mandar email");
               } else {
                  MessageBox.Show(ex.Message, "Falha ao mandar email");
               }
               msgMail.Dispose();
               return;
            } catch (Exception ex) {
               Console.WriteLine("{0} / {1}", ex.HResult, SmtpStatusCode.ClientNotPermitted);
               //Console.WriteLine("Exception caught in RetryIfBusy(): {0}",ex.ToString());
               msgMail.Dispose();
               return;
            }

            msgMail.Dispose();
         }

         this.Close();
         this.DialogResult = DialogResult.OK;
      }

      public string criarPdf(Medicao medicao) {
         int p = 10;

         FullBoletoLayout fullBoletoLayout = new FullBoletoLayout(cedente, medicao);
         //fullBoletoLayout.AutoSize = true;
         //fullBoletoLayout.Location = new Point(p,p);
         fullBoletoLayout.Size = new Size(900, (int)(900 * Math.Sqrt(2)));
         //fullBoletoLayout.setSizes();

         Bitmap b = new Bitmap(fullBoletoLayout.Width, fullBoletoLayout.Height);
         fullBoletoLayout.DrawToBitmap(b, new System.Drawing.Rectangle(0, 0, b.Width, b.Height));

         //string outputFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Sample.pdf");

         string outputFile = "";

         try {
            // If the directory doesn't exist, create it.
            if (!Directory.Exists("boletos")) {
               Directory.CreateDirectory("boletos");
            }

            string nomeArquivo = "boleto" + medicao.id + ".pdf";

            if (File.Exists("boletos\\" + nomeArquivo)) {
               File.Delete("boletos\\" + nomeArquivo);
            }

            File.Create("boletos\\" + nomeArquivo).Close();

            outputFile = Path.GetDirectoryName(Application.ExecutablePath) + "\\boletos\\" + nomeArquivo;

         } catch (Exception e) {
            MessageBox.Show(e.ToString(), "Erro ao criar o arquivo");
            return null;
         }

         using (FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)) {
            //Create a new PDF document setting the size to A4
            using (Document doc = new Document(new iTextSharp.text.Rectangle(900 + p * 2, (int)(900 * Math.Sqrt(2)) + p * 2), p, p, p, p)) {
               //Bind the PDF document to the FileStream using an iTextSharp PdfWriter
               using (PdfWriter w = PdfWriter.GetInstance(doc, fs)) {
                  doc.Open();

                  //doc.SetMargins(40, 40, 40, 80);

                  doc.Add(iTextSharp.text.Image.GetInstance(System.Drawing.Image.FromHbitmap(b.GetHbitmap()), BaseColor.WHITE));

                  doc.Close();
               }
            }
         }

         return outputFile;
      }

   }
}
