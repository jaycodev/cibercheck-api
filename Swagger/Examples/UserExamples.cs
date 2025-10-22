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
            Email = "juan.perez@instituto.edu",
            Role = "profesor",
            Password = "profe123"
        };
    }

    public class UpdateUserDtoExample : IExamplesProvider<UpdateUserDto>
    {
        public UpdateUserDto GetExamples() => new()
        {
            FullName = "Juan Pérez Actualizado",
            Role = "profesor"
        };
    }

    public class UserDtoExample : IExamplesProvider<UserDto>
    {
        public UserDto GetExamples() => new()
        {
            UserId = 1,
            FullName = "Juan Pérez",
            Email = "juan.perez@instituto.edu",
            Role = "profesor"
        };
    }

    public class UserDtoListExample : IExamplesProvider<IEnumerable<UserDto>>
    {
        public IEnumerable<UserDto> GetExamples() => new List<UserDto>
        {
            new() { UserId = 1, FullName = "Juan Pérez", Email = "juan.perez@instituto.edu", Role = "profesor" },
            new() { UserId = 5, FullName = "Ana López", Email = "ana.lopez@instituto.edu", Role = "estudiante" }
        };
    }
}
