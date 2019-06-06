using Impactro.Cobranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos {
   public static class Boleto {

      public static BoletoInfo makeBoleto(Cedente cedente, Medicao medicao) {
         double valor = cedente.getValor((Int32.Parse(medicao.medicao) - Int32.Parse(medicao.medicaoAnterior)));

         int diaVencimento = Int32.Parse(medicao.casa.diaVencimento);
         DateTime vencimento = medicao.dataMedicao;
         if (diaVencimento < medicao.dataMedicao.Day) {
            vencimento = new DateTime(vencimento.Year, vencimento.AddMonths(1).Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
         } else {
            vencimento = new DateTime(vencimento.Year, vencimento.Month, diaVencimento, vencimento.Hour, vencimento.Minute, vencimento.Second);
         }

         BoletoInfo boletoInfo = new BoletoInfo();

         boletoInfo.NossoNumero = medicao.id
            + medicao.dataBoletoGerado.ToString("yy")
            + medicao.dataBoletoGerado.ToString("MM");
         boletoInfo.NumeroDocumento = boletoInfo.NossoNumero;
         boletoInfo.ParcelaNumero = 1;
         boletoInfo.ParcelaTotal = 1;
         boletoInfo.Quantidade = 1;
         boletoInfo.ValorUnitario = valor;
         boletoInfo.ValorDocumento = boletoInfo.Quantidade * boletoInfo.ValorUnitario;
         boletoInfo.DataVencimento = vencimento;
         boletoInfo.Especie = Especies.RC;
         boletoInfo.DataDocumento = medicao.dataMedicao;
         boletoInfo.DataProcessamento = medicao.dataBoletoGerado;
         //Boleto.ValorMora = 0.03;
         boletoInfo.PercentualMulta = 0.02;
         boletoInfo.PercentualMora = 0.001;
         boletoInfo.DataPagamento = boletoInfo.DataVencimento.AddDays(60);
         boletoInfo.CalculaMultaMora = false;
         boletoInfo.ValorDesconto = 0;
         //Boleto.DataDesconto = DateTime.Now.AddDays(-10);
         boletoInfo.ValorAcrescimo = 0;
         boletoInfo.ValorOutras = 0;
         boletoInfo.Instrucoes = "Pague adasdasdasd";
         //BoletoInfo Boleto = new BoletoInfo();
         //boletoInfo.Especie = Especies.DS;
         return boletoInfo;
      }

   }
}
