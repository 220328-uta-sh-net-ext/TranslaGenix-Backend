using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("points")]
    public class Point
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user")]
        public User user { get; set; }
        [Column("points")]
        public int Points { get; set; } = 0;
    }
}
