using Microsoft.EntityFrameworkCore;
using Student.Command.Grpc.Data.Configrations;
using Student.Command.Grpc.Entities;
using Student.Command.Grpc.Events;
using Student.Command.Grpc.Events.DataTypes;

namespace Student.Command.Grpc.Data
{
    public class AppDbCon(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EventConfig());

            modelBuilder.ApplyConfiguration(new GenericEventConfig<StudentCreated, StudentCreatedData>());

            modelBuilder.ApplyConfiguration(new GenericEventConfig<StudentUpdated, StudentUpdatedData>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
