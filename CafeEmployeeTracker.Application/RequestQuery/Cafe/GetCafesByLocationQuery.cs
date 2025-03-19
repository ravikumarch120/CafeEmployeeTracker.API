using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeEmployeeTracker.Application.Commands.Cafe;
using System.Threading;
using CafeEmployeeTracker.Domain.Repositories;

namespace CafeEmployeeTracker.Application.RequestQuery.Cafe
{
    public record GetCafesByLocationQuery(string? Location) : IRequest<IEnumerable<CafeDto>>;

    public class GetCafesByLocationQueryHandler : IRequestHandler<GetCafesByLocationQuery, IEnumerable<CafeDto>>
    {
        private readonly ICafeRepository _cafeRepository;

        public GetCafesByLocationQueryHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }

        public async Task<IEnumerable<CafeDto>> Handle(GetCafesByLocationQuery request, CancellationToken cancellationToken)
        {
            var cafes = await _cafeRepository.GetAllAsync(request?.Location);
            return cafes.Select(cafe => new CafeDto
            {
                Id = cafe.Id != Guid.Empty ? cafe.Id : Guid.Empty,
                Name = cafe.Name ?? string.Empty,
                Description = cafe.Description ?? string.Empty,
                Logo = cafe.Logo ?? string.Empty,
                Location = cafe.Location ?? string.Empty,
                Employees = cafe.Employees?.Count ?? 0
            });
        }
    }

}
