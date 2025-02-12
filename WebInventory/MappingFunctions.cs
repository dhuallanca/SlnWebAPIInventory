using Application.Dtos;
using Domain.Entities;
using Mapster;

namespace WebInventory
{
    public static class MappingFunctions
    {
        public static ModelDto MapModelToDto(Model model) {
            return model.Adapt<ModelDto>();
        }
        public static Model MapDtoToModel(ModelDto model)
        {
            return model.Adapt<Model>();
        }
    }
}
