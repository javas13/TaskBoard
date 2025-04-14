using System.ComponentModel.DataAnnotations;

namespace TaskBoard.API.Contracts.Users
{
    public record RegisterUserRequest(
        [Required] string firstname,
        [Required] string surname,
        [Required] string password,
        [Required] string email)
    {
    }
}
