/*using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models
{
    [Table("simpleuser")]
    [Index(nameof(Username), IsUnique = true)]
    public class SimpleUser
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("username")]
        public string Username { get; set; }
        [Required]
        [Column("password")]
        public string Password { get; set; }
    }
}
*/