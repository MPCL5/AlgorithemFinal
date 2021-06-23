using AlgorithemFinal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithemFinal.Utiles
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public virtual string[] Policy { get; set; }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];

            if (user == null)
            {
                // not logged in
                context.Result =
                    new JsonResult(new { message = "Unauthorized", success = false }) {
                        StatusCode = StatusCodes.Status401Unauthorized
                    };

                return;
            }

            if (Policy == null)
                return;

            if (!(user.Master != null && Policy.Contains(nameof(Master)) ||
                user.Student != null && Policy.Contains(nameof(Student)) ||
                user.Admin != null && Policy.Contains(nameof(Admin))
                ))
                context.Result = new JsonResult(new { message = "Access Denied", success = false }) {
                    StatusCode = StatusCodes.Status403Forbidden 
                };
        }
    }
}
