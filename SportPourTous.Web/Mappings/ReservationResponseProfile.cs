using AutoMapper;
using SportPourTous.Domain.Entities;
using SportPourTous.Web.DTO;

namespace SportPourTous.Web.Mappings
{
    public class ReservationResponseProfile : Profile
    {
        public ReservationResponseProfile()
        {
            CreateMap<Reservation, ReservationResponseDto>();
        }
    }
}
