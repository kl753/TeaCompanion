/*Entry points for HTTP requests
 * Handles GET, POST, PUT, DELETE requests for user data.
 * Uses services layer to interact with user data.
 */
using Microsoft.AspNetCore.Mvc;
using TeaAPI.DTOs;
using TeaAPI.Services;

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/users
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //GET: api/users
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserDto>))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        //GET: api/users/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // Fix for CS0029: Ensure the method returns a Task<ActionResult<UserDto>> by wrapping the result in Task.FromResult.

        [HttpPost("create")] // Specify route for clarity
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)] // For username/email conflicts
        public async Task<ActionResult<UserDto>> PostUser(CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var userDto = await _userService.CreateUserAsync(createUserDto);
                return CreatedAtAction(nameof(GetUser), new { id = userDto.Id }, userDto);
            }
            catch (ApplicationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        //PUT: api/users/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> PutUser(int id, UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var updatedUserDto = await _userService.UpdateUserAsync(id, updateUserDto);
                if (updatedUserDto == null)
                {
                    return NotFound();
                }
                return Ok(updatedUserDto);
            }
            catch (ApplicationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        //DELETE: api/users/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleted = await _userService.DeleteUserAsync(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
