using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.Feedback.Model
{
    public class FeedbackModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
    }
}
