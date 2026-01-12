namespace CadastroWebVendedores_Mvc.Models
{
    public class Departamento
    {
        //Atributos da classe Departamento
        public int Id { get; set; }
        public required string Nome { get; set; }

        //Associação entre Departamento e Vendedor (1 para muitos)
        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        //Construtor vazio
        public Departamento()
        {
        }

        //Construtor com parâmetros
        public Departamento(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        //Método para adicionar um vendedor ao departamento
        public void AdicionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        //Total de vendas do departamento em um período específico
        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendedores //Vendedores é a coleção de vendedores
                //Para cada vendedor, calcula o total de vendas no período e soma tudo
                .Sum(v => v.TotalVendas(dataInicial, dataFinal));//v é cada vendedor na coleção de vendedores
        }
    }
}
