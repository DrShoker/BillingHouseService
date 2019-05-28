using BH.ServiceLayer.DTOs.UserProject.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BH.ServiceLayer.DTOs.UserProject
{
    public class UpdateUserProjectDto : UserProjectDto
    {
        public Guid Id { get; set; }
    }
}
