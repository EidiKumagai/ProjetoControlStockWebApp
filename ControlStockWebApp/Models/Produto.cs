using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Models
{
    public class Produto
    {
  
        public int ProdutoId { get; set; }
        public string Cod_Produto { get; set; }

        public string Nome { get; set; }

        public double Preco { get; set; }
    }
}
