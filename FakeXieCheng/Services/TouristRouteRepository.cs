using FakeXieCheng.Database;
using FakeXieCheng.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FakeXieCheng.Services
{
    public class TouristRouteRepository : ITouristRouteRepository
    {
        private readonly AppDbContext context;

        public TouristRouteRepository(AppDbContext context)
        {
            this.context = context; 
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
           return context.TouristRoutes.SingleOrDefault(t=>t.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes()
        {
            return context.TouristRoutes;
        }
    }
}
