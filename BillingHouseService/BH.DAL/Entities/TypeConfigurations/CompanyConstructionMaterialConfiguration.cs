using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class CompanyConstructionMaterialConfiguration : IEntityTypeConfiguration<CompanyConstructionMaterial>
    {
        public void Configure(EntityTypeBuilder<CompanyConstructionMaterial> builder)
        {
            builder.Property(ccm => ccm.Price).HasColumnType("decimal");

            //Entity CompanyConstructionMaterial - ConstructionMaterial
            builder
                .HasOne(ccm => ccm.ConstructionMaterial)
                .WithMany()
                .HasForeignKey(ccm => ccm.ConstructionMaterialId)
                .OnDelete(DeleteBehavior.Restrict);

            //Entity CompanyConstructionMaterial - Company
            builder
                .HasOne(ccm => ccm.Company)
                .WithMany(comp => comp.ConstructionMaterials)
                .HasForeignKey(ccm => ccm.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
