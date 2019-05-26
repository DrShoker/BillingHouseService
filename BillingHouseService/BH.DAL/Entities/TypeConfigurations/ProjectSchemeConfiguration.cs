using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class ProjectSchemeConfiguration : IEntityTypeConfiguration<ProjectScheme>
    {
        public void Configure(EntityTypeBuilder<ProjectScheme> builder)
        {
            builder.Property(projSchem => projSchem.CeilingArea).HasColumnType("decimal");
            builder.Property(projSchem => projSchem.CeilingPerimeter).HasColumnType("decimal");
            builder.Property(projSchem => projSchem.FloorArea).HasColumnType("decimal");
            builder.Property(projSchem => projSchem.WallsArea).HasColumnType("decimal");
            builder.Property(projSchem => projSchem.FloorPerimeter).HasColumnType("decimal");


            //Entity ProjectScheme - UserProject
            builder
                .HasOne(projSchem => projSchem.UserProject)
                .WithMany(usrProj => usrProj.ProjectShemes)
                .HasForeignKey(projSchem => projSchem.UserProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}