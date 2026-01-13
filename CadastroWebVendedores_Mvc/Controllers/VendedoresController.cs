using CadastroWebVendedores_Mvc.Models;
using CadastroWebVendedores_Mvc.Models.ViewModels;
using CadastroWebVendedores_Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace CadastroWebVendedores_Mvc.Controllers
{
   
    public class VendedoresController : Controller
    {
        //Declarar dependência do serviço de vendedor
       private readonly ServicoVendedor _servicoVendedor;

        //Declarar dependência do serviço de departamento
        private readonly ServicoDepartamento _servicoDepartamento;  

        //Construtor para injeção de dependência
        public VendedoresController(ServicoVendedor servicoVendedor, ServicoDepartamento servicoDepartamento)// Recebe a dependência via injeção
        {
            _servicoVendedor = servicoVendedor;// Inicializa a dependência
            _servicoDepartamento = servicoDepartamento;
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
            // Chama o serviço para obter a lista de departamentos
            var departamentos = _servicoDepartamento.FindAll();
            // Cria o formulario com a lista de departamentos e inicializa o vendedor requerido
            var formulario = new FormularioVendedor { Departamentos = departamentos };

            return View(formulario);
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

        //Ação Delete (GET)
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();// Retorna 404 se o id for nulo
            }

            var vendedor = _servicoVendedor.FindById(id.Value);
            if (vendedor == null)
            {
                return NotFound();
            }
            
            return View(vendedor);
        }

        //Ação Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendedor.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
