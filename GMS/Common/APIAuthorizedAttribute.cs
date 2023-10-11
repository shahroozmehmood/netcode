
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace GMS.Common
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class APIAuthorizedAttribute : Attribute, IAuthorizationFilter
    {
        

        public void OnAuthorization(AuthorizationFilterContext actionContext)
        {
            var apiKey = FetchFromHeader(actionContext);

            if (apiKey == null)
            {


                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                actionContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Provide Token";
                actionContext.Result = new JsonResult("NotAuthorized")
                {
                    Value = new
                    {
                        Success = false,
                        Message = "Please Provide Token"
                    },
                };

                return;
            }
            else if (apiKey == "")
            {
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                actionContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Provide Token";
                actionContext.Result = new JsonResult("NotAuthorized")
                {
                    Value = new
                    {
                        Success = false,
                        Message = "Please Provide Token"
                    },
                };

                return;
            }
            else if(apiKey == APICredentials.MahaanaKey)
            {

            }
            else
            {
                actionContext.HttpContext.Response.Headers.Add("BearerToken", apiKey);
                actionContext.HttpContext.Response.Headers.Add("AuthStatus", "Unauthorized Token");
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                actionContext.HttpContext.Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = "Invalid Token";
                actionContext.Result = new JsonResult("NotAuthorized")
                {
                    Value = new
                    {
                        Success = false,
                        Message = "Invalid Token"
                    },
                };



                return;
            }



        }

        /// <summary>
        /// retrive header detail from the request 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns name="userid"></returns>
        public string FetchFromHeader(AuthorizationFilterContext actionContext)
        {
            string requestToken = null;

            return actionContext.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
        }

    }




    //public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    //{
    //    public override void OnException(HttpActionExecutedContext context)
    //    {
    //        var exception = context.Exception as ApiException;
    //        if (exception != null)
    //        {
    //            HttpError err = new HttpError(exception.Message);
    //            context.Response = context.Request.CreateErrorResponse(exception.StatusCode, err);
    //        }
    //    }
    //}
}