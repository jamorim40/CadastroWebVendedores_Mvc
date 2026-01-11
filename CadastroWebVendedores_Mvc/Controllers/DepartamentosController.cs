using Microsoft.AspNetCore.Mvc;
using CadastroWebVendedores_Mvc.Models;
using System.Collections.Generic;

namespace CadastroWebVendedores_Mvc.Controllers
{
    public class DepartamentosController : Controller
    {
        public IActionResult Index()
        {
            List<Departamento> lista = new List<Departamento>();
            lista.Add(new Departamento { Id = 1, Nome = "Computadores" });
            lista.Add(new Departamento { Id = 2, Nome = "Eletrônicos" });

            return View(lista);
        }
    }
}
