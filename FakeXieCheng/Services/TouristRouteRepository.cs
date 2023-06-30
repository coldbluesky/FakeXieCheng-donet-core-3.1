using FakeXieCheng.Database;
using FakeXieCheng.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<TouristRoutePicture> GetPictureListForTouristRoute(Guid touristRouteId)
        {
            return context.TouristRoutePictures.Where(i => i.TouristRouteId == touristRouteId).ToList();
        }

        public TouristRoute GetTouristRoute(Guid touristRouteId)
        {
           return context.TouristRoutes.SingleOrDefault(t=>t.Id == touristRouteId);
        }

        public IEnumerable<TouristRoute> GetTouristRoutes(string keyword)
        {
            IQueryable<TouristRoute> result= context.TouristRoutes.Include(t=>t.TouristRoutePictures);
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                result = result.Where(t => t.Title.Contains(keyword));
            }   
            return result.ToList();
        }

        public bool IsTouristRouteExist(Guid touristRouteId)
        {
            return context.TouristRoutes.Any(a => a.Id ==  touristRouteId);
        }

        public void AddRoute(TouristRoute touristRoute)
        {
            if(touristRoute == null)
            {
                throw new ArgumentNullException(nameof(touristRoute));
            }
            context.TouristRoutes.Add(touristRoute);
        }
        public void AddPicture(TouristRoutePicture touristRoutePicture, Guid touristRouteId)
        {
            if (touristRoutePicture == null)
            {
                throw new ArgumentNullException(nameof(touristRoutePicture));

            }
            if (touristRouteId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(touristRouteId));

            }
            touristRoutePicture.TouristRouteId = touristRouteId;
            context.TouristRoutePictures.Add(touristRoutePicture);
        }
        public bool Save()
        {
            return context.SaveChanges()>=0;
        }
    }
}
