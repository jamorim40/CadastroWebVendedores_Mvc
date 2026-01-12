namespace CadastroWebVendedores_Mvc.Data
{
    public class ServicoPopularDados
    {
        //Registro de dependência do contexto do banco de dados
        private readonly CadastroWebVendedores_MvcContext _context;

        //Construtor que recebe o contexto via injeção de dependência
        public ServicoPopularDados(CadastroWebVendedores_MvcContext context)
        {
            _context = context;
        }

        //Método para popular o banco de dados com dados iniciais
        public void PopularDados()
        {
            //Verifica se já existem dados no banco de dados
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroDeVendas.Any())
            {
                return; //Banco de dados já foi populado
            }
            //Lógica para adicionar dados iniciais ao banco de dados
            //Exemplo:
            // var departamento = new Departamento { Nome = "Vendas" };
            // _context.Departamento.Add(departamento);

            //Observação: Populei os dados iniciais diretamente no Banco de Dados usando o script SQL 
            _context.SaveChanges(); //Salva as alterações no banco de dados


        }
    }
}
