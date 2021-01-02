using Data.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Data.IO;

namespace Services.Dealerships.Commands
{
    public sealed class CreateDealershipCommand : IRequest<string>
    {
        public Guid RequestId { get; } = Guid.NewGuid();

        public Dealership Dealership { get; set; }
    }

    public sealed class CreateDealershipCommandHandler : IRequestHandler<CreateDealershipCommand, string>
    {
        public async Task<string> Handle(CreateDealershipCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dealership = new Dealership
                {
                    Name = request.Dealership.Name,
                    Address1 = request.Dealership.Address1,
                    City = request.Dealership.City,
                    State = request.Dealership.State
                };

                await DealershipData.CreateDealership(dealership);
                return $"{request.RequestId}: Dealership {dealership.Name} created successfully.";
            }
            catch (Exception ex)
            {
                return $"{request.RequestId}: Dealership creation failed. Error: {ex.Message}";
            }
        }
    }
}
