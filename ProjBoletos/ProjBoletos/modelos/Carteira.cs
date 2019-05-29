using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjBoletos.modelos
{
    public class Carteira
    {

        public string carteira { get; set; }
        public string descricao { get; set; }
        public string convenioBB { get; set; }

        public Carteira(string carteira,string convenioBB, string descricao)
        {
            this.carteira = carteira;
            this.descricao = descricao;
            this.convenioBB = convenioBB;
        }

        public Carteira()
        {

        }
    }
}
