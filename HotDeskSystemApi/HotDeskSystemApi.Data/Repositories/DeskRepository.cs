using Microsoft.Extensions.Configuration;
using HotDeskSystemApi.Data.Entities;
using System.Net;

namespace HotDeskSystemApi.Data.Repositories
{
    public class DeskRepository : IDeskRepository
    {
        private AppDbContext _context;
        public DeskRepository(AppDbContext context)
        {
            _context = context;
        }
        public DeskRepository(IConfiguration configuration)
        {
            _context = new AppDbContext(configuration);
        }
        public List<Desk>? GetAvailableDesksAtDate(DateTime date)
        {
            var bookedDeskIds = _context.Reservations.Where(r => r.ReservationDate == date).Select(r => r.DeskId).Distinct().ToList();
            
            return _context.Desks.Where(d => d.Available && !bookedDeskIds.Contains(d.DeskId)).ToList();
        }
        public List<Desk>? GetUnAvailableDesksAtDate(DateTime date)
        {
            var bookedDeskIds = _context.Reservations.Where(r => r.ReservationDate == date).Select(r => r.DeskId).Distinct().ToList();

            return _context.Desks.Where(d => !d.Available || bookedDeskIds.Contains(d.DeskId)).ToList();
        }
        public List<Desk>? GetDesksByLocation(int userId, int locationId)
        {
            return _context.Desks.Where(d=>d.LocationId == locationId).ToList();
        }
        // Admin only
        public (Desk?, HttpStatusCode) CreateNewDesk(Desk desk, int userId)
        {
            // if not admin
            if(_context.Users.FirstOrDefault(u => u.UserId == userId)?.Role != "Admin")
                return (null, HttpStatusCode.Forbidden);

            _context.Desks.Add(desk);
            _context.SaveChanges();
            
            return (desk, HttpStatusCode.OK);
        }
        // Admin only
        public HttpStatusCode DeleteDesk(int deskId, int userId)
        {
            // if not admin
            if (_context.Users.FirstOrDefault(u => u.UserId == userId)?.Role != "Admin")
                return HttpStatusCode.Forbidden;

            // check if there are reservations
            if (_context.Reservations.FirstOrDefault(r => r.DeskId == deskId) != null)
                return HttpStatusCode.Forbidden;

            Desk? desk = _context.Desks.FirstOrDefault(d => d.DeskId == deskId);
            if (desk == null)
                return HttpStatusCode.NotFound;

            _context.Desks.Remove(desk);
            _context.SaveChanges();

            return HttpStatusCode.OK;
        }
        
    }
}
