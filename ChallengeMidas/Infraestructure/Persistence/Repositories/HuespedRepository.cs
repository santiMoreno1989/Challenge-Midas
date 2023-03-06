using Application.Common.Interfaces.IRepositories;
using Domain.Entities;

namespace Infraestructure.Persistence.Repositories
{
    public class HuespedRepository : BaseRepository<Huesped>, IHuespedRepository
    {
        public HuespedRepository(HotelDbContext hotelDbContext) : base(hotelDbContext) { }

    }
}
