using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
    class Medicao {

        public string id { get; set; }
        public string medicao { get; set; }
        public DateTime dataMedicao { get; set; }
        public string boletoGerado { get; set; }

        public medidor medidor;
        public Sacado sacado;
        public Casa casa;

        public Medicao(string id, string medicao, DateTime dataMedicao, string boletoGerado, medidor medidor, Sacado sacado, Casa casa) {
            this.id = id;
            this.medicao = medicao;
            this.dataMedicao = dataMedicao;
            this.boletoGerado = boletoGerado;
            this.medidor = medidor;
            this.sacado = sacado;
            this.casa = casa;
        }

        public Medicao() {

        }
    }
}
