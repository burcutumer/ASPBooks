using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Models;

namespace API.Data.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;
         public BooksService(AppDbContext context)
         {
            _context = context;
         }
         public void AddBook(BookVM book)
         {
            var _book = new Book
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverURl = book.CoverURl
            };
            _context.Books.Add(_book);
            _context.SaveChanges();
         }

         public List<Book> GetAllBooks() => _context.Books.ToList();
         public Book GetBookById(int bookId) => _context.Books.FirstOrDefault(n => n.Id == bookId);
         public Book UpdateBookById(int bookId,BookVM book)
         {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookId);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book.DateRead = book.IsRead ? book.DateRead : null;
                _book.Rate = book.IsRead ? book.Rate : null;
                _book.Genre = book.Genre;
                _book.Author = book.Author;
                _book.CoverURl = book.CoverURl;
                _context.SaveChanges();
            }
            return _book;
         }

         public bool DeleteBookById(int id)
         {
            var book = _context.Books.FirstOrDefault(n => n.Id == id);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
                return true;
            }
            return false;
         }

    }
}