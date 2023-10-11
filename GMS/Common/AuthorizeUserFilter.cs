using GMS.Manager;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Net.Http.Headers;
//using Services.Contracts;
//using Services.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;


namespace GMS.Common
{
    public class AuthorizeUserFilter : Attribute, IAuthorizationFilter//AuthorizationFilterAttribute
    {
        //private IUserService _IUserService;
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


            if (!ValidateToken(actionContext, apiKey))
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
        /// Validate the API Access Key with Database and Add's User Identity Claims to access the Resource in Controller 
        /// </summary>
        /// <param name="apiKey"></param>
        /// <returns name="bool"></returns>
        public bool ValidateToken(AuthorizationFilterContext actionContext,string apiKey)
        {
            UserAuthenticationManager userAuthenticationManager = new UserAuthenticationManager();
            var user_Roles = userAuthenticationManager.AuthorizeUser(apiKey); 
            if (user_Roles != null )
            {
                string errorMsg = "";

                int userId = user_Roles.user_id;// Convert.ToInt32(ds.Tables[0].Rows[0]["user_id"]);
                string userRole = user_Roles.user_role;// Convert.ToString(ds.Tables[0].Rows[0]["user_role"]);

                if (userId < 1)
                {
                    return false;//Authentication Failed
                }


                var identity = new GenericIdentity(userId.ToString());//Name of Identity
                                                                      //We can add more user claims with respective of validation API Response to use it in Controller methods                     
                identity.AddClaim(new Claim(ClaimTypes.Role, userRole));//Assign User Role
                                                                        //identity.AddClaim(new Claim(ClaimTypes.Name, user_id.ToString()));
                                                                        //identity.AddClaim(new Claim("LoggedOn", DateTime.Now.ToString()));
                IPrincipal principal = new GenericPrincipal(identity, new string[] { userRole });


                ClaimsPrincipal user = new ClaimsPrincipal(identity);


                Thread.CurrentPrincipal = principal;
                actionContext.HttpContext.User = user;
                return true;

            }
            else
            {
                return false;//Authentication Failed
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



            //Microsoft.Extensions.Primitives.StringValues authTokens;
            //actionContext.HttpContext.Request.Headers.TryGetValue("Bearer", out authTokens);

            //requestToken = authTokens.FirstOrDefault();

           return actionContext.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            //var authRequest = actionContext.HttpContext.Request.Headers["Bearer"].ToString();
            //if (authRequest != null && !string.IsNullOrEmpty(authRequest.Scheme) && authRequest.Scheme == "Bearer")
            //    requestToken = authRequest.Parameter;

            //if (!String.IsNullOrWhiteSpace(authRequest))
            //    return authRequest;



            return requestToken;
        }

       
    }
}