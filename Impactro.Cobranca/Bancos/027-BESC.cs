using System;
using System.Text;
using System.ComponentModel;

namespace Impactro.Cobranca
{
    /// <summary>
    /// Rotinas para o Baco BESC
    /// </summary>
    public abstract class Banco_BESC
    {
        /// <summary>
        /// Digito do C�digo do Banco
        /// </summary>
        public const string BancoDigito = "2";

        /// <summary>
        /// Rotina de Gera��o do Campo livre usado no C�digo de Barras para formar o IPTE
        /// </summary>
        /// <param name="blt">Intancia da Classe de Boleto</param>
        /// <returns>String de 25 caractere que representa 'Campo Livre'</returns>
        public static string CampoLivre(string cConvenio, string cCarteira, string cNossoNumero)
        {
            cConvenio = CobUtil.Right(cConvenio, 5);
            cCarteira = CobUtil.Right(cCarteira, 2);
            cNossoNumero = CobUtil.Right(cNossoNumero, 13);

            if (CobUtil.GetInt(cConvenio) == 0)
                throw new Exception("Informe o c�digo do convenio");
            if (CobUtil.GetInt(cCarteira) == 0)
                throw new Exception("Informe o a carteira");

            string cLivre = cConvenio + cNossoNumero.Substring(0, 3) + cCarteira + cNossoNumero.Substring(3) + "027";

            cLivre = cLivre + CobUtil.Modulo10(cLivre);
            cLivre = cLivre + CobUtil.Modulo11Padrao(cLivre, 7);

            return cLivre;
        }
    }

}
