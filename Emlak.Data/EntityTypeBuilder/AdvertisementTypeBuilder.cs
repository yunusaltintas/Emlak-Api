using Emlak.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Emlak.Data.EntityTypeBuilder
{
    public class AdvertisementTypeBuilder : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany(x => x.Advertisements).HasForeignKey(x=>x.UserId);

            builder.Property(x => x.Id).IsRequired().UseIdentityColumn(1,1);
            builder.Property(x => x.IsPublish).IsRequired();
            builder.Property(x => x.Explanation).IsRequired().HasMaxLength(1500);
            builder.Property(x => x.AdvertisementTitle).IsRequired().HasMaxLength(450);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.FilePictures);
            builder.Property(x => x.Province).IsRequired().HasMaxLength(100);
            builder.Property(x => x.District).IsRequired().HasMaxLength(120);
            builder.Property(x => x.SquareMeters).IsRequired();
            builder.Property(x => x.Room).IsRequired().HasMaxLength(50);
            builder.Property(x => x.BuildingAge).IsRequired();
        }
    }
}
