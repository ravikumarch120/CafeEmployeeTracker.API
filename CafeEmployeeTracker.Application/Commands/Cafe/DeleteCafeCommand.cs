using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeEmployeeTracker.Application.Commands.Cafe
{
    public record DeleteCafeCommand(Guid Id) : IRequest<Unit>;

    public class DeleteCafeCommandHandler : IRequestHandler<DeleteCafeCommand, Unit>
    {
        private readonly ICafeRepository _cafeRepository;
        public DeleteCafeCommandHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }
        public async Task<Unit> Handle(DeleteCafeCommand request, CancellationToken cancellationToken)
        {
            await _cafeRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
