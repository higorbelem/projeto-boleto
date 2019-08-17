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
using ProjBoletos.utils;
using RestSharp;
using ProjBoletos.components;
using ProjBoletos.telas.dialogs;

namespace ProjBoletos.telas.mainPageControls {
   public partial class MedidorVisualControl : UserControl {

      private List<MedidorVisualizador> medidores;
      private Cedente cedente;

      public MedidorVisualControl() {
         InitializeComponent();

         txtBoxSearch.hint = "PESQUISE POR NOME OU DOCUMENTO";

         var cedenteJson = Properties.Settings.Default["cedenteAtual"].ToString();
         cedente = JsonConvert.DeserializeObject<Cedente>(cedenteJson);

         if (cedente == null) {
            Application.Exit();
         }
      }

      private void MedidorVisualControl_Load(object sender, EventArgs e) {
         panelTop.BackColor = Colors.bg3;
         txtBoxSearch.BackColor = Colors.bg3;

         btnSearch.img = new Bitmap(Properties.Resources.search_white);

         btnAdicionar.title = "ADICIONAR";
         btnAdicionar.cornerRadius = 20;
         btnAdicionar.img = new Bitmap(Properties.Resources.group_add);

         customListView.update += () => {
            updateCustomViewList();
         };
      }

      private void MedidorVisualControl_Resize(object sender, EventArgs e) {
         panelTop.Location = new Point(0, 0);
         panelTop.Size = new Size(ClientRectangle.Width, 60);

         int panelTopPaddingLeftRight = 70;
         int panelTopPaddingTopBottom = 10;

         txtBoxSearch.Location = new Point(panelTopPaddingLeftRight, panelTopPaddingTopBottom);
         txtBoxSearch.Size = new Size((int)((panelTop.Width - panelTopPaddingLeftRight * 2) * 0.9), panelTop.Height - panelTopPaddingTopBottom * 2);

         btnSearch.Location = new Point(txtBoxSearch.Location.X + txtBoxSearch.Width, panelTopPaddingTopBottom);
         btnSearch.Size = new Size((int)((panelTop.Width - panelTopPaddingLeftRight * 2) * 0.1), panelTop.Height - panelTopPaddingTopBottom * 2);

         btnAdicionar.Size = new Size(300, 40);
         btnAdicionar.Location = new Point(ClientRectangle.Width / 2 - btnAdicionar.Width / 2, panelTop.Location.Y + panelTop.Height + 20);

         customListView.Size = new Size(ClientRectangle.Width - 40, 80); //0
         customListView.MinimumSize = new Size(ClientRectangle.Width - 40, 0); //0
         customListView.MaximumSize = new Size(ClientRectangle.Width - 40, 0); //0
         customListView.Location = new Point(20, btnAdicionar.Location.Y + btnAdicionar.Height + 20);
      }

      public void updateCustomViewList() {
         Loading loading = new Loading();
         loading.task = new Task(new Action(() => {
            var res = getMedidoresVisualizadores(txtBoxSearch.getValue().Trim(), cedente.id);

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
         customListViewItemCabecalho.addValor("NOME", "4");
         customListViewItemCabecalho.addValor("CPF", "4");
         customListViewItemCabecalho.addValor("TIPO", "4");
         items.Add(customListViewItemCabecalho);

         foreach (MedidorVisualizador medidor in medidores) {
            CustomListViewItem customListViewItem = new CustomListViewItem();
            customListViewItem.Size = new Size(ClientRectangle.Width, 50);
            customListViewItem.addValor(medidor.id, "1");
            customListViewItem.addValor(medidor.nome, "4");
            customListViewItem.addValor(medidor.cpf, "4");
            customListViewItem.addValor(medidor.tipo, "4");
            //customListViewItem.medicao = medicao;
            customListViewItem.circleColor = Color.Transparent;
            customListViewItem.btnVer.img = new Bitmap(Properties.Resources.edit_white);
            customListViewItem.btnGerar.Size = new Size(0, 0);
            customListViewItem.btnGerar.Visible = false;

            customListViewItem.btnVer.Click += new EventHandler((object sender, EventArgs e) => {
               AdicionarEditarMedidorVisualizador adicionarEditarMedidorVisualizador = new AdicionarEditarMedidorVisualizador(cedente, medidor, AdicionarEditarMedidorVisualizador.DIALOG_MODE_EDITAR);
               var resDialog = adicionarEditarMedidorVisualizador.ShowDialog();

               Parent.FindForm().Activate();

               if (resDialog == DialogResult.OK) {
                  updateCustomViewList();
               }
            });

            items.Add(customListViewItem);
         }
         customListView.UpdateList(items);
      }

      private bool getMedidoresVisualizadores(string busca, string idCedente) {
         //loading1.Visible = true;

         var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getMedidoresVisualizadores.php");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);

         var request = new RestRequest("text/plain");
         request.AddParameter("auth-usr", ServerConfig.serverAuthUsr);
         request.AddParameter("auth-psw", ServerConfig.serverAuthPsw);
         request.AddParameter("buscar-todos", txtBoxSearch.isEmpty ? "1" : "0");
         request.AddParameter("busca", busca);
         request.AddParameter("cedente-id", idCedente);

         var response = client.Post(request);

         var content = response.Content; // raw content as string

         //loading1.Visible = false;

         if (response.StatusCode == System.Net.HttpStatusCode.OK) {

            if (content.Split(';')[0].Trim().Equals("ok")) {
               medidores = JsonConvert.DeserializeObject<List<MedidorVisualizador>>(content.Trim().Remove(0, 3));
               /*foreach (Casa casa in sacados[0].casas) {
                  Console.WriteLine(casa.id + " " + casa.numero + " " + casa.bairro + " " + casa.cep + " " + casa.cidade + " " + casa.diaVencimento);
               }*/
               return true;
            } else {
               medidores = new List<MedidorVisualizador>();
               return false;
            }
         }

         return false;
      }

      public void btnSearch_Click(object sender, EventArgs e) {
         updateCustomViewList();
      }

      public void btnAdicionar_Click(object sender, EventArgs e) {
         AdicionarEditarMedidorVisualizador adicionarEditarMedidorVisualizador = new AdicionarEditarMedidorVisualizador(cedente, null, AdicionarEditarMedidorVisualizador.DIALOG_MODE_ADICIONAR);
         var resDialog = adicionarEditarMedidorVisualizador.ShowDialog();

         Parent.FindForm().Activate();

         if (resDialog == DialogResult.OK) {
            updateCustomViewList();
         }
         /*AdicionarEditarClienteDialog adicionarClienteDialog = new AdicionarEditarClienteDialog(cedente, null, AdicionarEditarClienteDialog.DIALOG_MODE_ADICIONAR);
         var resDialog = adicionarClienteDialog.ShowDialog();

         if (resDialog == DialogResult.OK) {
            updateCustomViewList();
         }*/
      }
   }
}
