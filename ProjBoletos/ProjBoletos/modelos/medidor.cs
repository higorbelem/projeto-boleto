using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
    public class medidor {

        public string id { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }

        public medidor(string id, string nome, string cpf) {
            this.id = id;
            this.nome = nome;
            this.cpf = cpf;
        }

        public medidor() {

        }
    }
}
