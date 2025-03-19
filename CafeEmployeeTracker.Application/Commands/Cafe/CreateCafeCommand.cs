﻿using CafeEmployeeTracker.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using CafeEmployeeTracker.Domain.Entity;

namespace CafeEmployeeTracker.Application.Commands.Cafe
{
    public record CreateCafeCommand(string Name, string Description, string Location) : IRequest<Guid>;
 
public class CreateCafeCommandHandler : IRequestHandler<CreateCafeCommand, Guid>
    {
        private readonly ICafeRepository _cafeRepository;

        public CreateCafeCommandHandler(ICafeRepository cafeRepository)
        {
            _cafeRepository = cafeRepository;
        }

        public async Task<Guid> Handle(CreateCafeCommand request, CancellationToken cancellationToken)
        {
            var newCafe = new Domain.Entity.Cafe
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Location = request.Location,
                Logo = string.Empty // Assuming Logo is required, set it to an empty string or a default value
            };

            await _cafeRepository.CreateAsync(newCafe);
            return newCafe.Id;
        }
    }
}
