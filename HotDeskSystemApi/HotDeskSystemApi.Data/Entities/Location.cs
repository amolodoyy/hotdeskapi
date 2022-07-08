using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDeskSystemApi.Data.Entities
{
    public class Location
    {
        [Key]
        [Column("LocationId", TypeName = "int")]
        public int LocationId { get; set; }

        [Required]
        [Column("LocationName", TypeName = "varchar(20)")]
        public string LocationName { get; set; } = string.Empty;
    }
}
