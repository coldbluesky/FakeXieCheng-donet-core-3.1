using AutoMapper;
using FakeXieCheng.DTOs;
using FakeXieCheng.Models;
using FakeXieCheng.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeXieCheng.Controllers
{
    [Route("api/TouristRoutes/{touristRouteId}/Pictures")]
    [ApiController]
    public class TouristRoutePicturesController : ControllerBase
    {
        private readonly ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;
        public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            this.touristRouteRepository = touristRouteRepository;
            this.mapper = mapper;
        }
        [HttpGet(Name = "GetPictureList")]
        public IActionResult GetPictureList(Guid touristRouteId) 
        {
            if (touristRouteRepository.IsTouristRouteExist(touristRouteId))
            {
                var result = touristRouteRepository.GetPictureListForTouristRoute(touristRouteId);
                if(result==null || result.Count() <= 0)
                {
                    return NotFound("无图片");
                }
                var resultDto = mapper.Map<IEnumerable<TouristRoutePictureDTO>>(result);
                return Ok(resultDto);
            }
            else
            {
                return NotFound($"路线{touristRouteId}找不到");
            }
        }
        [HttpPost]
        public IActionResult CreateTouristRoutePicture([FromRoute]Guid touristRouteId, [FromBody] TouristRoutePictureForCreationDTO touristRoutePictureForCreationDTO)
        {
            if (touristRouteRepository.IsTouristRouteExist(touristRouteId))
            {
                var TouristRoutePictureModel = mapper.Map<TouristRoutePicture>(touristRoutePictureForCreationDTO);
                touristRouteRepository.AddPicture(TouristRoutePictureModel, touristRouteId);
                touristRouteRepository.Save();
                var TouristRoutePictureReturn = mapper.Map<TouristRoutePictureDTO>(TouristRoutePictureModel);
                return CreatedAtRoute("GetPictureList", new { touristRouteId= TouristRoutePictureModel.TouristRouteId, pictureId= TouristRoutePictureModel.Id}, TouristRoutePictureReturn);
            }
            else
            {
                return NotFound($"路线{touristRouteId}找不到");
            }
        }

    }
}
