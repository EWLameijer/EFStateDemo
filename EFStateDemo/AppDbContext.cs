using Microsoft.EntityFrameworkCore;

namespace EFTest2
{
    class AppDbContext : DbContext
    {
        private const string _connectionString = @"Server=(localdb)\mssqllocaldb;Database=MiniPhoneDb;" +
            "Trusted_Connection=True;User Id=sa; Password=tLw49vq6aU;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        public DbSet<Phone> Phones { get; set; }
    }
}
