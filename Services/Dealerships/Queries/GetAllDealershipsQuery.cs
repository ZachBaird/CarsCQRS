using Data.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data.IO;

namespace Services.Dealerships.Queries
{
    public sealed class GetAllDealershipsQuery : IRequest<IEnumerable<Dealership>> { }

    public sealed class GetAllDealershipsQueryHandler : IRequestHandler<GetAllDealershipsQuery, IEnumerable<Dealership>>
    {
        public async Task<IEnumerable<Dealership>> Handle(GetAllDealershipsQuery request, CancellationToken cancellationToken) =>
            await DealershipData.GetAllDealerships();
    }
}
