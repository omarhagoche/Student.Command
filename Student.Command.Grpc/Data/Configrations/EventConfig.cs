using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Student.Command.Grpc.Entities;
using Student.Command.Grpc.Events;

namespace Student.Command.Grpc.Data.Configrations
{
    public class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasIndex(e => new { e.AggregateId, e.Sequence }).IsUnique();

            builder.Property(e => e.Type)
                .HasMaxLength(128)
                .HasConversion<string>();

            builder.HasDiscriminator(e => e.Type)
                .HasValue<StudentCreated>(Enums.EventType.StudentCreated)
                .HasValue<StudentUpdated>(Enums.EventType.StudentUpdated);
        }
    }
}
