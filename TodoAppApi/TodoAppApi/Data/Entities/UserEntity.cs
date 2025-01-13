using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAppApi.Data.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public string? SecondName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }


    public required string PasswordSalt {  get; set; }
    public required string PasswordHash {  get; set; } = string.Empty;
    public string? SessionToken {  get; set; }
    public DateTime? TokenExpiry { get; set; }


    // Navigation Property
    public AddressEntity Address { get; set; }
    public List<TodoEntity> Todos { get; set; } = new List<TodoEntity>();

}
