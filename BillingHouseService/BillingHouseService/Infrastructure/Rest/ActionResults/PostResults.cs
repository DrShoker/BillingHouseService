using BH.WebApi.Infrastructure.Rest.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BH.WebApi.Infrastructure.Rest.ActionResults
{
    public static class PostResults
    {
        public static IActionResult BadRequest(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();
            if (model != null)
                return controller.StatusCode(400, model);

            return controller.StatusCode(400);
        }

        public static IActionResult Created(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();
            //if (model != null)
                return controller.StatusCode(201, model);

            //return controller.StatusCode(201);
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

        public static IActionResult UnprocessableEntity(ControllerBase controller, object model = null)
        {
            controller.CheckNotNull();
            if (model != null)
                return controller.StatusCode(422, model);

            return controller.StatusCode(422);
        }
    }
}
