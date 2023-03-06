using Application.Common.Dtos.Requests;
using Application.Common.Dtos.Responses;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Common.Interfaces.IServices
{
    public interface IHuespedService
    {
        Task<IEnumerable<HuespedResponse>> GetAllHuespedesAsync();
        IQueryable<HuespedResponse> GetAllHuespedes();
        Task<HuespedResponse?> FindAsync(int id);
        Task<CreatedSuccessfull> AddHuesped(HuespedRequest huesped);
        Task UpdateHuesped(int id,HuespedRequest huesped);
        Task DeleteHuesped(int id);
    }
}
