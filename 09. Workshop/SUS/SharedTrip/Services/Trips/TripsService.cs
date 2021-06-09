using SharedTrip.Data;
using SharedTrip.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static SUS.MvcFramework.BaseHttpAttribute;

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

        public string AddUserToTrip(string tripId, string userId)
        {
            var userTrip = this.db.UsersTrips.FirstOrDefault(x => x.UserId == userId && x.TripId == tripId);

            if (userTrip == null && this.db.Trips.FirstOrDefault(x => x.Id == tripId && x.Seats - x.UserTrips.Count > 0) != null)
            {
                this.db.UsersTrips.Add(new UserTrip
                {
                    UserId = userId,
                    TripId = tripId
                });

                this.db.SaveChanges();

                return tripId;
            }

            return null;
        }

        public IEnumerable<TripViewModel> GetAll()
        {
            return this.db.Trips
                .Select(x => new TripViewModel
                {
                    Id = x.Id,
                    StartPoint = x.StartPoint,
                    EndPoint = x.EndPoint,
                    DepartureTime = x.DepartureTime.ToString("G"),
                    Seats = x.Seats - x.UserTrips.Count
                })
                .ToList();
        }

        public TripDetailsViewModel GetDetails(string tripId)
        {
            return this.db.Trips.Where(x => x.Id == tripId)
             .Select(x => new TripDetailsViewModel
             {
                 Id = x.Id,
                 StartPoint = x.StartPoint,
                 EndPoint = x.EndPoint,
                 DepartureTime = x.DepartureTime.ToString("s"),
                 Seats = x.Seats - x.UserTrips.Count,
                 ImagePath = x.ImagePath,
                 Description = x.Description
             })
             .FirstOrDefault();
        }
    }
}
