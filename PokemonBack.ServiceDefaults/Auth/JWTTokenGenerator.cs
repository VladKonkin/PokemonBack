using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PokemonBack.ServiceDefaults.Auth
{
	public class JWTTokenGenerator 
	{
		private readonly IConfiguration _configuration;

		public JWTTokenGenerator(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string GenerateToken(Guid userId,Guid battleId)
		{
			var jwtSettings = _configuration.GetSection("JwtSettings");
			var secretKey = jwtSettings["SecretKey"];
			var issuer = jwtSettings["Issuer"];
			var audience = jwtSettings["Audience"];

			var claims = new[]
			{
			new Claim("UserId", userId.ToString()),
			new Claim("BattleId", battleId.ToString()),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				issuer: issuer,
				audience: audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["TokenLifetimeMinutes"])),
				signingCredentials: creds);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
