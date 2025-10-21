using Microsoft.AspNetCore.Mvc;
using CiberCheck.Interfaces;
using CiberCheck.Features.Sections.Entities;
using CiberCheck.Features.Sections.Dtos;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/sections")]
    public class SectionController : ControllerBase
    {
        private readonly ISectionService _service;
        private readonly IMapper _mapper;

        public SectionController(ISectionService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar secciones", Description = "Obtiene todas las secciones.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SectionDtoListExample))]
        public async Task<ActionResult<IEnumerable<SectionDto>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<SectionDto>>(items));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obtener sección por Id", Description = "Retorna una sección por su identificador.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(SectionDtoExample))]
        public async Task<ActionResult<SectionDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(_mapper.Map<SectionDto>(item));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crear sección", Description = "Crea una nueva sección.")]
        [SwaggerRequestExample(typeof(CreateSectionDto), typeof(CreateSectionDtoExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(SectionDtoExample))]
        public async Task<ActionResult<SectionDto>> Create([FromBody] CreateSectionDto dto)
        {
            var entity = _mapper.Map<Section>(dto);
            var created = await _service.CreateAsync(entity);
            var result = _mapper.Map<SectionDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = result.SectionId }, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Actualizar sección", Description = "Actualiza una sección existente.")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateSectionDto dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();
            _mapper.Map(dto, existing);
            var ok = await _service.UpdateAsync(id, existing);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Eliminar sección", Description = "Elimina una sección por su identificador.")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
