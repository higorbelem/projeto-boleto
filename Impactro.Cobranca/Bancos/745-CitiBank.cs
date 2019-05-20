using System;
using System.Text;
using System.ComponentModel;

namespace Impactro.Cobranca
{

    /// <summary>
    /// Rotinas para o Banco Citibank
    /// </summary>
    public abstract class Banco_CitiBank
    {
        /// <summary>
        /// Digito do C�digo do Banco
        /// </summary>
        public const string BancoDigito = "5";

        /// <summary>
        /// Rotina de Gera��o do Campo livre usado no C�digo de Barras para formar o IPTE
        /// </summary>
        /// <param name="blt">Intancia da Classe de Boleto</param>
        /// <returns>String de 25 caractere que representa 'Campo Livre'</returns>
        public static string CampoLivre(Boleto blt, string cCodCedente, string cModalidade, string cNossoNumero)
        {
            // De acrodo com a documenta��o (pg 5) segue o calculo do digito do nosso numero
            cNossoNumero = CobUtil.Right(cNossoNumero, 11); // For�a ter 11 digitos
            cModalidade = CobUtil.Right(cModalidade, 3); // Portf�lio, 3 �ltimos d�gitos do campo de identifica��o da empresa
            cCodCedente = CobUtil.Right(cCodCedente, 9); // 'Conta COSMOS (somente numeros, sem o indice - 1 digito) 0/123456/789

            if (CobUtil.GetInt(cCodCedente) == 0)
                throw new Exception("Informe o C�digo de Cedente");
            if (CobUtil.GetInt(cModalidade) == 0)
                throw new Exception("Informe a Modalidade");

            string cDV  = CobUtil.Modulo11Padrao(cNossoNumero, 9).ToString(); // Calcula o digito verificador
            blt.NossoNumeroExibicao = blt.NossoNumero + "." + cDV; // formata o numero com o digito na tela
            cNossoNumero += cDV; //acrescenta o digito no boleto

            //De acordo com a documenta��o (pg 9) os 25 caracteres do campo livre s�o
            //TAM - Descri��o
            //  1 - C�digo do Produto 3 - Cobran�a com registro / sem registro
            //  3 - Portf�lio, 3 �ltimos d�gitos do campo de identifica��o da empresa no CITIBANK (Posi��o 44 a 46 do arquivo retorno)
            //  6 - Base da conta COSMOS (pg 13, veja abaixo)
            //  2 - Seq��ncia da conta COSMOS (pg 13, veja abaixo)
            //  1 - D�gito Conta COSMOS (pg 13, veja abaixo)
            // 12 - Nosso N�mero 
            //----
            // 25 - Total (campo livre)

            //De acordo com a documenta��o (pg 13) temos a configura��o da CONTA COSMOS
            //Ex.: 0/ 123456/ 789 = Conta Cosmos
            //     0 �ndice
            //123456 Base (Posi��o 24 a 29)
            //    78 Seq��ncia (Posi��o 30 a 31)
            //     9 D�gito Verificador (Posi��o 32)

            //Parametros:
            //O c�digo da conta COSMOS ficar� no campo 'CodCedente' somento os numeros 123456789
            //O c�digo do portfolio ficar� no campo 'Modalidade'

            string cLivre = "3" +
                cModalidade +
                cCodCedente +
                cNossoNumero;

            return cLivre;
        }
    }
}
