namespace KutuphaneService.Application.Models
{
    public class BookListViewModel
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string GenreName { get; set; }
        public string PublisherName { get; set; }
        public string WriterName { get; set; }
        public bool IsReserved { get; set; }
    }
}
