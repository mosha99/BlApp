using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlApp.Server.infrastructure.attributes
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class Authorizeattr :Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            /*Shared.user user = context.HttpContext.Items["User"] as Shared.user;

            if (user == null)
            {
                context.Result = new JsonResult(new { message = "UnAuthrize" })
                {
                    StatusCode=StatusCodes.Status401Unauthorized,
                };
            }*/
        }
    }
}
