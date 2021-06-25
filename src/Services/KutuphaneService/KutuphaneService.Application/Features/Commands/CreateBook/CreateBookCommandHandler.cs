using AutoMapper;
using KutuphaneService.Application.Contracts.Infrastucture.Mail;
using KutuphaneService.Application.Contracts.Persistance;
using KutuphaneService.Application.Models;
using KutuphaneService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.Application.Features.Commands.CreateBook
{
    public class CreateBookCommandHandler
         : IRequestHandler<CreateBookCommand>
    {
        private readonly IBookDal _bookDal;
        private readonly IGenreDal _genreDal;
        private readonly IWriterDal _writerDal;
        private readonly IPublisherDal _publisherDal;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public CreateBookCommandHandler(IBookDal bookDal, IEmailService emailService, IMapper mapper, IGenreDal genreDal, IWriterDal writerDal, IPublisherDal publisherDal)
        {
            _bookDal = bookDal;
            _emailService = emailService;
            _mapper = mapper;
            _genreDal = genreDal;
            _writerDal = writerDal;
            _publisherDal = publisherDal;
        }

        public async Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);
            await _bookDal.Add(book);

            var userMailList = new List<string>();
            var genre = await _genreDal.Get(x => x.Id == request.GenreId,
                includes: new List<Expression<Func<Genre, object>>>
            {
                x=>x.Users
            });
            var publisher = await _publisherDal.Get(x => x.Id == request.PublisherId,
                includes: new List<Expression<Func<Publisher, object>>>
            {
                x=>x.Users
            });
            var writer = await _writerDal.Get(x => x.Id == request.WriterId,
                includes: new List<Expression<Func<Writer, object>>>
            {
                    x=>x.Users
            });

            if (genre.Users.Count > 0)
                userMailList.AddRange(genre.Users.Select(x => x.Email));
            if (publisher.Users.Count > 0)
                userMailList.AddRange(genre.Users.Select(x => x.Email));
            if (writer.Users.Count > 0)
                userMailList.AddRange(writer.Users.Select(x => x.Email));
            userMailList = userMailList.ToList().Distinct().ToList();

            foreach (var userMail in userMailList)
            {
                await _emailService.SendMail(new Email
                {
                    Body = $"{writer.WriterName} Yazarının {publisher.PublisherName} Yayınevinden Çıkmış {genre.GenreName} Türündeki Kitabını Kaçırmayın",
                    To = userMail,
                    Subject = "Kitaplığımıza Yeni Kitap Eklenmesi Hakkında"
                });
            }

            return Unit.Value;
        }
    }
}
