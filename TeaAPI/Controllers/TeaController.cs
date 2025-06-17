using Microsoft.AspNetCore.Mvc;
using TeaAPI.Infrastructure;
using TeaAPI.Interfaces;
using TeaAPI.Services;

namespace TeaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/tea
    public class TeaController : ControllerBase
    {
        private readonly ITeaService _teaService;
        public TeaController(ITeaService teaService)
        {
            _teaService = teaService;
        }

        // GET: api/tea
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeaDTO>))]
        public async Task<ActionResult<IEnumerable<TeaDTO>>> GetAllTeas()
        {
            var teas = await _teaService.GetAllTeasAsync();
            return Ok(teas);
        }

        // GET: api/tea/{id}
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeaDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TeaDTO>> GetTeaById(int id)
        {
            var tea = await _teaService.GetTeaByIdAsync(id);
            if (tea == null) return NotFound();
            return Ok(tea);
        }

        // POST: api/tea
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeaDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<TeaDTO>> CreateTea(CreateTeaDTO createTeaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var teaDTO = await _teaService.CreateTeaAsync(createTeaDto);
            return CreatedAtAction(nameof(GetTeaById), new { id = teaDTO.Id }, teaDTO);
        }

        // PUT: api/tea/{id}
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeaDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutTea(int id, UpdateTeaDTO updateTeaDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var updatedTea = await _teaService.UpdateTeaAsync(id, updateTeaDto);
            if (updatedTea == null) return NotFound();
            return Ok(updatedTea);
        }

        // DELETE: api/tea/{id}
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTea(int id)
        {
            var result = await _teaService.DeleteTeaAsync(id);
            if (!result) return NotFound();
            return NoContent(); // 204 No Content
        }
    }
}
