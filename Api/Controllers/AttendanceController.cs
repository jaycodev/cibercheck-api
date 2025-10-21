using Microsoft.AspNetCore.Mvc;
using CiberCheck.Interfaces;
using CiberCheck.Features.Attendance.Entities;
using CiberCheck.Features.Attendance.Dtos;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/attendances")]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _service;
        private readonly IMapper _mapper;

        public AttendanceController(IAttendanceService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar asistencias", Description = "Obtiene todas las asistencias.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AttendanceDtoListExample))]
        public async Task<ActionResult<IEnumerable<AttendanceDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<AttendanceDto>>(items));
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
