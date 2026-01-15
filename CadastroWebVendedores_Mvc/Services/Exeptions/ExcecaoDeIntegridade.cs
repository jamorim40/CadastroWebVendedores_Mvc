namespace CadastroWebVendedores_Mvc.Services.Exeptions
{
    public class ExcecaoDeIntegridade : ApplicationException
    {
        public ExcecaoDeIntegridade(string message) : base(message)
        {
        }
    }
}
