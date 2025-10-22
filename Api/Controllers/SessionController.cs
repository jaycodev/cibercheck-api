using Microsoft.AspNetCore.Mvc;
using CiberCheck.Interfaces;
using CiberCheck.Features.Sessions.Entities;
using CiberCheck.Features.Sessions.Dtos;
using CiberCheck.Features.Common.Authorization;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;
using Microsoft.EntityFrameworkCore;
using CiberCheck.Data;
using System.Linq;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sessions")]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _service;
        private readonly ICourseService _courseService;
        private readonly ISectionService _sectionService;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public SessionController(
            ISessionService service, 
            ICourseService courseService,
            ISectionService sectionService,
            ApplicationDbContext db,
            IMapper mapper)
        {
            _service = service;
            _courseService = courseService;
            _sectionService = sectionService;
            _db = db;
            _mapper = mapper;
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obtener sesión por Id", Description = "Retorna una sesión por su identificador (para CRUD).")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SessionDtoExample))]
        public async Task<ActionResult<SessionDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<SessionDto>(item));
        }

        [HttpGet("course/{courseSlug}/section/{sectionSlug}")]
        [RequireTeacher]
        [SwaggerOperation(
            Summary = "Listar sesiones por slugs", 
            Description = "Obtiene todas las sesiones de una sección del profesor autenticado usando slugs."
        )]
        public async Task<ActionResult> GetSessionsBySlugs(string courseSlug, string sectionSlug)
        {
            var course = await _courseService.GetBySlugAsync(courseSlug);
            if (course == null) return NotFound(new { message = "Curso no encontrado" });

            var section = await _sectionService.GetBySlugAsync(course.CourseId, sectionSlug);
            if (section == null) return NotFound(new { message = "Sección no encontrada" });

            var sessions = await _db.Sessions
                .Where(s => s.SectionId == section.SectionId)
                .OrderBy(s => s.SessionNumber)
                .AsNoTracking()
                .Select(s => new
                {
                    sessionId = s.SessionId,
                    sessionNumber = s.SessionNumber,
                    date = s.Date,
                    startTime = s.StartTime,
                    endTime = s.EndTime,
                    topic = s.Topic
                })
                .ToListAsync();

            return Ok(sessions);
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
