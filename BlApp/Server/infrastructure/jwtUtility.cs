using BlApp.Server.infrastructure.ApplicationSetings;
using BlApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAl;

namespace BlApp.Server.infrastructure
{
    public class jwtUtility
    {
        public static string generateToken(us user, Main setings)
        {
            byte[] key = Encoding.ASCII.GetBytes(setings.key);
            var securitykey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key: key);
            var alguritm = Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature;
            var creatioal = new Microsoft.IdentityModel.Tokens.SigningCredentials(securitykey, alguritm);
            var tokendiscriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity
                                (new[]
                                {
                                    new System.Security.Claims.Claim(nameof(user.lastname), user.lastname),
                                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.firstname),
                                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Email, user.email),
                                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.NameIdentifier, user.id.ToString()),
                                }),


                Expires = DateTime.UtcNow.AddMinutes(setings.timeOut),
                SigningCredentials = creatioal,
            };
            var tokenHandled = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            Microsoft.IdentityModel.Tokens.SecurityToken securitytoken = tokenHandled.CreateToken(tokendiscriptor);
            string token = tokenHandled.WriteToken(securitytoken);
            return token;
        }
        public static int auth(string token, Main setings)
        {
            byte[] key = Encoding.ASCII.GetBytes(setings.key);
            var tokenHandled = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();

            tokenHandled.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,

                IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                ClockSkew = System.TimeSpan.Zero,
            }, out Microsoft.IdentityModel.Tokens.SecurityToken validatedtoken
            );
            var jwttoken = validatedtoken as System.IdentityModel.Tokens.Jwt.JwtSecurityToken;
            if (jwttoken == null)
            {
                return -1;
            }
            var userIdclimn = jwttoken.Claims.Where(x => x.Type.ToLower() == "NameId".ToLower()).FirstOrDefault();
            if (userIdclimn == null)
            {
                return -1;
            }

            int Uid = int.Parse(userIdclimn.Value);
            var x = manager.getu(Uid);
            if(x==null)return -1;
            return x.id;
        }

    }
}
