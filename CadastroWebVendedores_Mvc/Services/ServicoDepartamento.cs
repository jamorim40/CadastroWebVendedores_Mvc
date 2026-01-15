using CadastroWebVendedores_Mvc.Data;
using CadastroWebVendedores_Mvc.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(d => d.Nome).ToListAsync();// Retorna a lista de departamentos ordenada por nome
        }
    }
}
