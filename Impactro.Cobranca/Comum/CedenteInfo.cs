// Autor: F�bio Ferreira de Souza 
// email: fabio@impactro.com.br
// Sites: www.impactro.com.br / www.boletoasp.com.br

using System;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Impactro.Layout;

namespace Impactro.Cobranca
{
    /// <summary>
    /// Classe respons�vel pelas informa��es do Cedente de um boleto
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("0BABF45A-C06E-4895-AFE5-64C430859B8E")]
    [ProgId("CedenteInfo")]
    public class CedenteInfo
    {

        public string Id;

        /// <summary>
        /// Um c�digo do cedente para remessa.
        /// </summary>
        public string CedenteCOD;

        /// <summary>
        /// Nome do Cedente, Pessoa Juridica ou F�sica, titular da conta
        /// </summary>
        public string Cedente;

        /// <summary>
        /// C�digo do Banco no format 999-9, informe sempre o C�digo do Banco e o digito
        /// </summary>
        public string Banco;

        /// <summary>
        /// Agencia do Banco respons�vel pela conta do cedente
        /// </summary>
        public string Agencia;

        /// <summary>
        /// Numero da conta do Cedente
        /// </summary>
        public string Conta;

        /// <summary>
        /// C�digo Carteira do convenio do Titulo de Cobran�a
        /// (opcional para alguns bancos)
        /// </summary>
        public string Carteira;

        /// <summary>
        /// SubTipo da Carteira
        /// </summary>
        public string CarteiraTipo;

        /// <summary>
        /// C�digo da modalidade ou logica nescess�ria para a gera��o do boleto
        /// (opcional para alguns bancos)
        /// </summary>
        public string Modalidade;

        /// <summary>
        /// C�digo do convenio que representa a agencia/conta do cedente ou algum contrato junto ao banco
        /// (opcional para alguns bancos, veja tamb�m 'CodCedente')
        /// </summary>
        public string Convenio;

        /// <summary>
        /// C�digo do cendente junto ao banco que representa agencia/conta, ou algum contrato junto ao banco
        /// (opcional para alguns bancos, veja tamb�m 'Convenio')
        /// </summary>
        public string CodCedente;

        /// <summary>
        /// C�digo interno do uso do Banco para CIP
        /// </summary>
        public string UsoBanco;

        /// <summary>
        /// Codigo CIP
        /// </summary>
        public string CIP;

        /// <summary>
        /// Apenas para o banco Banespa, quando � necess�rio que seja emitido o boleto pelo layout do Santander
        /// </summary>
        public bool useSantander;

        /// <summary>
        /// Endere�o do Cedente
        /// </summary>
        public string Endereco;

        /// <summary>
        /// Pra�a da Agencia (Bairro)
        /// </summary>
        public string Praca;

        /// <summary>
        /// CNPJ do Cedente (ou CPF)
        /// </summary>
        public string CNPJ;

        /// <summary>
        /// Informa��es que ser�o exibidas no final do boleto
        /// </summary>
        public string Informacoes;

        public LayoutTipo Layout = LayoutTipo.Auto;

        /// <summary>
        /// Cria uma instancia das informa��es do Cedente com todos os dados em branco
        /// </summary>
        public CedenteInfo()
        {
            CedenteCOD = "";
            Cedente = "";
            Banco = "";
            Agencia = "";
            Conta = "";
            Carteira = "";
            Convenio = "";
            CodCedente = "";
            Modalidade = "";
            UsoBanco = "";
            CIP = "";
            useSantander = false;
            //ExibirCedenteEndereco = false;
            //ExibirCedenteDocumento = false;
            Informacoes = "";
            Layout = LayoutTipo.Auto;
        }

        /// <summary>
        /// Retorna somente os digitos do numero do CNPJ
        /// </summary>
        public string DocumentoNumeros
        {
            get
            {
                return CobUtil.SoNumeros(CNPJ);
                //if (CNPJ == null)
                //    return null;
                //Regex re = new Regex(@"\d");
                //Match m = re.Match(CNPJ);
                //string cOut = "";
                //while (m.Success)
                //{
                //    cOut += m.Value;
                //    m = m.NextMatch();
                //}
                //return cOut;
            }
        }

        /// <summary>
        /// Retorna 1 para CPF ou 2 para CNPJ
        /// </summary>
        public int Tipo
        {
            get
            {
                if (CNPJ != null && DocumentoNumeros.Length == 14)
                    return 2; // CNPJ
                else
                    return 1; // CPF
            }
        }
    }

}
