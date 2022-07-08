using Microsoft.Extensions.Configuration;
using HotDeskSystemApi.Data.Entities;
using System.Net;

namespace HotDeskSystemApi.Data.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public LocationRepository(IConfiguration configuration)
        {
            _context = new AppDbContext(configuration);
        }
        public (Location?, HttpStatusCode) CreateNewLocation(Location location, int userId)
        {
            if (_context.Users.FirstOrDefault(u => u.UserId == userId)?.Role != "Admin")
                return (null, HttpStatusCode.Forbidden);

            _context.Locations.Add(location); 
            _context.SaveChanges();

            return (location, HttpStatusCode.OK);
        }
        public HttpStatusCode DeleteLocation(int locationId, int userId)
        {
            // check if user have rights
            if (_context.Users.FirstOrDefault(u => u.UserId == userId)?.Role != "Admin")
                return HttpStatusCode.Forbidden;

            var location = _context.Locations.FirstOrDefault(l => l.LocationId == locationId);
            if (location == null)
                return HttpStatusCode.NotFound;

            // desk exists in location
            if (_context.Desks.FirstOrDefault(d => d.LocationId == locationId) != null)
                return HttpStatusCode.Forbidden;
            

            _context.Locations.Remove(location);
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }
    }
}
