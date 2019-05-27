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

            int medicoesNoPrazo = 0;
            int mmedicoesNoPrazoHoje = 0;
            int medicoesPertoDeVencer = 0;
            int medicoesPertoDeVencerHoje = 0;
            int medicoesAtrasadas = 0;
            int medicoesAtrasadasHoje = 0;

            for (int i = 0; i < medicoes.Count; i++) {
                if (medicoes[i].boletoGerado.Equals("0")) {
                    int diaVencimento = Int32.Parse(medicoes[i].casa.diaVencimento);

                    DateTime vencimento = medicoes[i].dataMedicao;

                    if (diaVencimento < medicoes[i].dataMedicao.Day) {
                        vencimento = new DateTime(vencimento.Year, vencimento.Month + 1, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
                    } else {
                        vencimento = new DateTime(vencimento.Year, vencimento.Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
                    }

                    //medicoes atrasadas
                    if (DateTime.Today.CompareTo(vencimento) > 0) {
                        medicoesAtrasadas++;
                        medicoes[i].nivelAtraso = 2;
                        if (DateTime.Today.Year == medicoes[i].dataMedicao.Year && DateTime.Today.Month == medicoes[i].dataMedicao.Month && DateTime.Today.Day == medicoes[i].dataMedicao.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                            medicoesAtrasadasHoje++;
                        }

                        continue;
                    }

                    //medicoes perto do vencimento
                    if (DateTime.Today.CompareTo(vencimento.AddDays(-5)) >= 0) {
                        medicoesPertoDeVencer++;
                        medicoes[i].nivelAtraso = 1;
                        if (DateTime.Today.Year == medicoes[i].dataMedicao.Year && DateTime.Today.Month == medicoes[i].dataMedicao.Month && DateTime.Today.Day == medicoes[i].dataMedicao.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                            medicoesPertoDeVencerHoje++;
                        }

                        continue;
                    }

                    //medicoes no prazo
                    medicoesNoPrazo++;
                    medicoes[i].nivelAtraso = 0;
                    if (DateTime.Today.Year == medicoes[i].dataMedicao.Year && DateTime.Today.Month == medicoes[i].dataMedicao.Month && DateTime.Today.Day == medicoes[i].dataMedicao.Day) { // se a medição é atrasada e foi feita hoje pode ser que seja a medição do mes seguinte
                        mmedicoesNoPrazoHoje++;
                    }
                }
            }

            customListView.UpdateList(medicoes);

            gerarTodasBtn.title = "GERAR TODAS";
            gerarTodasBtn.cornerRadius = 20;

            mainCard1.title = "Medições no prazo";
            mainCard1.numString = medicoesNoPrazo+"";
            mainCard1.notifString = mmedicoesNoPrazoHoje+"";
            mainCard1.ascentColor = Colors.noPrazo;

            mainCard2.title = "Medições perto de vencer";
            mainCard2.numString = medicoesPertoDeVencer+"";
            mainCard2.notifString = medicoesPertoDeVencerHoje+"";
            mainCard2.ascentColor = Colors.pertoDeVencer;

            mainCard3.title = "Medições atrasadas";
            mainCard3.numString = medicoesAtrasadas+"";
            mainCard3.notifString = medicoesAtrasadasHoje+"";
            mainCard3.ascentColor = Colors.atrasado;
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

        private bool buscarMedicoes(string idCedente) {
            loading1.Visible = true;

            var client = new RestClient(ServerConfig.ipServer + "projeto-boletos-server/getDadosMedicoes.php");
            // client.Authenticator = new HttpBasicAuthenticator(username, password);

            var request = new RestRequest("text/plain");
            request.AddParameter("cedente-id", idCedente);

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
    }
}
