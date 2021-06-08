using SharedTrip.Data;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Services.Trips
{
    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddTrip(TripAddModel model)
        {
            var trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                Description = model.Description
            };

            this.db.Trips.Add(trip);

            this.db.SaveChanges();
        }

        public IEnumerable<TripAddModel> GetAll()
        {
            return this.db.Trips
                .Select(x => new TripAddModel
                {
                    Id=x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("G"),
                    Seats = x.Seats
                })
                .ToList();
        }

        public TripAddModel GetDetails(string tripId)
        {
            return this.db.Trips.Where(x => x.Id == tripId)
             .Select(x => new TripAddModel
             {
                 StartPoint = x.StartPoint,
                 EndPoint = x.EndPoint,
                 DepartureTime = x.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                 Seats = x.Seats,
                 ImagePath = x.ImagePath,
                 Description = x.Description
             })
             .FirstOrDefault();
        }
    }
}
