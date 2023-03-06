using Application.Common.Dtos.Requests;
using Application.Common.Dtos.Responses;
using Application.Common.Exceptions;
using Application.Common.Interfaces.IRepositories;
using Application.Common.Interfaces.IServices;
using AutoMapper;
using Domain.Entities;

namespace Application.Services
{
    public class HuespedService : IHuespedService
    {
        private readonly IHuespedRepository _huespedRepository;
        private readonly IMapper _mapper;

        public HuespedService(IHuespedRepository huespedRepository, IMapper mapper)
        {
            _huespedRepository = huespedRepository;
            _mapper = mapper;
        }

        public async Task<CreatedSuccessfull> AddHuesped(HuespedRequest huespedRequest)
        {
            var huesped = new Huesped();
            _mapper.Map(huespedRequest,huesped);
            await _huespedRepository.AddAsync(huesped);
            return new CreatedSuccessfull { Id = huesped.Id, Message = "Huesped creado correctamente."};
        }

        public async Task DeleteHuesped(int id)
        {
            var huesped = await _huespedRepository.GetById(id);

            if (huesped == null) { throw new NotFoundException("El Huesped que intenta eliminar no existe en la base de datos."); }

            await _huespedRepository.DeleteAsync(huesped);
        }

        public async Task<HuespedResponse?> FindAsync(int id)
        {
            var huesped = await _huespedRepository.GetById(id);
            return _mapper.Map<HuespedResponse>(huesped);
        }

        public IQueryable<HuespedResponse> GetAllHuespedes()
        {
            var huespedes = _huespedRepository.GetAll();
            return _mapper.Map<IQueryable<HuespedResponse>>(huespedes);
        }

        public async Task<IEnumerable<HuespedResponse>> GetAllHuespedesAsync()
        {
            var huespedes =await _huespedRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HuespedResponse>>(huespedes);
        }

        public async Task UpdateHuesped(int id,HuespedRequest huespedRequest)
        {
            var huesped = await _huespedRepository.GetById(id);
            _mapper.Map(huespedRequest, huesped);
            await _huespedRepository.Update(huesped);

        }
    }
}
