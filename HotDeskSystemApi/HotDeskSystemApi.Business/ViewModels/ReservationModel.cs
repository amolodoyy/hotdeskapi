namespace HotDeskSystemApi.Business.ViewModels
{
    public class ReservationModel
    {
        public int ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public int UserId { get; set; }
        public int DeskId { get; set; }
    }
}
