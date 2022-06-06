using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models
{
    [Table("users")]    
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        public string Username { get; set; }
        [Required]
        [Column("firstname")]
        public string FirstName { get; set; }
        [Required]
        [Column("lastname")]
        public string LastName { get; set; }
        [Required]
        [Column("email")]
        public string Email { get; set; }
    }
}
