using System.Collections.Generic;
using CiberCheck.Features.Users.Dtos;
using Swashbuckle.AspNetCore.Filters;

namespace CiberCheck.Swagger.Examples
{
    public class CreateUserDtoExample : IExamplesProvider<CreateUserDto>
    {
        public CreateUserDto GetExamples() => new()
        {
            FullName = "Juan Pérez",
            Email = "juan.perez@ejemplo.com",
            Role = "student",
            Password = "StrongP@ssw0rd"
        };
    }

    public class UpdateUserDtoExample : IExamplesProvider<UpdateUserDto>
    {
        public UpdateUserDto GetExamples() => new()
        {
            FullName = "Juan Pérez Actualizado",
            Role = "student"
        };
    }

    public class UserDtoExample : IExamplesProvider<UserDto>
    {
        public UserDto GetExamples() => new()
        {
            UserId = 1,
            FullName = "Juan Pérez",
            Email = "juan.perez@ejemplo.com",
            Role = "student"
        };
    }

    public class UserDtoListExample : IExamplesProvider<IEnumerable<UserDto>>
    {
        public IEnumerable<UserDto> GetExamples() => new List<UserDto>
        {
            new() { UserId = 1, FullName = "Juan Pérez", Email = "juan.perez@ejemplo.com", Role = "student" },
            new() { UserId = 2, FullName = "Ana López", Email = "ana.lopez@ejemplo.com", Role = "teacher" }
        };
    }
}
