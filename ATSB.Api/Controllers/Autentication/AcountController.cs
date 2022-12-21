using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ATSB.Api.Areas.Identity.Entities.Security;
using ATSB.Areas.Identity.Data;
using ATSB.Helpers;
using ATSB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace ATSB.Api.Controllers.Autentication
{
    public class AcountController : ControllerBase
    {

        private readonly IUserHelper _userHelper;
        private readonly IConfiguration _configuration;
        private readonly ATSBIdentityDbContext _dbContext;

        public AcountController(IUserHelper userHelper, IConfiguration configuration, ATSBIdentityDbContext dbContext)
        {
            _userHelper = userHelper;
            _configuration = configuration;
            _dbContext = dbContext;
        }


        [HttpPost("Login")]

        public async Task<string> Login(LoginRequest model)
        {
            var response = new Response<Object>();
            var rolType = false;
            var userData = new UserResponse();
            var user = new UserAtsb();
            //var parempresa = new ParEmpresa();

            JsonSerializerSettings options = new()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            };

            var result = await _userHelper.LoginAsync(model);
            if (result.Succeeded)
            {
                user = await _userHelper.GetUserByEmailAsync(model.Username);
                rolType = await _userHelper.IsUserInRoleAsync(user, "Admin");
                userData = new UserResponse
                {
                    Id = user.Id,
                    Apellido1 = user.Apellido1,
                    Apellido2 = user.Apellido2,
                    Nombre = user.Nombre,
                    UserName = user.UserName
                };
                response.IsSuccess = true;
                response.Message = "Usuario autenticado";
                response.Result = userData;
            }
            else
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }

            string strResponse = JsonConvert.SerializeObject(response, options);

            return await Task.Run(() =>
            {
                return strResponse;
            });

        }


        [HttpPost("CreateToken")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateToken(LoginRequest model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserByEmailAsync(model.Username);
                if (user != null)
                {
                    var result = await _userHelper.ValidatePasswordAsync(
                        user,
                        model.Password);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(1),
                            signingCredentials: credentials);

                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            status = true
                        };

                        return Created(string.Empty, results);
                    }
                    else
                    {
                        throw new Exception("Usuario o contraseña incorrectos");
                    }
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrectos");
                }
            }
            else
            {
                throw new Exception("Usuario o contraseña incorrectos");
            }
        }
    }
}