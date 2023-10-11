using GMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;



namespace GMS.Common
{
    public class APIError
    {
        public static void Send(ResponseCode code)
        {
            throw new ApiException(System.Net.HttpStatusCode.OK, code.ToString());
        }
    }
}