using HotDeskSystemApi.Business.ViewModels;
using System.Net;

namespace HotDeskSystemApi.Business.Domains
{
    public interface IReservationServices
    {
        public (ReservationModel?, HttpStatusCode) CreateReservation(ReservationModel reservationModel);
        public (ReservationModel?, HttpStatusCode) EditReservation(ReservationModel reservationModel);
        public List<ReservationModel>? GetReservationsByLocation(int locationId);
    }
}
