using KutuphaneService.Domain.Common;
using System.Collections.Generic;

namespace KutuphaneService.Domain.Entities
{
    public class Writer
        : EntityBase
    {
        public Writer()
        {
            Books = new List<Book>();
            Users = new List<User>();
        }

        public string WriterName { get; set; }
        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }
    }
}
