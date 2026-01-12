using CadastroWebVendedores_Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroWebVendedores_Mvc.Controllers
{
   
    public class VendedoresController : Controller
    {
        //Declarar dependência do serviço de vendedor
       private readonly ServicoVendedor _servicoVendedor;

        //Construtor para injeção de dependência
        public VendedoresController(ServicoVendedor servicoVendedor)// Recebe a dependência via injeção
        {
            _servicoVendedor = servicoVendedor;// Inicializa a dependência
        }

        //Ação Index para listar vendedores
        public IActionResult Index()
        {
            var listaVendedores = _servicoVendedor.FindAll(); // Chama o serviço para obter a lista de vendedores
            return View(listaVendedores);// Retorna a view com a lista de vendedores
        }
    }
}
