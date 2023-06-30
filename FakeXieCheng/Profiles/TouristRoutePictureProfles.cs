using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using AutoMapper;
using FakeXieCheng.Models;
using FakeXieCheng.DTOs;

namespace FakeXieCheng.Profiles
{
    public class TouristRoutePictureProfles : Profile
    {
        public TouristRoutePictureProfles()
        {
            CreateMap<TouristRoutePicture,TouristRoutePictureDTO>();
            CreateMap<TouristRoutePictureForCreationDTO, TouristRoutePicture>();
        }
    }
}
