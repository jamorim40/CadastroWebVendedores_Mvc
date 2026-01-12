using Microsoft.AspNetCore.Mvc;

namespace CadastroWebVendedores_Mvc.Controllers
{
    public class VendedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
