using BH.ServiceLayer.DTOs.Feedback.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Feedback
{
    public class UpdateFeedbackDto : FeedbackDto
    {
        public Guid Id { get; set; }
    }
}
