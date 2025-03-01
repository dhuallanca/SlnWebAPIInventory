
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public abstract class AuditableEntity
    {
        public DateTime Created { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }
        [Column(TypeName = "varchar(60)")]
        public string? LastModifiedBy { get; set; }
    }
}
