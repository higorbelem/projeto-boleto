using System;
using System.Text;
using System.ComponentModel;

namespace Impactro.Cobranca
{
    /// <summary>
    /// Rotinas para o Banco Sicredi
    /// </summary>
    public abstract class Banco_Sicredi
    {
        /// <summary>
        /// Digito do C�digo do Banco
        /// </summary>
        public const string BancoDigito = "X";

        /* do arquivo: Sicred_Manual_Beneficiario_Cobranca_CNAB_400 == Atualizado 21/05/2015
        * pag 7
        5.4 F�rmula para c�lculo do d�gito verificador pelo m�dulo 11
        a) Relacionar os c�digos da cooperativa de 
        cr�dito/ag�ncia benefici�ria (aaaa), 
        posto benefici�rio (pp), 
        do benefici�rio (ccccc), 
        ano atual (yy), 
        indicador de gera��o do nosso n�mero (b) (1: Ag�ncia cedente, 2 a 9: Cedente) e 
        o n�mero seq�encial do benefici�rio (nnnnn): 
        aaaappcccccyybnnnnn;

        * pag 28
        Se a impress�o for pela Sicredi (A) � poss�vel deixar em branco (sem preenchimento - gerado automaticamente pelo Banco) ou informar "Nosso N�mero" devidamente preenchido. Se for impress�o pelo Cedente (B) - informar o "Nosso N�mero" conforme exemplo informa��es abaixo:
        13 - ano atual
        2 a 9 - byte de gera��o "somente ser� "1" se forem boletos pr�-impressos".
        xxxxx - n�mero sequencial
        d - d�gito verificador calculado ou seja, a nomenclatura correta �: 132xxxxxD => yybnnnnnd

        * pag 51 
        10.7.1 Composi��o do campo livre do c�digo de barras dos boletos do produto Sicredi cobran�a para impress�o completa dos boletos pelo benefici�rio: 
        Posi��o / Tamanho / Conte�do
C         20 � 20 01 C�digo num�rico correspondente ao tipo de cobran�a: �1� � Com Registro �3 � Sem Registro�. Obs.: O SICREDI n�o validar� este campo.
R         21 � 21 01 C�digo num�rico correspondente ao tipo de carteira: �1� - carteira simples
yybnnnnnd 22 � 30 09 Nosso n�mero (Ano/Controle/Sequencial/DAC)
AAAA      31 � 34 04 Cooperativa de cr�dito/ag�ncia benefici�ria
PP        35 � 36 02 Posto da cooperativa de cr�dito/ag�ncia benefici�ria
CCCCC     37 � 41 05 C�digo do benefici�rio
V         42 � 42 01 Ser� 1 (um) quando houver valor expresso no campo �valor do documento�
0         43 � 43 01 Filler � zeros �0�
D         44 � 44 01 DV do campo livre calculado por m�dulo 11 com aproveitamento total (resto igual a 0 ou 1 DV cai para 0)
  Final: CRyybnnnnndAAAAPPCCCCCV0D
        */
        /// <summary>
        /// Rotina de Gera��o do Campo livre usado no C�digo de Barras para formar o IPTE
        /// </summary>
        /// <param name="blt">Intancia da Classe de Boleto</param>
        /// <returns>String de 25 caractere que representa 'Campo Livre'</returns>
        public static string CampoLivre(Boleto blt, string cAgenciaNumero, string cModalidade, string cCodCedente, string cNossoNumero, string cCarteira)
        {
            if (CobUtil.GetInt(cCodCedente) == 0)
                throw new Exception("Informe o C�digo de Cedente");
            if (CobUtil.GetInt(cModalidade) == 0)
                throw new Exception("Informe o Numero do 'Posto' na Modalidade");
            if (CobUtil.GetInt(cCarteira) != 1 && CobUtil.GetInt(cCarteira) != 3)
                throw new Exception("N�mero de carteira inv�lido, informe 1=Registrada ou 3=Sem registro");

            cCarteira = CobUtil.Right(cCarteira, 1);

            MontaNossoNumero(ref cNossoNumero, ref cAgenciaNumero, ref cModalidade, ref cCodCedente);

            blt.NossoNumeroExibicao =
                //cAgenciaNumero +
                //cModalidade + "." +
                //cCodCedente + "." +
                //cNossoNumero;
                cNossoNumero.Substring(0, 2) + "/" +
                cNossoNumero.Substring(2, 6) + "-" +
                cNossoNumero.Substring(8, 1);

            blt.AgenciaConta =
                cAgenciaNumero + "." +
                cModalidade + "." +
                cCodCedente;

            // TODO: Criar algum campo que identifique quando for registrado, ou identificar pela carteira
            string cLivre =         // Anterior + Atual = Noto Total
                 cCarteira +        // 0+1=1 (1-Com Registro, ou 3-SEM REGISTRO)
                "1" +               // 1+1=2
                cNossoNumero +      // 2+9=11
                cAgenciaNumero +    // 11+4=15
                cModalidade +       // 15+2=17
                cCodCedente +       // 17+5=22
 (blt.ValorDocumento > 0 ? "1" : "0") + // 22+1=23
                "0";                // 23+1=24

            blt.CarteiraExibicao = "1"; // Carteira Simples

            // Digito verificador geral do Campo Livre
            string cDV = CobUtil.Modulo11Especial(cLivre, 9).ToString();
            cLivre += cDV;          // 24+1=25 posi��es o campo livre - OK

            return cLivre;
        }

        /* Sicred_Manual_Beneficiario_Cobranca_CNAB_400.pdf - P�gina 7
        AA/BXXXXX-D
        AA = Ano atual
        B = Byte (2 a 9). 1 s� poder� ser utilizado pela cooperativa.
        XXXXX � N�mero livre de 00000 a 99999.
        D = Digito Verificador pelo m�dulo 11.
        */
        public static void MontaNossoNumero(ref string cNossoNumero, ref string cAgenciaNumero, ref string cModalidade, ref string cCodCedente)
        {
            cNossoNumero = CobUtil.Right(cNossoNumero, 5);
            cAgenciaNumero = CobUtil.Right(cAgenciaNumero, 4);
            cModalidade = CobUtil.Right(cModalidade, 2); // Posto da Ag�ncia cedente - ser� colocado em modalidade
            cCodCedente = CobUtil.Right(cCodCedente, 5);

            cNossoNumero = string.Format("{0:yy}2", DateTime.Now) + // 3
                           cNossoNumero;                            // 3+5=8

            // Digito Verificado s� do Nosso Numero: aaaappcccccyybnnnnn
            // Aqui o nossonumero j� est� com o yybnnnnn

            string cDV = CobUtil.Modulo11Especial(
                cAgenciaNumero +
                cModalidade +
                cCodCedente +
                cNossoNumero, 9).ToString();

            cNossoNumero += cDV; // 8+1=9
        }
    }
}