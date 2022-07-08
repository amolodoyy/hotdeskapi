using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotDeskSystemApi.Data.Entities
{
    public class User
    {
        [Key]
        [Column("UserId", TypeName = "int")]
        public int UserId { get; set; }

        [Column("UserName", TypeName = "varchar(20)")]
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Column("Password", TypeName = "varchar(20)")]
        [Required]
        public string Password { get; set; } = string.Empty;
        [Column("Role", TypeName = "varchar(20)")]
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
