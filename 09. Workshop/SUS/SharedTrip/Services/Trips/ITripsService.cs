using SharedTrip.ViewModels;
using System.Collections.Generic;

namespace SharedTrip.Services.Trips
{
    public interface ITripsService
    {
        void AddTrip(TripAddModel model);

        IEnumerable<TripAddModel> GetAll();

        TripAddModel GetDetails(string tripId);
    }
}
