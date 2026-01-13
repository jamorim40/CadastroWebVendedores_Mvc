namespace CadastroWebVendedores_Mvc.Services.Exeptions
{
    public class ExcecoesNaoEncotradas : ApplicationException
    {
        //construtor que recebe uma mensagem de erro
        public ExcecoesNaoEncotradas(string message) : base(message)
        {
        }
    }
}
