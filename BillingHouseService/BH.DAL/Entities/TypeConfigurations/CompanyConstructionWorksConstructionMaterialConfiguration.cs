using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class CompanyConstructionWorksConstructionMaterialConfiguration : IEntityTypeConfiguration<CompanyConstructionWorksConstructionMaterial>
    {
        public void Configure(EntityTypeBuilder<CompanyConstructionWorksConstructionMaterial> builder)
        {
            builder.HasKey(ccwcm => new { ccwcm.ConstructionMaterialId, ccwcm.CompanyConstructionWorksId });

            //Entity CompanyConstructionWorksConstructionMaterial - CompanyConstructionWorks
            builder
                .HasOne(ccwcm => ccwcm.CompanyConstructionWorks)
                .WithMany(ccw => ccw.CompanyConstructionWorksConstructionMaterials)
                .HasForeignKey(ccwcm => ccwcm.CompanyConstructionWorksId);

            //Entity CompanyConstructionWorksConstructionMaterial - ConstructionMaterial
            builder
                .HasOne(ccwcm => ccwcm.ConstructionMaterial)
                .WithMany(cm => cm.CompanyConstructionWorksConstructionMaterials)
                .HasForeignKey(ccwcm => ccwcm.ConstructionMaterialId);
        }
    }
}
