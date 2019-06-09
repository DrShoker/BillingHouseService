using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BH.DTOL.Enums;
using BH.ServiceLayer.Common.Extensions;
using BH.WebApi.Infrastructure.Rest.ActionResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        [HttpGet("work-types")]
        public IActionResult GetConstructionWorkTypesList()
        {
            return GetResults.Ok(this, EnumExtensions.GetEnumElementsDescription(typeof(TypeOfConstructionWorksEnum)));
        }
    }
}