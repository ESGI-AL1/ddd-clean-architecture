using AutoMapper;
using SportPourTous.Domain.Entities;

namespace SportPourTous.Web.DTO.Mapping
{
    public class ReservationResponseProfile : Profile
    {
        public ReservationResponseProfile()
        {
            CreateMap<Reservation, ReservationResponseDto>()
                .ForMember(dest => dest.ReservationDate, opt => opt.MapFrom(src => src.ReservationDate.ToString("yyyy-MM-dd")))
                .ForMember(dest => dest.BeginningHour, opt => opt.MapFrom(src => src.ReservationDate.ToString("yyyy-MM-dd HH:mm")))
                .ForMember(dest => dest.EndingHour, opt => opt.MapFrom(src => src.ReservationDate.ToString("yyyy-MM-dd HH:mm")));
        }
    }
}
