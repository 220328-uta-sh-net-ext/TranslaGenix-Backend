using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class TGContext: DbContext
    {
        public TGContext() : base()
        {

        }
        public TGContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Point> points { get; set; }
        public DbSet<Words> wordList { get; set; }
        //public DbSet<SimpleUser> simpleUserList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Point>()
                .Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Words>()
                .Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();
            /*modelBuilder.Entity<SimpleUser>()
                .Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();*/
        }
        // dotnet ef migrations add AddSimpleUser -c TGContext --startup-project ../TranslaGenixAPI/TranslaGenixAPI.csproj
        // dotnet ef database update --startup-project ../TranslaGenixAPI/TranslaGenixAPI.csproj

    }
}