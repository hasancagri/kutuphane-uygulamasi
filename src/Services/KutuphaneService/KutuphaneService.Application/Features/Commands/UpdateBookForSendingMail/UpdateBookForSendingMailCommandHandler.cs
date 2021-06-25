using KutuphaneService.Application.Contracts.Persistance;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Commands.UpdateBookForSendingMail
{
    public class UpdateBookForSendingMailCommandHandler
         : IRequestHandler<UpdateBookForSendingMailCommand>
    {
        private readonly IBookDal _bookDal;

        public UpdateBookForSendingMailCommandHandler(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public async Task<Unit> Handle(UpdateBookForSendingMailCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookDal.Get(x => x.Id == request.Id);
            book.IsMailSend = true;
            await _bookDal.Update(book);
            return Unit.Value;
        }
    }
}
