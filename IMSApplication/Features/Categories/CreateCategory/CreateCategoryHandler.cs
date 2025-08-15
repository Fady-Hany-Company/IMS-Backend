using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.Categories.CreateCategory;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Categories.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICategoriesRepository _repository;
        private readonly IMapper _mapper;

        public CreateCategoryHandler(IUnitOfWork uow, ICategoriesRepository repository, IMapper mapper)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                var category = _mapper.Map<Domain.Entities.Categories>(request.category);
                category.CreatedAt = DateTime.UtcNow;
                var categoryId = await _repository.CreateAsync(category);
                await _uow.CommitAsync(ct);
                return categoryId;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }

    }
}
