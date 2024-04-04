using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace graphql_sql_server.src.Schemas
{
    [Table("users")]
    public class UserModel
    {
        [Key]
        [Column("UserId")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int User_Id { get; set; }
        [Column("Name")]
        [Required]
        [MaxLength(50)]
        public string Name{ get; set; }
        [Column("Surname")]
        [Required]
        [MaxLength(50)]
        public string Surname { get; set; }
        [Column("Email")]
        [Required]
        public string Email { get; set; }
        [Column("Password")]
        [Required]
        [MaxLength(60)]
        public string Password { get; set; }
        [Column("Created_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Created_At { get; set; }
        [Column("Updated_at")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime Updated_At { get; set; }
    }

}
