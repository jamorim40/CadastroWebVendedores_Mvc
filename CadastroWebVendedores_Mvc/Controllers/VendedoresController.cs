using CadastroWebVendedores_Mvc.Models;
using CadastroWebVendedores_Mvc.Models.ViewModels;
using CadastroWebVendedores_Mvc.Services;
using CadastroWebVendedores_Mvc.Services.Exeptions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });// Retorna erro se o id for nulo
            }

            var vendedor = _servicoVendedor.FindById(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });// Retorna erro se o vendedor não for encontrado 
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

        //Ação Details (GET)
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var vendedor = _servicoVendedor.FindById(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(vendedor);
        }

        //Ação Edit (GET)
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            var vendedor = _servicoVendedor.FindById(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            // Chama o serviço para obter a lista de departamentos
            var departamentos = _servicoDepartamento.FindAll();
            // Cria o formulario com a lista de departamentos e inicializa o vendedor requerido
            var formulario = new FormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };
            return View(formulario);
        }

        //Ação Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _servicoVendedor.Update(vendedor);
                    return RedirectToAction(nameof(Index));
                }
                catch (KeyNotFoundException ex)
                {
                    return RedirectToAction(nameof(Error), new { message = ex.Message });
                }
                catch(DB_ExcecoesDeConcorrencia ex)
                {
                    return RedirectToAction(nameof(Error), new { message = ex.Message });
                }
               
            }
            return View(vendedor);
        }

        //Ação Error
        public IActionResult Error(string message)
        {
            var mensagemErro = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                Message = message
            };
            return View(mensagemErro);
        }
    }
}
