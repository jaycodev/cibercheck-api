using System.Collections.Generic;
using CiberCheck.Features.Attendance.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CreateAttendanceDtoExample : IExamplesProvider<CreateAttendanceDto>
    {
        public CreateAttendanceDto GetExamples() => new()
        {
            StudentId = 5,
            SessionId = 1,
            Status = "presente",
            Notes = null
        };
    }

    public class UpdateAttendanceDtoExample : IExamplesProvider<UpdateAttendanceDto>
    {
        public UpdateAttendanceDto GetExamples() => new()
        {
            Status = "ausente",
            Notes = "Enfermo"
        };
    }

    public class AttendanceDtoExample : IExamplesProvider<AttendanceDto>
    {
        public AttendanceDto GetExamples() => new()
        {
            StudentId = 5,
            SessionId = 1,
            Status = "presente",
            Notes = null
        };
    }

    public class AttendanceDtoListExample : IExamplesProvider<IEnumerable<AttendanceDto>>
    {
        public IEnumerable<AttendanceDto> GetExamples() => new List<AttendanceDto>
        {
            new() { StudentId = 5, SessionId = 1, Status = "presente", Notes = null },
            new() { StudentId = 6, SessionId = 1, Status = "ausente", Notes = "Enfermo" },
            new() { StudentId = 7, SessionId = 1, Status = "tarde", Notes = "Tráfico" }
        };
    }
}
