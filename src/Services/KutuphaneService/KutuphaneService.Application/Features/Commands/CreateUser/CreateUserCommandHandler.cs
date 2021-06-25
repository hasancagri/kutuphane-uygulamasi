using AutoMapper;
using KutuphaneService.Application.Contracts.Infrastucture.Hashing;
using KutuphaneService.Application.Contracts.Infrastucture.Mail;
using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Commands.CreateUser
{
    class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUserDal _userDal;
        private readonly IEmailService _emailService;
        private readonly IHashingHelper _hashingHelper;

        public CreateUserCommandHandler(IMapper mapper, IUserDal userDal, IEmailService emailService, IHashingHelper hashingHelper)
        {
            _mapper = mapper;
            _userDal = userDal;
            _emailService = emailService;
            _hashingHelper = hashingHelper;
        }

        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            //Burada hoşgeldiniz tarzı bir mail atılsın
            byte[] passwordSalt, passwordHash;
            var user = _mapper.Map<User>(request);
            _hashingHelper.CreatePasswordHash(request.Password, out passwordSalt, out passwordHash);
            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;
            await _userDal.Add(user);
            return Unit.Value;
        }
    }
}
