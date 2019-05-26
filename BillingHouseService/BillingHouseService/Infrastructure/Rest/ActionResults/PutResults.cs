using BH.WebApi.Infrastructure.Rest.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Infrastructure.Rest.ActionResults
{
    public static class PutResults
    {
        public static IActionResult BadRequest(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();
            if (model != null)
                return controller.StatusCode(400, model);

            return controller.StatusCode(400);
        }

        public static IActionResult Accepted(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();

            if (model != null)
                return controller.StatusCode(202, model);

            return controller.StatusCode(202);
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

        public static IActionResult Modified(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();
            if (model != null)
                return controller.StatusCode(204, model);

            return controller.StatusCode(204);
        }
    }
}
