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
        public async Task<IActionResult> Index()
        {
            var listaVendedores = await _servicoVendedor.FindAllAsync(); // Chama o serviço para obter a lista de vendedores
            return View(listaVendedores);// Retorna a view com a lista de vendedores
        }

        //Criar acao "Criar" (GET)
        public async Task<IActionResult> Create()
        {
            // Chama o serviço para obter a lista de departamentos
            var departamentos = await _servicoDepartamento.FindAllAsync();
            // Cria o formulario com a lista de departamentos e inicializa o vendedor requerido
            var formulario = new FormularioVendedor { Departamentos = departamentos };

            return View(formulario);
        }

        //Criar ação "Criar" (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamentos = await _servicoDepartamento.FindAllAsync();
                var formulario = new FormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };

                return View(formulario);
            }

            await _servicoVendedor.InsertAsync(vendedor);
            return RedirectToAction(nameof(Index));
        }


        //Ação Delete (GET)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });// Retorna erro se o id for nulo
            }

            var vendedor = await _servicoVendedor.FindByIdAsync(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });// Retorna erro se o vendedor não for encontrado 
            }

            return View(vendedor);
        }

        //Ação Delete (POST)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _servicoVendedor.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }

        //Ação Details (GET)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }

            var vendedor = await _servicoVendedor.FindByIdAsync(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(vendedor);
        }

        //Ação Edit (GET)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não existe" });
            }
            var vendedor = await _servicoVendedor.FindByIdAsync(id.Value);
            if (vendedor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            // Chama o serviço para obter a lista de departamentos
            var departamentos = await _servicoDepartamento.FindAllAsync();
            // Cria o formulario com a lista de departamentos e inicializa o vendedor requerido
            var formulario = new FormularioVendedor { Vendedor = vendedor, Departamentos = departamentos };
            return View(formulario);
        }

        //Ação Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Edit(int id, FormularioVendedor formulario)
        {
            if (id != formulario.Vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não corresponde" });
            }
            if (ModelState.IsValid)
            {
                formulario.Departamentos = await _servicoDepartamento.FindAllAsync();
                return View(formulario);
            }
            try
            {
                await _servicoVendedor.UpdateAsync(formulario.Vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (KeyNotFoundException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
            catch (DB_ExcecoesDeConcorrencia ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }

        
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
