﻿
namespace Domain.Identity
{
    public class UserRole : AuditableEntity
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
