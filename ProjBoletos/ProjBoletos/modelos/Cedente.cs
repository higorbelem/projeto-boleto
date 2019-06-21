using Impactro.Cobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
   public class Cedente {

      public string id { get; set; }
      public string nome { get; set; }
      public string usoBanco { get; set; }
      public string useSantander { get; set; }
      public string cnpj { get; set; }
      public string informacoes { get; set; }
      public string contato { get; set; }
      public string uf { get; set; }
      public string cidade { get; set; }
      public string bairro { get; set; }
      public string rua { get; set; }
      public string numero { get; set; }
      public string cep { get; set; }
      public double valorPorMetroCubico { get; set; }
      public float esgoto { get; set; }
      public string email { get; set; }

      public List<Conta> contas { get; set; }

      public Cedente(string id, string nome, string usoBanco, string useSantander, string uf, string cidade, string bairro, string rua, string numero, string cep, string cnpj, string informacoes, string contato) {
         this.id = id;
         this.nome = nome;
         this.usoBanco = usoBanco;
         this.useSantander = useSantander;
         this.uf = uf;
         this.cidade = cidade;
         this.bairro = bairro;
         this.rua = rua;
         this.numero = numero;
         this.cep = cep;
         this.cnpj = cnpj;
         this.informacoes = informacoes;
         this.contato = contato;

         contas = new List<Conta>();
      }

      public Cedente() {
         contas = new List<Conta>();
      }

      public Conta getContaById(string id) {
         foreach (Conta conta in contas) {
            if (conta.id.Equals(id)) {
               return conta;
            }
         }

         return null;
      }

      public double getValor(int consumo) {
         double valor = consumo * valorPorMetroCubico;
         double valorComEsgoto = valor + (valor * esgoto / 100);

         return valorComEsgoto;
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
         cedenteInfo.CedenteCOD = conta.codigoEmpresa;
         cedenteInfo.CodCedente = conta.codigoEmpresa;

         cedenteInfo.Convenio = conta.convenio;

         cedenteInfo.Cedente = cedente.nome;
         cedenteInfo.CNPJ = cedente.cnpj;
         cedenteInfo.Endereco = cedente.rua + ", " + cedente.numero;
         cedenteInfo.Praca = cedente.bairro;
         cedenteInfo.Informacoes = cedente.informacoes;
         cedenteInfo.useSantander = cedente.useSantander.Equals("1");
         cedenteInfo.UsoBanco = cedente.usoBanco;

         return cedenteInfo;
      }
   }
}
