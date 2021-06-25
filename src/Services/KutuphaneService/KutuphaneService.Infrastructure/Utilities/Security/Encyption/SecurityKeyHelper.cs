using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace KutuphaneService.Infrastructure.Utilities.Security.Encyption
{
    public static class SecurityKeyHelper
    {
        public static SymmetricSecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
