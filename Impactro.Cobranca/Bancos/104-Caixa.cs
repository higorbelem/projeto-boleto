using System;
using System.Text;
using System.ComponentModel;

namespace Impactro.Cobranca
{
    /// <summary>
    /// Rotinas para o Banco Caixa Economica Federal
    /// </summary>
    public abstract class Banco_Caixa
    {
        /// <summary>
        /// Digito do C�digo do Banco
        /// </summary>
        public const string BancoDigito = "0";

        /// <summary>
        /// Rotina de Gera��o do Campo livre usado no C�digo de Barras para formar o IPTE
        /// </summary>
        /// <param name="blt">Intancia da Classe de Boleto</param>
        /// <returns>String de 25 caractere que representa 'Campo Livre'</returns>
        public static string CampoLivre(Boleto blt, string cAgenciaNumero, string cCodCedente, string cConvenio, string cCarteira, string cNossoNumero)
        {
            if (long.Parse(cCodCedente) == 0L)
                throw new Exception("Informe a C�digo de Cedente");

            if (cCodCedente.Length == 15)
            {
                cNossoNumero = CobUtil.Right(cNossoNumero, 10);
                string cLivre = cNossoNumero + cCodCedente;

                blt.NossoNumeroExibicao = cNossoNumero + "-" + CobUtil.Modulo11Especial(cNossoNumero, 9).ToString();
                
                cCodCedente += CobUtil.Modulo11Padrao(cCodCedente, 9).ToString();
                blt.AgenciaConta =
                    cCodCedente.Substring(0, 4) + "/" +
                    cCodCedente.Substring(4, 3) + "." +
                    cCodCedente.Substring(7, 8) + "." +
                    cCodCedente.Substring(15, 1);
                return cLivre;
            }
            else if (CobUtil.GetInt(cCarteira) == 0) // obrigat�rio para os outros casos
                throw new Exception("Informe a Carteira");

            else if (cCodCedente.Length == 6)
            {
                // PADR�O SIGCB (Nosso numero com 7 posi��es)
                // XYNNNNNNNNNNNNNNN-D, onde:
                //(12123456789012345-1)
                // X � Modalidade Cobran�a (1 � Registrada/2 � Sem Registro)
                // Y � Emiss�o do bloqueto (4 � cedente)
                // N - Numeros Livres de identifica��o do Nosso Numero
                // D - Digito do C�digo do Cedente
                // dai apenas 15 s�o de fato uteis!

                cNossoNumero = CobUtil.Right(cNossoNumero, 15);
                string cNN1 = cNossoNumero.Substring(0, 3);
                string cNN2 = cNossoNumero.Substring(3, 3);
                string cNN3 = cNossoNumero.Substring(6, 9);
                
                // digito de verifica��o do c�digo de cedente
                //string cDV1 = CobUtil.Modulo11Especial(cCodCedente, 9).ToString();
                //alterado em 2/12 para modulo padr�o!
                string cDV1 = CobUtil.Modulo11Especial(cCodCedente, 9).ToString();

                cCarteira = CobUtil.Right(cCarteira, 1);
                string cLivre = cCodCedente + cDV1 + // 6 + 1 = 7
                                cNN1 + cCarteira +  // 3 + 1 = 4
                                cNN2 + "4" + cNN3; // 3 + 1 + 9 = 13 (a constante "4" indica emiss�o no CEDENTE
                                // 7 + 4 + 13 = 24

                cLivre += CobUtil.Modulo11Especial(cLivre, 9); // 24 + 1 = 25 OK

                // exibi��o da agencia/conta
                blt.AgenciaConta = cAgenciaNumero + "/" + cCodCedente + "-" + cDV1;

                // exibi��o do nosso numero
                cNossoNumero = cCarteira + "4" + cNossoNumero;
                blt.NossoNumeroExibicao = cNossoNumero + "-" + CobUtil.Modulo11Especial(cNossoNumero, 9).ToString();
                blt.NossoNumeroExibicao = blt.NossoNumeroExibicao.Substring(0, 2) + "/" + blt.NossoNumeroExibicao.Substring(2);

                if (cCarteira == "1")
                    blt.CarteiraExibicao = "RG";
                else // 2
                    blt.CarteiraExibicao = "SR";

                return cLivre;
            }
            else if (cCarteira == "8")
            {
                /* Carteira 8 - Cobran�a sem Registro com 16 de Nosso Numero 
                 * ==========(p�gina 5 do arquivo de documenta��o: Caixa-Carteira8.pdf)
                 * IX - CAMPO LIVRE (posi��es 20 a 44)
                 * Para as posi��es do Campo Livre, informar:
                 * XXXXX AAAA C K NNNNNNNNNNNNNN
                 * Onde:
                 * XXXXX - C�digo do Cliente Cedente fornecido pela CAIXA
                 * AAAA - CNPJ da Ag�ncia da Conta do Cliente Cedente
                 * C - C�digo da Carteira = 8
                 * K - Constante = 7
                 * NNNNNNNNNNNNNN - Nosso N�mero do Cliente com 14 posi��es.
                 * */

                cCodCedente = CobUtil.Right(cCodCedente, 5);    // C�digo do Cedente
                cConvenio = CobUtil.Right(cConvenio, 4);        // CNPJ da Agencia da Conta do Cliente
                cNossoNumero = CobUtil.Right(cNossoNumero, 14); // Nosso Numero com 12 posi��es

                if (Int32.Parse(cConvenio) == 0)
                    throw new Exception("Informe o C�digo do Convenio");

                string cLivre =
                    cCodCedente +
                    cConvenio +
                    cCarteira +     // Carteira 8
                    "7" +           // Constante K
                    cNossoNumero;

                cNossoNumero = "8" + cNossoNumero;
                blt.NossoNumeroExibicao = cNossoNumero + "-" + CobUtil.Modulo11Especial(cNossoNumero, 9).ToString();

                blt.CarteiraExibicao = "SR";

                string cCod = cConvenio + ".870.000" + cCodCedente;
                string cCoddig = cCod.Replace(".", "");
                blt.AgenciaConta = cCod + "-" + CobUtil.Modulo11Padrao(cCoddig, 9);

                return cLivre;
            }
            else
            {
                /* Carteira Padr�o - Cobran�a sem Registro com 17 de Nosso Numero 
                 * ===============(p�gina 5 do arquivo de documenta��o: Caixa-CarteiraPadr�o.pdf)
                 * 1 - Fixo
                 * XXXXXX - C�digo do Cliente Cedente fornecido pela CAIXA
                 * 9 - Fixo
                 * NNNNNNNNNNNNNNNN - Nosso N�mero do Cliente com 17 posi��es.
                 */
                cCodCedente = CobUtil.Right(cCodCedente, 6);           // C�digo do Cliente ser� informado em 'Cedente' e ser� substituido na no Numero da Conta do Cliente!
                cNossoNumero = "9" + CobUtil.Right(cNossoNumero, 17);   // Adiciona o '9' Fixo! mais os 17 numeros do campo 'Nosso Numero'

                string cLivre =
                    "1" +
                    cCodCedente +
                    cNossoNumero;

                // Monta a exibi��o do Nosso Numero com o Digito Verificador
                blt.NossoNumeroExibicao = cNossoNumero + "-" + CobUtil.Modulo11Especial(cNossoNumero, 9);

                return cLivre;
            }
        }
    }
}
