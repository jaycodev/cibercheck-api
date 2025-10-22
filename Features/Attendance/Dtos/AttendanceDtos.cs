using System;
using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace CiberCheck.Features.Attendance.Dtos
{
    [SwaggerSchema(Description = "Registro de asistencia")]
    public class AttendanceDto
    {
        public int StudentId { get; set; }
        public int SessionId { get; set; }
        public string Status { get; set; } = null!;
        public string? Notes { get; set; }
    }

    [SwaggerSchema(Description = "Payload para crear asistencia")]
    public class CreateAttendanceDto
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SessionId { get; set; }
        [Required]
        public string Status { get; set; } = null!;
        public string? Notes { get; set; }
    }

    [SwaggerSchema(Description = "Payload para actualizar asistencia")]
    public class UpdateAttendanceDto
    {
        [Required]
        public string Status { get; set; } = null!;
        public string? Notes { get; set; }
    }

    [SwaggerSchema(Description = "Estudiante con asistencia en una sesión")]
    public class StudentAttendanceDto
    {
        [SwaggerSchema(Description = "Identificador del estudiante")]
        public int StudentId { get; set; }
        [SwaggerSchema(Description = "Nombre del estudiante")]
        public string FirstName { get; set; } = null!;
        [SwaggerSchema(Description = "Apellido del estudiante")]
        public string LastName { get; set; } = null!;
        [SwaggerSchema(Description = "Email del estudiante")]
        public string Email { get; set; } = null!;
        [SwaggerSchema(Description = "Estado de asistencia (presente, ausente, tarde, justificado)")]
        public string? Status { get; set; }
        [SwaggerSchema(Description = "Notas sobre la asistencia")]
        public string? Notes { get; set; }
    }

    [SwaggerSchema(Description = "Asistencia de una sesión completa")]
    public class SessionAttendanceDto
    {
        [SwaggerSchema(Description = "Slug del curso")]
        public string CourseSlug { get; set; } = null!;
        [SwaggerSchema(Description = "Nombre del curso")]
        public string CourseName { get; set; } = null!;
        [SwaggerSchema(Description = "Código del curso")]
        public string CourseCode { get; set; } = null!;
        [SwaggerSchema(Description = "Slug de la sección")]
        public string SectionSlug { get; set; } = null!;
        [SwaggerSchema(Description = "Nombre de la sección")]
        public string SectionName { get; set; } = null!;
        [SwaggerSchema(Description = "Lista de estudiantes con asistencia")]
        public List<StudentAttendanceDto> Students { get; set; } = new();
    }
}
