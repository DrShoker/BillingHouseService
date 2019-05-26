using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class CompanyContactPhonesConfiguration : IEntityTypeConfiguration<CompanyContactPhones>
    {
        public void Configure(EntityTypeBuilder<CompanyContactPhones> builder)
        {
            //Entity CompanyContactPhones - Company
            builder
                .HasOne(ph => ph.Company)
                .WithMany(comp => comp.ContactPhones)
                .HasForeignKey(ph => ph.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
