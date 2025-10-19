using System.ComponentModel.DataAnnotations;

namespace CiberCheck.Features.Users.Dtos
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }

    public class CreateUserDto
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }

    public class UpdateUserDto
    {
        [MaxLength(100)]
        public string? FullName { get; set; }
        [MaxLength(20)]
        public string? Role { get; set; }
    }
}
