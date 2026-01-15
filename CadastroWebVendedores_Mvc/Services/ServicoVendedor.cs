using CadastroWebVendedores_Mvc.Data;
using CadastroWebVendedores_Mvc.Models;
using CadastroWebVendedores_Mvc.Services.Exeptions;
using Microsoft.EntityFrameworkCore;

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
        public async Task<List<Vendedor>> FindAllAsync() // Operação assíncrona
        {
            return await _context.Vendedor.ToListAsync();// Retorna a lista de vendedores
        }

        //Inserir um novo vendedor no DB
        //Será chamado pelo botao "Criar" na view (tela) Criar vendedor
        public async Task InsertAsync(Vendedor obj)
        {
            _context.Add(obj);// Adiciona o objeto ao contexto
            await _context.SaveChangesAsync();// Salva as alterações no banco de dados
        }

        // Implementar operação FindById para retornar um vendedor pelo Id
        public async Task<Vendedor> FindByIdAsync(int id)
        {
            return await _context.Vendedor.Include(dep => dep.Departamento).FirstOrDefaultAsync(v => v.Id == id);
        }

        // Implementar operação Remove para remover um vendedor
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Vendedor.FindAsync(id);
            _context.Vendedor.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Implementar operação Update para atualizar um vendedor
        public async Task UpdateAsync(Vendedor obj)
        {
            if (!_context.Vendedor.Any(v => v.Id == obj.Id))
            {
                throw new KeyNotFoundException("Id não encontrado");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DB_ExcecoesDeConcorrencia(e.Message);
            }
        }
    }
}
