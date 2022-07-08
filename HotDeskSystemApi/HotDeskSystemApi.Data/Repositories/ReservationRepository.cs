using Microsoft.Extensions.Configuration;
using HotDeskSystemApi.Data.Entities;
using System.Net;

namespace HotDeskSystemApi.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }
        public ReservationRepository(IConfiguration configuration)
        {
            _context = new AppDbContext(configuration);
        }
        public (Reservation?, HttpStatusCode) CreateReservation(Reservation reservation)
        {
            if (reservation.ReservationDate.AddDays(1) > reservation.ReservationEndDate)
                return (null, HttpStatusCode.BadRequest);

            if((reservation.ReservationEndDate - reservation.ReservationDate).TotalDays > 7)
                return (null, HttpStatusCode.Forbidden);

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            return (reservation, HttpStatusCode.OK);
        }
        public (Reservation?, HttpStatusCode) EditReservation(Reservation reservation)
        {
            var updatedReservation = _context.Reservations.FirstOrDefault(r => r.ReservationId == reservation.ReservationId);

            // Not found
            if(updatedReservation == null)
                return (null, HttpStatusCode.NotFound);

            // Too late
            if ((updatedReservation.ReservationDate - DateTime.UtcNow).TotalHours < 24)
                return (null, HttpStatusCode.Forbidden);

            updatedReservation.DeskId = reservation.DeskId;
            _context.SaveChanges();

            return (updatedReservation, HttpStatusCode.OK);
        }
        // Admin only
        public List<Reservation>? GetReservationsByLocation(int locationId)
        {
            List<Reservation> reservations = new List<Reservation>();
            var desksInLocation = _context.Desks.Where(d => d.LocationId == locationId).ToList();

            foreach (var d in desksInLocation)
            {
                reservations.AddRange(_context.Reservations.Where(r => r.DeskId == d.DeskId).ToList());
            }

            return reservations;
        }
    }
}
