using Data.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Data.IO;

namespace Services.Dealerships.Queries
{
    public sealed class GetDealershipQuery : IRequest<Dealership>
    {
        public string DealershipId { get; set; }
    }

    public sealed class GetDealershipQueryHandler : IRequestHandler<GetDealershipQuery, Dealership>
    {
        public async Task<Dealership> Handle(GetDealershipQuery request, CancellationToken cancellationToken) =>
            await DealershipData.GetDealershipById(request.DealershipId);
    }
}
