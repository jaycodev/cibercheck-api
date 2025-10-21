using System;
using System.Collections.Generic;
using CiberCheck.Features.Sessions.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CourseSessionDtoExample : IExamplesProvider<CourseSessionDto>
    {
        public CourseSessionDto GetExamples() => new()
        {
          SessionId = 1,
 CourseId = 1,
            SectionId = 1,
        Date = new DateOnly(2025, 10, 14),
            StartTime = new TimeOnly(8, 0),
    EndTime = new TimeOnly(10, 0),
            Topic = "Introducción a Android Studio",
 };
    }

    public class CourseSessionDtoListExample : IExamplesProvider<IEnumerable<CourseSessionDto>>
    {
      public IEnumerable<CourseSessionDto> GetExamples() => new List<CourseSessionDto>
        {
      new()
    {
        SessionId = 1,
  CourseId = 1,
   SectionId = 1,
      Date = new DateOnly(2025, 10, 14),
     StartTime = new TimeOnly(8, 0),
       EndTime = new TimeOnly(10, 0),
  Topic = "Introducción a Android Studio"
    },
            new()
            {
    SessionId = 2,
    CourseId = 1,
           SectionId = 1,
       Date = new DateOnly(2025, 10, 21),
       StartTime = new TimeOnly(8, 0),
                EndTime = new TimeOnly(10, 0),
Topic = "Componentes de UI en Android"
      }
        };
    }
}
