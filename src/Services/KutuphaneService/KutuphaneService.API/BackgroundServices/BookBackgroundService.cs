using KutuphaneService.Application.Contracts.Infrastucture.Mail;
using KutuphaneService.Application.Features.Commands.UpdateBookForSendingMail;
using KutuphaneService.Application.Features.Queries.GetAllUsersBooks;
using KutuphaneService.Application.Models;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KutuphaneService.API.BackgroundServices
{
    public class BookBackgroundService
        : IHostedService, IDisposable
    {
        private readonly IMediator _mediator;
        private readonly IEmailService _emailService;
        private readonly ILogger<BookBackgroundService> _logger;
        private Timer _timer;

        public BookBackgroundService(ILogger<BookBackgroundService> logger, IMediator mediator,
            IEmailService emailService)
        {
            _logger = logger;
            _mediator = mediator;
            _emailService = emailService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(o =>
            {
                ControlBookDates();
            },
                null,
                TimeSpan.Zero,
                TimeSpan.FromSeconds(120));
            return Task.CompletedTask;
        }

        private async Task ControlBookDates()
        {
            var bookList = await _mediator.Send(new GetAllUsersBooksQuery());
            foreach (var book in bookList)
            {
                if (book.ReturnDate.Value.AddDays(2) > DateTime.Now)
                {
                    var email = new Email
                    {
                        To = book.User.Email,
                        Subject = "Yaklaşan İade Vakti",
                        Body = $"{book.BookName} Kitabı'nın Son İade Tarihi {book.ReturnDate.Value.ToShortDateString()} Olduğunu Hatırlatmak İsteriz!"
                    };
                    await _emailService.SendMail(email);
                    book.IsMailSend = true;
                    await _mediator.Send(new UpdateBookForSendingMailCommand { Id = book.Id });
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("BookService stopping");
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
