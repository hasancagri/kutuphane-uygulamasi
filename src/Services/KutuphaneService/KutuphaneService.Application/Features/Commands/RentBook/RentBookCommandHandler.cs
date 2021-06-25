using KutuphaneService.Application.Contracts.Infrastucture.Mail;
using KutuphaneService.Application.Contracts.Persistance;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Commands.RentBook
{
    public class RentBookCommandHandler
         : IRequestHandler<RentBookCommand>
    {
        private readonly IEmailService _emailService;
        private readonly IBookDal _bookDal;

        public RentBookCommandHandler(IEmailService emailService, IBookDal bookDal)
        {
            _emailService = emailService;
            _bookDal = bookDal;
        }

        public async Task<Unit> Handle(RentBookCommand request, CancellationToken cancellationToken)
        {
            var userBookCount = await _bookDal.GetUserBooksCount(request.UserId);
            if (userBookCount > 5)
                throw new Exception("Daha fazla kitap alamazsınız");

            var book = await _bookDal.Get(x => x.Id == request.UserId);
            book.UserId = request.UserId;
            book.ReturnDate = DateTime.Now.AddDays(15);
            await _bookDal.Update(book);
            return Unit.Value;
        }
    }
}
