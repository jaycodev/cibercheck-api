using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CiberCheck.Features.Sections.Dtos
{
    [SwaggerSchema(Description = "Sección de un curso")]
    public class SectionDto
    {
        public int SectionId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; } = null!;
        [SwaggerSchema(Description = "Slug único de la sección dentro del curso")]
        public string Slug { get; set; } = null!;
    }

    [SwaggerSchema(Description = "Payload para crear una sección")]
    public class CreateSectionDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }

    [SwaggerSchema(Description = "Payload para actualizar una sección")]
    public class UpdateSectionDto
    {
        [Required]
        public int CourseId { get; set; }
        [Required]
        public int TeacherId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
    }

    [SwaggerSchema(Description = "Sección de un curso con estadísticas")]
    public class SectionStatsDto
    {
        [SwaggerSchema(Description = "Slug único de la sección")]
        public string SectionSlug { get; set; } = null!;
        [SwaggerSchema(Description = "Nombre de la sección")]
        public string SectionName { get; set; } = null!;
        [SwaggerSchema(Description = "Total de sesiones en la sección")]
        public int TotalSessions { get; set; }
        [SwaggerSchema(Description = "Total de estudiantes en la sección")]
        public int TotalStudents { get; set; }
    }
}
