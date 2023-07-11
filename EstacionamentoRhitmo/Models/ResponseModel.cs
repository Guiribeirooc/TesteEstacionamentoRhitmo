namespace EstacionamentoRhitmo.Models
{
    public class ResponseModel
    {
        public ResponseModel(bool success,object data = null, string message = "")
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public bool Success { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}
