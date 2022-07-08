using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDeskSystemApi.Data.Entities
{
    public class Desk
    {
        [Key]
        [Column("DeskId", TypeName = "int")]
        public int DeskId { get; set; }

        [Column("Available", TypeName = "bit")]
        [Required]
        public bool Available { get; set;}

        [Column("LocationId", TypeName = "int")]
        [ForeignKey("Location")]
        [Required]
        public int LocationId { get; set; }

    }
}
