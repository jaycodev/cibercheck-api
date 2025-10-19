using System.Collections.Generic;
using CiberCheck.Features.Courses.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CreateCourseDtoExample : IExamplesProvider<CreateCourseDto>
    {
        public CreateCourseDto GetExamples() => new()
        {
            Name = "Mathematics I",
            Code = "MATH101"
        };
    }

    public class UpdateCourseDtoExample : IExamplesProvider<UpdateCourseDto>
    {
        public UpdateCourseDto GetExamples() => new()
        {
            Name = "Mathematics I - Updated",
            Code = "MATH101"
        };
    }

    public class CourseDtoExample : IExamplesProvider<CourseDto>
    {
        public CourseDto GetExamples() => new()
        {
            CourseId = 1,
            Name = "Mathematics I",
            Code = "MATH101"
        };
    }

    public class CourseDtoListExample : IExamplesProvider<IEnumerable<CourseDto>>
    {
        public IEnumerable<CourseDto> GetExamples() => new List<CourseDto>
        {
            new() { CourseId = 1, Name = "Mathematics I", Code = "MATH101" },
            new() { CourseId = 2, Name = "Physics I", Code = "PHYS101" }
        };
    }
}
