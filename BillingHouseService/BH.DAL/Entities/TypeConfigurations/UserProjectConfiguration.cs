using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class UserProjectConfiguration : IEntityTypeConfiguration<UserProject>
    {
        public void Configure(EntityTypeBuilder<UserProject> builder)
        {
            //Entity UserProject - User
            builder
                .HasOne(usrProj => usrProj.User)
                .WithMany(usr => usr.UserProjects)
                .HasForeignKey(usrProj => usrProj.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
