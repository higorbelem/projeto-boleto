using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
   public class Remessa {
      public string id { get; set; }
      public DateTime data { get; set; }
      public string arquivoRemessa { get; set; }
      public string arquivoRetorno { get; set; }
      public string enviado { get; set; }
      public List<Medicao> medicoes { get; set; }

      public Remessa(string id, DateTime data, string arquivoRemessa, string arquivoRetorno, string enviado, List<Medicao> medicoes) {
         this.id = id;
         this.data = data;
         this.arquivoRemessa = arquivoRemessa;
         this.arquivoRetorno = arquivoRetorno;
         this.enviado = enviado;
         this.medicoes = medicoes;
      }

      public Remessa() {

      }
   }
}
