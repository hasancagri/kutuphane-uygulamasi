using KutuphaneService.Application.Contracts.Infrastucture.Hashing;
using KutuphaneService.Application.Contracts.Infrastucture.Token;
using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Queries.LoginUser
{
    public class LoginUserQueryHandler
          : IRequestHandler<LoginUserQuery, AccessToken>
    {
        private readonly IUserDal _userDal;
        private readonly IHashingHelper _hashingHelper;
        private readonly ITokenHelper _tokenHelper;

        public LoginUserQueryHandler(IUserDal userDal, IHashingHelper hashingHelper, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _hashingHelper = hashingHelper;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var userToCheck = await _userDal.Get(x => x.Email == request.Email);
            if (userToCheck == null)
            {
                //Burası düzenlenecek
                return null;
            }

            if (!_hashingHelper.VerifyPasswordHash(request.Password, userToCheck.PasswordSalt, userToCheck.PasswordHash))
            {
                //Burası düzenlenecek
                return null;
            }

            AccessToken token = _tokenHelper.CreateToken(userToCheck);
            return token;
        }
    }
}
