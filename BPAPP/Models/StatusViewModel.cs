namespace BPAPP.Models
{
    public class StatusViewModel
    {
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = "OK";

        public object? ObjetoADeserializar { get; set; } = null;

        public StatusViewModel()
        {
        }

        public StatusViewModel(bool isSuccess, string message, object? objetoDeserealizar)
        {
            IsSuccess = isSuccess;
            Message = message;
            ObjetoADeserializar = objetoDeserealizar;
        }
    }
}