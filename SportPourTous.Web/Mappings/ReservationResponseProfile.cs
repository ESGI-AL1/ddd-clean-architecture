using AutoMapper;
using SportPourTous.Domain.Entities;
using SportPourTous.Web.DTO;

namespace SportPourTous.Web.Mappings
{
    public class ReservationResponseProfile : Profile
    {
        public ReservationResponseProfile()
        {
            CreateMap<Reservation, ReservationResponseDto>()
                .ForMember(dest => dest.Prestation, 
                    opt => 
                        opt.MapFrom(src => 
                            src.Prestation != null ? new PrestationDto 
                                { 
                                    Meal = src.Prestation.Meal, 
                                    Bus = src.Prestation.Bus 
                                } : null));
        }
    }
}