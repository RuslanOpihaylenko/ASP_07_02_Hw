using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Books.Application.Interfaces;
using Books.Domain.Entities;
using Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDBContext _context;
        public BookRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task<int?> AddBookAsync(BookEntity book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BookEntity>> DeleteAllBooksAsync()
        {
            var books = await _context.Books.ToListAsync();
            _context.Books.RemoveRange(books);
            await _context.SaveChangesAsync();
            return books;
        }

        public async Task<int?> DeleteBookAsync(BookEntity book)
        {
            if (book == null) 
            {
                return null;
            }
            _context.Books.Remove(book);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<BookEntity>> GetAllBooksAsync()
        {
            return await _context.Books
                .Include(b => b.Authors)
                .ToListAsync();
        }

        public async Task<BookEntity> GetBookById(int id)
        {
            return await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<BookEntity> UpdeteBookById(int id, BookEntity updateBook)
        {
            var isExist = await _context.Books
                 .Include(b => b.Authors)
                 .FirstOrDefaultAsync(b => b.Id == id);

            if (isExist == null)
            {
                return null;
            }

            isExist.Title = updateBook.Title;
            isExist.Year = updateBook.Year;
            isExist.GenreId = updateBook.GenreId;
            isExist.Authors = updateBook.Authors;

            await _context.SaveChangesAsync();

            return isExist;
        }
    }
}
