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

namespace ProjBoletos.components {
    public partial class CustomListView : UserControl {

        List<Medicao> medicoes;

        public CustomListView() {
            InitializeComponent();
        }

        private void CustomListView_Load(object sender, EventArgs e) {
            
        }

        public void UpdateList(List<Medicao> medicoes1) {
            medicoes = medicoes1;

            CustomListViewItem customListViewItemCabecalho = new CustomListViewItem();
            customListViewItemCabecalho.Size = new Size(ClientRectangle.Width, 50);
            customListViewItemCabecalho.addValor("DATA DA MEDIÇÂO", "1,5");
            customListViewItemCabecalho.addValor("ENDEREÇO", "3");
            customListViewItemCabecalho.addValor("CLIENTE", "3");
            customListViewItemCabecalho.addValor("MEDIÇÂO", "1,5");
            flowLayoutPanel.Controls.Add(customListViewItemCabecalho);

            flowLayoutPanel.Controls.Add(new Separator());

            foreach (Medicao medicao in medicoes) {
                CustomListViewItem customListViewItem = new CustomListViewItem();
                customListViewItem.Size = new Size(ClientRectangle.Width, 50);
                customListViewItem.addValor(medicao.dataMedicao.ToString(),"1,5");
                customListViewItem.addValor(medicao.casa.rua + ", " + medicao.casa.numero,"3");
                customListViewItem.addValor(medicao.sacado.nome, "3");
                customListViewItem.addValor(medicao.medicao, "1,5");
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

            for (int i = 2; i <  flowLayoutPanel.Controls.Count; i++) {
                flowLayoutPanel.Controls[i].Size = new Size(ClientRectangle.Width, 50);
            }
        }
    }
}
