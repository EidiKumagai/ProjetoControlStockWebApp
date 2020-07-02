using ControlStockWebApp.Context;
using ControlStockWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDbContext _context;

        public ProdutoRepository(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IEnumerable<Produto> Produtos => _context.produtos;

        public Produto GetProdutoById(int produtoId)
        {
           return _context.produtos.FirstOrDefault(l => l.ProdutoId == produtoId);
        }
    }
}
