namespace Domain.Entities.Identity
{
    public class RolePermission
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool IsActive { get; set; }
        public bool Create { get; set; }
        public bool Read { get; set; }
        public bool Delete { get; set; }
        public Role Role { get; set; } = null!;
        public Permission Permission { get; set; } = null!;
    }
}
