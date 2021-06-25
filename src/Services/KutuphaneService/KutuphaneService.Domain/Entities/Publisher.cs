using KutuphaneService.Domain.Common;
using System.Collections.Generic;

namespace KutuphaneService.Domain.Entities
{
    public class Publisher
        : EntityBase
    {
        public Publisher()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public string PublisherName { get; set; }
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
    }
}
