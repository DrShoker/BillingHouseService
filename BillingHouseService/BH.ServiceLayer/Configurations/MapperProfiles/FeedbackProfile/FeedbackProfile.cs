using AutoMapper;
using BH.DTOL.Entities;
using BH.ServiceLayer.DTOs.Feedback;
using BH.ServiceLayer.DTOs.Feedback.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Configurations.MapperProfiles.FeedbackProfile
{
    public class FeedbackProfile : Profile
    {
        public FeedbackProfile()
        {
            CreateMap<UserFeedbackAboutCompany, FeedbackModel>()
                .ForMember(model => model.UserName, opt => opt.MapFrom(fdbck => fdbck.Company != null ? fdbck.Company.Name : null))
                .ForMember(model => model.CompanyName, opt => opt.MapFrom(fdbck => fdbck.User != null ? fdbck.User.DisplayName : null));
            CreateMap<CreateFeedbackDto, UserFeedbackAboutCompany>();
            CreateMap<UpdateFeedbackDto, UserFeedbackAboutCompany>()
                .ForMember(fdbck => fdbck.CompanyId, opt => opt.Ignore())
                .ForMember(fdbck => fdbck.UserId, opt => opt.Ignore());

        }
    }
}
