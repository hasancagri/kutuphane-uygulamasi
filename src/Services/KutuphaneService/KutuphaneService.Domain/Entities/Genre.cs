using KutuphaneService.Domain.Common;
using System.Collections.Generic;

namespace KutuphaneService.Domain.Entities
{
    public class Genre
        : EntityBase
    {
        public Genre()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public string GenreName { get; set; }
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
    }
}
