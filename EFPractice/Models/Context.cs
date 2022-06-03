using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFPractice.Models
{
    public class Context: DbContext
    {
        public DbSet<UserProfile> users { get; set; }

        public DbSet<PointsSystem> points { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:translagenixserver.database.windows.net,1433;Initial Catalog=translagenixdb;Persist Security Info=False;User ID=projectthree;Password=Passw0rd123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }
}
