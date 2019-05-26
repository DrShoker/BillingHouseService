using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class CompanyConstructionWorksConfiguration : IEntityTypeConfiguration<CompanyConstructionWorks>
    {
        public void Configure(EntityTypeBuilder<CompanyConstructionWorks> builder)
        {
            builder.Property(ccw => ccw.PricePerSquareMeter).HasColumnType("decimal");

            //Entity CompanyConstructionWorks - ConstructionWorks
            builder
                .HasOne(ccw => ccw.ConstructionWorks)
                .WithMany()
                .HasForeignKey(ccw => ccw.ConstructionWorksId)
                .OnDelete(DeleteBehavior.Restrict);

            //Entity CompanyConstructionWorks - Company
            builder
                .HasOne(ccw => ccw.Company)
                .WithMany(comp => comp.ConstructionWorks)
                .HasForeignKey(ccw => ccw.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
