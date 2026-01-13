namespace CadastroWebVendedores_Mvc.Services.Exeptions
{
    //classe para tratar exceções de concorrência no banco de dados
    public class DB_ExcecoesDeConcorrencia : ApplicationException
    {
        //construtor que recebe uma mensagem de erro
        public DB_ExcecoesDeConcorrencia(string message) : base(message)
        {
        }
    }
}
