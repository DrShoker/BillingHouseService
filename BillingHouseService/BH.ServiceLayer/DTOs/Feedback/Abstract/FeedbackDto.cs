using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Feedback.Abstract
{
    public abstract class FeedbackDto
    {
        public string Message { get; set; }
        public DateTime DateOfCreation { get; set; }
        public Guid UserId { get; set; }
        public Guid CompanyId { get; set; }
    }
}
