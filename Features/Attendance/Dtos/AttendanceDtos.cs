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
}
