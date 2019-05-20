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

namespace Impactro.Cobranca
{
    /// <summary>
    /// Classe respons�vel pelas informa��es do Sacado de um Boleto
    /// </summary>
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [Guid("1402B8DC-2751-4755-9CAB-689A224D11AD")]
    [ProgId("SacadoInfo")]
    public class SacadoInfo
    {


        
        /// <summary>
        /// C�digo do Interno do Sacado, caso exista, em geral � um c�digo de cliente existente.
        /// S� � usado em alguns arquivos de remessa
        /// </summary>
        public string SacadoCodigo { get; set; }

        /// <summary>
        /// Nome do Sacado, pessoa F�sica ou Juridica que ser� cobrada pelo boleto.
        /// </summary>
        public String Sacado { get; set; }

        /// <summary>
        /// Um N�mero de documento, que identifique o Sacado, ex: CPF, CNPJ, RG, IE, Numero de Contrato, Codigo de Cliente.
        /// </summary>
        public String Documento { get; set; }

        /// <summary>
        /// Endere�o do Sacado (Rua/Avenida, Numero, Complemento)
        /// </summary>
        public String Endereco { get; set; }

        /// <summary>
        /// Bairro do Sacado
        /// </summary>
        public String Bairro { get; set; }

        /// <summary>
        /// Cidade do Sacado
        /// </summary>
        public String Cidade { get; set; }

        /// <summary>
        /// CEP do Sacado
        /// </summary>
        public String Cep { get; set; }

        /// <summary>
        /// Retorna somente os digitos do numero do CNPJ
        /// </summary>
        public string CepNumeros
        {
            get
            {
                return CobUtil.SoNumeros(Cep);
            }
        }
        /// <summary>
        /// Estado do Sacado
        /// </summary>
        public String UF;

        /// <summary>
        /// Campo para informar o nome do Avalista da Opera��o
        /// </summary>
        public String Avalista;

        /// <summary>
        /// Numero do CPF/CNPJ do avalista
        /// </summary>
        public String AvalistaDocumento;
        
        /// <summary>
        /// e-mail para envio (opcional)
        /// </summary>
        public object Email;

        /// <summary>
        /// Cria uma instancia da Classe de informa��es do sacado, com todas as vari�veis e, branco
        /// </summary>
        public SacadoInfo()
        {
            Sacado = "";
            Documento = "";
            Endereco = "";
            Bairro = "";
            Cidade = "";
            Cep = "";
            UF = "";
            Avalista = "";
        }

        /// <summary>
        /// retorna somente os digitos numericos do documento do sacado
        /// </summary>
        public string DocumentoNumeros
        {
            get
            {
                return CobUtil.SoNumeros(Documento);
                //if (Documento == null)
                //    return null;
                //Regex re = new Regex(@"\d");
                //Match m = re.Match(Documento);
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
        /// extrai apenas os digitos numericos da avalista
        /// </summary>
        public string AvalistaNumeros
        {
            get
            {
                return CobUtil.SoNumeros(Avalista);
            }
        }

        /// <summary>
        /// Tipo de documento do sacado (1-CPF, 2-CNPJ)
        /// </summary>
        public int Tipo {
            get
            {
                if (Documento != null && DocumentoNumeros.Length == 14)
                    return 2; // CNPJ
                else
                    return 1; // CPF
            }
        }

        /// <summary>
        /// Tipo de documento do avalista (1-CPF, 2-CNPJ)
        /// </summary>
        public int AvalistaTipo
        {
            get
            {
                if (AvalistaDocumento != null && AvalistaNumeros.Length == 14)
                    return 2; // CNPJ
                else
                    return 1; // CPF
            }
        }
    }
}
