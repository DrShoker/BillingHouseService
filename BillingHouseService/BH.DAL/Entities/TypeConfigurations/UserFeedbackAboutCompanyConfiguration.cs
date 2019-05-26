using System;
using System.Collections.Generic;
using System.Text;
using BH.DTOL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BH.DAL.Entities.TypeConfigurations
{
    class UserFeedbackAboutCompanyConfiguration : IEntityTypeConfiguration<UserFeedbackAboutCompany>
    {
        public void Configure(EntityTypeBuilder<UserFeedbackAboutCompany> builder)
        {
            //Entity UserFeedbackAboutCompany - User
            builder
                .HasOne(usrFdbk => usrFdbk.User)
                .WithMany()
                .HasForeignKey(usrFdbk => usrFdbk.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            //Entity UserFeedbackAboutCompany - Company
            builder
                .HasOne(usrFdbk => usrFdbk.Company)
                .WithMany(comp => comp.Feedbacks)
                .HasForeignKey(usrFdbk => usrFdbk.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
