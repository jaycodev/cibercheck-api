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
