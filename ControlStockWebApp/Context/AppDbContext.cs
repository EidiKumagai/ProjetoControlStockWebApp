using ControlStockWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlStockWebApp.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {       
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Entrada> entradas{ get; set; }

        public DbSet<Fornecedor> fornecedores{ get; set; }

        public DbSet<Produto> produtos{ get; set; }

        public DbSet<Saida> saidas{ get; set; }

        public DbSet<Usuario>usuarios { get; set; }
    }
}
