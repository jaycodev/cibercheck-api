using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Interfaces;
using CiberCheck.Features.Users.Entities;
using CiberCheck.Features.Users.Dtos;
using CiberCheck.Features.Users.Security;
using CiberCheck.Swagger.Examples;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        private readonly IMapper _mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Listar usuarios", Description = "Obtiene todos los usuarios.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserDtoListExample))]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(_mapper.Map<List<UserDto>>(users));
        }

        [HttpGet("{id:int}")]
        [SwaggerOperation(Summary = "Obtener usuario por Id", Description = "Retorna un usuario por su identificador.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserDtoExample))]
        public async Task<ActionResult<UserDto>> GetById(int id)
        {
            var user = await _service.GetByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Crear usuario", Description = "Crea un nuevo usuario.")]
        [SwaggerRequestExample(typeof(CreateUserDto), typeof(CreateUserDtoExample))]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto dto)
        {
            if (await _service.EmailExistsAsync(dto.Email))
            {
                return Conflict(new ProblemDetails
                {
                    Title = "Email ya registrado",
                    Detail = "El email proporcionado ya existe.",
                    Status = StatusCodes.Status409Conflict
                });
            }

            var entity = _mapper.Map<User>(dto);
            entity.PasswordHash = PasswordHasher.Hash(dto.Password);

            var created = await _service.CreateAsync(entity);
            var result = _mapper.Map<UserDto>(created);
            return CreatedAtAction(nameof(GetById), new { id = result.UserId }, result);
        }

        [HttpPut("{id:int}")]
        [SwaggerOperation(Summary = "Actualizar usuario", Description = "Actualiza un usuario existente.")]
        [SwaggerRequestExample(typeof(UpdateUserDto), typeof(UpdateUserDtoExample))]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto dto)
        {
            var existing = await _service.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing);

            var ok = await _service.UpdateAsync(id, existing);
            if (!ok) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [SwaggerOperation(Summary = "Eliminar usuario", Description = "Elimina un usuario por su identificador.")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
