using Application.Dtos;
using Application.Interfaces;
using Domain.Interfaces;
using Domain.ResultHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    /// <summary>
    /// use cases, business logic
    /// </summary>
    public class Service : IService
    {
        private readonly IModelRepository _repository;

        public Service(IModelRepository repository)
        {
            _repository = repository;
        }

        public Task<Result<bool>> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<IEnumerable<ModelDto>>> GetAllAsync(Expression<Func<ModelDto, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Result<ModelDto>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<int>> InsertAsync(ModelDto entity)
        {
            throw new NotImplementedException();
        }

        public Task<Result<bool>> UpdateByIdAsync(ModelDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
