using MediatR;
using Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Cars.Queries
{
    // command / query
    public sealed class GetAllCarsQuery : IRequest<IEnumerable<Car>> { }

    public sealed class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, IEnumerable<Car>>
    {
        public async Task<IEnumerable<Car>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken) =>
            await IO.CarData.GetAllCars();        
    }
}
