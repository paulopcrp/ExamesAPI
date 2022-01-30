using AutoMapper;
using ExamesAPI.Data.Dtos;
using ExamesAPI.Models;
using System;

namespace ExamesAPI.Profiles
{
    public class ExamesProfiles : Profile
    {
        public ExamesProfiles()
        {
            CreateMap<CreateExameDto, Exames>();
            CreateMap<Exames, ReadExameDto>();
            CreateMap<UpdateExameDto, Exames>();
        }
    }
}
