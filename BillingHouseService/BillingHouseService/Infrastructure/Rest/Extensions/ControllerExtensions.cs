using System;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Infrastructure.Rest.Extensions
{
    public static class ControllerExtensions
    {
        public static void CheckNotNull(this ControllerBase c)
        {
            if (c == null) throw new ArgumentException("controller");
        }
    }
}
