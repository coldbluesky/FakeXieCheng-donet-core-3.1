using FakeXieCheng.Models;
using System;
using System.Collections.Generic;

namespace FakeXieCheng.Services
{
    public interface ITouristRouteRepository
    {
        public TouristRoute GetTouristRoute(Guid touristRouteId);
        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword);
        public bool IsTouristRouteExist(Guid touristRouteId);
        public IEnumerable<TouristRoutePicture> GetPictureListForTouristRoute(Guid touristRouteId);
        public void AddRoute(TouristRoute touristRoute);
        public void AddPicture(TouristRoutePicture touristRoutePicture,Guid touristRouteId);
        public bool Save();
    }
}
