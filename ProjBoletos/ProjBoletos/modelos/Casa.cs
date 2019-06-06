using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
   public class Casa {

      public string id { get; set; }
      public string bairro { get; set; }
      public string cidade { get; set; }
      public string diaVencimento { get; set; }
      public string numHidrometro { get; set; }
      public string numero { get; set; }
      public string rua { get; set; }
      public string uf { get; set; }
      public string cep { get; set; }
      public string referencia { get; set; }

      public Casa(string id, string bairro, string cidade, string diaVencimento, string numHidrometro, string numero, string rua, string uf, string cep) {
         this.id = id;
         this.bairro = bairro;
         this.cidade = cidade;
         this.diaVencimento = diaVencimento;
         this.numHidrometro = numHidrometro;
         this.numero = numero;
         this.rua = rua;
         this.uf = uf;
         this.cep = cep;
      }

      public Casa() {

      }
   }
}
