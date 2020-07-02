using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Models
{
    public class Entrada
    {
 
        public int EntradaId { get; set; }

        public string Cod_Entrada { get; set; }

        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }

        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public int qtde_Entrada { get; set; }

    }
}
