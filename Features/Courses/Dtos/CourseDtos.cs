using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CiberCheck.Features.Courses.Dtos
{
    [SwaggerSchema(Description = "Curso disponible para inscripción")]
    public class CourseDto
    {
        [SwaggerSchema(Description = "Identificador del curso")]
        public int CourseId { get; set; }
        [SwaggerSchema(Description = "Nombre del curso")]
        public string Name { get; set; } = null!;
        [SwaggerSchema(Description = "Código único del curso")]
        public string Code { get; set; } = null!;
        [SwaggerSchema(Description = "Slug único del curso para URLs amigables")]
        public string Slug { get; set; } = null!;
    }

    [SwaggerSchema(Description = "Curso del profesor con sección")]
    public class TeacherCourseDto
    {
        [SwaggerSchema(Description = "Identificador del curso")]
        public int CourseId { get; set; }
        [SwaggerSchema(Description = "Nombre del curso")]
        public string Name { get; set; } = null!;
        [SwaggerSchema(Description = "Código único del curso")]
        public string Code { get; set; } = null!;
        [SwaggerSchema(Description = "Slug del curso")]
        public string Slug { get; set; } = null!;
        [SwaggerSchema(Description = "Identificador de la sección")]
        public int SectionId { get; set; }
        [SwaggerSchema(Description = "Nombre de la sección")]
        public string Section { get; set; } = null!;
        [SwaggerSchema(Description = "Slug de la sección")]
        public string SectionSlug { get; set; } = null!;
    }

    [SwaggerSchema(Description = "Payload para crear un curso")]
    public class CreateCourseDto
    {
        [Required]
        [MaxLength(100)]
        [SwaggerSchema(Description = "Nombre del curso")]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        [SwaggerSchema(Description = "Código único del curso")]
        public string Code { get; set; } = null!;
    }

    [SwaggerSchema(Description = "Payload para actualizar un curso")]
    public class UpdateCourseDto
    {
        [Required]
        [MaxLength(100)]
        [SwaggerSchema(Description = "Nombre del curso")]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        [SwaggerSchema(Description = "Código único del curso")]
        public string Code { get; set; } = null!;
    }
}
