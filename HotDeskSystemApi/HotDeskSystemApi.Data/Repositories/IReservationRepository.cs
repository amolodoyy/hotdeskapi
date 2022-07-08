using HotDeskSystemApi.Data.Entities;
using System.Net;

namespace HotDeskSystemApi.Data.Repositories
{
    public interface IReservationRepository
    {
        public (Reservation?, HttpStatusCode) CreateReservation(Reservation reservation);
        public (Reservation?, HttpStatusCode) EditReservation(Reservation reservation);
        public List<Reservation>? GetReservationsByLocation(int locationId);
    }
}
