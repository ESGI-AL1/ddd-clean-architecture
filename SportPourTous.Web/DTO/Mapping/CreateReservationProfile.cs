using AutoMapper;
using SportPourTous.Domain.CQRS.Commands;

namespace SportPourTous.Web.DTO.Mapping
{
    public class CreateReservationProfile : Profile
    {
        public CreateReservationProfile()
        {
            CreateMap<CreateReservationDto, CreateReservationCommand>();
        }   
    }
}
