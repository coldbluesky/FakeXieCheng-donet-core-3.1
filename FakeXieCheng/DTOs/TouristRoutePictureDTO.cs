using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace FakeXieCheng.DTOs
{
    public class TouristRoutePictureDTO
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public Guid TouristRouteId { get; set; }
    }
}
