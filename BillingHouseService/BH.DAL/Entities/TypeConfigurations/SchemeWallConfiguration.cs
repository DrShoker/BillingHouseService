using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class SchemeWallConfiguration : IEntityTypeConfiguration<SchemeWall>
    {
        public void Configure(EntityTypeBuilder<SchemeWall> builder)
        {
            builder.Property(sw => sw.Area).HasColumnType("decimal");

            //Entity SchemeWall - ProjectScheme
            builder
                .HasOne(sw => sw.ProjectScheme)
                .WithMany(ps => ps.Walls)
                .HasForeignKey(sw => sw.ProjectSchemeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
