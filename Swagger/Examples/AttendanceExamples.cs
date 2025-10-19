using System.Collections.Generic;
using CiberCheck.Features.Attendance.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CreateAttendanceDtoExample : IExamplesProvider<CreateAttendanceDto>
    {
        public CreateAttendanceDto GetExamples() => new()
        {
            StudentId = 3,
            SessionId = 1,
            Status = "present",
            Notes = null
        };
    }

    public class UpdateAttendanceDtoExample : IExamplesProvider<UpdateAttendanceDto>
    {
        public UpdateAttendanceDto GetExamples() => new()
        {
            Status = "absent",
            Notes = "Sick"
        };
    }

    public class AttendanceDtoExample : IExamplesProvider<AttendanceDto>
    {
        public AttendanceDto GetExamples() => new()
        {
            StudentId = 3,
            SessionId = 1,
            Status = "present",
            Notes = null
        };
    }

    public class AttendanceDtoListExample : IExamplesProvider<IEnumerable<AttendanceDto>>
    {
        public IEnumerable<AttendanceDto> GetExamples() => new List<AttendanceDto>
        {
            new() { StudentId = 3, SessionId = 1, Status = "present", Notes = null },
            new() { StudentId = 4, SessionId = 1, Status = "absent", Notes = "Sick" }
        };
    }
}
