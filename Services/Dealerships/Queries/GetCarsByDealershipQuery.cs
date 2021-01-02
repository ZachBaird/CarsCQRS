using Data.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data.IO;

namespace Services.Dealerships.Queries
{
    public sealed class GetCarsByDealershipQuery : IRequest<IEnumerable<Car>>
    {
        public string DealershipId { get; set; }
    }

    public sealed class GetCarsByDealershipQueryHandler : IRequestHandler<GetCarsByDealershipQuery, IEnumerable<Car>>
    {
        public async Task<IEnumerable<Car>> Handle(GetCarsByDealershipQuery request, CancellationToken cancellationToken) =>
            await DealershipData.GetCarsByDealership(request.DealershipId);
    }
}
