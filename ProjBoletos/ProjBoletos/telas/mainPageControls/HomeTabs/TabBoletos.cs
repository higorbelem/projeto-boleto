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
using ProjBoletos.modelos;
using Newtonsoft.Json;
using RestSharp;
using ProjBoletos.telas.dialogs;
using ProjBoletos.components;

namespace ProjBoletos.telas.mainPageControls.HomeTabs {

   public partial class TabBoletos : UserControl {

      int quantCards = 3;
      int spaceBetweenCards = 20;
      int cardHeight = 220;

      Padding padding = new Padding(40, 20, 40, 40);

      public Panel panel;

      Cedente cedente;
      List<Medicao> medicoes;

      public TabBoletos() {
         InitializeComponent();

         panel = panel1;
      }

      private void TabBoletos_Load(object sender, EventArgs e) {
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

         btnGerarRemessa.title = "GERAR REMESSA";
         btnGerarRemessa.cornerRadius = 20;
      }

      public void updateCustomViewList() {
         Loading loading = new Loading();
         loading.task = new Task(new Action(() => {
            bool result = buscarMedicoes(cedente.id);

            loading.terminou = true;
            loading.terminouBem = result;
         }));

         var res = loading.ShowDialog();

         atualizarCards(medicoes);

         customListView.vazioText = "Não há boletos";
         List<CustomListViewItem> items = new List<CustomListViewItem>();

         CustomListViewItem customListViewItemCabecalho = new CustomListViewItem();
         customListViewItemCabecalho.isCabecalho = true;
         customListViewItemCabecalho.Size = new Size(ClientRectangle.Width, 50);
         customListViewItemCabecalho.addValor("DATA", "2");
         customListViewItemCabecalho.addValor("ENDEREÇO", "3");
         customListViewItemCabecalho.addValor("CLIENTE", "3");
         items.Add(customListViewItemCabecalho);

         foreach (Medicao medicao in medicoes) {
            CustomListViewItem customListViewItem = new CustomListViewItem();
            customListViewItem.Size = new Size(ClientRectangle.Width, 50);
            customListViewItem.addValor(medicao.dataBoletoGerado.ToString(), "2");
            customListViewItem.addValor(medicao.casa.rua + ", " + medicao.casa.numero, "3");
            customListViewItem.addValor(medicao.sacado.nome, "3");
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
            customListViewItem.btnGerar.Size = new Size(0, 0);
            customListViewItem.btnGerar.Visible = false;

            customListViewItem.btnVer.title = "VER";

            customListViewItem.btnGerar.Click += new EventHandler((object sender, EventArgs e) => {
               GerarBoletoDialog gerarBoletoDialog = new GerarBoletoDialog(cedente);
               var resultMessageBox = gerarBoletoDialog.ShowDialog();

               Parent.FindForm().Activate();

               if (resultMessageBox == DialogResult.OK) {
                  //Console.WriteLine(gerarBoletoDialog.contaSelecionadaIndex + " " + gerarBoletoDialog.carteiraSelecionada + " " + gerarBoletoDialog.convenioSelecionado);
                  Loading loading1 = new Loading();
                  loading.task = new Task(new Action(() => {
                     var result = gerarBoletos(medicao.id, gerarBoletoDialog.contaSelecionadaIndex, gerarBoletoDialog.carteiraSelecionada);

                     loading.terminou = true;
                     loading.terminouBem = result;
                  }));

                  var res1 = loading1.ShowDialog();
                  
                  if (res1 == DialogResult.OK) {
                     customListView.update();
                  }
               }
            });

            customListViewItem.btnVer.Click += new EventHandler((object sender, EventArgs e) => {
               BoletoForm boletoForm = new BoletoForm(medicao);
               boletoForm.ShowDialog();
            });

            items.Add(customListViewItem);
         }
         customListView.UpdateList(items);
      }

      private void TabBoletos_Resize(object sender, EventArgs e) {
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

         btnGerarRemessa.Size = new Size(170, 40);
         btnGerarRemessa.Location = new Point((newSize.Width / 2) - (btnGerarRemessa.Width / 2), mainCard1.Location.Y + mainCard1.Height + 20);

         customListView.Size = new Size(newSize.Width, 80); //0
         customListView.MinimumSize = new Size(newSize.Width, 0); //0
         customListView.MaximumSize = new Size(newSize.Width, 0); //0
         customListView.Location = new Point(newSize.X, btnGerarRemessa.Location.Y + btnGerarRemessa.Height + 20);
      }

      private void atualizarCards(List<Medicao> medicoes1) {
         int medicoesNoPrazo = 0;
         int mmedicoesNoPrazoHoje = 0;
         int medicoesPertoDeVencer = 0;
         int medicoesPertoDeVencerHoje = 0;
         int medicoesAtrasadas = 0;
         int medicoesAtrasadasHoje = 0;

         for (int i = 0; i < medicoes1.Count; i++) {
            if (medicoes1[i].boletoGerado.Equals("1")) {
               int diaVencimento = Int32.Parse(medicoes1[i].casa.diaVencimento);

               DateTime vencimento = medicoes1[i].dataMedicao;

               if (diaVencimento < medicoes1[i].dataMedicao.Day) {
                  vencimento = new DateTime(vencimento.Year, vencimento.AddMonths(1).Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
               } else {
                  vencimento = new DateTime(vencimento.Year, vencimento.Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
               }

               //medicoes atrasadas
               if (DateTime.Today.CompareTo(vencimento) > 0) {
                  medicoesAtrasadas++;
                  medicoes1[i].nivelAtraso = 2;
                  if (DateTime.Today.Year == medicoes1[i].dataBoletoGerado.Year && DateTime.Today.Month == medicoes1[i].dataBoletoGerado.Month && DateTime.Today.Day == medicoes1[i].dataBoletoGerado.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                     medicoesAtrasadasHoje++;
                  }

                  continue;
               }

               //medicoes perto do vencimento
               if (DateTime.Today.CompareTo(vencimento.AddDays(-5)) >= 0) {
                  medicoesPertoDeVencer++;
                  medicoes1[i].nivelAtraso = 1;
                  if (DateTime.Today.Year == medicoes1[i].dataBoletoGerado.Year && DateTime.Today.Month == medicoes1[i].dataBoletoGerado.Month && DateTime.Today.Day == medicoes1[i].dataBoletoGerado.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                     medicoesPertoDeVencerHoje++;
                  }

                  continue;
               }

               //medicoes no prazo
               medicoesNoPrazo++;
               medicoes1[i].nivelAtraso = 0;
               if (DateTime.Today.Year == medicoes1[i].dataBoletoGerado.Year && DateTime.Today.Month == medicoes1[i].dataBoletoGerado.Month && DateTime.Today.Day == medicoes1[i].dataBoletoGerado.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                  mmedicoesNoPrazoHoje++;
               }
            }
         }

         mainCard1.title = "BOLETOS NO PRAZO";
         mainCard1.numString = medicoesNoPrazo + "";
         mainCard1.notifString = mmedicoesNoPrazoHoje + "";
         mainCard1.ascentColor = Colors.noPrazo;

         mainCard2.title = "BOLETOS PERTO DE VENCER";
         mainCard2.numString = medicoesPertoDeVencer + "";
         mainCard2.notifString = medicoesPertoDeVencerHoje + "";
         mainCard2.ascentColor = Colors.pertoDeVencer;

         mainCard3.title = "BOLETOS ATRASADOS";
         mainCard3.numString = medicoesAtrasadas + "";
         mainCard3.notifString = medicoesAtrasadasHoje + "";
         mainCard3.ascentColor = Colors.atrasado;
      }

      private bool buscarMedicoes(string idCedente) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getDadosMedicoes.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("cedente-id", idCedente);
         request.AddParameter("is-boleto", 1);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (content.Split(';')[0].Trim().Equals("ok")) {
               medicoes = JsonConvert.DeserializeObject<List<Medicao>>(content.Trim().Remove(0, 3));

               return true;
            } else {
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

      private void btnGerarRemessa_Click(object sender, EventArgs e) {
         List<RemessaModelDialog> remessas = new List<RemessaModelDialog>();

         foreach (Medicao medicao in medicoes) {
            Conta contaSelecionada = cedente.getContaById(medicao.contaSelecionadaIndex);

            if (remessas.Count <= 0) {
               RemessaModelDialog remessa = new RemessaModelDialog(contaSelecionada, medicao.carteiraSelecionada);
               remessa.medicoes.Add(medicao);

               remessas.Add(remessa);
            } else {
               bool addNewRemessa = true;
               foreach (RemessaModelDialog remessa in remessas) {
                  if (remessa.conta.agencia.Equals(contaSelecionada.agencia) && remessa.conta.conta.Equals(contaSelecionada.conta) && remessa.carteira.Equals(medicao.carteiraSelecionada)) {
                     remessa.medicoes.Add(medicao);
                     addNewRemessa = false;
                     break;
                  }
               }

               if (addNewRemessa) {
                  RemessaModelDialog remessa = new RemessaModelDialog(contaSelecionada, medicao.carteiraSelecionada);
                  remessa.medicoes.Add(medicao);

                  remessas.Add(remessa);
               }
            }
         }

         GerarRemessaDialog gerarBoletoDialog = new GerarRemessaDialog(remessas, cedente, Parent.FindForm());
         var res = gerarBoletoDialog.ShowDialog();

         Parent.FindForm().Activate();

         updateCustomViewList();

         if (res == DialogResult.OK) {

         } else if (res == DialogResult.Cancel) {

         }

         /*foreach (Remessa remessa in remessas) {
            Console.WriteLine("--------------------------------\n");
            foreach (Medicao medicao in remessa.medicoes) {
               Console.Write("remessa_conta: " + remessa.conta + "  remessa_carteira: " + remessa.carteira + "  medicao: " + medicao.medicao + "\n");
            }
            Console.WriteLine("--------------------------------\n");
         }*/
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
   }
}
