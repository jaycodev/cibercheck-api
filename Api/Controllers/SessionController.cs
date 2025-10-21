using Microsoft.AspNetCore.Mvc;
using CiberCheck.Interfaces;
using CiberCheck.Features.Sessions.Entities;
using CiberCheck.Features.Sessions.Dtos;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;
        private readonly IMapper _mapper;

        public SessionController(ISessionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar sesiones", Description = "Obtiene todas las sesiones.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SessionDtoListExample))]
        public async Task<ActionResult<IEnumerable<SessionDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<SessionDto>>(items));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obtener sesión por Id", Description = "Retorna una sesión por su identificador.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SessionDtoExample))]
        public async Task<ActionResult<SessionDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<SessionDto>(item));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crear sesión", Description = "Crea una nueva sesión.")]
        [SwaggerRequestExample(typeof(CreateSessionDto), typeof(CreateSessionDtoExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(SessionDtoExample))]
        public async Task<ActionResult<SessionDto>> Create([FromBody] CreateSessionDto dto)
        {
            var entity = _mapper.Map<Session>(dto);
            var created = await _service.CreateAsync(entity);
            var result = _mapper.Map<SessionDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = result.SessionId }, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Actualizar sesión", Description = "Actualiza una sesión existente.")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSessionDto dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            var ok = await _service.UpdateAsync(id, existing);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Eliminar sesión", Description = "Elimina una sesión por su identificador.")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
