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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryDBContext _context;
        public AuthorRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<int>? AddAuthorAsync(AuthorEntity author)
        {
            _context.Authors.Add(author);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AuthorEntity>> DeleteAllAuthorsAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            _context.Authors.RemoveRange(authors);
            await _context.SaveChangesAsync();
            return authors;
        }

        public async Task<int?> DeleteAuthorAsync(AuthorEntity author)
        {
            if(author == null)
            {
                return null;
            }
            _context.Authors.Remove(author);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<AuthorEntity>> GetAllAuthorAsync()
        {
            return await _context.Authors
                .Include(b => b.Books)
                .ToListAsync();
        }

        public async Task<AuthorEntity> GetAuthorById(int id)
        {
            return await _context.Authors.Include(b => b.Books).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<AuthorEntity> UpdeteAuthorById(int id, AuthorEntity updateAuthor)
        {
            var isExist = await _context.Authors
                .Include(b => b.Books)
                .FirstOrDefaultAsync(b => b.Id == id);

            if(isExist == null)
            {
                return null;
            }

            isExist.Name = updateAuthor.Name;
            isExist.Surname = updateAuthor.Surname;
            isExist.Books = updateAuthor.Books;

            await _context.SaveChangesAsync();

            return isExist;
        }
    }
}
