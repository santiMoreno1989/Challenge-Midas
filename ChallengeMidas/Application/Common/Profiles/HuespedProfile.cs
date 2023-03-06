using Application.Common.Dtos.Requests;
using Application.Common.Dtos.Responses;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Profiles
{
    public class HuespedProfile : Profile
    {
        public HuespedProfile()
        {
            CreateMap<HuespedRequest,Huesped>();
            CreateMap<Huesped, HuespedResponse>();
        }
    }
}
