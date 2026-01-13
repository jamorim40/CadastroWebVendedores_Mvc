namespace CadastroWebVendedores_Mvc.Models.ViewModels
{
    public class FormularioVendedor
    {
        //  Propriedade para o vendedor
        public  Vendedor Vendedor { get; set; }


        public  ICollection<Departamento> Departamentos { get; set; }
    }
}
