using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.testes;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs {
   public partial class GerarBoletoDialog : Form {

      public Cedente cedente;

      private List<Carteira> carteirasItau = new List<Carteira>(){
            new Carteira("102","Sem Registro Com Emissão Integral - Carnê"),
            new Carteira("103","Sem Registro Com Emissão/Entrega - Carnê"),
            new Carteira("104","Escritural Eletrônica - Carnê"),
            new Carteira("105","Escritural Eletrônica - Dólar - Carnê"),
            new Carteira("106","S/Registro C/Emissão/Entrega-15 dígitos-Carnê"),
            new Carteira("107","S/Registro C/Emissão Integral-15 Posições-Carnê"),
            new Carteira("108","Direta Eletrônica Emissão Integral - Carnê"),
            new Carteira("109","Direta Eletrônica Sem Emissão - Simples"),
            new Carteira("110","Direta Eletrônica Sem Emissão - Simples"),
            new Carteira("111","Direta Eletrônica Sem Emissão - Simples"),
            new Carteira("112","Escritural Eletrônica - simples / contratual"),
            new Carteira("113","Escritural Eletrônica - TR - Carnê"),
            new Carteira("114","Escritural Eletrônica - Seguros"),
            new Carteira("115","Carteira 115"),
            new Carteira("120","S/Registro Emissão Integral C/IOF 2% - Carnê"),
            new Carteira("121"," Direta Eletrônica Emissão Parcial - Simples/Contra"),
            new Carteira("122","S/Registro S/Emissão 15 Dígitos C/IOF 2%"),
            new Carteira("126","Direta Eletrônica Sem Emissão - Seguros"),
            new Carteira("129","S/Registro Emissão Parcial Seguros C/IOF 2%"),
            new Carteira("131","Direta Eletrônica c/ Valor em Aberto"),
            new Carteira("139","S/Registro Emissão Parcial Seguros C/IOF 4%"),
            new Carteira("140","S/Registro Emissão Integral C/IOF 4% - Carnê"),
            new Carteira("141","S/Registro Emissão Integral C/IOF 7% - Carnê"),
            new Carteira("142","S/Registro S/Emissão 15 DÍGITOS C/IOF 4%"),
            new Carteira("143","S/Registro S/Emissão 15 DÍGITOS C/IOF 7%"),
            new Carteira("146","Descrição Não Disponível"),
            new Carteira("147","Escritural Eletrônica - Dólar"),
            new Carteira("150","Direta Eletrônica Sem Emissão - Dólar"),
            new Carteira("166","Escritural Eletrônica - TR"),
            new Carteira("168","Direta Eletrônica Sem Emissão - TR"),
            new Carteira("169","S/Registro Emissão Parcial Seguros C/IOF 7%"),
            new Carteira("172","Sem Registro Com Emissão Integra"),
            new Carteira("173"," Sem Registro Com Emissão/Entrega"),
            new Carteira("174","Sem Registro Emissão Parcial Com Protesto Borderô"),
            new Carteira("175","Sem Registro Sem Emissão"),
        };
      private List<Carteira> carteirasBradesco = new List<Carteira>() {
            new Carteira("02","Carteira 02"),
            new Carteira("03","Carteira 03"),
            new Carteira("04","Pré-Impressos"),
            new Carteira("05","Recebimento Programado Bradesco - RPB"),
            new Carteira("06","Sem Registro"),
            new Carteira("07","Carteira 07"),
            new Carteira("09","Com Registro"),
            new Carteira("12","Carteira 12"),
            new Carteira("16","Sem Registro com Protesto"),
            new Carteira("17","Carteira 17"),
            new Carteira("19","Com Registro"),
            new Carteira("22","Sem Registro - Pagável somente no Bradescos")
        };
      private List<Carteira> carteirasBB = new List<Carteira>() {
            //new Carteira("11","Cobrança Simples"),
            //new Carteira("12","Cobrança Indexada"),
            //new Carteira("15","Cobrança Prêmios Seguro"),
            new Carteira("16","Cobranca Simples"),
            //new Carteira("17","Cobranca Direta Especial"),
            new Carteira("18","Cobranca Simples"),
            //new Carteira("31","Cobrança Cauc./Vinc."),
            //new Carteira("51","Cobrança Descontada")
        };

      public string carteiraSelecionada = "";
      public string contaSelecionadaIndex = "";

      public const int WM_NCLBUTTONDOWN = 0xA1;
      public const int HT_CAPTION = 0x2;

      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
      [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
      public static extern bool ReleaseCapture();

      public GerarBoletoDialog(Cedente cedente) {
         InitializeComponent();

         this.cedente = cedente;
      }

      private void GerarBoletoDialog_Load(object sender, EventArgs e) {

         BackColor = Colors.bg3;

         panelTopBar.BackColor = Colors.bgDark2;
         panelTopBar.Location = new Point(ClientRectangle.X, ClientRectangle.Y);
         panelTopBar.Size = new Size(ClientRectangle.Width, 60);
         panelTopBar.Margin = new Padding(0);

         backButtonImg.Location = new Point(panelTopBar.Location.X + 20, panelTopBar.Location.Y + 20);
         backButtonImg.Size = new Size(panelTopBar.Height - 40, panelTopBar.Height - 40);

         labelTitle.Text = "GERAR BOLETO";
         labelTitle.Location = new Point(panelTopBar.Location.X, panelTopBar.Location.Y);
         labelTitle.Size = new Size(panelTopBar.Width, panelTopBar.Height);
         labelTitle.TextAlign = ContentAlignment.MiddleCenter;
         labelTitle.Font = Fonts.mainBold14;
         labelTitle.ForeColor = Colors.bg;
         
         btnOk.title = "OK";
         btnOk.cornerRadius = 5;

         comboBoxContas.Items.Add("--Escolha uma conta--");
         comboBoxContas.SelectedIndex = 0;
         comboBoxCarteiras.Items.Add("--Escolha uma carteira--");
         comboBoxCarteiras.SelectedIndex = 0;

         foreach (Conta conta in cedente.contas) {
            comboBoxContas.Items.Add(conta.banco + " " + conta.agencia + " " + conta.conta);
         }

         comboBoxContas.SelectionChangeCommitted += new EventHandler((object sender1, EventArgs e1) => {
            if (comboBoxContas.SelectedIndex > 0) {

               comboBoxCarteiras.Items.Clear();
               comboBoxCarteiras.Items.Add("--Escolha uma carteira--");
               comboBoxCarteiras.SelectedIndex = 0;

               if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("001")) {
                  foreach (Carteira carteira in carteirasBB) {
                     comboBoxCarteiras.Items.Add(carteira.carteira + " - " + carteira.descricao);
                  }
               } else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("237")) {
                  foreach (Carteira carteira in carteirasBradesco) {
                     comboBoxCarteiras.Items.Add(carteira.carteira + " - " + carteira.descricao);
                  }
               } else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("341")) {
                  foreach (Carteira carteira in carteirasItau) {
                     comboBoxCarteiras.Items.Add(carteira.carteira + " - " + carteira.descricao);
                  }
               }
            }
         });

         //comboBox1.SelectedIndex
      }
      private void btnOk_Click(object sender, EventArgs e) {
         if (comboBoxContas.SelectedIndex == 0 || comboBoxCarteiras.SelectedIndex == 0) {
            MessageBox.Show("Alguma opção ficou vazia", "Atenção", MessageBoxButtons.OK);
         } else {

            if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("001")) {

               carteiraSelecionada = carteirasBB[comboBoxCarteiras.SelectedIndex - 1].carteira;

            } else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("237")) {

               carteiraSelecionada = carteirasBradesco[comboBoxCarteiras.SelectedIndex - 1].carteira;

            } else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("341")) {

               carteiraSelecionada = carteirasItau[comboBoxCarteiras.SelectedIndex - 1].carteira;

            } else {
               this.DialogResult = DialogResult.Cancel;
               this.Close();
            }

            contaSelecionadaIndex = cedente.contas[comboBoxContas.SelectedIndex - 1].id;

            this.DialogResult = DialogResult.OK;
            this.Close();
         }
      }

      private void btnFechar_Click(object sender, EventArgs e) {
         this.DialogResult = DialogResult.Cancel;
         this.Close();
      }

      /*protected override void OnPaintBackground(PaintEventArgs e) {
         e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

         GraphicsPath path = RoundedRectangles.Create(new Rectangle(1, 1, ClientRectangle.Width - 2, ClientRectangle.Height - 2), 5,true,true, true, true);

         e.Graphics.FillPath(new SolidBrush(Colors.bg3), path);
      }*/

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

      private void labelTitle_MouseDown(object sender, MouseEventArgs e) {
         if (e.Button == MouseButtons.Left) {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
         }
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
