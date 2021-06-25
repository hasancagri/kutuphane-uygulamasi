using KutuphaneService.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace KutuphaneService.Domain.Entities
{
    public class Book
        : EntityBase
    {
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsMailSend { get; set; }

        public int GenreId { get; set; }
        public int PublisherId { get; set; }
        public int WriterId { get; set; }
        public int? UserId { get; set; }

        public Genre Genre { get; set; }
        public Publisher Publisher { get; set; }
        public Writer Writer { get; set; }
        public User User { get; set; }
    }
}
