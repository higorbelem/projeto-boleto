﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjBoletos.modelos;
using ProjBoletos.utils;
using BoletoForm2;
using ProjBoletos.telas;
using RestSharp;
using ProjBoletos.telas.mainPageControls.HomeTabs;

namespace ProjBoletos.components {
    public partial class CustomListView : UserControl {

        List<Medicao> medicoes;

        public delegate void UpdateEvent();
        public UpdateEvent update;

        public CustomListView() {
            InitializeComponent();
        }

        private void CustomListView_Load(object sender, EventArgs e) {
            //MessageBox.Show("asdasd","asdasd",MessageBoxButtons.YesNo);
        }

        public void UpdateList(List<Medicao> medicoes1) {
            medicoes = medicoes1;

            flowLayoutPanel.Controls.Clear();

            CustomListViewItem customListViewItemCabecalho = new CustomListViewItem();
            customListViewItemCabecalho.isCabecalho = true;
            customListViewItemCabecalho.Size = new Size(ClientRectangle.Width, 50);
            customListViewItemCabecalho.addValor("DATA DA MEDIÇÂO", "1,5");
            customListViewItemCabecalho.addValor("ENDEREÇO", "3");
            customListViewItemCabecalho.addValor("CLIENTE", "3");
            customListViewItemCabecalho.addValor("MEDIÇÂO", "1,5");
            flowLayoutPanel.Controls.Add(customListViewItemCabecalho);

            flowLayoutPanel.Controls.Add(new Separator() {
                Size = new Size(ClientRectangle.Width, 20)
            });

            if (medicoes.Count == 0){
                flowLayoutPanel.Controls.Add(new Label() {
                    Text = "Não há medições",
                    Font = Fonts.mainBold10,
                    ForeColor = Colors.primaryText,
                    Size = new Size(ClientRectangle.Width, 50),
                    TextAlign = ContentAlignment.MiddleCenter
                });
            }

            foreach (Medicao medicao in medicoes) {
                CustomListViewItem customListViewItem = new CustomListViewItem();
                customListViewItem.Size = new Size(ClientRectangle.Width, 50);
                customListViewItem.addValor(medicao.dataMedicao.ToString(),"1,5");
                customListViewItem.addValor(medicao.casa.rua + ", " + medicao.casa.numero,"3");
                customListViewItem.addValor(medicao.sacado.nome, "3");
                customListViewItem.addValor(medicao.medicao, "1,5");
                customListViewItem.medicao = medicao;

                switch (medicao.nivelAtraso){
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

                customListViewItem.btnGerar.Click += new EventHandler((object sender, EventArgs e) => {
                    var resultMessageBox = MessageBox.Show("Gerar o boleto desta medição?", "", MessageBoxButtons.YesNo);

                    if (resultMessageBox == DialogResult.Yes){
                        var result = gerarBoletos(medicao.id);

                        if (result){
                            update();
                        }
                    }
                });

                customListViewItem.btnVer.Click += new EventHandler((object sender, EventArgs e) => {
                    MedicaoForm medicaoForm = new MedicaoForm(medicao);
                    medicaoForm.Show();
                });

                flowLayoutPanel.Controls.Add(customListViewItem);
            }

        }

        private void CustomListView_Resize(object sender, EventArgs e) {
            flowLayoutPanel.Location = new Point(0,0);
            flowLayoutPanel.Size = new Size(ClientRectangle.Width,ClientRectangle.Height);

            if (flowLayoutPanel.Controls.Count > 1) {
                flowLayoutPanel.Controls[0].Size = new Size(ClientRectangle.Width, 50);
                flowLayoutPanel.Controls[1].Size = new Size(ClientRectangle.Width, 10);
            }
            
            for (int i = 2; i < flowLayoutPanel.Controls.Count; i++){
                flowLayoutPanel.Controls[i].Size = new Size(ClientRectangle.Width, 50);
            }
        }

        private bool gerarBoletos(string idMedicao)
        {
            //loading1.Visible = true;

            var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/gerarBoletos.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("text/plain");
            request.AddParameter("medicao-id", idMedicao);

            var response = client.Post(request);

            var content = response.Content; // raw content as string

            //loading1.Visible = false;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {

                if (!content.Equals("erro"))
                {
                    

                    return true;
                }
                else
                {
                    

                    return false;
                }
            }

            return false;
        }
    }
}
