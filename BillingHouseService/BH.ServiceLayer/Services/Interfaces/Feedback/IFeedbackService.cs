using BH.ServiceLayer.DTOs.Feedback;
using BH.ServiceLayer.DTOs.Feedback.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.Services.Interfaces.Feedback
{
    public interface IFeedbackService
    {
        IEnumerable<FeedbackModel> GetCopmanyFeedbacks(Guid copmanyId);
        FeedbackModel GetCompanyFeedbackById(Guid id);
        FeedbackModel CreateCompanyFeedback(CreateFeedbackDto requestData);
        FeedbackModel UpdateCompanyFeedback(UpdateFeedbackDto requestData);
        void DeleteCompanyFeedback(Guid id);
    }
}
