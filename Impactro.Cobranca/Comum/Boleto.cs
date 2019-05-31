// Autor: F�bio Ferreira de Souza 
// email: fabio@impactro.com.br
// Sites: www.impactro.com.br / www.boletoasp.com.br

using System;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace Impactro.Cobranca
{

    #region "Classes & Delegates para boletos"

    /// <summary>
    /// Assinatura de uma rotina que gere o campo livre, no formato de 25 posi��es
    /// </summary>
    public delegate string BoletoMontaCampoLivre(Boleto blt);
    public delegate void ConfigureTable(Table tb);

    /// <summary>
    /// Tipo de Impress�o da GDI, para arquivo ou alta resolu��o em impress�o
    /// </summary>
    public enum PrintTypes
    {

        /// <summary>
        /// Define que o componente renderizar� o boleto em um arquivo de imagem
        /// </summary>
        Image,

        /// <summary>
        /// Define que o componente renderizar� o boleto em um dispositivo de impress�o com alta qualidade
        /// </summary>
        Documet
    };

    #endregion

    /// <summary>
    /// Classe respons�vel por todos os calculos do boleto.
    /// Modulo10, Modulo11, IPTE, CodBarras, Campo Livre para Bancos
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("29415AAB-5030-4E06-8580-30310C52363F")]
    [ProgId("Boleto")]
    public class Boleto
    {
        #region "Vari�veis"

        /// <summary>
        /// Propor��o padr�o de convers�o (640/170)
        /// </summary>
        public static double defaultEscala = 640 / 170d;

        /// <summary>
        /// Propor��o ideal de convers�o (640/170)
        /// </summary>
        public double Escala = defaultEscala;
        
        /// <summary>
        /// Resolu��o padr�o a ser usado na gera��o das imagens
        /// </summary>
        public static float defaultDPI = 96; // Padr�o do Windows

        /// <summary>
        /// Resolu��o a ser usado na gera��o das imagens
        /// </summary>
        public float DPI = defaultDPI; // Padr�o do Windows
        
        /// <summary>
        /// Tipo de imagem a ser gravada 
        /// (padr�o � BMP por quest�o de compatibilidade com VB6 e sistemas mais antigos)
        /// </summary>
        public static ImageFormat defaultImageSave = ImageFormat.Bmp;

        /// <summary>
        /// Tipo de imagem a ser gravada
        /// </summary>
        public ImageFormat ImageSave = defaultImageSave;

        /// <summary>
        /// Define um evento para montar o campo livre personalizado
        /// </summary>
        public event BoletoMontaCampoLivre onMontaCampoLivre;

        private System.Drawing.Image _ImageBanco = null;
        private System.Drawing.Image _ImageCorte = null;

        /// <summary>
        /// Obtem a imagem do banco
        /// </summary>
        public System.Drawing.Image ImageBanco
        {
            get
            {
                if (_ImageBanco == null && BancoNumero > 0)
                    _ImageBanco = CobUtil.ResLoadImage(String.Format("{0:000}.gif", BancoNumero));
                return _ImageBanco;
            }
            set
            {
                _ImageBanco = value;
            }
        }

        public System.Drawing.Image ImageCorte
        {
            get
            {
                if (_ImageCorte == null)
                    _ImageCorte = CobUtil.ResLoadImage("corte.gif");
                return _ImageCorte;
            }
            set
            {
                _ImageCorte = value;
            }
        }

        /// <summary>
        /// Define a classe que implementa a renderiza��o dos campos do boleto
        /// </summary>
        public BoletoLayout RenderBoleto { get; set; }

        /// <summary>
        ///  Define se deve usar o layout no formato carne
        /// </summary>
        public bool Carne
        {
            set
            {
                if (value)
                    RenderBoleto = new BoletoCarne();
                else
                    RenderBoleto = new BoletoNormal();
            }
            get
            {
                return RenderBoleto is BoletoCarne;
            }
        }

        public String Moeda = "9";
        private String CodBarras = "";
        private String LinDigitavel = "";
        public String Cedente = "";
        public String CedenteEndereco = "";
        public String CedenteDocumento = "";
        public String CedenteDocumentoTipo = "CPF/CNPJ";
        public String Banco = "";
        public String Agencia = "";
        public String Conta = "";
        public String Carteira = "";
        public String Modalidade = "";
        public String Convenio = "";
        public String CodCedente = "";
        public String SacadoCOD = "";
        public String Sacado = "";
        public String SacadoDocumento = "";
        public String SacadoEndereco = "";
        public String Bairro = "";
        public String Cidade = "";
        public String Cep = "";
        public String UF = "";
        public String Avalista = "";
        public String NumeroDocumento = "";
        public String NossoNumero = "";
        public String NossoNumeroExibicao = "";
        public bool useSantander = false;
        public bool ExibeReciboSacado = true;
        public bool ExibeEnderecoReciboSacado = false;
        public bool ExibeReciboLinhaDigitavel = false;
        public string Informacoes = "";
        public int Quantidade;
        public int ParcelaNumero = 0;
        public int ParcelaTotal = 0;
        public string MoedaEspecie = "R$";
        public double ValorUnitario;
        public double ValorDocumento;
        public double ValorDesconto;
        public double ValorAcrescimo;
        /// <summary>
        /// Se este valor n�o for definido ser� usado como o valor do documento
        /// </summary>
        public double ValorCobrado;
        public double ValorOutras;
        public double ValorMoraMulta;
        public DateTime DataDocumento;
        public DateTime DataVencimento;
        public DateTime DataProcessamento;
        public String Demonstrativo;
        public String Instrucoes;
        public String LocalPagamento = BoletoTextos.LocalPagamento;
        public String Aceite = "N";
        public Especies Especie;
        public String UsoBanco = "";
        public String CIP = "";
        public string CarteiraExibicao;
        public string AgenciaConta;
        public int CedenteLogoHeight = 20;
        internal string BancoDigito = "";

        public Bitmap CedenteLogo { get; set; }

        public int BancoNumero { get { return CobUtil.GetInt(this.Banco.Split('-')[0]); } }

        public string BancoCodigo
        {
            get
            {
                string cCod = CobUtil.Right(this.BancoNumero.ToString(), 3);
                if (this.BancoDigito != "")
                    return cCod + "-" + this.BancoDigito;
                else
                    return cCod;
            }
        }

        /// <summary>
        /// Retorna o c�digo de barras
        /// </summary>
        public string CodigoBarras { get { return CodBarras; } }

        /// <summary>
        /// Retorna a linha digit�vel (IPTE)
        /// </summary>
        public string LinhaDigitavel { get { return LinDigitavel; } }

        #endregion

        #region "Fun��es"

        /// <summary>
        /// Retorna o C�digo de barras com os campos separados por ponto e espe�o
        /// </summary>
        /// <param name="TamanhosCampoLivre">Tamanho dos peda�oes do campo livre</param>
        public string CodigoBarrasFormatado(int[] TamanhosCampoLivre)
        {
            return CobUtil.CodigoBarrasFormatado(CodigoBarras, TamanhosCampoLivre);
        }

        /// <summary>
        /// Carrega as vari�veis internas do boleto
        /// </summary>
        /// <param name="Cedente">Informa��es do Cedente</param>
        /// <param name="Sacado">Informa��es do Sacado</param>
        /// <param name="Boleto">Informa��es do Boleto</param>
        public void MakeBoleto(CedenteInfo Cedente, SacadoInfo Sacado, BoletoInfo Boleto)
        {
            this.Cedente = Cedente.Cedente;
            if (!string.IsNullOrEmpty(Cedente.CNPJ))
            {
                this.CedenteDocumentoTipo = (Cedente.Tipo == 1 ? "CPF" : "CNPJ");
                this.CedenteDocumento = Cedente.CNPJ;
            }
            this.Banco = Cedente.Banco;
            this.Agencia = Cedente.Agencia;
            this.Conta = Cedente.Conta;
            this.Carteira = Cedente.Carteira;
            this.Modalidade = Cedente.Modalidade;
            this.Convenio = Cedente.Convenio;
            this.CodCedente = Cedente.CodCedente;
            this.UsoBanco = Cedente.UsoBanco;
            this.CIP = Cedente.CIP;
            this.useSantander = Cedente.useSantander;
            this.CedenteEndereco = Cedente.Endereco;
            this.Informacoes = Cedente.Informacoes;

            this.Sacado = Sacado.Sacado;
            if (!string.IsNullOrEmpty(Sacado.Documento))
                this.SacadoDocumento = (Sacado.Tipo == 1 ? "CPF: " : "CNPJ: ") + Sacado.Documento;
            this.SacadoEndereco = Sacado.Endereco;
            this.Bairro = Sacado.Bairro;
            this.Cidade = Sacado.Cidade;
            this.Cep = Sacado.Cep;
            this.UF = Sacado.UF;
            this.Avalista = Sacado.Avalista;

            this.NumeroDocumento = Boleto.NumeroDocumento;
            this.NossoNumero = Boleto.NossoNumero;
            this.Quantidade = Boleto.Quantidade;
            this.ParcelaNumero = Boleto.ParcelaNumero;
            this.ParcelaTotal = Boleto.ParcelaTotal;
            this.ValorUnitario = Boleto.ValorUnitario;
            this.ValorDocumento = Math.Round(Boleto.ValorDocumento, 2);

            this.ValorAcrescimo = Boleto.ValorAcrescimo;
            this.ValorCobrado = Boleto.ValorCobrado;
            this.ValorOutras = Boleto.ValorOutras;
            this.DataDocumento = Boleto.DataDocumento;
            this.DataVencimento = Boleto.DataVencimento;
            this.DataProcessamento = Boleto.DataProcessamento;
            this.Demonstrativo = Boleto.Demonstrativo;
            this.Instrucoes = Boleto.Instrucoes;
            this.LocalPagamento = Boleto.LocalPagamento ?? BoletoTextos.LocalPagamento;
            this.Aceite = Boleto.Aceite;
            this.Especie = Boleto.Especie;

            // Valores que podem alterar a forma de exibi��o de acordo com o banco
            this.CarteiraExibicao = Cedente.Carteira;
            this.AgenciaConta = this.Agencia + "/" + this.Conta;

            // quando � gerado isntru��o, tamb�m � gerado o calculo da multa quando vencido
            if (Boleto.CalculaMultaMora
            && Boleto.DataVencimento.Date < DateTime.Now.Date // TODAY! Apenas para evitar erros com horario se o vencimento contiver 'horas'
            && (Boleto.ValorMora > 0 || Boleto.PercentualMora>0)
            && Boleto.PercentualMulta > 0)
            {
                int nDias;
                if (Boleto.DataPagamento > Boleto.DataVencimento)
                    nDias = (int)Boleto.DataPagamento.Subtract(DataVencimento).TotalDays;
                else
                    nDias = (int)DateTime.Now.Subtract(DataVencimento).TotalDays;
                
                if(Boleto.PercentualMora>0 && Boleto.ValorMora==0)
                    // http://calculoexato.com.br/parprima.aspx?codMenu=DividBoletoVencido
                    // http://exame.abril.com.br/seu-dinheiro/ferramentas/boleto-vencido.shtml
                {
                    double nValorComMulta = (1 + Boleto.PercentualMulta) * Boleto.ValorDocumento;
                    double nValorMora = nValorComMulta * Boleto.PercentualMora * nDias;
                    this.ValorMoraMulta = Boleto.PercentualMulta * Boleto.ValorDocumento + nValorMora;
                }
                else
                    this.ValorMoraMulta = Boleto.PercentualMulta * Boleto.ValorDocumento + Boleto.ValorMora * nDias;

                if (this.ValorMoraMulta < 0.01)
                    this.ValorMoraMulta = 0.01;
                else
                    this.ValorMoraMulta = Math.Round(this.ValorMoraMulta, 2);
            }
            if (Boleto.DataDesconto != DateTime.MinValue && Boleto.DataDesconto >= DateTime.Now)
                this.ValorDesconto = Boleto.ValorDesconto;
            else
                this.ValorDesconto = Boleto.ValorDesconto;
        }

        /// <summary>
        /// Calculao c�digo de Barras e a linha digit�vel (IPTE)
        /// </summary>
        public void CalculaBoleto()
        {
            CalcCodBar();
            LinDigitavel = CobUtil.CalcLinDigitavel(this.CodBarras);

            if (RenderBoleto == null)
                RenderBoleto = new BoletoNormal();

            if (RenderBoleto.Count == -1)
                RenderBoleto.MakeFields(this);
        }

        /// <summary>
        /// Desenha a imagem do boleto em um coponente de imagem COM do Windows hDC
        /// </summary>
        public void Desenha(IntPtr hDC, int tamanhoDaParteDeCima, int escala)
        {
            try
            {
                if (LinhaDigitavel == "")
                    CalculaBoleto();

                Impactro.WindowsControls.BoletoForm wBol = new WindowsControls.BoletoForm(this);
                Graphics g = Graphics.FromHdc(hDC);
                wBol.Print(g, tamanhoDaParteDeCima, escala);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        public FieldDraw AddFieldDraw(int nX, int nY, string cCampo, string cValor)
        {
            if (LinhaDigitavel == "")
                CalculaBoleto();
            
            FieldDraw fd = new FieldDraw(nX, nY, cCampo, cValor);
            RenderBoleto.Add(fd);
            return fd;
        }

        public FieldDraw AddFieldDraw(int nX, int nY, string cCampo, string cValor, int nWidth, int nHeight)
        {
            if (LinhaDigitavel == "")
                CalculaBoleto();

            FieldDraw fd = new FieldDraw(nX, nY, cCampo, cValor, nWidth, nHeight);
            RenderBoleto.Add(fd);
            return fd;
        }

        /// <summary>
        /// Retorna uma imagem de um Boleto j� rederizada
        /// </summary>
        /// /// <returns>Imagem Bitmap</returns>
        public Bitmap ImageBoleto( int tamanhoDaParteDeCima)
        {
            return ImageBoleto(null, tamanhoDaParteDeCima);
        }

        /// <summary>
        /// Retorna uma imagem de um Boleto j� rederizada
        /// </summary>
        /// <returns>Imagem Bitmap</returns>
        public Bitmap ImageBoleto(BoletoLayout bLayout, int tamanhoDaParteDeCima)
        {
            if (bLayout != null)
                RenderBoleto = bLayout;

            if (LinhaDigitavel == "")
                CalculaBoleto();
            
            Bitmap bmp = NewImage();
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            Render(g, tamanhoDaParteDeCima);
            g.Flush();

            return bmp;
        }

        /// <summary>
        /// Renderiza um boleto por meio de um ponteiro Graphics
        /// </summary>
        public void Render(Graphics g, int tamanhoDaParteDeCima)
        {
            if (RenderBoleto == null)
                RenderBoleto = new BoletoNormal();

            if (RenderBoleto.Count == -1)
                RenderBoleto.MakeFields(this);

            RenderBoleto.Render(g, Escala, tamanhoDaParteDeCima);
        }

        /// <summary>
        /// Cria a imagem do tamanho correto ( Adicionado novos recursos por Alexandre Savelli Bencz )
        /// </summary>
        public Bitmap NewImage()
        {
            if (LinhaDigitavel == "")
                CalculaBoleto();

            if (RenderBoleto == null)
                RenderBoleto = new BoletoNormal();

            if (RenderBoleto.Count == -1)
                RenderBoleto.MakeFields(this);

            int w = (int)(Escala * RenderBoleto.Width); // Retorna em pixels
            int h = (int)(Escala * RenderBoleto.Height); // Retorna em pixels
            return new Bitmap(w, h);
        }

        /// <summary>
        /// Salva a imagem do boleto em um arquivo de imagem ( corrigido por Alexandre Savelli Bencz )
        /// </summary>
        public void Save(string cFileName, int tamanhoDaParteDeCima, int escala)
        {
            try
            {
                if (LinhaDigitavel == "")
                    CalculaBoleto();

                Impactro.WindowsControls.BoletoForm wBol = new WindowsControls.BoletoForm(this);
                wBol.PrintType = Impactro.Cobranca.PrintTypes.Image;
                Bitmap img = NewImage();
                img.SetResolution(DPI, DPI);
                Graphics g = Graphics.FromImage(img);
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                wBol.Print(g, tamanhoDaParteDeCima, escala);
                img.Save(cFileName, ImageSave);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace, "ERRO", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        #endregion

        #region "Bancos e Carteiras suportadas"

        private void CalcCodBar()
        {

            #region "�rea comum a todos os bancos"

            string cCodePadrao, cDV, cLivre = "";
            string cBanco = this.Banco.Split('-')[0];
            string cCalcFat = CobUtil.CalcFatVenc(this.DataVencimento).ToString();
            string cNossoNumero = this.NossoNumero.Split('-', '/')[0];
            string cAgenciaNumero = this.Agencia.Split('-', '/')[0];
            string cContaNumero = this.Conta.Split('-', '/')[0];
            string cCarteira = this.Carteira;
            string cModalidade = this.Modalidade;
            string cCodCedente = this.CodCedente.Split('-', '/')[0];
            string cCedente = this.Cedente;
            string cConvenio = this.Convenio.Split('-', '/')[0];
            string cValor = this.ValorCobrado > 0 ? this.ValorCobrado.ToString() : this.ValorDocumento.ToString();

            cValor = cValor.Replace(".", ",");
            if (cValor.IndexOf(",") != -1)
            {
                cValor += "00";
                int n = cValor.IndexOf(",");
                cValor = cValor.Substring(0, n) + cValor.Substring(n + 1, 2);
            }
            else
                cValor = cValor + "00";

            cCodePadrao = CobUtil.Right(cBanco, 3) +
                this.Moeda +
                CobUtil.Right(cCalcFat, 4) +
                CobUtil.Right(cValor, 10);

            #endregion

            if (onMontaCampoLivre != null)
            {
                #region "Banco/Carteira personalizada - definida pelo usu�rio"
                string[] cDIG = this.Banco.Split('-');

                if (cDIG.Length > 1)
                    BancoDigito = cDIG[1];

                cLivre = onMontaCampoLivre(this);
                if (cLivre == null ||
                    cLivre.Length != 25)
                    throw new Exception("onMontaCampoLivre � nulo ou n�o retorna 25 posi��es");
                else
                {
                    int n;
                    string cValidChars = "0123456789";
                    for (n = 0; n < 25; n++)
                    {
                        if (cValidChars.IndexOf(cLivre.Substring(n, 1)) == -1)
                            throw new Exception("Caracter inv�lido na " + n.ToString() + "� posi��o da string '" + cLivre + "'");
                    }
                }
                #endregion
            }
            else
            {
                // Verifica se o banco n�o foi especificado
                if (cBanco == "")
                {
                    CodBarras = new String('0', 44);
                    return;
                }

                #region Bancos
                //Montegem do campo livre
                switch (Int32.Parse(cBanco))
                {
                    case 1:	// BANCO DO BRASIL

                        BancoDigito = Banco_do_Brasil.BancoDigito;
                        cLivre = Banco_do_Brasil.CampoLivre(this, cAgenciaNumero, cContaNumero, cConvenio, cModalidade, cCarteira, cNossoNumero);
                        break;

                    case 21: // BANESTES

                        BancoDigito = Banco_Banestes.BancoDigito;
                        cLivre = Banco_Banestes.CampoLivre(this, cCodCedente, cModalidade, cNossoNumero);
                        break;

                    case 27: // BESC

                        BancoDigito = Banco_BESC.BancoDigito;
                        cLivre = Banco_BESC.CampoLivre(cConvenio, cCarteira, cNossoNumero);
                        break;

                    case 33: // BANESPA SANTANDER

                        BancoDigito = Banco_Banespa.BancoDigito;
                        if (useSantander || (cModalidade != null && cModalidade.ToUpper() == "SANTANDER")) // Todo: ideal: (cCarteira == "101" || cCarteira == "102" || cCarteira == "201")) //
                            cLivre = Banco_Santander.CampoLivre(this, cCodCedente, cCarteira, cNossoNumero, cModalidade);
                        else
                            cLivre = Banco_Banespa.CampoLivre(this, cCodCedente, cNossoNumero);

                        break;

                    case 41: // BARINSUL

                        BancoDigito = Banco_Banrisul.BancoDigito;
                        cLivre = Banco_Banrisul.CampoLivre(this, cAgenciaNumero, cCodCedente, cNossoNumero);
                        break;

                    case 47: // BANESE

                        BancoDigito = Banco_Banese.BancoDigito;
                        cLivre = Banco_Banese.CampoLivre(this, this.Agencia, cCodCedente, cNossoNumero);
                        break;

                    case 70: // BRB

                        BancoDigito = Banco_BRB.BancoDigito;
                        cLivre = Banco_BRB.CampoLivre(this, cAgenciaNumero, cContaNumero, cCarteira, cNossoNumero);
                        break;

                    case 91: // UNICRED

                        BancoDigito = Banco_UniCred.BancoDigito;
                        cLivre = Banco_UniCred.CampoLivre(this, cAgenciaNumero, cContaNumero, cNossoNumero);
                        break;

                    case 104: // CAIXA ECONOMICA FEDERAL

                        BancoDigito = Banco_Caixa.BancoDigito;
                        cLivre = Banco_Caixa.CampoLivre(this, cAgenciaNumero, cCodCedente, cConvenio, cCarteira, cNossoNumero);
                        break;

                    case 151: // NOSSA CAIXA

                        BancoDigito = Banco_NossaCaixa.BancoDigito;
                        cLivre = Banco_NossaCaixa.CampoLivre(this, cAgenciaNumero, cContaNumero, cModalidade, cNossoNumero);
                        break;

                    case 237: // BRADESCO

                        BancoDigito = Banco_Bradesco.BancoDigito;
                        cLivre = Banco_Bradesco.CampoLivre(this, cAgenciaNumero, cContaNumero, cCarteira, cNossoNumero, cModalidade);
                        break;

                    case 341: // ITAU

                        BancoDigito = Banco_Itau.BancoDigito;
                        cLivre = Banco_Itau.CampoLivre(this, cAgenciaNumero, cContaNumero, cCarteira, cCodCedente, cNossoNumero, NumeroDocumento);
                        break;

                    case 347: // SUDAMERIS

                        BancoDigito = Banco_Sudameris.BancoDigito;
                        cLivre = Banco_Sudameris.CampoLivre(this, cAgenciaNumero, cContaNumero, cNossoNumero);
                        break;

                    case 353: // SANTANDER

                        BancoDigito = Banco_Santander.BancoDigito;
                        cLivre = Banco_Santander.CampoLivre(this, cCodCedente, cCarteira, cNossoNumero, cModalidade);
                        break;

                    case 356: // REAL

                        BancoDigito = Banco_Real.BancoDigito;
                        cLivre = Banco_Real.CampoLivre(this, cAgenciaNumero, cContaNumero, cNossoNumero);
                        break;

                    case 389: // MERCANTIL

                        BancoDigito = Banco_Mercantil.BancoDigito;
                        cLivre = Banco_Mercantil.CampoLivre(this, cAgenciaNumero, cCodCedente, cModalidade, cNossoNumero);
                        break;

                    case 399: // HSBC

                        BancoDigito = Banco_HSBC.BancoDigito;
                        cLivre = Banco_HSBC.CampoLivre(this, cAgenciaNumero, cContaNumero, cCodCedente, cModalidade, cCarteira, cNossoNumero);
                        break;

                    case 409: // UNIBANCO

                        BancoDigito = Banco_Unibanco.BancoDigito;
                        cLivre = Banco_Unibanco.CampoLivre(this, cCodCedente, cModalidade, cNossoNumero);
                        break;

                    case 422: // SAFRA

                        BancoDigito = Banco_Safra.BancoDigito;
                        cLivre = Banco_Safra.CampoLivre(this, cCarteira, cCodCedente, Agencia, Conta, cNossoNumero);
                        break;

                    case 745: // CITIBANK

                        BancoDigito = Banco_CitiBank.BancoDigito;
                        cLivre = Banco_CitiBank.CampoLivre(this, cCodCedente, cModalidade, cNossoNumero);
                        break;

                    case 748: // SICREDI

                        BancoDigito = Banco_Sicredi.BancoDigito;
                        cLivre = Banco_Sicredi.CampoLivre(this, cAgenciaNumero, cModalidade, cCodCedente, cNossoNumero, cCarteira);
                        break;

                    case 756: // SICOOB

                        BancoDigito = Banco_SICOOB.BancoDigito;
                        cLivre = Banco_SICOOB.CampoLivre(this, cCarteira, this.ParcelaNumero.ToString(), cConvenio, cModalidade, cCodCedente, cNossoNumero);
                        break;

                    default:
                        // Erro: Banco n�o implementado
                        throw new Exception("Banco invalido ou ainda n�o implementado");
                }
                #endregion
            }

            if (cLivre.Length != 25)
                throw new Exception("O Campo Livre deve conter exatamente 25 posi��es!\n'" + cLivre + "' Length=" + cLivre.Length.ToString());
            if (cBanco == "151") // Caso especial para Nossa Caixa
                cDV = CobUtil.Modulo11Especial(cCodePadrao + cLivre, 9).ToString();
            else
                cDV = CobUtil.Modulo11Padrao(cCodePadrao + cLivre, 9).ToString();

            CodBarras = cCodePadrao.Substring(0, 4) + cDV + cCodePadrao.Substring(4, 14) + cLivre;

        }

        /// <summary>
        /// Define o IPTE
        /// </summary>
        public void SetIPTE(string cIPTE)
        {
            LinDigitavel = cIPTE;
        }

        /// <summary>
        /// Defino o C�digo de Barras
        /// </summary>
        public void SetCodBar(string cCodBar)
        {
            CodBarras = cCodBar;
        }

        #endregion

    }
}