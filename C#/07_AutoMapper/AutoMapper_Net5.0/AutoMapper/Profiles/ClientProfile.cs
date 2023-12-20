using AutoMapper;
using AutoMapper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMapper.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreteMap<Client, ClientViewModel>()
                .ForMember(dest => dest.SurName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.EmailAddress, opt => opt.MapFrom(src => src.Email));
        }
    }
}