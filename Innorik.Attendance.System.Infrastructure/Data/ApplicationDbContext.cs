using Innorik.Attendance.System.Domain;
using Microsoft.EntityFrameworkCore;
using static Innorik.Attendance.System.Application.Dtos.CommandDto;
using static Innorik.Attendance.System.Application.Dtos.QueryDto;

namespace Innorik.Attendance.System.Infrastructure.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
        
        }

        public DbSet<AttendanceSheet> AttendanceSheets { get; set; }
        public DbSet<CreateCheckInDto> CreateCheckInDtos { get; set; }
        public DbSet<CreateCheckoutDto> CreateCheckoutDto { get; set; }
        public DbSet<GetAllCheckInDto> GetAllCheckInDtos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CreateCheckInDto>().HasNoKey();
            modelBuilder.Entity<CreateCheckoutDto>().HasNoKey();
            modelBuilder.Entity<GetAllCheckInDto>().HasNoKey();

            modelBuilder.Entity<AttendanceSheet>(entity =>
            {
                entity.HasKey(k => k.AtsIDpk);
            });
        }

    }
}