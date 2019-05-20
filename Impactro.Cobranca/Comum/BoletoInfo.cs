// Autor: F�bio Ferreira de Souza 
// email: fabio@impactro.com.br
// Sites: www.impactro.com.br / www.boletoasp.com.br

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using Impactro.Layout;

namespace Impactro.Cobranca
{
    /// <summary>
    /// Classe que contem os parametros de um boleto, exceto: Sacado e Cedente
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("FA7A8FD9-D041-41AC-8A3A-1C52120FEC98")]
    [ProgId("BoletoInfo")]
    public class BoletoInfo
    {

        /// <summary>
        /// C�digo interno do boleto, dentro de um banco de dados, por exemplo um autonumerador.
        /// Esta informa��o n�o ser� usada apenas para gera��o de remessa no campo: USO DA EMPRESA - IDENTIFICA��O DO T�TULO NA EMPRESA
        /// </summary>
        public int BoletoID;

        /// <summary>
        /// C�digo do Cedente (o mesmo que em CedenteInfo) para relacionar o cedente
        /// Esta informa��o n�o ser� utilizada em nenhum momento pelo componente.
        /// </summary>
        //public int CedenteID;

        /// <summary>
        /// C�digo do Sacado (o mesmo que em SacadoInfo) para relacionar o sacado
        /// Esta informa��o n�o ser� utilizada em nenhum momento pelo componente.
        /// </summary>
        //public int SacadoID;
        public SacadoInfo Sacado { get; private set; }

        /// <summary>
        /// Numero do documento � um numero qualquer apenas de exibi��o, no boleto para identifica��o visual
        /// Este numero pode ou n�o ser o mesmo do NossoNumero, ou BoletoID
        /// </summary>
        public string NumeroDocumento;

        /// <summary>
        /// � uma das principais informa��es do Boleto, este numero n�o deve se repetir, pois � o controle numerico que referencia o boleto junto ao banco.
        /// Este valor, ir� compor o C�digo de Barras e o IPTE, tamb�m � este numero que ser� exibido no extrato de titulos (Boletos) pagos.
        /// </summary>
        public string NossoNumero;

        /// <summary>
        /// Informa��o que ser� exibida no campo quantidade
        /// (veja Valor)
        /// ATEN��O, este 'Valor' n�o � o valor do documento.
        /// </summary>
        public int Quantidade;

        /// <summary>
        /// Valor que ser� exibido no campo Valor
        /// (veja quantidade)
        /// </summary>
        public double ValorUnitario;

        /// <summary>
        /// � o valor efetivo do boleto, este valor ir� compor o c�digo de barras, e o IPTE
        /// </summary>
        public double ValorDocumento;

        /// <summary>
        /// � um valor que ser� apenas exibido no campo 'Valor do Desconto'
        /// </summary>
        public double ValorDesconto;

        #region Adicionado por Alexandre Savelli Bencz
        /// <summary>
        /// Data limite para o Desconto 2
        /// </summary>
        public DateTime DataLimiteDesconto2;

        /// <summary>
        /// Data limite para o Desconto 3
        /// </summary>
        public DateTime DataLimiteDesconto3;

        /// <summary>
        /// Valor do desconto 2
        /// </summary>
        public double ValorDesconto2;
        #endregion

        /// <summary>
        /// Valor do desconto 3
        /// </summary>
        public double ValorDesconto3;

        /// <summary>
        /// � um valor que ser� apenas exibido no campo 'Valor do Acrescimo'
        /// </summary>
        public double ValorAcrescimo;
        /// <summary>
        /// Se zero, ser� usado o valor do documento, caso seja diferente ser� usado este valor
        /// </summary>
        public double ValorCobrado;
        public double ValorOutras;
        public double ValorIOF; // S� para retorno
        public double PercentualMulta;
        public double ValorMora;
        public double PercentualMora;
        public DateTime DataDocumento;
        /// <summary>
        /// Conforme determinado pelo Banco Central do Brasil, por meio das circulares 3.598 e 3.656, em vigor a partir de 28/06/2013,  fica proibido boletos sem valor  e  sem vencimento,  ou com  as informa��es �Vencimento � vista� e �Contra apresenta��o�.
        /// </summary>
        public DateTime DataVencimento;
        public DateTime DataProcessamento;
        public DateTime DataCredito;
        public DateTime DataTarifa;
        public DateTime DataDesconto;
        public string Demonstrativo;
        public string Instrucoes;
        public int Comando;
        public int Instrucao1;
        public int Instrucao2;
        public int DiasProtesto;
        public int DiasBaixa;
        public DateTime DataPagamento;
        public double ValorPago;
        public double ValorLiquido;
        public double ValorTarifa;
        public int SituacaoID;
        public string LocalPagamento;
        public bool CalculaMultaMora;

        /// <summary>
        /// Quando os dados do boleto originarem de um ou mais linhas de um arquivo de retorno
        /// </summary>
        public string LinhaOrigem;

        public void SacadoInit(SacadoInfo sac)
        {
            Sacado = sac;
        }

        /// <summary>
        /// Indicando que o sacado 'aceitou' ('A') o t�tulo, ou ('N') por padr�o.
        /// Quando o pagamento apos o vencimento deve ser feito no banco, vem com o campo "aceite" com o valor "N" (ou seja � o valor padr�o).
        /// Um boleto sem aceite N�O PODE SER PROTESTADO, e se n�o pagar eles s�o cancelados automaticamente sem prejuizo para nenhuma das partes.
        /// J� um boleto com ACEITE � cobrado independentemente de ser pago ou n�o, pois a taxa para gerar o mesmo ser� debitada da conta do credor.
        /// </summary>
        public string Aceite;
        public Especies Especie;

        public int ParcelaNumero;
        public int ParcelaTotal;

        /// <summary>
        /// C�digo da Ocorrencia
        /// </summary>
        public Ocorrencias Ocorrencia; // Para criar registro de cobran�a

        /// <summary>
        /// C�digo de ororrencias do retorno
        /// </summary>
        public OcorrenciaRetorno OcorrenciaRetorno = OcorrenciaRetorno.NaoDefinida; // Para criar registro de cobran�a

        /// <summary>
        /// Tenta defini o c�digo de retorno de uma ocorrencia conhecida
        /// </summary>
        // TODO: melhorar, com op��o de definir o banco
        public int SetOcorrenciaRetorno
        {
            set
            {
                try
                {
                    OcorrenciaRetorno = (OcorrenciaRetorno)value;
                }
                catch (Exception)
                {
                    OcorrenciaRetorno = OcorrenciaRetorno.NaoDefinida;
                }
            }
        }

        private Dictionary<string, object> Reg;

        public BoletoInfo()
        {
            //BoletoID = 0;
            //CedenteID = 0;
            //SacadoID = 0;

            NumeroDocumento = "0";
            NossoNumero = "0";
            Quantidade = 0;
            ValorUnitario = 0;
            ValorDocumento = 0;
            ValorDesconto = 0;
            ValorAcrescimo = 0;
            ValorCobrado = 0;
            DataDocumento = DateTime.Now.Date;
            DataProcessamento = DateTime.Now.Date;
            DataVencimento = DateTime.MinValue;
            Demonstrativo = "";
            Instrucoes = "";
            DataPagamento = DateTime.Now.Date;
            SituacaoID = 0;
            LocalPagamento = BoletoTextos.LocalPagamento;
            Aceite = "N";
            Especie = Especies.DM; // 1
            Ocorrencia = Ocorrencias.Remessa; //1
            ParcelaNumero = 0;
            ParcelaTotal = 0;
            CalculaMultaMora = true;
            Comando = 1; // 01 - Registro de t�tulos

            DataLimiteDesconto2 = DataVencimento;
            DataLimiteDesconto3 = DataVencimento;
            ValorDesconto2 = 0;
            ValorDesconto3 = 0;

            LinhaOrigem = "";
            Reg = new Dictionary<string, object>();
        }

        /// <summary>
        /// Clona os valores e propriedades das informa��es de um boleto. 
        /// Fundamental para obter tamb�m as informa��es de registro complementares
        /// </summary>
        public BoletoInfo Clone()
        {
            BoletoInfo bi = (BoletoInfo)CobUtil.Clone(this);
            foreach (var r in Reg)
                bi.Reg.Add(r.Key, r.Value);

            return bi;
        }

        /// <summary>
        /// Devine o valor de um registro e seu valor
        /// </summary>
        public void SetRegEnumValue(Enum key, object value)
        {
            Type tp = key.GetType();
            Reg[tp.Name + "." + key.ToString()] = value;
        }

        /// <summary>
        /// Define o valor de um campo de registro caso este campo exista e seja suportado pelo layout
        /// </summary>
        public void SetRegKeyValue(string key, object value)
        {
            Reg[key] = value;
        }

        internal void BindReg(IReg ireg)
        {
            foreach (var r in Reg)
                ireg.Set(r.Key, r.Value);
        }

        /// <summary>
        /// Cria o Texto de Instru��es Baseado nos parametros
        /// </summary>
        public void GeraInstrucoes()
        {
            if (Instrucoes == null)
                Instrucoes = "";
            else
                Instrucoes += "<br/>";

            if (PercentualMulta > 0)
                Instrucoes += string.Format("Ap�s vencimento multa de {0}%<br/>", PercentualMulta * 100);

            if (ValorMora > 0)
                Instrucoes += string.Format("Ap�s vencimento mora de {0:C} por dia<br/>", ValorMora);

            if (DiasProtesto > 0)
                Instrucoes += "Protestar " + DiasProtesto + " dias ap�s o vencimento<br/>";

            if (ValorMora > 0 && PercentualMulta > 0 && DataVencimento < DateTime.Now)
            {
                CalculaMultaMora = true;
                Instrucoes += "<br/>(Valor de mora e multa j� calculados)<br/>";
            }
        }
    }

    /// <summary>
    /// Especie do titulo
    /// </summary>
    public enum Especies
    {
        /// <summary>
        /// Duplicata Mercantil
        /// </summary>
        [Description("DM - Duplicata Mercantil")]
        DM = 1,

        /// <summary>
        /// Nota Promiss�ria
        /// </summary>
        [Description("NP - Nota Promiss�ria")]
        NP = 2,

        /// <summary>
        /// Nota de Seguro
        /// </summary>
        [Description("NS - Nota de Seguro")]
        NS = 3,

        /// <summary>
        /// Mensalidade Escolar
        /// </summary>
        [Description("ME - Mensalidade Escolar")]
        ME = 4,

        /// <summary>
        /// Recibo
        /// </summary>
        [Description("RC - Recibo")]
        RC = 5,

        /// <summary>
        /// Contrato
        /// </summary>
        [Description("CT - Contrato")]
        CT = 6,

        /// <summary>
        /// Consessionaria de Seguro
        /// </summary>
        [Description("CS - Consessionaria de Seguro")]
        CS = 7,

        /// <summary>
        /// Duplicata de Servi�o
        /// </summary>
        [Description("DS - Duplicata de Servi�o")]
        DS = 8,

        /// <summary>
        /// Letra de Cambio
        /// </summary>
        [Description("LC - Letra de Cambio")]
        LC = 9,

        /// <summary>
        /// Nota de Debitos
        /// </summary>
        [Description("ND - Nota de Debitos")]
        ND = 13,

        /// <summary>
        /// Documeto de D�vida
        /// </summary>
        [Description("DD - Documeto de D�vida")]
        DD = 15,

        /// <summary>
        /// Encargo Condominiais
        /// </summary>
        [Description("EC - Encargo Condominiais")]
        EC = 16,

        /// <summary>
        /// Conta de Presta��o de Servi�os
        /// </summary>
        [Description("CPS - Conta de Presta��o de Servi�os")]
        CPS = 17,

        /// <summary>
        /// Diversos
        /// </summary>
        [Description("DV - Diversos")]
        DV = 99
    }

    // Vou segui os c�digos padr�o do itau, mas pode ser que outros bancos ussem outros c�digos, assim para padronizar valer� esse sempre
    public enum OcorrenciaRetorno
    {
        NaoDefinida =0,

        NaoIdentificada = 1,

        /// <summary>
        /// ENTRADA CONFIRMADA
        /// </summary>
        Confirmada = 2,

        /// <summary>
        /// LIQUIDA��O NORMAL
        /// </summary>
        LiquidacaoNormal = 6,

        /// <summary>
        /// BAIXA SIMPLES
        /// </summary>
        BaixaSimples = 9,

        /// <summary>
        /// BAIXA POR TER SIDO LIQUIDADO
        /// </summary>
        BaixaLiquidado = 10
    }

    /// <summary>
    /// Tipos de ocorrencia para remessa
    /// </summary>
    public enum Ocorrencias
    {
        /// <summary>
        /// REMESSA => TODOS OS CAMPOS
        /// </summary>
        Remessa = 1,

        /// <summary>
        /// PEDIDO DE BAIXA
        /// </summary>
        Baixa = 2,

        /// <summary>
        /// CONCESS�O DE ABATIMENTO (INDICADOR 12.5) => VALOR DO ABATIMENTO
        /// </summary>
        Abatimento = 4,

        /// <summary>
        /// CANCELAMENTO DE ABATIMENTO => VALOR DO ABATIMENTO
        /// </summary>
        CancelamentoAbatimento = 5,

        /// <summary>
        /// ALTERA��O DO VENCIMENTO => VENCIMENTO
        /// </summary>
        AlterarVencimento = 6,

        /// <summary>
        /// ALTERA��O DO USO DA EMPRESA => USO DA EMPRESA
        /// </summary>
        AlterarUsoEmpresa = 7,

        /// <summary>
        /// ALTERA��O DO SEU N�MERO => SEU N�MERO
        /// </summary>
        AlterarSeuNumero = 8,

        /// <summary>
        ///PROTESTAR (emite aviso ao sacado ap�s xx dias do vencimento, e envia ao cart�rio ap�s 5 dias �teis)
        /// </summary>
        Protestar = 9,

        /// <summary>
        /// N�O PROTESTAR (inibe protesto autom�tico, quando houver instru��o permanente na conta corrente)
        /// </summary>
        NaoProtestar = 10,

        /// <summary>
        ///PROTESTO PARA FINS FALIMENTARES (falencia) 
        /// </summary>
        ProtestoFalimentar = 11,

        /// <summary>
        /// SUSTAR O PROTESTO
        /// </summary>
        SustarProtesto = 18,

        /// <summary>
        /// ALTERA��O DE OUTROS DADOS => CAMPOS A ALTERAR
        /// </summary>
        AlterarDados = 31,

        /// <summary>
        /// BAIXA POR TER SIDO PAGO DIRETAMENTE AO CEDENTE
        /// </summary>
        BaixaPago = 34,

        /// <summary>
        /// CANCELAMENTO DE INSTRU��O => C�DIGO DA INSTRU��O
        /// </summary>
        Cancelamento = 35,

        /// <summary>
        /// PROTESTO URGENTE (envia a cart�rio ap�s XX dias �teis do vencimento)
        /// </summary>
        ProtestoUrgente = 36,

        /// <summary>
        /// ALTERA��O DO VENCIMENTO E SUSTAR PROTESTO => VENCIMENTO
        /// </summary>
        AlterarVencimentoSustarProtesto = 37,

        /// <summary>
        /// CEDENTE N�O CONCORDA COM ALEGA��O DO SACADO => C�DIGO DA ALEGA��O
        /// </summary>
        NaoConcorda = 38,

        /// <summary>
        /// CEDENTE SOLICITA DISPENSA DE JUROS
        /// </summary>
        DispensaJuros = 47
    }
}