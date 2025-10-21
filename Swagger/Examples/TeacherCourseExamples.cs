using CiberCheck.Features.Courses.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class TeacherCourseDtoExample : IExamplesProvider<TeacherCourseDto>
    {
        public TeacherCourseDto GetExamples() => new()
        {
            CourseId = 1,
            Name = "Desarrollo de Aplicaciones Móviles I",
            Code = "DAM-I",
            SectionId = 1,
            Section = "Sección A"
        };
    }

    public class TeacherCourseDtoListExample : IExamplesProvider<IEnumerable<TeacherCourseDto>>
    {
        public IEnumerable<TeacherCourseDto> GetExamples() => new List<TeacherCourseDto>
        {
            new() { CourseId = 1, Name = "Desarrollo de Aplicaciones Móviles I", Code = "DAM-I", SectionId = 1, Section = "Sección A" },
            new() { CourseId = 1, Name = "Desarrollo de Aplicaciones Móviles I", Code = "DAM-I", SectionId = 2, Section = "Sección B" },
            new() { CourseId = 4, Name = "Lenguaje de Programación II", Code = "LP-II", SectionId = 6, Section = "Sección A" }
        };
    }
}
