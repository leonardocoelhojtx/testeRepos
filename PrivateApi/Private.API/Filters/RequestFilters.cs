using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Controllers;

namespace Private.API.Filters
{
    public class RequestFilters : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.Headers.ContainsKey("Authorization"))
            {
                var access_code = actionContext.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var tkn = new JwtSecurityToken(access_code);


                //var handler = new JwtSecurityTokenHandler();
                //var token = handler.ReadJwtToken(tkn);
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
