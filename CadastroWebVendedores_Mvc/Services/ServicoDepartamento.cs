using CadastroWebVendedores_Mvc.Data;
using CadastroWebVendedores_Mvc.Models;

namespace CadastroWebVendedores_Mvc.Services
{
    public class ServicoDepartamento
    {
        // Implementar dependendências ao dbcontext
        private readonly CadastroWebVendedores_MvcContext _context;

        // Construtor para injeção de dependência
        public ServicoDepartamento(CadastroWebVendedores_MvcContext context)
        {
            _context = context;
        }

        // Retornar todos os departamentos
        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(d => d.Nome).ToList();// Retorna a lista de departamentos ordenada por nome
        }
    }
}
