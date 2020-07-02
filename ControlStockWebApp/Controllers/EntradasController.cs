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
    public class EntradasController : Controller
    {
        private readonly AppDbContext _context;

        public EntradasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Entradas
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.entradas.Include(e => e.Fornecedor).Include(e => e.Produto);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Entradas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.entradas
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // GET: Entradas/Create
        public IActionResult Create()
        {
            ViewData["FornecedorId"] = new SelectList(_context.fornecedores, "FornecedorId", "FornecedorId");
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId");
            return View();
        }

        // POST: Entradas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EntradaId,Cod_Entrada,FornecedorId,ProdutoId,qtde_Entrada")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entrada);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FornecedorId"] = new SelectList(_context.fornecedores, "FornecedorId", "FornecedorId", entrada.FornecedorId);
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId", entrada.ProdutoId);
            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.entradas.FindAsync(id);
            if (entrada == null)
            {
                return NotFound();
            }
            ViewData["FornecedorId"] = new SelectList(_context.fornecedores, "FornecedorId", "FornecedorId", entrada.FornecedorId);
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId", entrada.ProdutoId);
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EntradaId,Cod_Entrada,FornecedorId,ProdutoId,qtde_Entrada")] Entrada entrada)
        {
            if (id != entrada.EntradaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entrada);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaExists(entrada.EntradaId))
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
            ViewData["FornecedorId"] = new SelectList(_context.fornecedores, "FornecedorId", "FornecedorId", entrada.FornecedorId);
            ViewData["ProdutoId"] = new SelectList(_context.produtos, "ProdutoId", "ProdutoId", entrada.ProdutoId);
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entrada = await _context.entradas
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.EntradaId == id);
            if (entrada == null)
            {
                return NotFound();
            }

            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entrada = await _context.entradas.FindAsync(id);
            _context.entradas.Remove(entrada);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaExists(int id)
        {
            return _context.entradas.Any(e => e.EntradaId == id);
        }
    }
}
