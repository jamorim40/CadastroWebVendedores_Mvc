namespace CadastroWebVendedores_Mvc.Models.ViewModels
{
    public class ErrorViewModel
    {
        // Obtém ou define o identificador único da solicitação.
        public string? RequestId { get; set; }
        // Obtém ou define a mensagem de erro.
        public string? Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
