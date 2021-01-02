using Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Cars.Queries
{
    public sealed class GetCarQuery : IRequest<Car>
    {
        public string CarId { get; set; }
    }

    public sealed class GetCarQueryHandler : IRequestHandler<GetCarQuery, Car>
    {
        public async Task<Car> Handle(GetCarQuery request, CancellationToken cancellationToken) =>
            await Data.IO.CarData.GetCarById(request.CarId);
        
    }
}
