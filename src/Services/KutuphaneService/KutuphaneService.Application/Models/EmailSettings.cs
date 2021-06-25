namespace KutuphaneService.Application.Models
{
    public class EmailSettings
    {
        public bool EnableSsl { get; set; }
        public int Port { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public string Credentials { get; set; }
        public string From { get; set; }
        public string Password { get; set; }
        public int Timeout { get; set; }
        public string Smtp { get; set; }
    }
}
