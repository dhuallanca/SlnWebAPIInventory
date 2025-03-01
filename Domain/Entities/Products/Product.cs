

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.Products
{
    public class Product : AuditableEntity
    {
        public int Id { get; set; }
        [Column(TypeName = "varchar(60)")]
        public required string Name { get; set; }
        [Column(TypeName = "varchar(150)")]
        public string? Description { get; set; }
        public int CategoryId { get; set; }
    }
}
