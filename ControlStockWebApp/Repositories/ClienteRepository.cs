using ControlStockWebApp.Context;
using ControlStockWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Cliente> Clientes => _context.clientes;

        public void CadastrarCliente(Cliente cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

        }
    }
}
