using System.Collections.Generic;
using CiberCheck.Features.Sessions.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CreateSessionDtoExample : IExamplesProvider<CreateSessionDto>
    {
        public CreateSessionDto GetExamples() => new()
        {
            SectionId = 1,
            Date = new DateOnly(2025,10,16),
            StartTime = new TimeOnly(8,0),
            EndTime = new TimeOnly(10,0),
            Topic = "Linear Equations"
        };
    }

    public class UpdateSessionDtoExample : IExamplesProvider<UpdateSessionDto>
    {
        public UpdateSessionDto GetExamples() => new()
        {
            Date = new DateOnly(2025,10,23),
            StartTime = new TimeOnly(8,0),
            EndTime = new TimeOnly(10,0),
            Topic = "Quadratic Functions"
        };
    }

    public class SessionDtoExample : IExamplesProvider<SessionDto>
    {
        public SessionDto GetExamples() => new()
        {
            SessionId = 1,
            SectionId = 1,
            Date = new DateOnly(2025,10,16),
            StartTime = new TimeOnly(8,0),
            EndTime = new TimeOnly(10,0),
            Topic = "Linear Equations"
        };
    }

    public class SessionDtoListExample : IExamplesProvider<IEnumerable<SessionDto>>
    {
        public IEnumerable<SessionDto> GetExamples() => new List<SessionDto>
        {
            new() { SessionId = 1, SectionId = 1, Date = new DateOnly(2025,10,16), StartTime = new TimeOnly(8,0), EndTime = new TimeOnly(10,0), Topic = "Linear Equations" },
            new() { SessionId = 2, SectionId = 1, Date = new DateOnly(2025,10,23), StartTime = new TimeOnly(8,0), EndTime = new TimeOnly(10,0), Topic = "Quadratic Functions" }
        };
    }
}
