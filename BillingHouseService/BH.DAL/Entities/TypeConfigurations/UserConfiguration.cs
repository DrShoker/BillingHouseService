using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasIndex(usr => usr.Email).IsUnique();
        }
    }
}
