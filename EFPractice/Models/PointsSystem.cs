using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFPractice.Models
{
    public class PointsSystem
    {
        [Key]
        public int Id { get; set; }
        public UserProfile User { get; set; }
        public int Points { get; set; } = 0;
    }
}
