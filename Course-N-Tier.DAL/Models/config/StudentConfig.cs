using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_N_Tier.DAL.Models.config
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
              .HasDefaultValueSql("NEWID()");

            builder.Property(u => u.JoinStudent)
                   .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
