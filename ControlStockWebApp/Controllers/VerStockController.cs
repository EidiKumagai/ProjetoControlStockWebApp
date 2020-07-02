using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlStockWebApp.Context;
using ControlStockWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControlStockWebApp.Controllers
{
    public class VerStockController : Controller
    {
        private readonly AppDbContext _context;
        public VerStockController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int resultadoSaida = 0;
            int resultadoEntrada = 0;

            List<Saida> listadeSaidas = new List<Saida>();
            listadeSaidas = _context.saidas.ToList();

            List<Entrada> listadeEntradas = new List<Entrada>();
            listadeEntradas = _context.entradas.ToList();

            foreach (Saida saida in listadeSaidas)
            {
                resultadoSaida += saida.Qtde_Saida;
            }

            foreach (Entrada item in listadeEntradas)
            {
                resultadoEntrada += item.qtde_Entrada;
            }


            int resultadoFinal = resultadoEntrada - resultadoSaida;

            ViewBag.resultado = resultadoFinal;
            return View("Index");
        }

      
    }
}
