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
            Slug = "desarrollo-de-aplicaciones-moviles-i",
            SectionId = 1,
            Section = "Sección A",
            SectionSlug = "seccion-a"
        };
    }

    public class TeacherCourseDtoListExample : IExamplesProvider<IEnumerable<TeacherCourseDto>>
    {
        public IEnumerable<TeacherCourseDto> GetExamples() => new List<TeacherCourseDto>
        {
            new() { CourseId = 1, Name = "Desarrollo de Aplicaciones Móviles I", Code = "DAM-I", Slug = "desarrollo-de-aplicaciones-moviles-i", SectionId = 1, Section = "Sección A", SectionSlug = "seccion-a" },
            new() { CourseId = 1, Name = "Desarrollo de Aplicaciones Móviles I", Code = "DAM-I", Slug = "desarrollo-de-aplicaciones-moviles-i", SectionId = 2, Section = "Sección B", SectionSlug = "seccion-b" },
            new() { CourseId = 4, Name = "Lenguaje de Programación II", Code = "LP-II", Slug = "lenguaje-de-programacion-ii", SectionId = 6, Section = "Sección A", SectionSlug = "seccion-a" }
        };
    }
}
