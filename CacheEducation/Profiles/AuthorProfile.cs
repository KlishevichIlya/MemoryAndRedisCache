using AutoMapper;
using CacheEducation.Dtos;
using CacheEducation.Models;

namespace CacheEducation.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => src.FirstName)
                )
                .ForMember(
                    dest => dest.CountryId,
                    opt => opt.MapFrom( src => src.CountryId)                
                )
                ;
        }
    }
}
