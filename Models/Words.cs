using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Models
{
    [Table("words")]
    [Index(nameof(Word), IsUnique = true)]
    public class Words
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("word")]
        public string Word { get; set; }
        [Column("tag")]
        public string Tag { get; set; }
    }
}
