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
    [Route("api/[controller]")]
    [ApiController]
    public class TouristRoutesController : ControllerBase
    {
        private readonly ITouristRouteRepository touristRouteRepository;
        private readonly IMapper mapper;
        public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
        {
            this.touristRouteRepository = touristRouteRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTouristRoutes(string keyword)
        {
            var result = touristRouteRepository.GetTouristRoutes(keyword);
            if (result == null || result.Count()<=0)
            {
                return NotFound($"没有旅游路线");
            }
            var resultDto = mapper.Map<IEnumerable<TouristRouteDTO>>(result);
            return Ok(resultDto);
        }

        [HttpGet("{touristRouteId}",Name = "GetTouristRoutesById")]
        public IActionResult GetTouristRoutesById(Guid touristRouteId)
        {
            var result = touristRouteRepository.GetTouristRoute(touristRouteId);
            if(result == null)
            {
                return NotFound($"旅游路线{touristRouteId}找不到"); 
            }
            var resultDto = mapper.Map<TouristRouteDTO>(result);
            return Ok(resultDto);

        }

        [HttpPost]
        public IActionResult CreateTouristRoute([FromBody] TouristRouteForCreationDTO touristRouteForCreationDTO)
        {
            var touristRouteModel = mapper.Map<TouristRoute>(touristRouteForCreationDTO);
            touristRouteRepository.AddRoute(touristRouteModel);
            touristRouteRepository.Save();
            var touristRouteReture = mapper.Map<TouristRouteDTO>(touristRouteModel);
            return CreatedAtRoute("GetTouristRoutesById", new { touristRouteId = touristRouteReture.Id }, touristRouteReture);
        }
    }
}
