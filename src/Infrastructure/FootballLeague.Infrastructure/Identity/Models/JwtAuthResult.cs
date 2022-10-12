namespace FootballLeague.Infrastructure.Identity.Models
{
    public class JwtAuthResult : BaseAuthResult
    {
        public JwtAuthResult(bool success, string message) : base(success, message)
        {
        }
        public string AccessToken { get; internal set; }
    }
}