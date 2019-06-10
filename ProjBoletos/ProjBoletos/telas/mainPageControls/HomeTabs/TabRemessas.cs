﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.utils;
using RestSharp;
using ProjBoletos.modelos;
using Newtonsoft.Json;

namespace ProjBoletos.telas.mainPageControls.HomeTabs {
   public partial class TabRemessas : UserControl {

      private List<Remessa> remessas;

      Padding padding = new Padding(40, 20, 40, 40);
      int quantCards = 2;
      int spaceBetweenCards = 20;
      int cardHeight = 220;

      private Cedente cedente;
      public Panel panel;

      bool buscaCompleta = false;

      public TabRemessas() {
         InitializeComponent();

         panel = panel1;
      }

      private void TabRemessas_Load(object sender, EventArgs e) {

         panel1.BackColor = Colors.bg;
         BackColor = Colors.bg;

         var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
         cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);
         if (cedente == null) {
            Application.Exit();
         }

         updatePage();
      }

      private void atualizarCards(List<Remessa> remessas) {
         int remessasNaoEnviada = 0;
         int remessasNaoEnviadaHoje = 0;
         int remessasEnviada = 0;
         int remessasEnviadaHoje = 0;

         for (int i = 0; i < remessas.Count; i++) {
            if (remessas[i].enviado.Equals("1")) {
               remessasEnviada++;
               if (DateTime.Today.Year == remessas[i].data.Year && DateTime.Today.Month == remessas[i].data.Month && DateTime.Today.Day == remessas[i].data.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                  remessasEnviadaHoje++;     
               }
            } else {
               remessasNaoEnviada++;
               if (DateTime.Today.Year == remessas[i].data.Year && DateTime.Today.Month == remessas[i].data.Month && DateTime.Today.Day == remessas[i].data.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                  remessasNaoEnviadaHoje++;
               }
            }
         }

         mainCard1.title = "REMESSAS AGUARDANDO RETORNO";
         mainCard1.numString = remessasEnviada + "";
         mainCard1.notifString = remessasEnviadaHoje + "";
         mainCard1.ascentColor = Colors.noPrazo;

         mainCard2.title = "REMESSAS NÂO ENVIADAS";
         mainCard2.numString = remessasNaoEnviada + "";
         mainCard2.notifString = remessasNaoEnviadaHoje + "";
         mainCard2.ascentColor = Colors.pertoDeVencer;
      }

      public void updatePage() {
         var res = buscarRemessas(cedente.id);

         if (res) {
            buscaCompleta = true;
            atualizarCards(remessas);
            atualizarFlow(remessas);
            //customListView.UpdateList(medicoes);
         }
      }

      public void atualizarFlow(List<Remessa> remessas) {
         if (buscaCompleta) {
            flowRemessas.Controls.Clear();

            for (int i = 0; i < remessas.Count; i += 2) {
               Console.WriteLine(i);

               Panel panel = new Panel() {
                  Size = new Size(flowRemessas.Width, 200)
               };

               panel.Controls.Add(criaPanelRemessa(new Point(panel.Location.X, panel.Location.Y), new Size(panel.Width / 2 - spaceBetweenCards/2, panel.Height), remessas[i]));
               if (i + 1 < remessas.Count) {
                  panel.Controls.Add(criaPanelRemessa(new Point(panel.Location.X + (panel.Width / 2 - spaceBetweenCards / 2) + spaceBetweenCards, panel.Location.Y), new Size(panel.Width / 2 - spaceBetweenCards / 2, panel.Height), remessas[i + 1]));
               }

               flowRemessas.Controls.Add(panel);
            }
         }
      }

      public Panel criaPanelRemessa(Point loc, Size size, Remessa remessa) {
         Panel panel = new Panel() {
            Location = loc,
            Size = size,
            BackColor = Colors.bg2
         };

         Rectangle rectLabelTop = new Rectangle(0,0,size.Width,20);
         string labelText = "";
         Color labelBackColor;
         if (remessa.enviado.Equals("1")) {
            labelText = "REMESSA AGUARDANDO RETORNO";
            labelBackColor = Colors.noPrazo;
         } else {
            labelText = "REMESSA NÂO ENVIADA";
            labelBackColor = Colors.pertoDeVencer;
         }
         panel.Controls.Add(new Label() {
            Text = labelText,
            BackColor = labelBackColor,
            ForeColor = Colors.bg,
            Font = Fonts.mainBold8,
            Location = new Point(rectLabelTop.X, rectLabelTop.Y),
            Size = new Size(rectLabelTop.Width, rectLabelTop.Height),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false
         });

         Rectangle rectLabelId = new Rectangle(0, rectLabelTop.Location.Y + rectLabelTop.Height, 80, 40);
         panel.Controls.Add(new Label() {
            Text = "#" + remessa.id,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold12,
            Location = new Point(rectLabelId.X, rectLabelId.Y),
            Size = new Size(rectLabelId.Width, rectLabelId.Height),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false
         });

         Rectangle rectLabelBanco = new Rectangle(0, rectLabelTop.Location.Y + rectLabelTop.Height, size.Width, 40);
         string labelBancoText = "";
         if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("001")) {
            labelBancoText = "Banco Do Brasil";
         } else if(cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("341")){
            labelBancoText = "Itaú";
         } else if (cedente.getContaById(remessa.medicoes[0].contaSelecionadaIndex).banco.Equals("237")){
            labelBancoText = "Bradesco";
         }
         panel.Controls.Add(new Label() {
            Text = labelBancoText,
            BackColor = Colors.bg2,
            ForeColor = Colors.primaryText,
            Font = Fonts.mainBold12,
            Location = new Point(rectLabelBanco.X, rectLabelBanco.Y),
            Size = new Size(rectLabelBanco.Width, rectLabelBanco.Height),
            TextAlign = ContentAlignment.MiddleCenter,
            AutoSize = false
         });

         return panel;
      }

      private bool buscarRemessas(string idCedente) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getDadosRemessa.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("cedente-id", idCedente);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (!content.Equals("erro")) {
               remessas = JsonConvert.DeserializeObject<List<Remessa>>(content);

               return true;
            } else {
               remessas = new List<Remessa>();

               return false;
            }
         } else {
            MessageBox.Show("Houve um erro ao resgatar as remessas. Http status Code: " + response.StatusCode);
         }

         /*Properties.Settings.Default["cedenteAtual"] = "";
         Properties.Settings.Default["logado"] = false;
         Properties.Settings.Default.Save();

         this.Hide();
         Login login = new Login();
         //login.Closed += (s, args) => this.Close();
         login.Show();*/

         return false;
      }

      private void TabRemessas_Resize(object sender, EventArgs e) {
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

         flowRemessas.Size = new Size(newSize.Width, 80); //0
         flowRemessas.MinimumSize = new Size(newSize.Width, 0); //0
         flowRemessas.MaximumSize = new Size(newSize.Width, 0); //0
         flowRemessas.Location = new Point(newSize.X, mainCard1.Location.Y + mainCard1.Height + 20);
         //atualizarFlow(remessas);
      }
   }
}