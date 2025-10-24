using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CiberCheck.Interfaces;
using CiberCheck.Features.Otps.Dtos;
using CiberCheck.Features.Otps.Entities;
using AutoMapper;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;
using CiberCheck.Swagger.Examples;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CiberCheck.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/otps")]
    public class OtpController : ControllerBase
    {
        private readonly IOtpService _service;
        private readonly IMapper _mapper;

        public OtpController(IOtpService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Genera un nuevo OTP para un correo.
        /// </summary>
        [HttpPost]
        [SwaggerOperation(Summary = "Generar OTP", Description = "Genera un nuevo código OTP para el correo indicado.")]
        [SwaggerRequestExample(typeof(CreateOtpDto), typeof(CreateOtpDtoExample))]
        [SwaggerResponseExample(StatusCodes.Status201Created, typeof(OtpDtoExample))]
        public async Task<ActionResult<OtpDto>> Generate([FromBody] CreateOtpDto dto)
        {
            var otp = await _service.GenerateOtpAsync(dto.Email);
            var result = _mapper.Map<OtpDto>(otp);
            return Created(string.Empty, result);
        }

        /// <summary>
        /// Verifica un OTP y devuelve un JWT si es válido.
        /// </summary>
        [HttpPost("verify")]
        [SwaggerOperation(Summary = "Verificar OTP", Description = "Verifica que el código OTP ingresado sea válido y devuelve un JWT.")]
        [SwaggerRequestExample(typeof(VerifyOtpDto), typeof(VerifyOtpDtoExample))]
        [SwaggerResponse(StatusCodes.Status200OK, "OTP válido, devuelve JWT")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "OTP inválido o expirado")]
        public async Task<IActionResult> Verify([FromBody] VerifyOtpDto dto)
        {
            var jwt = await _service.VerifyOtpAsync(dto.Email, dto.Codigo);
            if (jwt == null) return BadRequest(new { message = "OTP inválido o expirado" });

            return Ok(new { token = jwt, message = "OTP verificado correctamente" });
        }

        /// <summary>
        /// Obtiene el último OTP generado para un correo.
        /// </summary>
        [HttpGet("{email}")]
        [Authorize(Roles = "Admin")]
        [SwaggerOperation(Summary = "Obtener último OTP", Description = "Devuelve el último OTP generado para un correo.")]
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OtpDtoExample))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No se encontró OTP para este correo")]
        public async Task<ActionResult<OtpDto>> GetLastByEmail(string email)
        {
            var otp = await _service.GetLastOtpByEmailAsync(email);
            if (otp == null) return NotFound(new { message = "No se encontró OTP para este correo" });

            return Ok(_mapper.Map<OtpDto>(otp));
        }

        
    }
}
