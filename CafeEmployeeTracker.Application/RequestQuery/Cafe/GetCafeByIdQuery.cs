using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.RequestQuery.Cafe
{
    public record GetCafeByIdQuery(Guid Id) : IRequest<CafeDto>;

    public class GetCafeByIdQueryHandler : IRequestHandler<GetCafeByIdQuery, CafeDto>
    {
        private readonly ICafeRepository _cafeRepository;
        public GetCafeByIdQueryHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<CafeDto> Handle(GetCafeByIdQuery request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetCafeByIdAsync(request.Id);
            if (cafe == null)
            {
                throw new Exception("Cafe not found");
            }
            return new CafeDto
            {
                Id = cafe.Id,
                Name = cafe.Name ?? string.Empty,
                Description = cafe.Description ?? string.Empty,
                Logo = cafe.Logo ?? string.Empty,
                Location = cafe.Location ?? string.Empty,
                EmployeeCount = cafe.Employees?.Count ?? 0
            };
        }
    }


}
