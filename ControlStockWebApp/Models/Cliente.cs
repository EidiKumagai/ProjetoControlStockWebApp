using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string Cod_Cliente { get; set; }

        public string Nome { get; set; }

        public string RazaoSocial { get; set; }

        public string CpforCnpj { get; set; }

        public string Telefone { get; set; }
    }
}
