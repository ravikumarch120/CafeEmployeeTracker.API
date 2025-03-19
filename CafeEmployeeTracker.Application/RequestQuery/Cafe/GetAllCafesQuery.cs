using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Cafe
{
    public record GetAllCafesQuery : IRequest<IEnumerable<CafeDto>>;
     
    public class GetAllCafesQueryHandler : IRequestHandler<GetAllCafesQuery, IEnumerable<CafeDto>>
    {
        private readonly ICafeRepository _cafeRepository;
        public GetAllCafesQueryHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<IEnumerable<CafeDto>> Handle(GetAllCafesQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafeRepository.GetAllCafesAsync();
            return cafes.Select(cafe => new CafeDto
            {
                Id = cafe.Cafe.Id != Guid.Empty ? cafe.Cafe.Id : Guid.Empty,
                Name = cafe.Cafe.Name ?? string.Empty,
                Description = cafe.Cafe.Description ?? string.Empty,
                Logo = cafe.Cafe.Logo ?? string.Empty,
                Location = cafe.Cafe.Location ?? string.Empty,
                EmployeeCount = cafe.EmployeesCount
            });
        }
    }

}
