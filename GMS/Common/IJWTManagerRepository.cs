using GMS.Common;
using GMS.Serializer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMS.Common
{
    public interface IJWTManagerRepository
    {
        TokensSerializer Authenticate(string username);
    }
}