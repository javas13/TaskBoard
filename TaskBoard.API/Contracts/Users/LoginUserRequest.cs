using System.ComponentModel.DataAnnotations;

namespace TaskBoard.API.Contracts.Users
{
    public record LoginUserRequest([Required] string password, [Required] string email)
    {
    }
}
