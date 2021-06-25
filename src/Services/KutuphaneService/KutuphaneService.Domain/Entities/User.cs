using KutuphaneService.Domain.Common;
using System.Collections.Generic;

namespace KutuphaneService.Domain.Entities
{
    public class User
        : EntityBase
    {
        public User()
        {
            Books = new List<Book>();
            Writers = new List<Writer>();
            Publishers = new List<Publisher>();
            Genres = new List<Genre>();
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public List<Book> Books { get; set; }
        public List<Writer> Writers { get; set; }
        public List<Publisher> Publishers { get; set; }
        public List<Genre> Genres { get; set; }

    }
}
