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
using ProjBoletos.components;
using ProjBoletos.telas.dialogs;
using ProjBoletos.modelos;
using RestSharp;
using Newtonsoft.Json;

namespace ProjBoletos.telas.mainPageControls {
   public partial class ClienteControl : UserControl {

      List<Sacado> sacados;

      public ClienteControl() {
         InitializeComponent();

         txtBoxSearch.hint = "PESQUISE POR NOME OU DOCUMENTO";

      }

      private void ClienteControl_Load(object sender, EventArgs e) {
         panelTop.BackColor = Colors.bg3;
         txtBoxSearch.BackColor = Colors.bg3;

         btnSearch.title = "PESQUISAR";

         updateCustomViewList();

         customListView.update += () => {
            updateCustomViewList();
         };
      }

      public void updateCustomViewList() {
         Loading loading = new Loading();
         loading.task = new Task(new Action(() => {
            var res = getSacados(txtBoxSearch.txtBox.Text);

            loading.terminou = true;
            loading.terminouBem = res;
         }));
         loading.ShowDialog();

         customListView.vazioText = "NENHUM RESULTADO";
         List<CustomListViewItem> items = new List<CustomListViewItem>();

         CustomListViewItem customListViewItemCabecalho = new CustomListViewItem();
         customListViewItemCabecalho.isCabecalho = true;
         customListViewItemCabecalho.Size = new Size(ClientRectangle.Width, 50);
         customListViewItemCabecalho.addValor("ID", "1");
         customListViewItemCabecalho.addValor("NOME", "3");
         customListViewItemCabecalho.addValor("DOCUMENTO", "3");
         customListViewItemCabecalho.addValor("EMAIL", "3");
         items.Add(customListViewItemCabecalho);

         foreach (Sacado sacado in sacados) {
            CustomListViewItem customListViewItem = new CustomListViewItem();
            customListViewItem.Size = new Size(ClientRectangle.Width, 50);
            customListViewItem.addValor(sacado.id, "1");
            customListViewItem.addValor(sacado.nome, "3");
            customListViewItem.addValor(sacado.documento, "3");
            customListViewItem.addValor(sacado.email, "3");
            //customListViewItem.medicao = medicao;
            customListViewItem.circleColor = Color.Transparent;
            customListViewItem.btnVer.title = "EDITAR";
            customListViewItem.btnGerar.Size = new Size(0, 0);
            customListViewItem.btnGerar.Visible = false;

            customListViewItem.btnVer.Click += new EventHandler((object sender, EventArgs e) => {

            });

            items.Add(customListViewItem);
         }
         customListView.UpdateList(items);
      }

      private void ClienteControl_Resize(object sender, EventArgs e) {
         panelTop.Location = new Point(0, 0);
         panelTop.Size = new Size(ClientRectangle.Width, 60);

         int panelTopPaddingLeftRight = 70;
         int panelTopPaddingTopBottom = 10;

         txtBoxSearch.Location = new Point(panelTopPaddingLeftRight, panelTopPaddingTopBottom);
         txtBoxSearch.Size = new Size((int)((panelTop.Width - panelTopPaddingLeftRight * 2) * 0.8), panelTop.Height - panelTopPaddingTopBottom * 2);

         btnSearch.Location = new Point(txtBoxSearch.Location.X + txtBoxSearch.Width, panelTopPaddingTopBottom);
         btnSearch.Size = new Size((int)((panelTop.Width - panelTopPaddingLeftRight * 2) * 0.2), panelTop.Height - panelTopPaddingTopBottom * 2);

         customListView.Size = new Size(ClientRectangle.Width - 40, 80); //0
         customListView.MinimumSize = new Size(ClientRectangle.Width - 40, 0); //0
         customListView.MaximumSize = new Size(ClientRectangle.Width - 40, 0); //0
         customListView.Location = new Point(20, panelTop.Location.Y + panelTop.Height + 20);
      }

      private bool getSacados(string busca) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/procuraSacado.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("busca", busca);
         request.AddParameter("buscar-todos", txtBoxSearch.isEmpty ? "1" : "0");

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {
            if (!content.Equals("erro")) {
               sacados = JsonConvert.DeserializeObject<List<Sacado>>(content);
               return true;
            } else {
               sacados = new List<Sacado>();
               return false;
            }
         }

         return false;
      }

      public void btnSearch_Click(object sender, EventArgs e) {
         updateCustomViewList();
      }
   }
}
