using Impactro.Cobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
    class Cedente {

        public string id { get; set; }
        public string nome { get; set; }
        public string usoBanco { get; set; }
        public string useSantander { get; set; }
        public string endereco { get; set; }
        public string praca { get; set; }
        public string cnpj { get; set; }
        public string informacoes { get; set; }

        public List<Conta> contas { get; set; }

        public Cedente(string id, string nome, string usoBanco, string useSantander, string endereco, string praca, string cnpj, string informacoes) {
            this.id = id;
            this.nome = nome;
            this.usoBanco = usoBanco;
            this.useSantander = useSantander;
            this.endereco = endereco;
            this.praca = praca;
            this.cnpj = cnpj;
            this.informacoes = informacoes;
            this.contas = contas;

            contas = new List<Conta>();
        }

        public Cedente() {
            contas = new List<Conta>();
        }

        public static CedenteInfo makeCedenteInfo(Cedente cedente, Conta conta, string carteira, string carteiraTipo) {
            CedenteInfo cedenteInfo = new CedenteInfo();

            cedenteInfo.Agencia = conta.agencia;
            cedenteInfo.Banco = conta.banco;
            cedenteInfo.Carteira = carteira;
            cedenteInfo.CarteiraTipo = carteiraTipo;
            cedenteInfo.Conta = conta.conta;
            cedenteInfo.CIP = conta.cip;
            cedenteInfo.Modalidade = conta.modalidade;
            cedenteInfo.Convenio = conta.convenio;

            cedenteInfo.Cedente = cedente.nome;
            cedenteInfo.CedenteCOD = cedente.id;
            cedenteInfo.CNPJ = cedente.cnpj;
            cedenteInfo.CodCedente = cedente.id;
            cedenteInfo.Endereco = cedente.endereco;
            cedenteInfo.Praca = cedente.praca;
            cedenteInfo.Informacoes = cedente.informacoes;
            cedenteInfo.useSantander = cedente.useSantander.Equals("1");
            cedenteInfo.UsoBanco = cedente.usoBanco;

            return cedenteInfo;
        }
    }
}
