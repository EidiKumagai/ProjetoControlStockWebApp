using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Models
{
    public class Fornecedor
    {

        public int FornecedorId { get; set; }

        public string Cod_Fornecedor { get; set; }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public string CpforCnpj { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
    }
}
