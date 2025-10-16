using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Course_N_Tier.DAL.Models.config
{
    public class InstructorConfig : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
              .HasDefaultValueSql("NEWID()");
            builder.Property(i => i.SaleryPrice)
       .HasPrecision(18, 2);

        }
    }
}
