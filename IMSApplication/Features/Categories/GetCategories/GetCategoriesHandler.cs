using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using IMS.Application.DTOs.Categories.GetCategories;
using IMS.Application.Interfaces;
using MediatR;

namespace IMS.Application.Features.Categories.GetCategories
{
    public class GetCategoriesHandler:IRequestHandler<GetCategoriesQuery, List<GetCategoriesResponseDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICategoriesRepository _repository;
        private readonly IMapper _mapper;
        public GetCategoriesHandler(IUnitOfWork uow, ICategoriesRepository repository, IMapper mapper)
        {
            _uow = uow;
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<GetCategoriesResponseDto>> Handle(GetCategoriesQuery request, CancellationToken ct)
        {
            await _uow.BeginAsync(ct);
            try
            {
                var categories = await _repository.GetCategoriesAsync();
                await _uow.CommitAsync(ct);
                return categories;
            }
            catch (Exception ex)
            {
                await _uow.RollbackAsync(ct);
                throw;
            }
        }
    }
}
