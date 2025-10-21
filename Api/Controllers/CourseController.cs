using Microsoft.AspNetCore.Mvc;
using CiberCheck.Interfaces;
using CiberCheck.Features.Courses.Entities;
using CiberCheck.Features.Courses.Dtos;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;
using System.Linq;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly IMapper _mapper;

        public CourseController(ICourseService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar cursos", Description = "Obtiene todos los cursos disponibles.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CourseDtoListExample))]
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<CourseDto>>(items));
        }

        [HttpGet("teacher/{teacherId:int}")]
        [SwaggerOperation(Summary = "Listar cursos del profesor", Description = "Obtiene todos los cursos de un profesor con sus secciones.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(TeacherCourseDtoListExample))]
        public async Task<ActionResult<IEnumerable<TeacherCourseDto>>> GetCoursesByTeacher(int teacherId)
        {
            var courses = await _service.GetCoursesByTeacherIdAsync(teacherId);

            var result = courses
                .SelectMany(c => c.Sections
                    .Where(s => s.TeacherId == teacherId)
                    .Select(s => new TeacherCourseDto
                    {
                        CourseId = c.CourseId,
                        Name = c.Name,
                        Code = c.Code,
                        SectionId = s.SectionId,
                        Section = s.Name
                    }))
                .ToList();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obtener curso por Id", Description = "Retorna un curso por su identificador.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(CourseDtoExample))]
        public async Task<ActionResult<CourseDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<CourseDto>(item));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crear curso", Description = "Crea un nuevo curso.")]
        [SwaggerRequestExample(typeof(CreateCourseDto), typeof(CreateCourseDtoExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(CourseDtoExample))]
        public async Task<ActionResult<CourseDto>> Create([FromBody] CreateCourseDto dto)
        {
            var entity = _mapper.Map<Course>(dto);
            var created = await _service.CreateAsync(entity);
            var result = _mapper.Map<CourseDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = result.CourseId }, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Actualizar curso", Description = "Actualiza un curso existente.")]
        [SwaggerRequestExample(typeof(UpdateCourseDto), typeof(UpdateCourseDtoExample))]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            var ok = await _service.UpdateAsync(id, existing);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Eliminar curso", Description = "Elimina un curso por su identificador.")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
