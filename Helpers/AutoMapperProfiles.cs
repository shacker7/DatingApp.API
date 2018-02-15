using System.Linq;
using AutoMapper;
using DatingApp.API.Dtos;
using DatingApp.API.Models;

namespace DatingApp.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserForListDto, User>();
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<UserForDetailsDto, User>();
            CreateMap<User, UserForDetailsDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url);
                })
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(d => d.DateOfBirth.CalculateAge());
                });

            CreateMap<Photo, PhotosForDetailsDto>();
            CreateMap<PhotosForDetailsDto, Photo>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserForUpdateDto>();
            CreateMap<PhotoForCreationDto, Photo>();
            CreateMap<Photo, PhotoForCreationDto>();
            CreateMap<PhotoForReturnDto, Photo>();
            CreateMap<Photo, PhotoForReturnDto>();
            CreateMap<User, UserForRegisterDto>();
            CreateMap<UserForRegisterDto, User>();
        }
    }
}