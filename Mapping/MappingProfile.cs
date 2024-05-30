using AutoMapper;
using Vjezba.Models.Dbo;
using Vjezba.Models.ViewModel;

namespace Vjezba.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<ApplicationUser, ApplicationUserViewModel>();

        }
    }
}
