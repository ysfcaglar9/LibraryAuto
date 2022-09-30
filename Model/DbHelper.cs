using LibraryAuto.EfCore;

namespace LibraryAuto.Model
{
    public class DbHelper
    {
        private Ef_DataContext _context;
        public DbHelper(Ef_DataContext context)
        {
            _context = context;
        }

        //GET

        public List<BookModel> GetBook()
        {
            List<BookModel> response = new List<BookModel>();
            var dataList = _context.Book.ToList();
            dataList.ForEach(row => response.Add(new BookModel()
            {
                BookId = row.BookId,
                Name = row.Name,
                Author = row.Author,
                Publisher = row.Publisher,
                Year = row.Year,
                TypeOfBook = row.TypeOfBook,
                NumberOfPages = row.NumberOfPages,

            }));

            return response;
        }
        public BookModel GetBookById(int id)
        {
            BookModel response = new BookModel();
            var row = _context.Book.Where(d => d.BookId.Equals(id)).FirstOrDefault();
            return new BookModel()
            {
                BookId = row.BookId,
                Name = row.Name,
                Author = row.Author,
                Publisher = row.Publisher,
                Year = row.Year,
                TypeOfBook = row.TypeOfBook,
                NumberOfPages = row.NumberOfPages,
            };
        }
        // post put patch kullandırıyor.
        public void SaveReserved(ReservedModel reservedModel)
        {
            Reserved dbTable = new Reserved();
            //PUT
            dbTable.BookId = reservedModel.BookId;

            dbTable.Name = reservedModel.Name;
            dbTable.StartingDate = reservedModel.StartingDate;
            dbTable.EndingDate = reservedModel.EndingDate;
            dbTable.ReservedBook = reservedModel.ReservedBook;
            _context.Reserved.Add(dbTable);

            _context.SaveChanges();

        }


        public void DeleteOrder(int id)
        {
            var reserved = _context.Reserved.Where(d => d.ReservedId.Equals(id)).FirstOrDefault();
            if (reserved != null)
            {
                _context.Reserved.Remove(reserved);
                _context.SaveChanges();
            }
        }

        internal void SaveOrder(BookModel model)
        {
            var book = new Book()
            {
                Author = model.Author,
                Name = model.Name,
                NumberOfPages = model.NumberOfPages,
                Publisher = model.Publisher,
                TypeOfBook = model.TypeOfBook,
                Year = model.Year,
            };

            _context.Book.Add(book);
            _context.SaveChanges();
        }
        internal void UpdateBook(BookModel model)
        {
            var book = _context.Book.Where(p => p.BookId == model.BookId).FirstOrDefault();
            book.Author = model.Author;
            book.Name = model.Name;
            book.NumberOfPages = model.NumberOfPages;
            book.Publisher = model.Publisher;
            book.Year = model.Year;
            book.TypeOfBook = model.TypeOfBook;

            _context.Book.Update(book);
            _context.SaveChanges();
        }

    }

}
