using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services.Trips
{
    public interface ITripsService
    {
        void AddTrip(TripAddModel model);

        IEnumerable<TripViewModel> GetAll();

        TripDetailsViewModel GetDetails(string tripId);

        bool AddUserToTrip(string tripId, string userId);

        bool HasAvailableSeats(string tripId);
    }
}
