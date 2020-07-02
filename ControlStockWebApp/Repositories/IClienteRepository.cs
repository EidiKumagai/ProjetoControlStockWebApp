using ControlStockWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Repositories
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> Clientes { get; }
        void CadastrarCliente(Cliente cliente);
    }
}
