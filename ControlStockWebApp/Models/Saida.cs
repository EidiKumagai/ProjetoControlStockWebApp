using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Models
{
    public class Saida
    {
     
        public int SaidaId { get; set; }

        public string Cod_Saida { get; set; }

        public int Qtde_Saida { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
