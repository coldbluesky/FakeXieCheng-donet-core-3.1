﻿using FakeXieCheng.Models;
using System;
using System.Collections.Generic;

namespace FakeXieCheng.DTOs
{
    public class TouristRouteForCreationDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateTime { get; set; }

        public DateTime? UpdateTime { get; set; }

        public DateTime? DepartureTime { get; set; }
        public string Features { get; set; }
        public string Fees { get; set; }
        public string Notes { get; set; }
        public decimal Price { get; set; }

        public double? Rating { get; set; }
        public string TravelDays { get; set; }
        public string TripType { get; set; }
        public string DepartureCity { get; set; }
        public ICollection<TouristRoutePictureForCreationDTO> TouristRoutePictures { get; set; }
                = new List<TouristRoutePictureForCreationDTO>();
    }
}
