using Books.Application.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Interfaces
{
    public interface IUserService
    {
        Task<Guid> CreateUserAsync(UserCreateDto dto);
        Task<ICollection<UserReadDto>> GetAllUserAsync();
        Task<UserReadDto?> GetByIdUserAsync(Guid id);
    }
}
