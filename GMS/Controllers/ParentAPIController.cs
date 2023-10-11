using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using System.Threading.Tasks;
using ComputerBeacon.Json;
using log4net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GMS.Controllers
{
	//[Route("api/[controller]")]

	
	[ApiController]
	[Route("api/v1/[controller]")]//[Route("[controller]")]
	[ProducesResponseType(StatusCodes.Status200OK)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[ProducesResponseType(StatusCodes.Status400BadRequest)]
	[Produces(MediaTypeNames.Application.Json)]

	public  class ParentAPIController : Controller
    {
		protected IWebHostEnvironment _webHostEnvironment = Startup._webHostEnvironment;
		public string Status = "Status";
		public string Success = "Success";
		public string Message = "Message";
		public string Data = "Data";
		public string APIKey = "apikey";
		
		public List<KeyValuePair<string, StringValues>> list;
		public ILog log;
		public HttpContextAccessor context;
		public IConfigurationRoot _config;
		
		protected String getRootPath(String path) {
			string webRootPath = _webHostEnvironment.WebRootPath;
			string contentRootPath = _webHostEnvironment.ContentRootPath;
            return Path.Combine(webRootPath, path);
		}

		protected String ToJsonString(Object obj)
		{
			return JsonConvert.SerializeObject(obj);
		}

		protected JsonArray DtToJsonArray(DataTable dt)
		{
			return new JsonArray(JsonConvert.SerializeObject(dt));
		}

		protected JsonObject DrToJsonObject(DataTable dt, int index = 0)
		{
			return (JsonObject)(new JsonArray(JsonConvert.SerializeObject(dt)))[index];
		}

		protected static DateTime TimeStampToDateTime(String TimeStamp)
		{
			System.DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
			dt = dt.AddSeconds(Math.Round(Convert.ToDouble(TimeStamp))).ToLocalTime();
			System.Diagnostics.Debug.WriteLine(dt.ToString());
			return dt;
		}

		protected static Int64 DateTimeToTimeStamp(DateTime dt)
		{
			DateTime sTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
			return (Int64)(dt - sTime).TotalSeconds - 5 * 3600;
		}


		protected int GetUserIdFromIdentity()
		{
			var identity = (ClaimsIdentity)User.Identity;
		
			return Convert.ToInt32(identity.Name);

		}

	}
}
