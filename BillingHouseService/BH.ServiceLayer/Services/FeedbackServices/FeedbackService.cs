using AutoMapper;
using BH.DTOL.Entities;
using BH.DTOL.Interfaces;
using BH.ServiceLayer.DTOs.Feedback;
using BH.ServiceLayer.DTOs.Feedback.Model;
using BH.ServiceLayer.Services.Interfaces.Feedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.FeedbackServices
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IUnitOfWork _contextEntities;
        private readonly IMapper _mapper;

        public FeedbackService(IUnitOfWork contextEntities, IMapper mapper)
        {
            _mapper = mapper;
            _contextEntities = contextEntities;
        }

        public IEnumerable<FeedbackModel> GetCopmanyFeedbacks(Guid copmanyId)
        {
            var feedbackIncludeProps = new string[] { "User", "Company" };
            var dbFeedbacks = _contextEntities.Repository.GetAll<UserFeedbackAboutCompany>(fdbk => fdbk.CompanyId == copmanyId, includeProperties: feedbackIncludeProps);
            var responseData = _mapper.Map<IEnumerable<FeedbackModel>>(dbFeedbacks);

            return responseData;
        }

        public FeedbackModel GetCompanyFeedbackById(Guid id)
        {
            var feedbackIncludeProps = new string[] { "User", "Company" };
            var dbFeedback = _contextEntities.Repository.GetById<UserFeedbackAboutCompany>(id, feedbackIncludeProps);

            var responseData = _mapper.Map<FeedbackModel>(dbFeedback);

            return responseData;
        }

        public FeedbackModel CreateCompanyFeedback(CreateFeedbackDto requestData)
        {
            var feedback = _mapper.Map<UserFeedbackAboutCompany>(requestData);
            feedback.Id = Guid.NewGuid();

            _contextEntities.Create(feedback);
            _contextEntities.Save();

            return GetCompanyFeedbackById(feedback.Id);
        }

        public FeedbackModel UpdateCompanyFeedback(UpdateFeedbackDto requestData)
        {
            var dbFeedback = _contextEntities.Repository.GetById<UserFeedbackAboutCompany>(requestData.Id);

            _mapper.Map(requestData, dbFeedback);

            _contextEntities.Save();

            return GetCompanyFeedbackById(dbFeedback.Id);
        }

        public void DeleteCompanyFeedback(Guid id)
        {
            _contextEntities.Delete<UserFeedbackAboutCompany>(id);
            _contextEntities.Save();
        }
    }
}
