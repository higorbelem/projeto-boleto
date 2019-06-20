using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using ProjBoletos.utils;

namespace ProjBoletos.components {
   public partial class AdicionarEditarClienteCasaItem : UserControl {

      private System.Timers.Timer timer;

      private bool aberto = false;

      public int heightFechado = 50;
      public int heightAberto = 380;

      public bool isItemToEdit = false;
      public string id = null;
      string vencimento = null;
      string bairro = null;
      string cep = null;
      string cidade = null;
      string numHidrometro = null;
      string numero = null;
      string referencia = null;
      string rua = null;
      string uf = null;

      public AdicionarEditarClienteCasaItem() {
         InitializeComponent();

         txtBoxVencimento.hint = "VENCIMENTO";
         txtBoxBairro.hint = "BAIRRO";
         txtBoxCep.hint = "CEP";
         txtBoxCidade.hint = "CIDADE";
         txtBoxHidrometro.hint = "NÚMERO DO HIDRÔMETRO";
         txtBoxNumero.hint = "NÚMERO";
         txtBoxReferencia.hint = "REFERÊNCIA";
         txtBoxRua.hint = "RUA";
         txtBoxUf.hint = "UF";

         btnBuscarCep.title = "BUSCAR";

         btnDeletar.title = "DELETAR";

         labelFechado.Text = "ALGUM CAMPO VAZIO";
      }

      public AdicionarEditarClienteCasaItem(string id, string vencimento, string bairro, string cep, string cidade, string numHidrometro, string numero, string referencia, string rua, string uf) {
         InitializeComponent();

         isItemToEdit = true;

         txtBoxVencimento.useHint = false;
         txtBoxBairro.useHint = false;
         txtBoxCep.useHint = false;
         txtBoxCidade.useHint = false;
         txtBoxHidrometro.useHint = false;
         txtBoxNumero.useHint = false;
         txtBoxReferencia.useHint = false;
         txtBoxRua.useHint = false;
         txtBoxUf.useHint = false;

         this.id = id;
         this.vencimento = vencimento;
         this.bairro = bairro;
         this.cep = cep;
         this.cidade = cidade;
         this.numHidrometro = numHidrometro;
         this.numero = numero;
         this.referencia = referencia;
         this.rua = rua;
         this.uf = uf;

         txtBoxVencimento.hint = "VENCIMENTO";
         txtBoxBairro.hint = "BAIRRO";
         txtBoxCep.hint = "CEP";
         txtBoxCidade.hint = "CIDADE";
         txtBoxHidrometro.hint = "NÚMERO DO HIDRÔMETRO";
         txtBoxNumero.hint = "NÚMERO";
         txtBoxReferencia.hint = "REFERÊNCIA";
         txtBoxRua.hint = "RUA";
         txtBoxUf.hint = "UF";

         btnBuscarCep.title = "BUSCAR";

         btnDeletar.title = "DELETAR";

         labelFechado.Text = rua + ", " + numero + " " + bairro;
      }

      private void AdicionarEditarClienteCasaItem_Load(object sender, EventArgs e) {
         BackColor = Colors.bg3;

         txtBoxVencimento.BackColor = Colors.bg3;
         txtBoxBairro.BackColor = Colors.bg3;
         txtBoxCep.BackColor = Colors.bg3;
         txtBoxCidade.BackColor = Colors.bg3;
         txtBoxHidrometro.BackColor = Colors.bg3;
         txtBoxNumero.BackColor = Colors.bg3;
         txtBoxReferencia.BackColor = Colors.bg3;
         txtBoxRua.BackColor = Colors.bg3;
         txtBoxUf.BackColor = Colors.bg3;

         if (isItemToEdit) {
            txtBoxVencimento.txtBox.Text = vencimento;
            txtBoxBairro.txtBox.Text = bairro;
            txtBoxCep.txtBox.Text = cep;
            txtBoxCidade.txtBox.Text = cidade;
            txtBoxHidrometro.txtBox.Text = numHidrometro;
            txtBoxNumero.txtBox.Text = numero;
            txtBoxReferencia.txtBox.Text = referencia;
            txtBoxRua.txtBox.Text = rua;
            txtBoxUf.txtBox.Text = uf;
         }

         labelFechado.Font = Fonts.mainBold12;
         labelFechado.ForeColor = Colors.primaryText;

         btnDeletar.setColor(Colors.accent2);

         timer = new System.Timers.Timer(8); //~60 FPS
         timer.AutoReset = true;
         timer.SynchronizingObject = this;
         timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
      }

      private void timer_Elapsed(object sender, ElapsedEventArgs e) {
         if (aberto) {
            if (Height > heightFechado) {
               Height -= 20;
            } else {
               timer.Stop();
               Height = heightFechado;
               aberto = false;
               //labelFechado.Visible = true;
               labelFechado.Text = txtBoxRua.txtBox.Text + ", " + txtBoxNumero.txtBox.Text + " " + txtBoxBairro.txtBox.Text;
            }
         } else {
            if (Height < heightAberto) {
               Height += 20;
            } else {
               timer.Stop();
               Height = heightAberto;
               aberto = true;
            }
         }
      }

      public void abrir() {
         aberto = true;
         Invalidate();
      }

      public void fechar() {
         aberto = false;
         Invalidate();
      }

      private void imgBtnOpen_Click(object sender, EventArgs e) {
         timer.Start();

         if (!aberto) {
            //labelFechado.Visible = false;
            labelFechado.Text = "EDITAR CASA";
            imgBtnOpenClose.Image = new Bitmap(Properties.Resources.arrow_up);
         } else {
            imgBtnOpenClose.Image = new Bitmap(Properties.Resources.arrow_down);

            if (hasEmptyFields()) {
               labelFechado.Text = "ALGUM CAMPO VAZIO";
            } else {
               labelFechado.Text = txtBoxRua.txtBox.Text + ", " + txtBoxNumero.txtBox.Text + " " + txtBoxBairro.txtBox.Text;
            }
         }
      }

      public bool hasEmptyFields() {
         if (txtBoxBairro.isEmpty) {
            return true;
         }
         if (txtBoxCep.isEmpty) {
            return true;
         }
         if (txtBoxCidade.isEmpty) {
            return true;
         }
         if (txtBoxHidrometro.isEmpty) {
            return true;
         }
         if (txtBoxNumero.isEmpty) {
            return true;
         }
         if (txtBoxReferencia.isEmpty) {
            return true;
         }
         if (txtBoxRua.isEmpty) {
            return true;
         }
         if (txtBoxUf.isEmpty) {
            return true;
         }
         if (txtBoxVencimento.isEmpty) {
            return true;
         }

         return false;
      }

      private void AdicionarEditarClienteCasaItem_Resize(object sender, EventArgs e) {
         int imgPadding = 5;
         imgBtnOpenClose.Size = new Size(heightFechado - imgPadding * 2, heightFechado - imgPadding * 2);
         imgBtnOpenClose.Location = new Point(ClientRectangle.Width - imgBtnOpenClose.Width, imgPadding);

         labelFechado.Location = new Point(10, 0);
         labelFechado.Size = new Size(ClientRectangle.Width - imgBtnOpenClose.Width - 10, heightFechado);
         labelFechado.TextAlign = ContentAlignment.MiddleLeft;

         int padding = 5;
         int txtBoxHeight = 40;

         txtBoxCep.Location = new Point(padding, labelFechado.Location.Y + labelFechado.Height + padding);
         txtBoxCep.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.8), txtBoxHeight);

         btnBuscarCep.Location = new Point(txtBoxCep.Location.X + txtBoxCep.Width, txtBoxCep.Location.Y);
         btnBuscarCep.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.2), txtBoxHeight);

         txtBoxRua.Location = new Point(padding, txtBoxCep.Location.Y + txtBoxCep.Height + padding);
         txtBoxRua.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.7), txtBoxHeight);

         txtBoxNumero.Location = new Point(txtBoxRua.Location.X + txtBoxRua.Width, txtBoxRua.Location.Y);
         txtBoxNumero.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.3), txtBoxHeight);

         txtBoxBairro.Location = new Point(padding, txtBoxRua.Location.Y + txtBoxRua.Height + padding);
         txtBoxBairro.Size = new Size(ClientRectangle.Width - padding * 2, txtBoxHeight);

         txtBoxCidade.Location = new Point(padding, txtBoxBairro.Location.Y + txtBoxBairro.Height + padding);
         txtBoxCidade.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.7), txtBoxHeight);

         txtBoxUf.Location = new Point(txtBoxCidade.Location.X + txtBoxCidade.Width, txtBoxCidade.Location.Y);
         txtBoxUf.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.3), txtBoxHeight);

         txtBoxReferencia.Location = new Point(padding, txtBoxCidade.Location.Y + txtBoxCidade.Height + padding);
         txtBoxReferencia.Size = new Size(ClientRectangle.Width - padding * 2, txtBoxHeight);

         txtBoxHidrometro.Location = new Point(padding, txtBoxReferencia.Location.Y + txtBoxReferencia.Height + padding);
         txtBoxHidrometro.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.7), txtBoxHeight);

         txtBoxVencimento.Location = new Point(txtBoxHidrometro.Location.X + txtBoxHidrometro.Width, txtBoxHidrometro.Location.Y);
         txtBoxVencimento.Size = new Size((int)((ClientRectangle.Width - padding * 2) * 0.3), txtBoxHeight);

         btnDeletar.Size = new Size(200, txtBoxHeight);
         btnDeletar.Location = new Point(ClientRectangle.Width / 2 - btnDeletar.Width / 2, txtBoxHidrometro.Location.Y + txtBoxHidrometro.Height + padding + 10);

      }
   }
}
