using Books.Application.DTOs.UserDTOs;
using Books.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Books.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserService _userService):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUserAsync();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _userService.GetByIdUserAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateDto dto)
        {
            var id = await _userService.CreateUserAsync(dto);

            if (id != null)
            {
                return CreatedAtAction(nameof(GetUserById), new { id }, id);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
