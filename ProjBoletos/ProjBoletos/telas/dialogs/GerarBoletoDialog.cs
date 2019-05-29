using ProjBoletos.components;
using ProjBoletos.modelos;
using ProjBoletos.testes;
using ProjBoletos.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjBoletos.telas.dialogs
{
    public partial class GerarBoletoDialog : Form
    {

        public Cedente cedente;

        private List<Carteira> carteirasItau = new List<Carteira>(){
            new Carteira("102","0","Sem Registro Com Emissão Integral - Carnê"),
            new Carteira("103","0","Sem Registro Com Emissão/Entrega - Carnê"),
            new Carteira("104","0","Escritural Eletrônica - Carnê"),
            new Carteira("105","0","Escritural Eletrônica - Dólar - Carnê"),
            new Carteira("106","0","S/Registro C/Emissão/Entrega-15 dígitos-Carnê"),
            new Carteira("107","0","S/Registro C/Emissão Integral-15 Posições-Carnê"),
            new Carteira("108","0","Direta Eletrônica Emissão Integral - Carnê"),
            new Carteira("109","0","Direta Eletrônica Sem Emissão - Simples"),
            new Carteira("110","0","Direta Eletrônica Sem Emissão - Simples"),
            new Carteira("111","0","Direta Eletrônica Sem Emissão - Simples"),
            new Carteira("112","0","Escritural Eletrônica - simples / contratual"),
            new Carteira("113","0","Escritural Eletrônica - TR - Carnê"),
            new Carteira("114","0","Escritural Eletrônica - Seguros"),
            new Carteira("115","0","Carteira 115"),
            new Carteira("120","0","S/Registro Emissão Integral C/IOF 2% - Carnê"),
            new Carteira("121","0"," Direta Eletrônica Emissão Parcial - Simples/Contra"),
            new Carteira("122","0","S/Registro S/Emissão 15 Dígitos C/IOF 2%"),
            new Carteira("126","0","Direta Eletrônica Sem Emissão - Seguros"),
            new Carteira("129","0","S/Registro Emissão Parcial Seguros C/IOF 2%"),
            new Carteira("131","0","Direta Eletrônica c/ Valor em Aberto"),
            new Carteira("139","0","S/Registro Emissão Parcial Seguros C/IOF 4%"),
            new Carteira("140","0","S/Registro Emissão Integral C/IOF 4% - Carnê"),
            new Carteira("141","0","S/Registro Emissão Integral C/IOF 7% - Carnê"),
            new Carteira("142","0","S/Registro S/Emissão 15 DÍGITOS C/IOF 4%"),
            new Carteira("143","0","S/Registro S/Emissão 15 DÍGITOS C/IOF 7%"),
            new Carteira("146","0","Descrição Não Disponível"),
            new Carteira("147","0","Escritural Eletrônica - Dólar"),
            new Carteira("150","0","Direta Eletrônica Sem Emissão - Dólar"),
            new Carteira("166","0","Escritural Eletrônica - TR"),
            new Carteira("168","0","Direta Eletrônica Sem Emissão - TR"),
            new Carteira("169","0","S/Registro Emissão Parcial Seguros C/IOF 7%"),
            new Carteira("172","0","Sem Registro Com Emissão Integra"),
            new Carteira("173","0"," Sem Registro Com Emissão/Entrega"),
            new Carteira("174","0","Sem Registro Emissão Parcial Com Protesto Borderô"),
            new Carteira("175","0","Sem Registro Sem Emissão"),
        };
        private List<Carteira> carteirasBradesco = new List<Carteira>() {
            new Carteira("02","0","Carteira 02"),
            new Carteira("03","0","Carteira 03"),
            new Carteira("04","0","Pré-Impressos"),
            new Carteira("05","0","Recebimento Programado Bradesco - RPB"),
            new Carteira("06","0","Sem Registro"),
            new Carteira("07","0","Carteira 07"),
            new Carteira("09","0","Com Registro"),
            new Carteira("12","0","Carteira 12"),
            new Carteira("16","0","Sem Registro com Protesto"),
            new Carteira("17","0","Carteira 17"),
            new Carteira("19","0","Com Registro"),
            new Carteira("22","0","Sem Registro - Pagável somente no Bradescos")
        };
        private List<Carteira> carteirasBB = new List<Carteira>() {
            new Carteira("11","0","Cobrança Simples - Com Registro"),
            new Carteira("11","0000","Cobrança Simples - C/Registro Convênio 4 dígitos"),
            new Carteira("12","0","Cobrança Indexada - Com Registro"),
            new Carteira("12","0000","Cobrança Indexada - C/Registro Convênio 4 dígitos"),
            new Carteira("12","0000000","Cobrança Indexada - C/Registro Convênio 7 dígitos"),
            new Carteira("15","0","Cobrança de Prêmios de Seguro - Com Registro"),
            new Carteira("15","0000","Cob.Prêmios Seguro - C/Registro Convênio 4 dígitos"),
            new Carteira("16","0","Cobranca Simples"),
            new Carteira("16","00000000000000000","Cobranca Simples - Nosso Número 17 Dígitos"),
            new Carteira("16","0000","Cobranca Simples - Convênio 4 dígitos"),
            new Carteira("17","0","Cobranca Direta Especial - Com Registro"),
            new Carteira("17","0000","Cob. Direta Esp. - C/Registro Convênio 4 dígitos"),
            new Carteira("17","0000000","Cob. Direta Esp. - C/Registro Convênio 7 dígitos"),
            new Carteira("18","0","Cobranca Simples - Nosso Número 11 Dígitos"),
            new Carteira("18","00000000000000000","Cobranca Simples - Nosso Número 17 Dígitos"),
            new Carteira("18","0000","Cobranca Simples - Convênio 4 dígitos"),
            new Carteira("18","0000000","Cobranca Simples - Convênio 7 dígitos"),
            new Carteira("31","0","Cobrança Caucionada/Vinculada - Com Registro"),
            new Carteira("31","0000","Cob.Cauc./Vinc. - C/Registro Convênio 4 dígitos"),
            new Carteira("51","0","Cobrança Descontada - Com Registro"),
            new Carteira("51","0000","Cob. Descontada - C/Registro Convênio 4 dígitoss")
        };

        public string carteiraSelecionada = "";
        public string convenioSelecionado = "";
        public string contaSelecionadaIndex = "";

        public GerarBoletoDialog(Cedente  cedente)
        {
            InitializeComponent();

            this.cedente = cedente;
        }

        private void GerarBoletoDialog_Load(object sender, EventArgs e)
        {

            btnFechar.title = "FECHAR";
            btnFechar.cornerRadius = 5;
            btnOk.title = "OK";
            btnOk.cornerRadius = 5;

            label1.Text = "DADOS ADICIONAIS";
            label1.Font = Fonts.mainBold14;
            label1.BackColor = Colors.bg3;
            label1.Location = new Point((ClientRectangle.Width/2)-(label1.Width/2), label1.Location.Y);

            comboBoxContas.Items.Add("--Escolha uma conta--");
            comboBoxContas.SelectedIndex = 0;
            comboBoxCarteiras.Items.Add("--Escolha uma carteira--");
            comboBoxCarteiras.SelectedIndex = 0;

            foreach (Conta conta in cedente.contas){
                comboBoxContas.Items.Add(conta.banco + " " + conta.agencia + " " + conta.conta);
            }

            comboBoxContas.SelectionChangeCommitted += new EventHandler((object sender1, EventArgs e1) => {
                if (comboBoxContas.SelectedIndex > 0) {

                    comboBoxCarteiras.Items.Clear();
                    comboBoxCarteiras.Items.Add("--Escolha uma carteira--");
                    comboBoxCarteiras.SelectedIndex = 0;

                    if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("001")) {
                        foreach (Carteira carteira in carteirasBB) {
                            if (carteira.convenioBB.Equals("0"))
                            {
                                comboBoxCarteiras.Items.Add(carteira.carteira + " - " + carteira.descricao);
                            }
                            else
                            {
                                comboBoxCarteiras.Items.Add(carteira.carteira + "-" + carteira.convenioBB + " - " + carteira.descricao);
                            }
                        }
                    }
                    else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("237")) {
                        foreach (Carteira carteira in carteirasBradesco) {
                            comboBoxCarteiras.Items.Add(carteira.carteira + " - " + carteira.descricao);
                        }
                    }
                    else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("341")) {
                        foreach (Carteira carteira in carteirasItau) {
                            comboBoxCarteiras.Items.Add(carteira.carteira + " - " + carteira.descricao);
                        }
                    }
                }
            });

            //comboBox1.SelectedIndex
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (comboBoxContas.SelectedIndex == 0 || comboBoxCarteiras.SelectedIndex == 0){
                MessageBox.Show("Alguma opção ficou vazia", "Atenção", MessageBoxButtons.OK);
            }else{

                if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("001")){

                    carteiraSelecionada = carteirasBB[comboBoxCarteiras.SelectedIndex - 1].carteira;
                    convenioSelecionado = carteirasBB[comboBoxCarteiras.SelectedIndex - 1].convenioBB;

                }
                else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("237")){

                    convenioSelecionado = "0";
                    carteiraSelecionada = carteirasBradesco[comboBoxCarteiras.SelectedIndex - 1].carteira;

                }else if (cedente.contas[comboBoxContas.SelectedIndex - 1].banco.Equals("341")){

                    convenioSelecionado = "0";
                    carteiraSelecionada = carteirasItau[comboBoxCarteiras.SelectedIndex - 1].carteira;

                }else{
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                
                contaSelecionadaIndex = cedente.contas[comboBoxContas.SelectedIndex - 1].id;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = RoundedRectangles.Create(new Rectangle(1,1,ClientRectangle.Width-2,ClientRectangle.Height-2), 5);

            e.Graphics.FillPath(new SolidBrush(Colors.bg3), path);
        }
    }
}
