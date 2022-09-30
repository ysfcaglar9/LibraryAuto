using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryAuto.EfCore
{
    [Table("Reserved")]
    public class Reserved
    {
        [Key, Required]
        public int ReservedId { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public string Name { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public string ReservedBook { get; set; }

    }
}
