using FakeXieCheng.Models;
using System;
using System.Collections.Generic;

namespace FakeXieCheng.Services
{
    public interface ITouristRouteRepository
    {
        public TouristRoute GetTouristRoute(Guid touristRouteId);
        public IEnumerable<TouristRoute> GetTouristRoutes();
    }
}
