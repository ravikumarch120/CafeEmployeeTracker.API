using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.Commands.Cafe
{
    public record UpdateCafeCommand(string CafeName, string Name, string Description, string Logo, string Location) : IRequest<Unit>;

    public class UpdateCafeCommandHandler : IRequestHandler<UpdateCafeCommand, Unit>
    {
        private readonly ICafeRepository _cafeRepository;
        public UpdateCafeCommandHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<Unit> Handle(UpdateCafeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cafe = await _cafeRepository.GetCafeByNameAsync(request.CafeName);
                if (cafe == null)
                {
                    throw new Exception("Cafe not found");
                }
                cafe.Name = request.Name;
                cafe.Description = request.Description;
                cafe.Logo = request.Logo;
                cafe.Location = request.Location;
                await _cafeRepository.UpdateCafeDetailsAsync(cafe);
                return Unit.Value;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                throw new ApplicationException("An error occurred while updating the cafe details.", ex);
            }
        }
    }
}
