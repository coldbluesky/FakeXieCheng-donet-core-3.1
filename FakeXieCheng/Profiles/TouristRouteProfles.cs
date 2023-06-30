using AutoMapper;
using FakeXieCheng.DTOs;
using FakeXieCheng.Models;
using System;

namespace FakeXieCheng.Profiles
{
    public class TouristRouteProfles : Profile
    {
        public  TouristRouteProfles()
        {
            CreateMap<TouristRoute, TouristRouteDTO>()
                .ForMember(
                    dest => dest.Price,
                    opt => opt.MapFrom(src => src.OriginalPrice * (decimal)(src.DiscountPresent ?? 1))
                )
                .ForMember(
                    dest => dest.TravelDays,
                    opt=>opt.MapFrom(src=>src.TravelDays.ToString())
                )
                 .ForMember(
                    dest => dest.TripType,
                    opt => opt.MapFrom(src => src.TripType.ToString())
                )
                 .ForMember(
                 dest => dest.DepartureCity,
                 opt => opt.MapFrom(src => src.DepartureCity.ToString())
                );
            CreateMap<TouristRouteForCreationDTO, TouristRoute>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(scr => new Guid())
                );
            CreateMap<TouristRouteForUpdateDTO, TouristRoute>();
        }
    }
}
