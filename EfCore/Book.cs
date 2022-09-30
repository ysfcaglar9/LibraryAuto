using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuto.EfCore
{
    [Table ("Book")]
    public class Book
    { 

        [Key,Required]
        public int  BookId { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Author { get; set; } = string.Empty;
        public string? Publisher { get; set; }
        public string? Year { get; set; }
        public string? TypeOfBook { get; set; }
        public int NumberOfPages { get; set; }

    }
}
