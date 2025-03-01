using Domain.Entities.Entreprise;


namespace Domain.Entities.Products
{
    public class ProductSubsidiary : AuditableEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SubsidiaryId {  get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Product Product { get; set; } = null!;
        public Subsidiary Subsidiary { get; set; } = null!;
    }
}
