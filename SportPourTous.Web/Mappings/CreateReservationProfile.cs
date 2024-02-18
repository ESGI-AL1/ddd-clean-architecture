using AutoMapper;
using SportPourTous.Domain.CQS.Commands;
using SportPourTous.Web.DTO;

namespace SportPourTous.Web.Mappings
{
    public class CreateReservationProfile : Profile
    {
        public CreateReservationProfile()
        {
            CreateMap<CreateReservationDto, CreateReservationCommand>();
        }   
    }
}
