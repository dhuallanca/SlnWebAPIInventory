using Application.Dtos;
using Application.Features.Identity;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;

namespace Application
{
    public static class MappingFunctions<M, DTO>
    {
        public static DTO MapModelToDto(M model) {
            return model.Adapt<DTO>();
        }
        public static M MapDtoToModel(DTO model)
        {
            return model.Adapt<M>();
        }

        public static UserDto MapUserToDto(User model)
        {
            return model.Adapt<UserDto>();
        }
        public static User MapUseDtoToModel(UserDto model)
        {
            return model.Adapt<User>();
        }
    }
}
