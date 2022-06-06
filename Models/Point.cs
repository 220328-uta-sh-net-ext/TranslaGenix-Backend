using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("points")]
    [Index(nameof(userId), IsUnique = true)]
    public class Point
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userId")]
        //Manually added userId being a foregin Key
        // ALTER TABLE Points ADD FOREIGN KEY (userid) REFERENCES users(id);
        public int userId { get; set; }
        [Column("points")]
        public int Points { get; set; } = 0;
    }
}
