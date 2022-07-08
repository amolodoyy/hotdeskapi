using System.Net;
using HotDeskSystemApi.Data.Entities;

namespace HotDeskSystemApi.Data.Repositories
{
    public interface ILocationRepository
    {
        public (Location?, HttpStatusCode) CreateNewLocation(Location location, int userId);
        public HttpStatusCode DeleteLocation(int locationId, int userId);
    }
}
