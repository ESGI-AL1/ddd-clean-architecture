using AutoMapper;
using SportPourTous.Domain.Entities;

namespace SportPourTous.Web.DTO.Mapping
{
    public class ReservationResponseProfile : Profile
    {
        public ReservationResponseProfile()
        {
            CreateMap<Reservation, ReservationResponseDto>();
        }
    }
}
