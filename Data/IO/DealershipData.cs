using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IO
{
    public static class DealershipData
    {
        public static async Task<IEnumerable<Dealership>> GetAllDealerships()
        {
            using var session = Database.AsyncSession;
            return await session.Advanced.AsyncDocumentQuery<Dealership>().ToListAsync();
        }

        public static async Task<Dealership> GetDealershipById(string id)
        {
            using var session = Database.AsyncSession;
            return await session.LoadAsync<Dealership>(id);
        }

        public static async Task CreateDealership(Dealership dealership)
        {
            using var session = Database.AsyncSession;
            await session.StoreAsync(dealership);
            await session.SaveChangesAsync();
        }
    }
}
