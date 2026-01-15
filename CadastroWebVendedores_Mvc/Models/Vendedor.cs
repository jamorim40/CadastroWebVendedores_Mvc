using System.ComponentModel.DataAnnotations;

namespace CadastroWebVendedores_Mvc.Models
{
    public class Vendedor
    {
        //Atributos da classe Vendedor
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} Obrigatório")]
        [StringLength(60,MinimumLength =3, ErrorMessage = "O campo {0} deve conter entre {2} e {1} caracteres")]//Formatando 
        public string Nome { get; set; }

        //Email com link de acesso
        [Required(ErrorMessage = "{0} Obrigatório")]
        [EmailAddress(ErrorMessage = "Entre com um {0} válido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        //Data de nascimento com formatação de data
        [Required(ErrorMessage = "{0} Obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
       
        //Salário base com formatação de moeda
        [Required(ErrorMessage = "{0} Obrigatório")]
        [Range (100.0, 50000.0, ErrorMessage = "{0} deve ser entre {1} e {2}")]
        [Display(Name = "Salário Base")]
        
        public decimal SalarioBase { get; set; }

        //Associação entre Vendedor e Departamento (muitos para 1)
        public Departamento? Departamento { get; set; }
        //Chave estrangeira para o Departamento
        //Isso cria a coluna DepartamentoId na tabela Vendedor no banco de dados e garantia a integridade referencial
        [Required(ErrorMessage ="Departamento obrigatório")]
        public int DepartamentoId { get; set; } 

        //Associação entre Vendedor e RegistroDeVendas (1 para muitos)
        public ICollection<RegistroDeVendas> Vendas { get; set; } = new List<RegistroDeVendas>();//Vendas é uma coleção de registros de vendas

        //Construtor vazio
        public Vendedor()
        {
        }

        //Construtor com parâmetros
        public Vendedor(int id, string nome, string email, DateTime dataNascimento, decimal salarioBase, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            SalarioBase = salarioBase;
            Departamento = departamento;
        }

        //Método para adicionar uma venda ao vendedor
        public void AdicionarVenda(RegistroDeVendas rv) //rv = registro de vendas
        {
            Vendas.Add(rv);
        }

        //Método para remover uma venda do vendedor
        public void RemoverVenda(RegistroDeVendas rv)
        {
            Vendas.Remove(rv);
        }

        //Método para calcular o total de vendas em um período específico
        public double TotalVendas(DateTime dataInicial, DateTime dataFinal)
        {
            return Vendas //Vendas é a coleção de registros de vendas
                .Where(rv => rv.Data >= dataInicial && rv.Data <= dataFinal)
                .Sum(rv => rv.ValorDeVenda);
        }
    }
}
