using AutoMapper;
using Books.Application.DTOs.UserDTOs;
using Books.Application.Interfaces;
using Books.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<Guid> CreateUserAsync(UserCreateDto dto)
        {
            if (dto.Password != dto.ConfirmPassword)
                throw new Exception("Passwords do not match");

            var entity = _mapper.Map<UserEntity>(dto);

            entity.PasswordHash = UserHashings.Hash(dto.Password);

            return await _repo.AddUserAsync(entity);
        }
        public async Task<ICollection<UserReadDto>> GetAllUserAsync()
        {
            var users = await _repo.GetAllUserAsync();
            return _mapper.Map<ICollection<UserReadDto>>(users);
        }
        public async Task<UserReadDto?> GetByIdUserAsync(Guid id)
        {
            var user = await _repo.GetUserByIdAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserReadDto>(user);
        }
    }
}
