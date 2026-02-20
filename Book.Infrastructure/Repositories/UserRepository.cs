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
    public class UserRepository:IUserRepository
    {
        private readonly LibraryDBContext _context;

        public UserRepository(LibraryDBContext context)
        {
            _context = context;
        }
        public async Task<Guid> AddUserAsync(UserEntity user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }
        public async Task<ICollection<UserEntity>> GetAllUserAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<UserEntity?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
