using System.Collections.Generic;
using CiberCheck.Features.Sections.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CreateSectionDtoExample : IExamplesProvider<CreateSectionDto>
    {
        public CreateSectionDto GetExamples() => new()
        {
            CourseId = 1,
            TeacherId = 1,
            Name = "Sección A"
        };
    }

    public class UpdateSectionDtoExample : IExamplesProvider<UpdateSectionDto>
    {
        public UpdateSectionDto GetExamples() => new()
        {
            CourseId = 1,
            TeacherId = 1,
            Name = "Sección B"
        };
    }

    public class SectionDtoExample : IExamplesProvider<SectionDto>
    {
        public SectionDto GetExamples() => new()
        {
            SectionId = 1,
            CourseId = 1,
            TeacherId = 1,
            Name = "Sección A",
            Slug = "seccion-a"
        };
    }

    public class SectionDtoListExample : IExamplesProvider<IEnumerable<SectionDto>>
    {
        public IEnumerable<SectionDto> GetExamples() => new List<SectionDto>
        {
            new() { SectionId = 1, CourseId = 1, TeacherId = 1, Name = "Sección A", Slug = "seccion-a" },
            new() { SectionId = 2, CourseId = 1, TeacherId = 1, Name = "Sección B", Slug = "seccion-b" }
        };
    }
}
