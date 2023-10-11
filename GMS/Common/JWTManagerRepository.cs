using GMS.Common;
using GMS.Serializer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GMS.Common
{
	public class JWTManagerRepository : IJWTManagerRepository
	{
		private readonly IConfiguration iconfiguration;
		public JWTManagerRepository(IConfiguration iconfiguration)
		{
			this.iconfiguration = iconfiguration;
		}
		public TokensSerializer Authenticate(string username)
		{

			// Else we generate JSON Web Token
			var tokenHandler = new JwtSecurityTokenHandler();
			var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
			  {
			 new Claim(ClaimTypes.Name, username)
			  }),
				Expires = DateTime.UtcNow.AddMinutes(10),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return new TokensSerializer { Token = tokenHandler.WriteToken(token) };

		}
	}
}
