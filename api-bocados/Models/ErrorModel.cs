namespace api_bocados.Models
{
    public class ErrorModel
    {
        public ErrorModel(string message, int errorCode)
        {
            Message = message;
            ErrorCode = errorCode;
        }

        public string Message { get; set; }
        public int ErrorCode { get; set; }
    }
}
