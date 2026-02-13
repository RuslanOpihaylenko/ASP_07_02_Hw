using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Get authors from BD
        /// </summary>
        /// <returns></returns>
        Task<ICollection<AuthorEntity>> GetAllAuthorAsync();
        Task<AuthorEntity> GetAuthorById(int id);
        Task<int>? AddAuthorAsync(AuthorEntity author);
        Task<AuthorEntity> UpdeteAuthorById(int id, AuthorEntity updateAuthor);
        Task<int?> DeleteAuthorAsync(AuthorEntity author);
        Task<ICollection<AuthorEntity>> DeleteAllAuthorsAsync();
    }
}
