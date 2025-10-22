using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CiberCheck.Interfaces;
using CiberCheck.Features.Attendance.Entities;
using CiberCheck.Features.Attendance.Dtos;
using CiberCheck.Features.Common.Authorization;
using CiberCheck.Data;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;
using System.Linq;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/attendances")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
        private readonly ICourseService _courseService;
        private readonly ISectionService _sectionService;
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public AttendanceController(
            IAttendanceService service,
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

        [HttpGet("course/{courseSlug}/section/{sectionSlug}/session/{sessionNumber:int}")]
        [RequireTeacher]
        [SwaggerOperation(
            Summary = "Ver asistencia de una sesión",
            Description = "Obtiene la lista de estudiantes de la sección con su asistencia para una sesión específica."
        )]
        public async Task<ActionResult> GetSessionAttendance(string courseSlug, string sectionSlug, int sessionNumber)
        {
            var course = await _courseService.GetBySlugAsync(courseSlug);
            if (course == null) return NotFound(new { message = "Curso no encontrado" });

            var section = await _sectionService.GetBySlugAsync(course.CourseId, sectionSlug);
            if (section == null) return NotFound(new { message = "Sección no encontrada" });

            var session = await _db.Sessions
                .AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectionId == section.SectionId && s.SessionNumber == sessionNumber);

            if (session == null) return NotFound(new { message = "Sesión no encontrada" });

            var studentsWithAttendance = await _db.Users
                .Where(u => u.SectionsNavigation.Any(s => s.SectionId == section.SectionId))
                .Select(student => new
                {
                    studentId = student.UserId,
                    fullName = student.FullName,
                    email = student.Email,
                    attendance = _db.Attendances
                        .Where(a => a.StudentId == student.UserId && a.SessionId == session.SessionId)
                        .Select(a => new
                        {
                            status = a.Status,
                            notes = a.Notes
                        })
                        .FirstOrDefault()
                })
                .OrderBy(s => s.fullName)
                .ToListAsync();

            return Ok(new
            {
                course = new
                {
                    id = course.CourseId,
                    name = course.Name,
                    slug = course.Slug
                },
                section = new
                {
                    id = section.SectionId,
                    name = section.Name,
                    slug = section.Slug
                },
                session = new
                {
                    id = session.SessionId,
                    sessionNumber = session.SessionNumber,
                    date = session.Date,
                    startTime = session.StartTime,
                    endTime = session.EndTime,
                    topic = session.Topic
                },
                students = studentsWithAttendance
            });
        }

        [HttpGet("{studentId:int}/{sessionId:int}")]
        [SwaggerOperation(Summary = "Obtener asistencia por claves", Description = "Retorna una asistencia por StudentId y SessionId.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AttendanceDtoExample))]
        public async Task<ActionResult<AttendanceDto>> GetById(int studentId, int sessionId)
        {
            var item = await _service.GetByIdAsync(studentId, sessionId);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<AttendanceDto>(item));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crear asistencia", Description = "Crea un registro de asistencia.")]
        [SwaggerRequestExample(typeof(CreateAttendanceDto), typeof(CreateAttendanceDtoExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(AttendanceDtoExample))]
        public async Task<ActionResult<AttendanceDto>> Create([FromBody] CreateAttendanceDto dto)
        {
            var entity = _mapper.Map<Attendance>(dto);
            var created = await _service.CreateAsync(entity);
            var result = _mapper.Map<AttendanceDto>(created);
            return CreatedAtAction(nameof(GetById), new { studentId = result.StudentId, sessionId = result.SessionId }, result);
        }

        [HttpPut("{studentId:int}/{sessionId:int}")]
        [SwaggerOperation(Summary = "Actualizar asistencia", Description = "Actualiza un registro de asistencia.")]
        public async Task<IActionResult> Update(int studentId, int sessionId, [FromBody] UpdateAttendanceDto dto)
        {
            var existing = await _service.GetByIdAsync(studentId, sessionId);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            var ok = await _service.UpdateAsync(studentId, sessionId, existing);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{studentId:int}/{sessionId:int}")]
        [SwaggerOperation(Summary = "Eliminar asistencia", Description = "Elimina un registro de asistencia.")]
        public async Task<IActionResult> Delete(int studentId, int sessionId)
        {
            var ok = await _service.DeleteAsync(studentId, sessionId);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
