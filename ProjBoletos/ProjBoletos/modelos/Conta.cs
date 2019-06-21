using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
   public class Conta {

      public string id { get; set; }
      public string banco { get; set; }
      public string cip { get; set; }
      public string conta { get; set; }
      public string convenio { get; set; }
      public string modalidade { get; set; }
      public string agencia { get; set; }
      public string codigoEmpresa { get; set; }

      public Conta(string id, string banco, string cip, string conta, string convenio, string modalidade, string agencia) {
         this.id = id;
         this.banco = banco;
         this.cip = cip;
         this.conta = conta;
         this.convenio = convenio;
         this.modalidade = modalidade;
         this.agencia = agencia;
      }

      public Conta() {
      }
   }
}
