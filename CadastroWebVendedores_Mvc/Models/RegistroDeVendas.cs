using CadastroWebVendedores_Mvc.Models.Enumerado;

namespace CadastroWebVendedores_Mvc.Models
{
    public class RegistroDeVendas
    {
        //Propriedades da classe RegistroDeVendas
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public decimal ValorDeVenda { get; set; }
        public StatusVendas Status { get; set; }

        //FK explicita
        public int VendedorId { get; set; }

        //Associação entre RegistroDeVendas e Vendedor (muitos para 1)
        public required Vendedor Vendedor { get; set; }

        //Construtor vazio
        public RegistroDeVendas()
        {
        }

        //Construtor com parâmetros
        public RegistroDeVendas(int id, DateTime data, decimal valorDeVenda, StatusVendas status, Vendedor vendedor)
        {
            Id = id;
            Data = data;
            ValorDeVenda = valorDeVenda;
            Status = status;
            Vendedor = vendedor;
        }
    }
}
