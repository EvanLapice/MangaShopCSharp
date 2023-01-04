using MSSA_Assignment_12._2.Models;

namespace MSSA_Assignment_12._2.Services
{
    public interface ICRUD
    {
        List<Book> GetBooks();
        Book GetBook(int? id);
        void AddBook(Book book);
        void DeleteBook(int? id);
        void UpdateBook(Book book);
        int GetMaxID();
    }
}
