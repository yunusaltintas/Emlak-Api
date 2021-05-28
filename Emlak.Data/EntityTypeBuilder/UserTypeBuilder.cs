using Emlak.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.EntityTypeBuilder
{
    public class UserTypeBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Advertisements).WithOne(x => x.User).HasForeignKey(x=>x.UserId);

            builder.Property(x => x.Id).IsRequired().UseIdentityColumn(1, 1);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(450);
            builder.Property(x => x.UserName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(150);
        }
    }
}
