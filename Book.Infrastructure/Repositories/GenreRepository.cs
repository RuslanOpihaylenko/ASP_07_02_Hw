using Books.Application.Interfaces;
using Books.Domain.Entities;
using Books.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Infrastructure.Repositories
{
    public class GenreRepository : IGenerRepository
    {
        private readonly LibraryDBContext _context;
        public GenreRepository(LibraryDBContext context)
        {
            _context = context;
        }

        public async Task<int>? AddGenreAsync(GenreEntity genre)
        {
            _context.Genres.Add(genre);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GenreEntity>> DeleteAllGenresAsync()
        {
            var genres = await _context.Genres.ToListAsync();
            _context.Genres.RemoveRange(genres);
            await _context.SaveChangesAsync();
            return genres;
        }

        public async Task<int?> DeleteGenreAsync(GenreEntity genre)
        {
            if(genre == null)
            {
                return null;
            }

            _context.Genres.Remove(genre);
            return await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GenreEntity>> GetAllGenreAsync()
        {
            return await _context.Genres
                .Include(b => b.Books)
                .ToListAsync();
        }

        public async Task<GenreEntity> GetGenreById(int id)
        {
            return await _context.Genres.Include(b => b.Books).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<GenreEntity> UpdeteGenreById(int id, GenreEntity updateGenre)
        {
            var isExist = await _context.Genres
                .Include(b => b.Books)
                .FirstOrDefaultAsync(b => b.Id == id);

            if(isExist == null)
            {
                return null;
            }

            isExist.Title = updateGenre.Title;
            isExist.Books = updateGenre.Books;

            await _context.SaveChangesAsync();

            return isExist;
        }
    }
}
