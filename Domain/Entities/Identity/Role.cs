namespace Domain.Entities.Identity
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ICollection<User> Users { get; } = [];
        public ICollection<UserRole> UserRoles { get; } = [];
    }
}
