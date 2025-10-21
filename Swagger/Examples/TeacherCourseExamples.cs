using CiberCheck.Features.Courses.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class TeacherCourseDtoExample : IExamplesProvider<TeacherCourseDto>
    {
        public TeacherCourseDto GetExamples() => new()
        {
            CourseId = 1,
            Name = "Desarrollo de Aplicaciones M�viles I",
            Code = "DAM-I",
            SectionId = 1,
            Section = "Secci�n A"
        };
    }

    public class TeacherCourseDtoListExample : IExamplesProvider<IEnumerable<TeacherCourseDto>>
    {
        public IEnumerable<TeacherCourseDto> GetExamples() => new List<TeacherCourseDto>
        {
            new() { CourseId = 1, Name = "Desarrollo de Aplicaciones M�viles I", Code = "DAM-I", SectionId = 1, Section = "Secci�n A" },
            new() { CourseId = 1, Name = "Desarrollo de Aplicaciones M�viles I", Code = "DAM-I", SectionId = 2, Section = "Secci�n B" },
            new() { CourseId = 4, Name = "Lenguaje de Programaci�n II", Code = "LP-II", SectionId = 6, Section = "Secci�n A" }
        };
    }
}
