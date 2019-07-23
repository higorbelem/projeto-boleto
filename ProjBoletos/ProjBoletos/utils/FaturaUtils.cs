using ProjBoletos.modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.utils {
   public class FaturaUtils {

      public static int calculaValorMedicao(Medicao medicaoAtual) {
         int valorMedicaoAtual = Int32.Parse(medicaoAtual.medicao);
         int valorMedicaoAnterior = Int32.Parse(medicaoAtual.medicaoAnterior);
         int valorMaximoMedidor = Int32.Parse(medicaoAtual.casa.maxHidrometro);

         int valor = 0;

         if (valorMedicaoAtual < valorMedicaoAnterior) {
            valor = (valorMaximoMedidor - valorMedicaoAnterior) + valorMedicaoAtual;
         } else {
            valor = Int32.Parse(medicaoAtual.medicao) - valorMedicaoAnterior;
         }
         //Console.WriteLine("medicaoAtual: " + valorMedicaoAtual + " medicaoAnterior: " + valorMedicaoAnterior + " valorMaximoMedidor: " + valorMaximoMedidor + " valor: " +valor);
         return valor;
      }

   }
}
