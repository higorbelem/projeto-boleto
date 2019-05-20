using Impactro.Cobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
    class Sacado {

        public SacadoInfo sacado { get; set; }
        public List<BoletoInfo> boletos = new List<BoletoInfo>();

        public Sacado() {
        }

        public Sacado(SacadoInfo sacado) {
            this.sacado = sacado;
        }

        public Sacado(SacadoInfo sacado, List<BoletoInfo> boletos) {
            this.sacado = sacado;
            this.boletos = boletos;
        }

        public void addBoleto(BoletoInfo boletoInfo) {
            boletos.Add(boletoInfo);
        }

    }
}
