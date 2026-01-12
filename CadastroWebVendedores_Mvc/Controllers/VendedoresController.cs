using CadastroWebVendedores_Mvc.Models;
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

        //Criar acao "Criar" (GET)
        public IActionResult Create()
        {
            return View();
        }

        //Criar ação "Criar" (POST)
        [HttpPost]// Indica que esta ação responde a requisições POST
        [ValidateAntiForgeryToken]// Protege contra ataques CSRF
        public IActionResult Create(Vendedor vendedor)
        {
            if (ModelState.IsValid)// Verifica se o modelo é válido
            {
                _servicoVendedor.Insert(vendedor);// Chama o serviço para inserir o novo vendedor
                return RedirectToAction(nameof(Index));// Redireciona para a ação Index após a criação
            }
            return View(vendedor);
        }
    }
}
