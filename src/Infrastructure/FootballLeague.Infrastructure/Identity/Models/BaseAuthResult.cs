namespace FootballLeague.Infrastructure.Identity.Models
{
    public class BaseAuthResult
    {
        public BaseAuthResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}