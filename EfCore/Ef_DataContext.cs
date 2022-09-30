using Microsoft.EntityFrameworkCore;

namespace LibraryAuto.EfCore
{
    public class Ef_DataContext : DbContext
    {
        public Ef_DataContext(DbContextOptions<Ef_DataContext> options) : base(options) { }
        
        public DbSet<Book> Book { get; set; }
        public DbSet<Reserved> Reserved { get; set; }
    }
}
