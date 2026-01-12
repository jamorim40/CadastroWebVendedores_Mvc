using CadastroWebVendedores_Mvc.Data;
using CadastroWebVendedores_Mvc.Models;

namespace CadastroWebVendedores_Mvc.Services
{
    public class ServicoVendedor
    {

        // Implementar dependendências ao dbcontext
        private readonly CadastroWebVendedores_MvcContext _context;

        // Construtor para injeção de dependência
        public ServicoVendedor(CadastroWebVendedores_MvcContext context)
        {
            _context = context;
        }

        // Implemantar operação FindAllAsync para retornar todos os vendedores
        public List<Vendedor> FindAll() // Operação síncrona
        {
            return  _context.Vendedor.ToList();// Retorna a lista de vendedores
        }
    }
}
