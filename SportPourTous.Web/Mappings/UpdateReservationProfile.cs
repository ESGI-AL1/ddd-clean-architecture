using AutoMapper;
using SportPourTous.Domain.CQS.Commands;
using SportPourTous.Web.DTO;

namespace SportPourTous.Web.Mappings
{
    public class UpdateReservationProfile : Profile
    {
        public UpdateReservationProfile()
        {
            CreateMap<UpdateReservationDto, UpdateReservationCommand>();
        }   
    }
}