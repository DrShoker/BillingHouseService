using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class SchemeConstructionWorksConfiguration : IEntityTypeConfiguration<SchemeConstructionWorks>
    {
        public void Configure(EntityTypeBuilder<SchemeConstructionWorks> builder)
        {
            builder.HasKey(schemConsWrks => new { schemConsWrks.ConstructionWorksId, schemConsWrks.SchemeId });

            //Entity SchemeConstructionWorks - ProjectScheme
            builder
                .HasOne(schemConsWrks => schemConsWrks.ProjectScheme)
                .WithMany(projSchem => projSchem.SchemeConstructionWorks)
                .HasForeignKey(schemConsWrks => schemConsWrks.SchemeId);

            //Entity SchemeConstructionWorks - ConstructionWorks
            builder
                .HasOne(schemConsWrks => schemConsWrks.ConstructionWorks)
                .WithMany(consWrks => consWrks.SchemeConstructionWorks)
                .HasForeignKey(schemConsWrks => schemConsWrks.ConstructionWorksId);
        }
    }
}
