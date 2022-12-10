using Avram_Alin_Lab2.Models;

namespace Avram_Alin_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }

    }
}
