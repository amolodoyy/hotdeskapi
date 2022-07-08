using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDeskSystemApi.Data.Entities
{
    public class Reservation
    {
        [Key]
        [Column("ReservationId", TypeName = "int")]
        public int ReservationId { get; set; }

        [Column("ReservationDate", TypeName = "date")]
        [Required]
        public DateTime ReservationDate { get; set;}

        [Column("ReservationEndDate", TypeName = "date")]
        [Required]
        public DateTime ReservationEndDate { get; set; }

        [Column("UserId", TypeName = "int")]
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Column("DeskId", TypeName = "int")]
        [Required]
        [ForeignKey("Desk")]
        public int DeskId { get; set; }
    }
}
