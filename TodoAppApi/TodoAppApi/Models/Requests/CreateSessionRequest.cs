using System.ComponentModel.DataAnnotations;

namespace TodoAppApi.Models.Requests
{
    public record CreateSessionRequest(
        [EmailAddress]string Email,
        [Required]string Password)
    {
    }
}
