using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Identity
{
    public class User : AuditableEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public required string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salt { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Role> Roles { get; } = [];
        public ICollection<UserRole> UserRoles { get; } = [];
    }
}
