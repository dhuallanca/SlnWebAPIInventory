using Domain.ResultHandler;

namespace Domain.Entities.Products
{
    public static class CategoryBehavior
    {
        public static readonly Error CategoryNameExists = new Error("Category Name already exists", ErrorHttpStatus.BadRequest);
    }
}
