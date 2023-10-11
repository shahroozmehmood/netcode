using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GMS.Common
{
    public enum ResponseCode
    {
        VALID_DATA = 101,
        INVALID_CREDENTIALS = 102,
        
        INVALID_DATA = 103,
        EXCEPTION =104,
        

        
        OTHER_ERROR = 1007,
        NEGATIVE_AMOUNT = 1008,
        INVALID_TRANSACTION_AMOUNT = 1009,
        OK = 1010,

        INVALID_HEADER_SCHEME = 9001,
        INVALID_HEADER = 9002,
        INVALID_PUBLIC_KEY = 9017,
        INVALID_HEADER_CASTING = 9003
        
    }
  
}