using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using TeaAPI.DTOs;
using TeaAPI.Services;

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/stash")]
    [Authorize]
    public class UserStashController : ControllerBase
    {
        private readonly IUserTeaStashService _stashService;

        public UserStashController(IUserTeaStashService stashService)
        {
            _stashService = stashService;
        }

        //Helper to get current user's Id from JWT token
        private int GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                throw new UnauthorizedAccessException("User ID not found in token.");
            }
            return userId;
        }

        //Ensure userId in route matches the authenticated user's id
        private IActionResult ValidateUserAccess(int routeUserId)
        {
            var currentUserId = GetCurrentUserId();
            if (routeUserId != currentUserId)
            {
                return Forbid("You do not have permission to access this user's stash.");
            }
            return Ok();
        }

        //GET: api/users/{userId}/stash
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserTeaStashEntryDto>))]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<IEnumerable<UserTeaStashEntryDto>>> GetStashEntries(int userId)
        {
            var validationResult = ValidateUserAccess(userId);
            if (validationResult is ForbidResult) return validationResult;
            
            var entries = await _stashService.GetStashEntriesForUserAsync(userId);
            return Ok(entries);
        }

        // GET: api/users/{userId}/stash/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserTeaStashEntryDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserTeaStashEntryDto>> GetStashEntry(int userId, int id)
        {
            var validationResult = ValidateUserAccess(userId);
            if (validationResult is ForbidResult) return validationResult;
            
            var entry = await _stashService.GetStashEntryByIdAsync(id, userId);
            if (entry == null)
            {
                return NotFound();
            }
            return Ok(entry);
        }

        // POST: api/users/{userId}/stash
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(UserTeaStashEntryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserTeaStashEntryDto>> CreateTeaToStash(int userId, [FromBody] CreateUserTeaStashEntryDto createDto)
        {
            var validationResult = ValidateUserAccess(userId);
            if (validationResult is ForbidResult) return validationResult;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newEntry = await _stashService.CreateTeaStashAsync(userId, createDto);
                return CreatedAtAction(nameof(GetStashEntry), new { userId = userId, id = newEntry.Id }, newEntry);
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // PUT: api/users/{userId}/stash/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserTeaStashEntryDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateStashEntry(int userId, int id, [FromBody] UpdateUserTeaStashEntryDto updateDto)
        {
            var validationResult = ValidateUserAccess(userId);
            if (validationResult is ForbidResult) return validationResult;
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var updatedEntry = await _stashService.UpdateStashEntryAsync(id, userId, updateDto);
            if (updatedEntry == null)
            {
                return NotFound();
            }
            return Ok(updatedEntry);
        }

        // DELETE: api/users/{userId}/stash/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> DeleteStashEntry(int userId, int id)
        {
            var validationResult = ValidateUserAccess(userId);
            if (validationResult is ForbidResult) return validationResult;
            
            var deleted = await _stashService.DeleteStashEntryAsync(id, userId);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}