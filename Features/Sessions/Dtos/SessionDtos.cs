using System;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CiberCheck.Features.Sessions.Dtos
{
    public class SessionDto
    {
        public int SessionId { get; set; }
        public int SectionId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Topic { get; set; }
    }

    [SwaggerSchema(Description = "Sesión de un curso con información completa")]
    public class CourseSessionDto
    {
        [SwaggerSchema(Description = "Identificador de la sesión")]
        public int SessionId { get; set; }
        [SwaggerSchema(Description = "Identificador del curso")]
        public int CourseId { get; set; }
        [SwaggerSchema(Description = "Identificador de la sección")]
        public int SectionId { get; set; }
        [SwaggerSchema(Description = "Fecha de la sesión")]
        public DateOnly Date { get; set; }
        [SwaggerSchema(Description = "Hora de inicio")]
        public TimeOnly? StartTime { get; set; }
        [SwaggerSchema(Description = "Hora de fin")]
        public TimeOnly? EndTime { get; set; }
        [SwaggerSchema(Description = "Tema de la sesión")]
        public string? Topic { get; set; }
    }

    [SwaggerSchema(Description = "Payload para crear una sesión")]
    public class CreateSessionDto
    {
        [Required]
        public int SectionId { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Topic { get; set; }
    }

    [SwaggerSchema(Description = "Payload para actualizar una sesión")]
    public class UpdateSessionDto
    {
        [Required]
        public DateOnly Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Topic { get; set; }
    }
}
