using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
   public class Remessa {

      public string conta { get; set; }
      public string carteira { get; set; }
      public List<Medicao> medicoes { get; set; }

      public Remessa(string conta, string carteira){
         this.conta = conta;
         this.carteira = carteira;
         medicoes = new List<Medicao>();
      }

   }
}
