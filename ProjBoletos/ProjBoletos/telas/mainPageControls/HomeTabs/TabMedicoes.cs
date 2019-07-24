using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.modelos;
using Newtonsoft.Json;
using RestSharp;
using ProjBoletos.utils;
using Newtonsoft.Json.Converters;
using ProjBoletos.telas.dialogs;
using ProjBoletos.components;

namespace ProjBoletos.telas.mainPageControls.HomeTabs {
   public partial class TabMedicoes : UserControl {

      int quantCards = 3;
      int spaceBetweenCards = 20;
      int cardHeight = 220;

      public Padding padding = new Padding(40, 20, 40, 40);

      public Panel panel;

      Cedente cedente;
      List<Medicao> medicoes;

      int totalMedicoesMes = 0;

      public TabMedicoes() {
         InitializeComponent();

         panel = panel1;
      }

      private void TabMedicoes_Load(object sender, EventArgs e) {
         panel1.BackColor = Colors.bg;
         BackColor = Colors.bg;

         var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
         cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);
         if (cedente == null) {
            Application.Exit();
         }

         //updateCustomViewList();

         customListView.update += () => {
            updateCustomViewList();
         };

         gerarTodasBtn.title = "GERAR TODAS";
         gerarTodasBtn.cornerRadius = 20;
      }

      public void updateCustomViewList() {
         Loading loading = new Loading();
         loading.task = new Task(new Action(() => {
            var result = buscarMedicoes(cedente.id);

            string medicoesSum = getMedicoesMes(cedente.id);

            if (medicoesSum != null) {
               int number;
               bool success = Int32.TryParse(medicoesSum, out number);
               if (success) {
                  totalMedicoesMes = number;
               } else {
                  //MessageBox.Show(medicoesSum);
               }
            }

            loading.terminou = true;
            loading.terminouBem = result;
         }));

         var res = loading.ShowDialog();

         atualizarCards(medicoes);

         labelMedicaoGeral.Text = totalMedicoesMes + " M³ DE ÁGUA MEDIDOS DESDE 01/" + DateTime.Now.Month.ToString("d2");
         customListView.vazioText = "Não há medições";
         List<CustomListViewItem> items = new List<CustomListViewItem>();

         CustomListViewItem customListViewItemCabecalho = new CustomListViewItem();
         customListViewItemCabecalho.isCabecalho = true;
         customListViewItemCabecalho.Size = new Size(ClientRectangle.Width, 50);
         customListViewItemCabecalho.addValor("DATA DA MEDIÇÂO", "1,5");
         customListViewItemCabecalho.addValor("ENDEREÇO", "3");
         customListViewItemCabecalho.addValor("CLIENTE", "3");
         customListViewItemCabecalho.addValor("MEDIÇÂO", "1,5");
         items.Add(customListViewItemCabecalho);

         foreach (Medicao medicao in medicoes) {
            CustomListViewItem customListViewItem = new CustomListViewItem();
            customListViewItem.Size = new Size(ClientRectangle.Width, 50);
            customListViewItem.addValor(medicao.dataMedicao.ToString(), "1,5");
            customListViewItem.addValor(medicao.casa.rua + ", " + medicao.casa.numero, "3");
            customListViewItem.addValor(medicao.sacado.nome, "3");
            customListViewItem.addValor(medicao.medicao, "1,5");
            customListViewItem.medicao = medicao;

            switch (medicao.nivelAtraso) {
               case 0:
                  customListViewItem.circleColor = Colors.noPrazo;
                  break;
               case 1:
                  customListViewItem.circleColor = Colors.pertoDeVencer;
                  break;
               case 2:
                  customListViewItem.circleColor = Colors.atrasado;
                  break;
            }

            customListViewItem.btnGerar.title = "GERAR";
            //customListViewItem.btnVer.title = "VER";
            customListViewItem.btnVer.img = new Bitmap(Properties.Resources.search_white);

            customListViewItem.btnGerar.Click += new EventHandler((object sender, EventArgs e) => {
               GerarBoletoDialog gerarBoletoDialog = new GerarBoletoDialog(cedente);
               var resultMessageBox = gerarBoletoDialog.ShowDialog();

               Parent.FindForm().Activate();

               if (resultMessageBox == DialogResult.OK) {
                  //Console.WriteLine(gerarBoletoDialog.contaSelecionadaIndex + " " + gerarBoletoDialog.carteiraSelecionada + " " + gerarBoletoDialog.convenioSelecionado);
                  var result = gerarBoletos(medicao.id, gerarBoletoDialog.contaSelecionadaIndex, gerarBoletoDialog.carteiraSelecionada);

                  if (result) {
                     customListView.update();
                  }
               }
            });

            customListViewItem.btnVer.Click += new EventHandler((object sender, EventArgs e) => {
               MedicaoForm medicaoForm = new MedicaoForm(medicao);
               medicaoForm.ShowDialog();
            });

            items.Add(customListViewItem);
         }
         customListView.UpdateList(items);

      }

      private void TabMedicoes_Resize(object sender, EventArgs e) {
         panel1.Location = new Point(0, 0);
         panel1.Size = new Size(ClientRectangle.Width, panel1.Height);
         panel1.MinimumSize = new Size(ClientRectangle.Width, 0);
         panel1.MaximumSize = new Size(ClientRectangle.Width, 0);

         Rectangle newSize = new Rectangle(padding.Left, padding.Top, panel1.Width - padding.Left - padding.Right, panel1.Height - padding.Top - padding.Bottom);

         int cardWidth = (newSize.Width - (spaceBetweenCards * (quantCards - 1))) / quantCards;

         mainCard1.Location = new Point(newSize.X, newSize.Y);
         mainCard1.Size = new Size(cardWidth, cardHeight);

         mainCard2.Location = new Point(newSize.X + cardWidth + spaceBetweenCards, newSize.Y);
         mainCard2.Size = new Size(cardWidth, cardHeight);

         mainCard3.Location = new Point(newSize.X + cardWidth * 2 + spaceBetweenCards * 2, newSize.Y);
         mainCard3.Size = new Size(cardWidth, cardHeight);

         labelMedicaoGeral.Size = new Size(newSize.Width, 30);
         labelMedicaoGeral.Location = new Point((newSize.Width / 2) - (labelMedicaoGeral.Width / 2), mainCard1.Location.Y + mainCard1.Height + 10);
         //labelMedicaoGeral.Text = "240 m³ de água medidos desde 01/" + DateTime.Now.Month.ToString("d2");
         labelMedicaoGeral.TextAlign = ContentAlignment.MiddleCenter;
         labelMedicaoGeral.Font = Fonts.mainBold12;
         labelMedicaoGeral.ForeColor = Colors.primaryText;

         gerarTodasBtn.Size = new Size(170, 40);
         gerarTodasBtn.Location = new Point((newSize.Width / 2) - (gerarTodasBtn.Width / 2), labelMedicaoGeral.Location.Y + labelMedicaoGeral.Height + 10);

         //medicoesFlowLayout.Controls.Add();
         customListView.Size = new Size(newSize.Width, 80); //0
         customListView.MinimumSize = new Size(newSize.Width, 0); //0
         customListView.MaximumSize = new Size(newSize.Width, 0); //0
         customListView.Location = new Point(newSize.X, gerarTodasBtn.Location.Y + gerarTodasBtn.Height + 20);
      }

      private void label3_Click(object sender, EventArgs e) {

      }

      private void gerarTodosBtn_Click(object sender, EventArgs e) {
         GerarBoletoDialog gerarBoletoDialog = new GerarBoletoDialog(cedente);
         var resultMessageBox = gerarBoletoDialog.ShowDialog();

         Parent.FindForm().Activate();

         if (resultMessageBox == DialogResult.OK) {

            //Console.WriteLine(gerarBoletoDialog.contaSelecionadaIndex + " " + gerarBoletoDialog.carteiraSelecionada);
            Loading loading = new Loading();
            loading.task = new Task(new Action(() => {
               var result = gerarMedicoes(cedente.id, gerarBoletoDialog.contaSelecionadaIndex, gerarBoletoDialog.carteiraSelecionada);

               loading.terminou = true;
               loading.terminouBem = result;
            }));

            var res = loading.ShowDialog();

            if (res == DialogResult.OK) {
               customListView.update();
            }
         }
         /*var resultMessageBox = MessageBox.Show("Gerar todos boletos?", "", MessageBoxButtons.YesNo);

         if (resultMessageBox == DialogResult.Yes)
         {
             var result = gerarMedicoes(cedente.id);

             if (result)
             {
                 customListView.update();
             }
         }*/
      }

      private void atualizarCards(List<Medicao> medicoes1) {
         int medicoesNoPrazo = 0;
         int mmedicoesNoPrazoHoje = 0;
         int medicoesPertoDeVencer = 0;
         int medicoesPertoDeVencerHoje = 0;
         int medicoesAtrasadas = 0;
         int medicoesAtrasadasHoje = 0;

         for (int i = 0; i < medicoes1.Count; i++) {
            if (medicoes1[i].boletoGerado.Equals("0")) {
               int diaVencimento = Int32.Parse(medicoes1[i].casa.diaVencimento);

               DateTime vencimento = medicoes1[i].dataMedicao;

               if (diaVencimento < medicoes1[i].dataMedicao.Day) {
                  //Console.WriteLine("mes antes" + vencimento.Month);
                  vencimento = new DateTime(vencimento.Year, vencimento.AddMonths(1).Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
                  //Console.WriteLine("mes dps" + vencimento.Month);
               } else {
                  vencimento = new DateTime(vencimento.Year, vencimento.Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
               }

               //medicoes atrasadas
               if (DateTime.Today.CompareTo(vencimento) > 0) {
                  medicoesAtrasadas++;
                  medicoes1[i].nivelAtraso = 2;
                  if (DateTime.Today.Year == medicoes1[i].dataMedicao.Year && DateTime.Today.Month == medicoes1[i].dataMedicao.Month && DateTime.Today.Day == medicoes1[i].dataMedicao.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                     medicoesAtrasadasHoje++;
                  }

                  continue;
               }

               //medicoes perto do vencimento
               if (DateTime.Today.CompareTo(vencimento.AddDays(-5)) >= 0) {
                  medicoesPertoDeVencer++;
                  medicoes1[i].nivelAtraso = 1;
                  if (DateTime.Today.Year == medicoes1[i].dataMedicao.Year && DateTime.Today.Month == medicoes1[i].dataMedicao.Month && DateTime.Today.Day == medicoes1[i].dataMedicao.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                     medicoesPertoDeVencerHoje++;
                  }

                  continue;
               }

               //medicoes no prazo
               medicoesNoPrazo++;
               medicoes1[i].nivelAtraso = 0;
               if (DateTime.Today.Year == medicoes1[i].dataMedicao.Year && DateTime.Today.Month == medicoes1[i].dataMedicao.Month && DateTime.Today.Day == medicoes1[i].dataMedicao.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                  mmedicoesNoPrazoHoje++;
               }
            }
         }

         mainCard1.title = "MEDIÇÕES NO PRAZO";
         mainCard1.numString = medicoesNoPrazo + "";
         mainCard1.notifString = mmedicoesNoPrazoHoje + "";
         mainCard1.ascentColor = Colors.noPrazo;

         mainCard2.title = "MEDICÕES PERTO DE VENCER";
         mainCard2.numString = medicoesPertoDeVencer + "";
         mainCard2.notifString = medicoesPertoDeVencerHoje + "";
         mainCard2.ascentColor = Colors.pertoDeVencer;

         mainCard3.title = "MEDICÕES ATRASADAS";
         mainCard3.numString = medicoesAtrasadas + "";
         mainCard3.notifString = medicoesAtrasadasHoje + "";
         mainCard3.ascentColor = Colors.atrasado;
      }

      private bool buscarMedicoes(string idCedente) {

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getDadosMedicoes.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("cedente-id", idCedente);
         request.AddParameter("is-boleto", 0);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (content.Split(';')[0].Trim().Equals("ok")) {
               medicoes = JsonConvert.DeserializeObject<List<Medicao>>(content.Trim().Remove(0, 3));

               return true;
            } else {
               //MessageBox.Show(content);
               medicoes = new List<Medicao>();

               return false;
            }
         }

         Properties.Settings.Default["cedenteAtual"] = "";
         Properties.Settings.Default["logado"] = false;
         Properties.Settings.Default.Save();

         this.Hide();
         Login login = new Login();
         //login.Closed += (s, args) => this.Close();
         login.Show();

         return false;
      }

      private string getMedicoesMes(string idCedente) {

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getTotalMedicoesMes.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("cedente-id", idCedente);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (content.Split(';')[0].Trim().Equals("ok")) {
               return content.Trim().Remove(0, 3);
            } else {
               return null;
            }
         }

         return null;
      }

      private bool gerarMedicoes(string idCedente, string contaIndex, string carteira) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/gerarTodosBoletos.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("cedente-id", idCedente);
         request.AddParameter("carteira", carteira);
         request.AddParameter("conta_index", contaIndex);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            
            if (content.Trim().Equals("ok")) {

               return true;
            } else {

               return false;
            }
         }

         return false;
      }

      private bool gerarBoletos(string idMedicao, string contaIndex, string carteira) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/gerarBoletos.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("medicao-id", idMedicao);
         request.AddParameter("carteira", carteira);
         request.AddParameter("conta_index", contaIndex);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            if (content.Trim().Equals("ok")) {
               return true;
            } else {
               return false;
            }
         }

         return false;
      }

      public void nada() {

      }
   }
}
