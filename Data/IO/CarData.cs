using Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.IO
{
    public static class CarData
    {
        public static async Task<IEnumerable<Car>> GetAllCars()
        {
            using var session = Database.AsyncSession;
            return await session.Advanced.AsyncDocumentQuery<Car>().ToListAsync();
        }

        public static async Task CreateCar(Car car)
        {
            using var session = Database.AsyncSession;
            await session.StoreAsync(car);
            await session.SaveChangesAsync();
        }
    }
}
