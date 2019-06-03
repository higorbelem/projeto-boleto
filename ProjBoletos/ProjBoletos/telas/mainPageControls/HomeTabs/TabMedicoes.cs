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

namespace ProjBoletos.telas.mainPageControls.HomeTabs {
    public partial class TabMedicoes : UserControl {
        
        int quantCards = 3;
        int spaceBetweenCards = 20;
        int cardHeight = 220;

        public Padding padding = new Padding(40,20,40,40);

        public Panel panel;

        Cedente cedente;
        List<Medicao> medicoes;

        public TabMedicoes() {
            InitializeComponent();

            loading1.Visible = false;

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
            buscarMedicoes(cedente.id);
            atualizarCards(medicoes);
            customListView.UpdateList(medicoes);

            customListView.update += () =>{
                updateCustomViewList();
            };

            gerarTodasBtn.title = "GERAR TODAS";
            gerarTodasBtn.cornerRadius = 20;
        }

        public void updateCustomViewList(){
            buscarMedicoes(cedente.id);
            atualizarCards(medicoes);
            customListView.UpdateList(medicoes);
        }

        private void TabMedicoes_Resize(object sender, EventArgs e) {
            loading1.Size = new Size(300,300);
            loading1.Location = new Point((ClientRectangle.Width/2) - (loading1.Width/2),(ClientRectangle.Height/2) - (loading1.Height/2));

            panel1.Location = new Point(0, 0);
            panel1.Size = new Size(ClientRectangle.Width, panel1.Height);
            panel1.MinimumSize = new Size(ClientRectangle.Width, 0);
            panel1.MaximumSize = new Size(ClientRectangle.Width, 0);

            Rectangle newSize = new Rectangle(padding.Left,padding.Top,panel1.Width - padding.Left - padding.Right, panel1.Height - padding.Top - padding.Bottom);
            
            int cardWidth = (newSize.Width - (spaceBetweenCards * (quantCards - 1))) / quantCards;

            mainCard1.Location = new Point(newSize.X, newSize.Y);
            mainCard1.Size = new Size(cardWidth, cardHeight);

            mainCard2.Location = new Point(newSize.X + cardWidth + spaceBetweenCards, newSize.Y);
            mainCard2.Size = new Size(cardWidth, cardHeight);

            mainCard3.Location = new Point(newSize.X + cardWidth * 2 + spaceBetweenCards * 2, newSize.Y);
            mainCard3.Size = new Size(cardWidth, cardHeight);

            gerarTodasBtn.Size = new Size(170,40);
            gerarTodasBtn.Location = new Point((newSize.Width/2) - (gerarTodasBtn.Width/2), mainCard1.Location.Y + mainCard1.Height + 20);

            //medicoesFlowLayout.Controls.Add();
            customListView.Size = new Size(newSize.Width, 80); //0
            customListView.MinimumSize = new Size(newSize.Width, 0); //0
            customListView.MaximumSize = new Size(newSize.Width, 0); //0
            customListView.Location = new Point(newSize.X, gerarTodasBtn.Location.Y + gerarTodasBtn.Height + 20);
        }

        private void label3_Click(object sender, EventArgs e) {

        }

        private void gerarTodosBtn_Click(object sender, EventArgs e){
            GerarBoletoDialog gerarBoletoDialog = new GerarBoletoDialog(cedente);
            var resultMessageBox = gerarBoletoDialog.ShowDialog();

            if (resultMessageBox == DialogResult.OK)
            {

                //Console.WriteLine(gerarBoletoDialog.contaSelecionadaIndex + " " + gerarBoletoDialog.carteiraSelecionada);

                var result = gerarMedicoes(cedente.id, gerarBoletoDialog.contaSelecionadaIndex, gerarBoletoDialog.carteiraSelecionada);

                if (result)
                {
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

        private void atualizarCards(List<Medicao> medicoes1){
            int medicoesNoPrazo = 0;
            int mmedicoesNoPrazoHoje = 0;
            int medicoesPertoDeVencer = 0;
            int medicoesPertoDeVencerHoje = 0;
            int medicoesAtrasadas = 0;
            int medicoesAtrasadasHoje = 0;

            for (int i = 0; i < medicoes1.Count; i++){
                if (medicoes1[i].boletoGerado.Equals("0")){
                    int diaVencimento = Int32.Parse(medicoes1[i].casa.diaVencimento);

                    DateTime vencimento = medicoes1[i].dataMedicao;

                    if (diaVencimento < medicoes1[i].dataMedicao.Day){
                        //Console.WriteLine("mes antes" + vencimento.Month);
                        vencimento = new DateTime(vencimento.Year, vencimento.AddMonths(1).Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
                        //Console.WriteLine("mes dps" + vencimento.Month);
                    }else{
                        vencimento = new DateTime(vencimento.Year, vencimento.Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
                    }

                    //medicoes atrasadas
                    if (DateTime.Today.CompareTo(vencimento) > 0)
                    {
                        medicoesAtrasadas++;
                        medicoes1[i].nivelAtraso = 2;
                        if (DateTime.Today.Year == medicoes1[i].dataMedicao.Year && DateTime.Today.Month == medicoes1[i].dataMedicao.Month && DateTime.Today.Day == medicoes1[i].dataMedicao.Day)
                        { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                            medicoesAtrasadasHoje++;
                        }

                        continue;
                    }

                    //medicoes perto do vencimento
                    if (DateTime.Today.CompareTo(vencimento.AddDays(-5)) >= 0)
                    {
                        medicoesPertoDeVencer++;
                        medicoes1[i].nivelAtraso = 1;
                        if (DateTime.Today.Year == medicoes1[i].dataMedicao.Year && DateTime.Today.Month == medicoes1[i].dataMedicao.Month && DateTime.Today.Day == medicoes1[i].dataMedicao.Day)
                        { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                            medicoesPertoDeVencerHoje++;
                        }

                        continue;
                    }

                    //medicoes no prazo
                    medicoesNoPrazo++;
                    medicoes1[i].nivelAtraso = 0;
                    if (DateTime.Today.Year == medicoes1[i].dataMedicao.Year && DateTime.Today.Month == medicoes1[i].dataMedicao.Month && DateTime.Today.Day == medicoes1[i].dataMedicao.Day)
                    { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
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
            loading1.Visible = true;

            var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getDadosMedicoes.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("text/plain");
            request.AddParameter("cedente-id", idCedente);
            request.AddParameter("is-boleto", 0);

            var response = client.Post(request);

            var content = response.Content; // raw content as string

            loading1.Visible = false;

            if (response.StatusCode == System.Net.HttpStatusCode.OK) {

                if (!content.Equals("erro")) {
                    medicoes = JsonConvert.DeserializeObject<List<Medicao>>(content);

                    return true;
                }else{
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

        private bool gerarMedicoes(string idCedente, string contaIndex, string carteira)
        {
            //loading1.Visible = true;

            var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/gerarTodosBoletos.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("text/plain");
            request.AddParameter("cedente-id", idCedente);
            request.AddParameter("carteira", carteira);
            request.AddParameter("conta_index", contaIndex);

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

        public void nada()
        {

        }
    }
}
