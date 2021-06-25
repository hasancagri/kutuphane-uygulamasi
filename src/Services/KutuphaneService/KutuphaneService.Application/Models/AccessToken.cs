using System;

namespace KutuphaneService.Application.Models
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
