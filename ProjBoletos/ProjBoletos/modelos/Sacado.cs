using Impactro.Cobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
    class Sacado {

        public string id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string documento { get; set; }
        public string avalista { get; set; }
        public string avalistaDocumento { get; set; }

        public Sacado(string id, string nome, string email, string documento, string avalista, string avalistaDocumento) {
            this.id = id;
            this.nome = nome;
            this.email = email;
            this.documento = documento;
            this.avalista = avalista;
            this.avalistaDocumento = avalistaDocumento;
        }

        public Sacado() {

        }

        public static SacadoInfo makeSacadoInfo(Sacado sacado, Casa casa) {
            SacadoInfo sacadoInfo = new SacadoInfo();

            sacadoInfo.Avalista = sacado.avalista;
            sacadoInfo.AvalistaDocumento = sacado.avalistaDocumento;
            sacadoInfo.Documento = sacado.documento;
            sacadoInfo.Email = sacado.email;
            sacadoInfo.SacadoCodigo = sacado.id;
            sacadoInfo.Sacado = sacado.nome;

            sacadoInfo.Endereco = casa.rua + ", " + casa.numero;
            sacadoInfo.Bairro = casa.bairro;
            sacadoInfo.Cidade = casa.cidade;
            sacadoInfo.Cep = casa.cep;

            return sacadoInfo;
        }
    }
}
