/*Entry points for HTTP requests
 * Handles GET, POST, PUT, and DELETE requests for tea data.
 * Uses service layer to perform operations on tea data.
 */
using Microsoft.AspNetCore.Mvc;
using TeaAPI.DTOs; // Assuming DTOs are in the DTOs namespace
using TeaAPI.Services; // Assuming the service layer is in the Services namespace

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/teas
    public class TeaController : ControllerBase
    {
        private readonly ITeaService _teaService;

        public TeaController(ITeaService teaService)
        {
            _teaService = teaService;
        }

        //GET: api/teas
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeaDto>))]
        public async Task<ActionResult<IEnumerable<TeaDto>>> GetTeas()
        {
            var teas = await _teaService.GetAllTeasAsync();
            return Ok(teas);
        }

        //GET: api/teas/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeaDto>> GetTea(int id)
        {
            var tea = await _teaService.GetTeaByIdAsync(id);
            if (tea == null) return NotFound();
            return Ok(tea);
        }

        //POST: api/teas
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeaDto>> PostTea(CreateTeaDto createTeaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState); //Validate the model state
            var teaDto = await _teaService.CreateTeaAsync(createTeaDto);
            // Return 201 Created with the location of the new resource
            return CreatedAtAction(nameof(GetTea), new { id = teaDto.Id }, teaDto);
        }

        //PUT: api/teas/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTea(int id, [FromBody] UpdateTeaDto updateTeaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedTeaDto = await _teaService.UpdateTeaAsync(id, updateTeaDto);
            if (updatedTeaDto == null) return NotFound();
            return Ok(updatedTeaDto);
        }

        //DELETE: api/teas/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTea(int id)
        {
            var deleted = await _teaService.DeleteTeaAsync(id);
            if (!deleted) return NotFound();
            return NoContent(); // 204 No Content
        }
    }
}
