using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
    public class Medicao {

        public string id { get; set; }
        public string medicao { get; set; }
        public DateTime dataMedicao { get; set; }
        public string boletoGerado { get; set; }

        //[JsonIgnore]
        public DateTime dataBoletoGerado { get; set; }

        public medidor medidor;
        public Sacado sacado;
        public Casa casa;

        public int nivelAtraso = 0;

        //[JsonIgnore]
        public string carteiraSelecionada = "";

        //[JsonIgnore]
        public string contaSelecionadaIndex = "";

        public Medicao(string id, string medicao, DateTime dataMedicao, string boletoGerado, DateTime dataBoletoGerado, medidor medidor, Sacado sacado, Casa casa, int nivelAtraso)
        {
            this.id = id;
            this.medicao = medicao;
            this.dataMedicao = dataMedicao;
            this.boletoGerado = boletoGerado;
            this.dataBoletoGerado = dataBoletoGerado;
            this.medidor = medidor;
            this.sacado = sacado;
            this.casa = casa;
            this.nivelAtraso = nivelAtraso;
        }

        public Medicao() {

        }
    }
}
