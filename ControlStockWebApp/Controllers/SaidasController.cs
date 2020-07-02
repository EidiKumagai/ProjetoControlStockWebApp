using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControlStockWebApp.Context;
using ControlStockWebApp.Models;

namespace ControlStockWebApp.Controllers
{
    public class SaidasController : Controller
    {
        private readonly AppDbContext _context;

        public SaidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Saidas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.saidas.Include(s => s.Cliente).Include(s => s.Produto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Saidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saida = await _context.saidas
                .Include(s => s.Cliente)
                .Include(s => s.Produto)
                .FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saida == null)
            {
                return NotFound();
            }

            return View(saida);
        }

        // GET: Saidas/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.clientes, "ClienteId", "ClienteId");
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId");
            return View();
        }

        // POST: Saidas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SaidaId,Cod_Saida,Qtde_Saida,ClienteId,ProdutoId")] Saida saida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(saida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "ClienteId", "ClienteId", saida.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId", saida.ProdutoId);
            return View(saida);
        }

        // GET: Saidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saida = await _context.saidas.FindAsync(id);
            if (saida == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "ClienteId", "ClienteId", saida.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId", saida.ProdutoId);
            return View(saida);
        }

        // POST: Saidas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SaidaId,Cod_Saida,Qtde_Saida,ClienteId,ProdutoId")] Saida saida)
        {
            if (id != saida.SaidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(saida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaidaExists(saida.SaidaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.clientes, "ClienteId", "ClienteId", saida.ClienteId);
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId", saida.ProdutoId);
            return View(saida);
        }

        // GET: Saidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saida = await _context.saidas
                .Include(s => s.Cliente)
                .Include(s => s.Produto)
                .FirstOrDefaultAsync(m => m.SaidaId == id);
            if (saida == null)
            {
                return NotFound();
            }

            return View(saida);
        }

        // POST: Saidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saida = await _context.saidas.FindAsync(id);
            _context.saidas.Remove(saida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SaidaExists(int id)
        {
            return _context.saidas.Any(e => e.SaidaId == id);
        }
    }
}
