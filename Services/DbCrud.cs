using MSSA_Assignment_12._2.Models;


namespace MSSA_Assignment_12._2.Services
{
    public class DbCrud : ICRUD
    {
        private BookContext _bookContext;
        public DbCrud(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public void AddBook(Book book)
        {
            _bookContext.Books.Add(book);
            _bookContext.SaveChanges();
        }

        public void DeleteBook(int? id)
        {
            var book = _bookContext.Books.Find(id);
            if(book != null)
            {
                _bookContext.Books.Remove(book);
                _bookContext.SaveChanges();
            }
        }

        public Book GetBook(int? id)
        {
            return _bookContext.Books.Find(id);
        }

        public List<Book> GetBooks()
        {
            return new List<Book>(_bookContext.Books);
        }

        public int GetMaxID()
        {
            return _bookContext.Books.Max(x => x.Id) + 1;
        }

        public void UpdateBook(Book book)
        {
            var bookToUpdate = _bookContext.Books.Find(book.Id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Id = book.Id;
                bookToUpdate.Name = book.Name;
                bookToUpdate.Author = book.Author;
                bookToUpdate.Description = book.Description;
                bookToUpdate.Price = book.Price;
                bookToUpdate.ImageName = book.ImageName;

                _bookContext.SaveChanges();
            }
        }
    }
}
