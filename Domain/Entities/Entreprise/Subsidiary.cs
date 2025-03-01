
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Entreprise
{
    public class Subsidiary : AuditableEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public required string Name { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Address { get; set; }
        public bool IsActive { get; set; }
    }
}
