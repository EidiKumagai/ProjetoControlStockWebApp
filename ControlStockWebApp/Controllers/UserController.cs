using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ControlStockWebApp.Context;
using ControlStockWebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ControlStockWebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            return View(_context.usuarios.ToList());
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Usuario usuario) {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                ModelState.AddModelError("", "Some Error Occured!");
            }
            return View(usuario);
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var obj = _context.usuarios.Where(u => u.Login.Equals(usuario.Login) && u.Senha.Equals(usuario.Senha)).FirstOrDefault();

                if (obj != null)
                {
                    HttpContext.Session.SetString("UsuarioId", obj.UsuarioId.ToString());
                    HttpContext.Session.SetString("Login", obj.Login.ToString());
                    return RedirectToAction("LoggedIn");
                }

            }

            return View(usuario);
        }


        public ActionResult LoggedIn() 
        {
            if (HttpContext.Session.GetString("UsuarioId") != null )
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                return RedirectToAction("Login");
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UsuarioId");
            HttpContext.Session.Remove("Login");

            return RedirectToAction("Login");
        }

    }
}
