using BH.WebApi.Infrastructure.Rest.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Infrastructure.Rest.ActionResults
{
    public static class DeleteResults
    {
        public static IActionResult Deleted(ControllerBase controller)
        {
            controller.CheckNotNull();
            return controller.StatusCode(204);
        }

        public static IActionResult BadRequest(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();
            if (model != null)
                return controller.StatusCode(400, model);

            return controller.StatusCode(400);
        }

        public static IActionResult Unautorized(ControllerBase controller)
        {
            controller.CheckNotNull();
            return controller.StatusCode(401, controller.RouteData);
        }

        public static IActionResult NotFound(ControllerBase controller)
        {
            controller.CheckNotNull();
            return controller.StatusCode(404);
        }
    }
}
