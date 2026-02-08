using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    internal interface IAuthorRepository
    {
        /// <summary>
        /// Get authors from BD
        /// </summary>
        /// <returns></returns>
        Task<ICollection<AuthorEntity>> GetAllAuthorAsync();
        Task<AuthorEntity> GetAuthorById(int id);
        Task<int>? AddAuthorAsync(AuthorEntity author);
    }
}
