using MediatR;
using Data.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Cars.Commands
{
    public sealed class CreateCarCommand : IRequest<string>
    {
        public Guid RequestId { get; } = Guid.NewGuid();

        public string Name { get; set; }
    }

    public sealed class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, string>
    {
        public async Task<string> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var car = new Car { Name = request.Name };
                await IO.CarData.CreateCar(car);

                return $"Request {request.RequestId}: Car {car.Name} created successfully.";
            }
            catch (Exception ex)
            {
                return $"{request.RequestId}: {ex.Message}";
            }
        }
    }
}
