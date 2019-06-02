using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.ServiceLayer.DTOs.Feedback;
using BH.ServiceLayer.Services.Interfaces.Feedback;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    //[Route("api/feedbacks")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("api/companies/{companyId}/feedbacks")]
        public IActionResult GetCopmanysFeedbacksByCompanyId(Guid companyId)
        {
            var responseData = _feedbackService.GetCopmanyFeedbacks(companyId);

            return GetResults.Ok(this, responseData);
        }

        [HttpPost("api/users/{userId}/feedbacks")]
        public IActionResult CreateCopmanysFeedbacks(CreateFeedbackDto requestData)
        {
            var resposneData = _feedbackService.CreateCompanyFeedback(requestData);

            return PostResults.Created(this, resposneData);
        }

        [HttpPut("api/users/{userId}/feedbacks")]
        public IActionResult UpdateCopmanysFeedbacks(UpdateFeedbackDto requestData)
        {
            var resposneData = _feedbackService.UpdateCompanyFeedback(requestData);

            return PutResults.Accepted(this, resposneData);
        }

        [HttpDelete("api/users/{userId}/feedbacks/{id}")]
        public IActionResult UpdateCopmanysFeedbacks(Guid id)
        {
            _feedbackService.DeleteCompanyFeedback(id);

            return PutResults.Accepted(this);
        }
    }
}