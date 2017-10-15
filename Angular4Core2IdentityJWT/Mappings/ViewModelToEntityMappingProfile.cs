using Angular4Core2IdentityJWT.Models.Entities;
using Angular4Core2IdentityJWT.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular4Core2IdentityJWT.Mappings
{
    public class ViewModelToEntityMappingProfile : Profile
    {
        public ViewModelToEntityMappingProfile()
        {
            CreateMap<RegistrationViewModel, AppUser>()
                .ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email)); //pare to Email tou VM kai valto sto uusername tou AU
        }
    }
}
