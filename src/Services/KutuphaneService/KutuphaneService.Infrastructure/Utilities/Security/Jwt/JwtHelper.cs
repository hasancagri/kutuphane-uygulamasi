using KutuphaneService.Application.Contracts.Infrastucture.Token;
using KutuphaneService.Application.Models;
using KutuphaneService.Domain.Entities;
using KutuphaneService.Infrastructure.Extensions;
using KutuphaneService.Infrastructure.Utilities.Security.Encyption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


namespace KutuphaneService.Infrastructure.Utilities.Security.Jwt
{
    public class JwtHelper
        : ITokenHelper
    {
        private TokenOptions _tokenOptions;
        private IConfiguration Configuration { get; }
        private DateTime _accessTokenExpiration;

        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public AccessToken CreateToken(User user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(signingCredentials, user);
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Expiration = _accessTokenExpiration,
                Token = token
            };
        }

        private JwtSecurityToken CreateJwtSecurityToken(SigningCredentials signingCredentials, User user)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                 issuer: _tokenOptions.Issuer,
                 audience: _tokenOptions.Audience,
                 notBefore: DateTime.Now,
                 expires: _accessTokenExpiration,
                 signingCredentials: signingCredentials,
                 claims: SetClaims(user)
                );

            return jwtSecurityToken;
        }

        private IEnumerable<Claim> SetClaims(User user)
        {
            var claimList = new List<Claim>();
            claimList.AddEmail(user.Email);
            claimList.AddName($"{user.UserName}");
            claimList.AddNameIdentifier(user.Id.ToString());
            return claimList;
        }
    }
}
