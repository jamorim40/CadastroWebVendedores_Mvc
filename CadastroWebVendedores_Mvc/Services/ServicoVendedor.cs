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

        //Inserir um novo vendedor no DB
        //Será chamado pelo botao "Criar" na view (tela) Criar vendedor
        public void Insert (Vendedor obj)
        {
            _context.Add(obj);// Adiciona o objeto ao contexto
            _context.SaveChanges();// Salva as alterações no banco de dados
        }
    }
}
