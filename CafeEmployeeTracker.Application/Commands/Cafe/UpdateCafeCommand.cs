using CafeEmployeeTracker.Domain.Entity;
using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.Commands.Cafe
{
    public record UpdateCafeCommand(Guid Id, string Name, string Description, string Logo, string Location) : IRequest<CafeEmployeeTracker.Domain.Entity.Cafe>;

    public class UpdateCafeCommandHandler : IRequestHandler<UpdateCafeCommand, CafeEmployeeTracker.Domain.Entity.Cafe>
    {
        private readonly ICafeRepository _cafeRepository;
        public UpdateCafeCommandHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<CafeEmployeeTracker.Domain.Entity.Cafe> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
        {
            var cafe = await _cafeRepository.GetCafeByIdAsync(request.Id);
            if (cafe == null)
            {
                throw new Exception("Cafe not found");
            }
            cafe.Name = request.Name;
            cafe.Description = request.Description;
            cafe.Logo = request.Logo;
            cafe.Location = request.Location;
            await _cafeRepository.UpdateCafeDetailsAsync(cafe);
            return cafe;
        }
    }
}
