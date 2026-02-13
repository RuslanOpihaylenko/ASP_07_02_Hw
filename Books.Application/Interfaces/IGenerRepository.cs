using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IGenerRepository
    {
        /// <summary>
        /// Get genres from BD
        /// </summary>
        /// <returns></returns>
        Task<ICollection<GenreEntity>> GetAllGenreAsync();
        Task<GenreEntity> GetGenreById(int id);
        Task<int>? AddGenreAsync(GenreEntity genre);
        Task<GenreEntity> UpdeteGenreById(int id, GenreEntity updateGenre);
        Task<int?> DeleteGenreAsync(GenreEntity genre);
        Task<ICollection<GenreEntity>> DeleteAllGenresAsync();
    }
}
